using Terraria.ModLoader;
using Terraria;
using Terraria.ID;

namespace Fargowiltas.Items.Summons.SwarmSummons.Energizers
{
    public class EnergizerEye : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Optical Energizer");
            Tooltip.SetDefault("'It feels like it's watching you'");
        }

        public override void SetDefaults()
        {
            item.width = 20;
            item.height = 20;
            item.maxStack = 999;
            item.rare = ItemRarityID.Blue;
            item.value = 100000;
        }
    }
}