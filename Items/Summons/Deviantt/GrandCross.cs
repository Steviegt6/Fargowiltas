using Terraria;
using Terraria.ID;

namespace Fargowiltas.Items.Summons.Deviantt
{
    public class GrandCross : BaseSummon
    {
        public override int NPCType => NPCID.Paladin;

        public override string NPCName => "Paladin";

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Grand Cross");
            Tooltip.SetDefault("Summons Paladin" +
                               "\nOnly usable at night or underground");
        }

        public override bool CanUseItem(Player player) => !Main.dayTime || player.ZoneRockLayerHeight || player.ZoneUnderworldHeight;
    }
}