using Terraria.ID;
using Terraria.ModLoader;

namespace Fargowiltas.Items.Summons.SwarmSummons.Energizers
{
    public class EnergizerDestroy : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Destruction Energizer");
            Tooltip.SetDefault("'It makes you want to break some kids'");
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