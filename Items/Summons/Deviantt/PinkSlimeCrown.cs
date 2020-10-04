using Terraria.ID;

namespace Fargowiltas.Items.Summons.Deviantt
{
    public class PinkSlimeCrown : BaseSummon
    {
        public override int NPCType => NPCID.Pinky;

        public override string NPCName => "Pinky";

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Pink Slime Crown");
            Tooltip.SetDefault("Summons Pinky");
        }
    }
}