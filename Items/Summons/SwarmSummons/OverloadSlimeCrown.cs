using Terraria;
using Terraria.ID;

namespace Fargowiltas.Items.Summons.SwarmSummons
{
    public class OverloadSlimeCrown : SwarmSummonBase
    {
        public OverloadSlimeCrown() : base(NPCID.KingSlime, "Welcome to the true slime rain!", 50, "SlimyCrown")
        {
        }

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Swarm Crown");
            Tooltip.SetDefault("Summons several King Slimes");
        }

        public override bool CanUseItem(Player player)
        {
            return !Fargowiltas.SwarmActive;
        }
    }
}