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
    public class OverloadBee : SwarmSummonBase
    {
        public OverloadBee() : base(NPCID.QueenBee, "A deafening buzz pierces through you!", 50, "Abeemination2")
        {
        }

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Overstuffed Larva");
            Tooltip.SetDefault("Summons several Queen Bees");
        }

        public override bool CanUseItem(Player player)
        {
            return !Fargowiltas.SwarmActive;
        }
    }
}