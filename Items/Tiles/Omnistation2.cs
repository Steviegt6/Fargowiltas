using Terraria.ID;
using Terraria.ModLoader;

namespace Fargowiltas.Items.Tiles
{
    public class Omnistation2 : Omnistation
    {
        public override void SetDefaults()
        {
            base.SetDefaults();
            item.createTile = mod.TileType("OmnistationSheet2");
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.Sunflower, 20);
            recipe.AddIngredient(ItemID.Campfire, 20);
            recipe.AddIngredient(ItemID.HeartLantern, 20);
            recipe.AddIngredient(ItemID.StarinaBottle, 20);
            recipe.AddIngredient(ItemID.HoneyBucket, 20);
            recipe.AddIngredient(ItemID.SharpeningStation, 5);
            recipe.AddIngredient(ItemID.AmmoBox, 5);
            recipe.AddIngredient(ItemID.CrystalBall, 5);
            recipe.AddIngredient(ItemID.BewitchingTable, 5);
            recipe.AddIngredient(ItemID.TitaniumBar, 5);
            recipe.AddTile(TileID.MythrilAnvil);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}