using Terraria;
using Terraria.ID;

namespace Fargowiltas.Items.Summons.SwarmSummons
{
    public class OverloadWall : SwarmSummonBase
    {
        public OverloadWall() : base(NPCID.WallofFlesh, "A fortress of flesh arises from the depths!", 10, "FleshyDoll")
        {
        }

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Bundle of Dolls");
            Tooltip.SetDefault("Summons several Walls of Flesh");
        }

        public override bool CanUseItem(Player player)
        {
            return !Fargowiltas.SwarmActive && player.ZoneUnderworldHeight;
        }
    }
}