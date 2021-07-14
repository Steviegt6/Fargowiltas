using Fargowiltas.Content.UI.StatSheet;
using Fargowiltas.Core.CrossMod;
using Terraria.ModLoader;

namespace Fargowiltas
{
    public class FargosMutantMod : Mod
    {
        public override object Call(params object[] args) =>
            ModContent.GetInstance<CrossModManager>().CallCataloger.HandleCall(args);

        public override void Unload()
        {
            base.Unload();

            StatSheetState.ModCallStats = null;
        }
    }
}