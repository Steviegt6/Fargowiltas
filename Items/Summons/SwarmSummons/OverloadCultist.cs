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
    public class OverloadCultist : SwarmSummonBase
    {
        public OverloadCultist() : base(NPCID.CultistBoss, "Defeaning chants fill your ears!", 25, "CultistSummon")
        {
        }

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Zealot's Madness");
            Tooltip.SetDefault("Summons several Lunatic Cultists");
        }

        public override bool CanUseItem(Player player)
        {
            return !Fargowiltas.SwarmActive;
        }
    }
}