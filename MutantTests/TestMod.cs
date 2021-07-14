using System;
using Terraria.ID;
using Terraria.ModLoader;

namespace MutantTests
{
    public class TestMod : Mod
    {
        public override void Load()
        {
            base.Load();

            AddContent(new DoActionCommand("addstat",
                (_, _) =>
                {
                    ModLoader.GetMod("Fargowiltas").Call("StatSheet", "Add",
                        (Func<string>) (() => "Example Mod.Call Stat"), ItemID.FallenStar);
                }));
        }
    }
}