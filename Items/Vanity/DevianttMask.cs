using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Fargowiltas.Items.Vanity
{
    [AutoloadEquip(EquipType.Head)]
    public class DevianttMask : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Deviantt Mask");
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

            recipe.AddIngredient(ItemID.RuneHat);
            recipe.AddIngredient(ItemID.MetalDetector);
            recipe.AddTile(TileID.TinkerersWorkbench);

            recipe.Register();
        }
    }
}