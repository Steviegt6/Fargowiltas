using Terraria;
using Terraria.ID;

namespace Fargowiltas.Items.Summons
{
    public class MechSkull : BaseSummon
    {
        public override string Texture => "Terraria/Item_557";

        public override int NPCType => NPCID.SkeletronPrime;

        public override string NPCName => "Skeletron Prime";

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Some Kind of Metallic Skull");
            Tooltip.SetDefault("Summons Skeletron Prime");
        }

        public override bool CanUseItem(Player player) => !Main.dayTime;

        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe();
            recipe.AddIngredient(ItemID.MechanicalSkull);
            recipe.AddTile(TileID.WorkBenches);            recipe.Register();
        }
    }
}