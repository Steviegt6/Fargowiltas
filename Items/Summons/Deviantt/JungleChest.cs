using Terraria.ID;

namespace Fargowiltas.Items.Summons.Deviantt
{
    public class JungleChest : BaseSummon
    {
        public override int NPCType => NPCID.BigMimicJungle;

        public override string NPCName => "Jungle Mimic";

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Jungle Chest");
            Tooltip.SetDefault("Summons Jungle Mimic");
        }
    }
}