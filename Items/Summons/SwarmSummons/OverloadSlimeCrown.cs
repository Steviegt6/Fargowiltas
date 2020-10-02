using Fargowiltas.NPCs;
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
    public class OverloadSlimeCrown : SwarmSummonBase
    {
        public OverloadSlimeCrown() : base(NPCID.KingSlime, "Welcome to the true slime rain!", 50, "SlimyCrown")
        {
        }

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Swarm Crown");
            Tooltip.SetDefault("Summons several King Slimes");
        }

        public override bool CanUseItem(Player player)
        {
            return !Fargowiltas.SwarmActive;
        }
    }
}