using Terraria;
using Terraria.ID;

namespace Fargowiltas.Items.Summons
{
    public class MechWorm : BaseSummon
    {
        public override string Texture => "Terraria/Item_556";

        public override int NPCType => NPCID.TheDestroyer;

        public override string NPCName => "The Destroyer";

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Some Kind of Metallic Worm");
            Tooltip.SetDefault("Summons the Destroyer");
        }

        public override bool CanUseItem(Player player) => !Main.dayTime;

        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe();
            recipe.AddIngredient(ItemID.MechanicalWorm);
            recipe.AddTile(TileID.WorkBenches);            recipe.Register();
        }
    }
}