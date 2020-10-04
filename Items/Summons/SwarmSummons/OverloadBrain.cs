using Terraria;
using Terraria.ID;

namespace Fargowiltas.Items.Summons.SwarmSummons
{
    public class OverloadBrain : SwarmSummonBase
    {
        public OverloadBrain() : base(NPCID.BrainofCthulhu, "You feel dumb among so many brains!", 25, "GoreySpine")
        {
        }

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Brain Storm");
            Tooltip.SetDefault("Summons several Brains of Cthulhu");
        }

        public override bool CanUseItem(Player player) => !Fargowiltas.SwarmActive;
    }
}