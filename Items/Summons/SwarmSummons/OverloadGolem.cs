using Terraria;
using Terraria.ID;

namespace Fargowiltas.Items.Summons.SwarmSummons
{
    public class OverloadGolem : SwarmSummonBase
    {
        public OverloadGolem() : base(NPCID.Golem, "Ancient automatons come crashing down!", 25, "LihzahrdPowerCell2")
        {
        }

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Runic Power Cell");
            Tooltip.SetDefault("Summons several Golems");
        }

        public override bool CanUseItem(Player player) => !Fargowiltas.SwarmActive && NPC.downedPlantBoss;
    }
}