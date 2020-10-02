using Terraria;
using Terraria.Audio;
using Terraria.Chat;
using Terraria.ID;

namespace Fargowiltas.Items.Summons.Deviantt
{
    public class LeesHeadband : BaseSummon
    {
        public override int Type => NPCID.BoneLee;

        public override string NPCName => "Bone Lee";

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Lee's Headband");
            Tooltip.SetDefault("Summons Bone Lee" +
                               "\nOnly usable at night or underground");
        }

        public override bool CanUseItem(Player player)
        {
            return !Main.dayTime || player.ZoneRockLayerHeight || player.ZoneUnderworldHeight;
        }
    }
}