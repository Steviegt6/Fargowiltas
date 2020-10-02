using Terraria.ID;
using Terraria.ModLoader;
using Terraria;

namespace Fargowiltas.Items.Tiles
{
    public class Omnistation : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Omnistation");
            Tooltip.SetDefault(@"Effects of all vanilla buff stations
Grants Honey when touched
Right click while holding a weapon for its respective buff");
        }

        public override void SetDefaults()
        {
            item.width = 20;
            item.height = 20;
            item.useTurn = true;
            item.autoReuse = true;
            item.useAnimation = 15;
            item.useTime = 10;
            item.useStyle = ItemUseStyleID.Swing;
            item.rare = ItemRarityID.Blue;
            item.createTile = ModContent.TileType<OmnistationSheet>();
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
            recipe.AddIngredient(ItemID.AdamantiteBar, 5);
            recipe.AddTile(TileID.MythrilAnvil);
            
            recipe.Register();
        }
    }
}