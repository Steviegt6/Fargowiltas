using System;
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
        public static List<IUIProfile> Interfaces { get; private set; }

        public UIManager()
        {
            Interfaces = new List<IUIProfile>();
        }

        #region ModSystem

        public override void UpdateUI(GameTime gameTime)
        {
            base.UpdateUI(gameTime);

            foreach (IUIProfile profile in Interfaces)
                profile.UserInterface.CurrentState?.Update(gameTime);
        }

        public override void ModifyInterfaceLayers(List<GameInterfaceLayer> layers)
        {
            base.ModifyInterfaceLayers(layers);

            foreach (IUIProfile profile in Interfaces)
            {
                int index = layers.FindIndex(x => x.Name.Equals(profile.InsertionLayer));

                if (index != -1)
                    layers.Insert(index, new LegacyGameInterfaceLayer($"Fargowiltas:Interface {profile.Identifier}",
                        () =>
                        {
                            profile.UserInterface.CurrentState?.Draw(Main.spriteBatch);

                            return true;
                        }, InterfaceScaleType.UI));
            }
        }

        #endregion

        #region UIManager

        public static void CreateInterface(UIState state, string layer)
        {
            if (!Main.dedServ)
                Interfaces.Add(new UIProfile(state, layer));
        }

        public static void Register<TUIState>(string layer) where TUIState : UIState, new()
        {
            if (Main.dedServ) return;

            TUIState state = new();
            state.Activate();
            CreateInterface(state, layer);
        }

        public static void Open<TUIState>() where TUIState : UIState
        {
            if (Main.dedServ) return;

            IUIProfile profile = GetProfile<TUIState>();
            profile.UserInterface.SetState(profile.State);
        }

        public static void Close<TUIState>() where TUIState : UIState
        {
            if (!Main.dedServ)
                GetProfile<TUIState>().UserInterface.SetState(null);
        }

        public static void Toggle<TUIState>() where TUIState : UIState
        {
            if (Main.dedServ) return;

            if (GetProfile<TUIState>().UserInterface.CurrentState == null)
                Open<TUIState>();
            else
                Close<TUIState>();
        }

        #endregion

        public static IUIProfile GetProfile<TUIState>() where TUIState : UIState =>
            Interfaces.First(x => x.State.GetType() == typeof(TUIState));

        public static IUIProfile GetProfile(Guid guid) => Interfaces.First(x => x.Identifier.Equals(guid));
    }
}