using Terraria.ID;
using Terraria.ModLoader;
using Terraria;

namespace Fargowiltas.Items.Tiles
{
    public class MultitaskCenter : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Multitask Center");
            Tooltip.SetDefault("Functions as several basic crafting stations");
        }

        public override void SetDefaults()
        {
            item.width = 28;
            item.height = 14;
            item.maxStack = 99;
            item.useTurn = true;
            item.autoReuse = true;
            item.useAnimation = 15;
            item.useTime = 10;
            item.useStyle = ItemUseStyleID.Swing;
            item.consumable = true;
            item.createTile = ModContent.TileType<MultitaskCenterSheet>();
        }

        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe();

            recipe.AddIngredient(ItemID.WorkBench);
            recipe.AddIngredient(ItemID.HeavyWorkBench);
            recipe.AddIngredient(ItemID.Furnace);
            recipe.AddRecipeGroup("Fargowiltas:AnyAnvil");
            recipe.AddIngredient(ItemID.Bottle);
            recipe.AddIngredient(ItemID.Sawmill);
            recipe.AddIngredient(ItemID.Loom);
            recipe.AddIngredient(ItemID.WoodenTable);
            recipe.AddIngredient(ItemID.WoodenChair);
            recipe.AddIngredient(ItemID.CookingPot);
            recipe.AddIngredient(ItemID.WoodenSink);
            recipe.AddIngredient(ItemID.Keg);
            recipe.AddTile(TileID.DemonAltar);

            
            recipe.Register();
        }
    }
}