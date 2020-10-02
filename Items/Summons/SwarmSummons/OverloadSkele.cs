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
    public class OverloadSkele : SwarmSummonBase
    {
        public OverloadSkele() : base(NPCID.SkeletronHead, "A great clammering of bones rises from the dungeon!", 40, "SuspiciousSkull")
        {
        }

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Skull Chain Necklace");
            Tooltip.SetDefault(
@"Summons several Skeletrons during the night
Summons several Dungeon Guardians during the day");
        }

        public override bool CanUseItem(Player player)
        {
            return !Fargowiltas.SwarmActive;
        }
    }
}