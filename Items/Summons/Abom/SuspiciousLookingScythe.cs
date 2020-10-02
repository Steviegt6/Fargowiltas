using Terraria;
using Terraria.Audio;
using Terraria.Chat;
using Terraria.ID;

namespace Fargowiltas.Items.Summons.Abom
{
    public class SuspiciousLookingScythe : BaseSummon
    {
        public override int Type => NPCID.Pumpking;

        public override string NPCName => "Pumpking";

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Suspicious Looking Scythe");
            Tooltip.SetDefault("Summons Pumpking" +
                               "\nOnly usable at night");
        }

        public override bool CanUseItem(Player player)
        {
            return !Main.dayTime;
        }
    }
}