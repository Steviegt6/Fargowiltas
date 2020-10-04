using Terraria.ID;

namespace Fargowiltas.Items.Summons.Abom
{
    public class MartianMemoryStick : BaseSummon
    {
        public override int NPCType => NPCID.MartianSaucerCore;

        public override string NPCName => "Martian Saucer";

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Martian Memory Stick");
            Tooltip.SetDefault("Summons Martian Saucer");
        }
    }
}