using Terraria;
using Terraria.Audio;
using Terraria.Chat;
using Terraria.ID;

namespace Fargowiltas.Items.Summons.Deviantt
{
    public class RuneOrb : BaseSummon
    {
        public override int Type => NPCID.RuneWizard;

        public override string NPCName => "Rune Wizard";

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Rune Orb");
            Tooltip.SetDefault("Summons Rune Wizard" +
                               "\nOnly usable at night or underground");
        }

        public override bool CanUseItem(Player player)
        {
            return !Main.dayTime || player.ZoneRockLayerHeight || player.ZoneUnderworldHeight;
        }
    }
}