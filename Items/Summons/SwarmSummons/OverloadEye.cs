using Terraria;
using Terraria.ID;

namespace Fargowiltas.Items.Summons.SwarmSummons
{
    public class OverloadEye : SwarmSummonBase
    {
        public OverloadEye() : base(NPCID.EyeofCthulhu, "Countless eyes pierce the veil staring in your direction!", 50, "SuspiciousEye")
        {
        }

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Eyemalgamation");
            Tooltip.SetDefault("Summons several Eyes of Cthulhu");
        }

        public override bool CanUseItem(Player player) => !Fargowiltas.SwarmActive && !Main.dayTime;
    }
}