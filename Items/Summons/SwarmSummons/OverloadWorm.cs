using Terraria;
using Terraria.ID;

namespace Fargowiltas.Items.Summons.SwarmSummons
{
    public class OverloadWorm : SwarmSummonBase
    {
        public OverloadWorm() : base(NPCID.EaterofWorldsHead, "The ground shifts with formulated precision!", 25, "WormyFood")
        {
        }

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Worm Chicken");
            Tooltip.SetDefault("Summons several Eater of Worlds");
        }

        public override bool CanUseItem(Player player) => !Fargowiltas.SwarmActive;
    }
}