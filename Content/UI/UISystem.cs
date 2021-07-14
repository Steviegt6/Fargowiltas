using Fargowiltas.Content.UI.StatSheet;
using Fargowiltas.Core.UserInterfaces;
using Terraria;
using Terraria.ModLoader;

namespace Fargowiltas.Content.UI
{
    public class UISystem : ModSystem
    {
        public override void OnModLoad()
        {
            base.OnModLoad();

            if (Main.dedServ) return;

            UIManager.Register<StatSheetState>("Vanilla: Inventory");
            UIManager.Register<StatSheetButtonState>("Vanilla: Mouse Text");

            UIManager.Open<StatSheetButtonState>();
        }
    }
}