using Terraria.ID;
using Terraria.ModLoader;
using Terraria;

namespace Fargowiltas.Items.Vanity
{
    [AutoloadEquip(EquipType.Head)]
    public class LumberjackMask : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Lumberjack Mask");
        }

        public override void SetDefaults()
        {
            item.width = 18;
            item.height = 18;
            item.rare = ItemRarityID.Blue;
            item.vanity = true;
        }
    }
}
