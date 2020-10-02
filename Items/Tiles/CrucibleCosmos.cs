using Terraria.ID;
using Terraria.ModLoader;
using Terraria;
using Terraria.Localization;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.Audio;
using Terraria.Chat;

namespace Fargowiltas.Items.Tiles
{
    public class CrucibleCosmos : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Crucible of the Cosmos");
            Tooltip.SetDefault("'It seems to be hiding magnificent power'\nFunctions as every crafting station");
            DisplayName.AddTranslation((int)GameCulture.CultureName.Chinese, "宇宙坩埚");
            Tooltip.AddTranslation((int)GameCulture.CultureName.Chinese, "'它似乎隐藏着巨大的力量'\n包含几乎所有制作环境");
        }

        public override void ModifyTooltips(List<TooltipLine> list)
        {
            foreach (TooltipLine tooltipLine in list)
            {
                if (tooltipLine.mod == "Terraria" && tooltipLine.Name == "ItemName")
                {
                    tooltipLine.overrideColor = new Color?(new Color(Main.DiscoR, Main.DiscoG, Main.DiscoB));
                }
            }
        }

        public override void SetDefaults()
        {
            item.width = 28;
            item.height = 14;
            item.rare = ItemRarityID.Red;
            item.maxStack = 99;
            item.useTurn = true;
            item.autoReuse = true;
            item.useAnimation = 15;
            item.useTime = 10;
            item.useStyle = ItemUseStyleID.Swing;
            item.consumable = true;
            item.createTile = ModContent.TileType<CrucibleCosmosSheet>();
        }

        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe();

            recipe.AddIngredient(ModContent.ItemType<MultitaskCenter>());
            recipe.AddIngredient(ModContent.ItemType<ElementalAssembler>());
            recipe.AddRecipeGroup("Fargowiltas:AnyForge");
            recipe.AddRecipeGroup("Fargowiltas:AnyHMAnvil");
            recipe.AddRecipeGroup("Fargowiltas:AnyBookcase");
            recipe.AddIngredient(ItemID.CrystalBall);
            recipe.AddIngredient(ItemID.Autohammer);
            recipe.AddIngredient(ItemID.BlendOMatic);
            recipe.AddIngredient(ItemID.MeatGrinder);
            recipe.AddIngredient(ItemID.SteampunkBoiler);
            recipe.AddIngredient(ItemID.FleshCloningVaat);
            recipe.AddIngredient(ItemID.LihzahrdFurnace);
            recipe.AddIngredient(ItemID.LunarCraftingStation);
            recipe.AddIngredient(ItemID.LunarBar, 25);
            recipe.AddTile(TileID.DemonAltar);
            
            recipe.Register();
        }
    }
}