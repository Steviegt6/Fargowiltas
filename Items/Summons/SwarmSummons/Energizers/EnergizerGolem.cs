using Terraria.ModLoader;
using Terraria;
using Terraria.ID;

namespace Fargowiltas.Items.Summons.SwarmSummons.Energizers
{
    public class EnergizerGolem : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Lihzahrd Energizer");
            Tooltip.SetDefault("'You wish it was spelled \"lizard\"");
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