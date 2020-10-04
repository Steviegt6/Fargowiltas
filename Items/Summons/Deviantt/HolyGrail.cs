using Terraria;
using Terraria.ID;

namespace Fargowiltas.Items.Summons.Deviantt
{
    public class HolyGrail : BaseSummon
    {
        public override int NPCType => NPCID.Tim;

        public override string NPCName => "Tim";

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Holy Grail");
            Tooltip.SetDefault("Summons Tim" +
                               "\nOnly usable at night or underground");
        }

        public override bool CanUseItem(Player player) => !Main.dayTime || player.ZoneRockLayerHeight || player.ZoneUnderworldHeight;
    }
}