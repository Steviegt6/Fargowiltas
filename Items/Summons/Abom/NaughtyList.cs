using Terraria;
using Terraria.Audio;
using Terraria.Chat;
using Terraria.ID;

namespace Fargowiltas.Items.Summons.Abom
{
    public class NaughtyList : BaseSummon
    {
        public override int Type => NPCID.SantaNK1;

        public override string NPCName => "Santa-NK1";

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Naughty List");
            Tooltip.SetDefault("Summons Santa-NK1" +
                               "\nOnly usable at night");
        }

        public override bool CanUseItem(Player player)
        {
            return !Main.dayTime;
        }
    }
}