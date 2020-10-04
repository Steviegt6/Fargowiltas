using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Fargowiltas.Items.Tiles
{
    public class Omnistation2 : Omnistation
    {
        public override void SetDefaults()
        {
            base.SetDefaults();

            item.createTile = ModContent.TileType<OmnistationSheet2>();
        }

        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe();
            recipe.AddIngredient(ItemID.Sunflower, 30);
            recipe.AddIngredient(ItemID.Campfire, 30);
            recipe.AddIngredient(ItemID.HeartLantern, 30);
            recipe.AddIngredient(ItemID.StarinaBottle, 30);
            recipe.AddIngredient(ItemID.HoneyBucket, 30);
            recipe.AddIngredient(ItemID.SharpeningStation, 5);
            recipe.AddIngredient(ItemID.AmmoBox, 5);
            recipe.AddIngredient(ItemID.CrystalBall, 5);
            recipe.AddIngredient(ItemID.BewitchingTable, 5);
            recipe.AddIngredient(ItemID.TitaniumBar, 5);
            recipe.AddTile(TileID.MythrilAnvil);            recipe.Register();
        }
    }
}