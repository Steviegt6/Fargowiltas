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
    public class OverloadTwins : SwarmSummonBase
    {
        public OverloadTwins() : base(NPCID.Retinazer, "A legion of glowing iris sing a dreadful song!", 25, "MechEye")
        {
        }

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Omnifocal Lens");
            Tooltip.SetDefault("Summons several sets of Twins");
        }

        public override bool CanUseItem(Player player)
        {
            return !Fargowiltas.SwarmActive && !Main.dayTime;
        }
    }
}