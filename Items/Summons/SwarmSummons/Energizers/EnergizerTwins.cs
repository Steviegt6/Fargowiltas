using Terraria.ID;
using Terraria.ModLoader;

namespace Fargowiltas.Items.Summons.SwarmSummons.Energizers
{
    public class EnergizerTwins : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Sibling Energizer");
            Tooltip.SetDefault("'You wish you had more'");
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