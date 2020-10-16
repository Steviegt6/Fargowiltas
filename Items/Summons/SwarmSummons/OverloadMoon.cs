using Terraria;
using Terraria.ID;

namespace Fargowiltas.Items.Summons.SwarmSummons
{
    public class OverloadMoon : SwarmSummonBase
    {
        public OverloadMoon() : base(NPCID.MoonLordCore, "The wind whispers of death's approach!", 20, "CelestialSigil2")
        {
        }

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Runic Inscription");
            Tooltip.SetDefault("Summons several Moon Lords");
        }

        public override bool CanUseItem(Player player) => !Fargowiltas.SwarmActive;
    }
}