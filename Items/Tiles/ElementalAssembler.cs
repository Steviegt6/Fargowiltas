using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Fargowiltas.Items.Tiles
{
    public class ElementalAssembler : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Elemental Assembler");
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
            item.createTile = ModContent.TileType<ElementalAssemblerSheet>();
        }

        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe();

            recipe.AddIngredient(ItemID.Hellforge);
            recipe.AddIngredient(ItemID.AlchemyTable);
            recipe.AddIngredient(ItemID.TinkerersWorkshop);
            recipe.AddIngredient(ItemID.ImbuingStation);
            recipe.AddIngredient(ItemID.DyeVat);
            recipe.AddIngredient(ItemID.LivingLoom);
            recipe.AddIngredient(ItemID.GlassKiln);
            recipe.AddIngredient(ItemID.IceMachine);
            recipe.AddIngredient(ItemID.HoneyDispenser);
            recipe.AddIngredient(ItemID.SkyMill);
            recipe.AddIngredient(ItemID.Solidifier);
            recipe.AddIngredient(ItemID.BoneWelder);
            recipe.AddTile(TileID.DemonAltar);            recipe.Register();
        }
    }
}