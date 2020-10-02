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
    public class OverloadPlant : SwarmSummonBase
    {
        public OverloadPlant() : base(NPCID.Plantera, "The jungle beats as one!", 25, "PlanterasFruit")
        {
        }

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Heart of the Jungle");
            Tooltip.SetDefault("Summons several Planteras");
        }

        public override bool CanUseItem(Player player)
        {
            return !Fargowiltas.SwarmActive;
        }
    }
}