using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Fargowiltas.Items.Vanity
{
    [AutoloadEquip(EquipType.Body)]
    public class AbominationnBody : ModItem
    {
        public override void SetStaticDefaults() => DisplayName.SetDefault("Abominationn Body");

        public override void SetDefaults()
        {
            item.width = 18;
            item.height = 18;
            item.vanity = true;
            item.rare = ItemRarityID.Blue;
        }

        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe();
            recipe.AddIngredient(ItemID.PirateShirt);
            recipe.AddIngredient(ItemID.ChargedBlasterCannon);
            recipe.AddTile(TileID.TinkerersWorkbench);            recipe.Register();
        }
    }
}