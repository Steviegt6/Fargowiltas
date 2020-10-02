using Terraria;
using Terraria.ID;

namespace Fargowiltas.Items.Summons
{
    public class GoreySpine : BaseSummon
    {
        public override string Texture => "Terraria/Item_1331";

        public override int Type => NPCID.BrainofCthulhu;

        public override string NPCName => "Brain of Cthulhu";

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Red Stained Spine");
            Tooltip.SetDefault("Summons the Brain of Cthulhu");
        }

        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe();
            recipe.AddIngredient(ItemID.BloodySpine);
            recipe.AddTile(TileID.WorkBenches);

            recipe.Register();
        }
    }
}