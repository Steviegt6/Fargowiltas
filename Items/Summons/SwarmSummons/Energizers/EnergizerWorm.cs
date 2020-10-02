using Terraria.ModLoader;
using Terraria;
using Terraria.ID;

namespace Fargowiltas.Items.Summons.SwarmSummons.Energizers
{
    public class EnergizerWorm : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Wormy Energizer");
            Tooltip.SetDefault("'It's a little squishy'");
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