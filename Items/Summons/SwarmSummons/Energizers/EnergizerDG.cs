using Terraria.ModLoader;
using Terraria;
using Terraria.ID;

namespace Fargowiltas.Items.Summons.SwarmSummons.Energizers
{
    public class EnergizerDG : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Extra Boney Energizer");
            Tooltip.SetDefault("'Reminds you of a mean cow'");
        }

        public override string Texture => "Fargowiltas/Items/Summons/SwarmSummons/Energizers/EnergizerSkele";

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