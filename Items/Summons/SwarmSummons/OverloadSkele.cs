using Terraria;
using Terraria.ID;

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
            Tooltip.SetDefault("Summons several Skeletrons during the night" +
                "\nSummons several Dungeon Guardians during the day");
        }

        public override bool CanUseItem(Player player) => !Fargowiltas.SwarmActive;
    }
}