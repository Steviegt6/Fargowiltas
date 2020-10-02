using Terraria;
using Terraria.DataStructures;
using Terraria.ID;

namespace Fargowiltas.Items.Summons.Deviantt
{
    public class CoreoftheFrostCore : BaseSummon
    {
        public override int Type => NPCID.IceGolem;

        public override string NPCName => "Ice Golem";

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Core of the Frost Core");
            Tooltip.SetDefault("Summons Ice Golem");
            Main.RegisterItemAnimation(item.type, new DrawAnimationVertical(6, 4));
        }

        public override void SetDefaults()
        {
            base.SetDefaults();
            item.noUseGraphic = true;
        }
    }
}