using Terraria;
using Terraria.ID;

namespace Fargowiltas.Items.Summons
{
    public class WormyFood : BaseSummon
    {
        public override string Texture => "Terraria/Item_70";

        public override int Type => NPCID.EaterofWorldsHead;

        public override string NPCName => "Eater of Worlds";

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Wormy Food");
            Tooltip.SetDefault("Summons the Eater of Worlds");
        }

        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe();
            recipe.AddIngredient(ItemID.WormFood);
            recipe.AddTile(TileID.WorkBenches);

            recipe.Register();
        }
    }
}