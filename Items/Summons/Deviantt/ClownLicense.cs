using Terraria;
using Terraria.ID;

namespace Fargowiltas.Items.Summons.Deviantt
{
    public class ClownLicense : BaseSummon
    {
        public override int NPCType => NPCID.Clown;

        public override string NPCName => "Clown";

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Clown License");
            Tooltip.SetDefault("Summons Clown" +
                               "\nOnly usable at night or underground");
        }

        public override bool CanUseItem(Player player) => !Main.dayTime || player.ZoneRockLayerHeight || player.ZoneUnderworldHeight;
    }
}