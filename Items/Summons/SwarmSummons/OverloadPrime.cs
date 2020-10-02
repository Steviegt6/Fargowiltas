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
    public class OverloadPrime : SwarmSummonBase
    {
        public OverloadPrime() : base(NPCID.SkeletronPrime, "A sickly chill envelops the world!", 25, "MechSkull")
        {
        }

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Primal Control Chip");
            Tooltip.SetDefault("Summons several Skeletron Primes");
        }

        public override bool CanUseItem(Player player)
        {
            return !Fargowiltas.SwarmActive && !Main.dayTime;
        }
    }
}