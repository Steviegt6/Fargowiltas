using Terraria;
using Terraria.ID;

namespace Fargowiltas.Items.Summons
{
    public class TruffleWorm2 : BaseSummon
    {
        public override string Texture => "Terraria/Item_2673";

        public override int Type => NPCID.DukeFishron;

        public override string NPCName => "Duke Fishron";

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Truffly Worm");
            Tooltip.SetDefault("Summons Duke Fishron without fishing");
        }

        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe();
            recipe.AddIngredient(ItemID.TruffleWorm);
            recipe.AddTile(TileID.WorkBenches);

            recipe.Register();
        }
    }
}