using Terraria;
using Terraria.ID;

namespace Fargowiltas.Items.Summons.SwarmSummons
{
    public class OverloadTwins : SwarmSummonBase
    {
        public OverloadTwins() : base(NPCID.Retinazer, "A legion of glowing iris sing a dreadful song!", 25, "MechEye")
        {
        }

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Omnifocal Lens");
            Tooltip.SetDefault("Summons several sets of Twins");
        }

        public override bool CanUseItem(Player player)
        {
            return !Fargowiltas.SwarmActive && !Main.dayTime;
        }
    }
}