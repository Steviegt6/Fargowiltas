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
    public class OverloadFish : SwarmSummonBase
    {
        public OverloadFish() : base(NPCID.DukeFishron, "The ocean swells with ferocious pigs!", 25, "TruffleWorm2")
        {
        }

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Truffle Worm Clump");
            Tooltip.SetDefault("Summons several Duke Fishrons");
        }

        public override bool CanUseItem(Player player)
        {
            return !Fargowiltas.SwarmActive;
        }
    }
}