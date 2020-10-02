using Terraria;
using Terraria.ID;

namespace Fargowiltas.Items.Summons.SwarmSummons
{
    public class OverloadFish : SwarmSummonBase
    {
        public OverloadFish() : base(NPCID.DukeFishron, "The ocean swells with ferocious pigs!", 25, "TruffleWorm2")
        {
        }

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Truffle Worm Clump");
            Tooltip.SetDefault("Summons several Duke Fishrons");
        }

        public override bool CanUseItem(Player player)
        {
            return !Fargowiltas.SwarmActive;
        }
    }
}