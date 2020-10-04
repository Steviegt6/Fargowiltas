using Terraria;
using Terraria.ID;

namespace Fargowiltas.Items.Summons.Deviantt
{
    public class RuneOrb : BaseSummon
    {
        public override int NPCType => NPCID.RuneWizard;

        public override string NPCName => "Rune Wizard";

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Rune Orb");
            Tooltip.SetDefault("Summons Rune Wizard" +
                               "\nOnly usable at night or underground");
        }

        public override bool CanUseItem(Player player) => !Main.dayTime || player.ZoneRockLayerHeight || player.ZoneUnderworldHeight;
    }
}