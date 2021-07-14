using System;
using System.Linq;
using Fargowiltas.Core.CrossMod.ModCall;
using Terraria.ModLoader;

namespace Fargowiltas.Core.CrossMod
{
    // thx pbone: https://github.com/Pbone3/PboneLib/blob/master/Core/CrossMod/CrossModManager.cs
    // eventual goal: refs from pbone mod utils lib lol
    public class CrossModManager : ModSystem, ICrossModManager
    {
        public IModCallCataloger CallCataloger { get; }

        public CrossModManager()
        {
            CallCataloger = new ModCallCataloger(Mod);
        }

        public override void OnModLoad()
        {
            base.Load();

            foreach (Type type in Mod.Code.GetTypes().Where(x =>
                !x.IsAbstract && x.GetConstructor(Array.Empty<Type>()) != null &&
                x.IsSubclassOf(typeof(ModCaller))))
            {
                IModCaller caller = (IModCaller) Activator.CreateInstance(type);

                CallCataloger.RegisterHandler(caller);
            }

            CallCataloger.MapCallersToMessages();
        }
    }
}