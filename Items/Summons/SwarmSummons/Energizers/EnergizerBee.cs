using Terraria.ModLoader;
using Terraria;
using Terraria.ID;

namespace Fargowiltas.Items.Summons.SwarmSummons.Energizers
{
    public class EnergizerBee : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Buzzy Energizer");
            Tooltip.SetDefault("'Smells like it tastes like honey'");
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