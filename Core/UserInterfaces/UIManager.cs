using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;
using Terraria.UI;

namespace Fargowiltas.Core.UserInterfaces
{
    // Over-engineered version of pbone's UIManager
    // https://github.com/Pbone3/PboneLib/blob/master/Core/UI/UIManager.cs
    public class UIManager : ModSystem
    {
        public static Dictionary<IUIStateIdentity, IUIProfile> UserInterfaceCollection { get; private set; }

        public static List<UIState> States { get; private set; }

        public UIManager()
        {
            UserInterfaceCollection = new Dictionary<IUIStateIdentity, IUIProfile>();
            States = new List<UIState>();
        }

        #region ModSystem

        public override void UpdateUI(GameTime gameTime)
        {
            base.UpdateUI(gameTime);

            foreach (IUIProfile profile in UserInterfaceCollection.Values)
                profile.UserInterface.CurrentState?.Update(gameTime);
        }

        public override void ModifyInterfaceLayers(List<GameInterfaceLayer> layers)
        {
            base.ModifyInterfaceLayers(layers);

            foreach ((IUIStateIdentity identity, IUIProfile profile) in UserInterfaceCollection)
            {
                int index = layers.FindIndex(x => x.Name.Equals(profile.InsertionLayer));

                if (index != -1)
                    layers.Insert(index, new LegacyGameInterfaceLayer($"Fargowiltas:Interface {identity.Identity}", () =>
                    {
                        profile.UserInterface.CurrentState?.Draw(Main.spriteBatch);

                        return true;
                    }, InterfaceScaleType.UI));
            }
        }

        #endregion

        #region UIManager

        public static void CreateInterface(IUIStateIdentity identity, string layer)
        {
            if (!Main.dedServ)
                UserInterfaceCollection.Add(identity, new UIProfile(new UserInterface(), layer));
        }

        public static IUIStateIdentity CreateInterface<TUIState>(string layer) where TUIState : UIState
        {
            UIStateIdentity<TUIState> @return = new();

            if (!Main.dedServ)
                UserInterfaceCollection.Add(@return, new UIProfile(new UserInterface(), layer));

            return @return;
        }

        public static void Register<TUIState>(string layer) where TUIState : UIState, new()
        {
            if (Main.dedServ) return;

            TUIState state = new();
            state.Activate();
            States.Add(state);
            CreateInterface<TUIState>(layer);
        }

        public static void Open<TUIState>() where TUIState : UIState
        {
            if (!Main.dedServ)
                GetInterface<TUIState>().UserInterface.SetState(States.First(x =>
                {
                    string fullName = x.GetType().FullName;
                    return fullName != null && fullName.Equals(typeof(TUIState).FullName);
                }));
        }

        public static void Close<TUIState>() where TUIState : UIState
        {
            if (!Main.dedServ)
                GetInterface<TUIState>().UserInterface.SetState(null);
        }

        public static void Toggle<TUIState>() where TUIState : UIState
        {
            if (Main.dedServ) return;

            UserInterface @interface = GetInterface<TUIState>().UserInterface;

            if (@interface.CurrentState is null)
                Open<TUIState>();
            else
                Close<TUIState>();
        }

        #endregion

        public static IUIProfile GetInterface<TUIState>() =>
            UserInterfaceCollection.First(x => x.Key.TypeName.Equals(typeof(TUIState).FullName)).Value;

        public static IUIStateIdentity GetIdentity<TUIState>() =>
            UserInterfaceCollection.First(x => x.Key.TypeName.Equals(typeof(TUIState).FullName)).Key;
    }
}