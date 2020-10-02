using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;

namespace Fargowiltas.Items.Summons.SwarmSummons
{
    public class Overloader : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Overloader");
            Tooltip.SetDefault("Used to craft swarm summons\n" +
                               "When used, all summons in the stack will be consumed\n" +
                               "The more consumed, the more bosses will spawn");
            Main.RegisterItemAnimation(item.type, new DrawAnimationVertical(6, 4));
        }

        public override void SetDefaults()
        {
            item.width = 20;
            item.height = 20;
            item.maxStack = 999;
            item.rare = ItemRarityID.Green;
        }
    }
}