using Terraria.ID;

namespace Fargowiltas.Items.Summons.Deviantt
{
    public class CloudSnack : BaseSummon
    {
        public override int NPCType => NPCID.WyvernHead;

        public override string NPCName => "Wyvern";

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Cloud Snack");
            Tooltip.SetDefault("Summons Wyvern");
        }
    }
}