using Terraria;
using Terraria.ID;

namespace Fargowiltas.Items.Summons.Deviantt
{
    public class HeartChocolate : BaseSummon
    {
        public override int Type => NPCID.Nymph;

        public override string NPCName => "Nymph";

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Heart Chocolate");
            Tooltip.SetDefault("Summons Nymph" +
                               "\nOnly usable at night or underground");
        }

        public override bool CanUseItem(Player player)
        {
            return !Main.dayTime || player.ZoneRockLayerHeight || player.ZoneUnderworldHeight;
        }
    }
}