using Terraria.ID;
using Terraria.ModLoader;

namespace Fargowiltas.Items.Summons.SwarmSummons.Energizers
{
    public class EnergizerSkele : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Boney Energizer");
            Tooltip.SetDefault("'Reminds you of a cow'");
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