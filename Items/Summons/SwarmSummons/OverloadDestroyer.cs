using Fargowiltas.NPCs;
using Fargowiltas.NPCs.Destroyer;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.Audio;
using Terraria.Chat;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;
using Terraria;

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

        public override bool CanUseItem(Player player)
        {
            return !Fargowiltas.SwarmActive && !Main.dayTime;
        }
    }
}