using Fargowiltas.NPCs.Destroyer;
using Terraria;
using Terraria.ModLoader;

namespace Fargowiltas.Items.Summons.SwarmSummons
{
    public class OverloadDestroyer : SwarmSummonBase
    {
        public OverloadDestroyer() : base(ModContent.NPCType<Destroyer>(), "The planet trembles from the core!", 10, "MechWorm")
        {
        }

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Seismic Actuator");
            Tooltip.SetDefault("Summons several Destroyers");
        }

        public override bool CanUseItem(Player player) => !Fargowiltas.SwarmActive && !Main.dayTime;
    }
}