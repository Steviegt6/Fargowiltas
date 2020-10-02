using Terraria.ID;
using Terraria.ModLoader;
using Terraria;

namespace Fargowiltas.Items.Vanity
{
    [AutoloadEquip(EquipType.Legs)]
    public class LumberjackPants : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Lumberjack Pants");
        }

        public override void SetDefaults()
        {
            item.width = 18;
            item.height = 18;
            item.vanity = true;
            item.rare = ItemRarityID.Blue;
        }
    }
}
