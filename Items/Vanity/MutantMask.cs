using Terraria.ID;
using Terraria.ModLoader;
using Terraria;

namespace Fargowiltas.Items.Vanity
{
    [AutoloadEquip(EquipType.Head)]
    public class MutantMask : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Mutant Mask");
        }

        public override void SetDefaults()
        {
            item.width = 18;
            item.height = 18;
            item.rare = ItemRarityID.Blue;
            item.vanity = true;
        }

        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe();

            recipe.AddIngredient(ItemID.EyeMask);
            recipe.AddIngredient(ItemID.BrainMask);
            recipe.AddIngredient(ItemID.EaterMask);
            recipe.AddTile(TileID.TinkerersWorkbench);
            
            recipe.Register();
        }
    }
}
