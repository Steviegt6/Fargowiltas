using Terraria;
using Terraria.ID;

namespace Fargowiltas.Items.Summons.Abom
{
    public class HeadofMan : BaseSummon
    {
        public override int Type => NPCID.HeadlessHorseman;

        public override string NPCName => "Headless Horseman";

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Head of Man");
            Tooltip.SetDefault("Summons Headless Horseman" +
                               "\nOnly usable at night");
        }

        public override bool CanUseItem(Player player)
        {
            return !Main.dayTime;
        }
    }
}