using Terraria;
using Terraria.Audio;
using Terraria.Chat;
using Terraria.ID;

namespace Fargowiltas.Items.Summons.Deviantt
{
    public class AthenianIdol : BaseSummon
    {
        public override int Type => NPCID.Medusa;

        public override string NPCName => "Medusa";

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Athenian Idol");
            Tooltip.SetDefault("Summons Medusa" +
                               "\nOnly usable at night or underground");
        }

        public override bool CanUseItem(Player player)
        {
            return !Main.dayTime || player.ZoneRockLayerHeight || player.ZoneUnderworldHeight;
        }
    }
}