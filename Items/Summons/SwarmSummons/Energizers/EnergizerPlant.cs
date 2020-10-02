using Terraria.ModLoader;
using Terraria;
using Terraria.ID;

namespace Fargowiltas.Items.Summons.SwarmSummons.Energizers
{
    public class EnergizerPlant : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Leafy Energizer");
            Tooltip.SetDefault("'Being a leaf sounds like a good time'");
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