using Terraria;
using Terraria.Audio;
using Terraria.Chat;
using Terraria.ID;

namespace Fargowiltas.Items.Summons.Deviantt
{
    public class ClownLicense : BaseSummon
    {
        public override int Type => NPCID.Clown;

        public override string NPCName => "Clown";

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Clown License");
            Tooltip.SetDefault("Summons Clown" +
                               "\nOnly usable at night or underground");
        }

        public override bool CanUseItem(Player player)
        {
            return !Main.dayTime || player.ZoneRockLayerHeight || player.ZoneUnderworldHeight;
        }
    }
}