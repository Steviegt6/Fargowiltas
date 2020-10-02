using Microsoft.Xna.Framework;
using Terraria;
using Terraria.Audio;
using Terraria.Chat;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria;
using Fargowiltas.Projectiles.Explosives;

namespace Fargowiltas.Items.Explosives
{
    public class InstaBridge : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Instabridge");
            Tooltip.SetDefault("Creates a bridge of platforms across the whole world" +
                               "\nAlso clears the area right above the platforms" +
                               "\nDo not use if any important building is nearby");
        }

        public override void SetDefaults()
        {
            item.width = 10;
            item.height = 32;
            item.maxStack = 99;
            item.consumable = true;
            item.useStyle = ItemUseStyleID.Swing;
            item.rare = ItemRarityID.Green;
            item.UseSound = SoundID.Item1;
            item.useAnimation = 20;
            item.useTime = 20;
            item.value = Item.buyPrice(0, 0, 3);
            item.noUseGraphic = true;
            item.noMelee = true;
            item.shoot = ModContent.ProjectileType<InstabridgeProj>();
        }

        public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
        {
            Vector2 mouse = Main.MouseWorld;

            Projectile.NewProjectile(mouse, Vector2.Zero, type, 0, 0, player.whoAmI );

            return false;
        }

        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe();
            recipe.AddIngredient(ItemID.FossilOre, 20);
            recipe.AddIngredient(ItemID.Dynamite, 10);
            recipe.AddIngredient(ItemID.WoodPlatform, 1000);
            recipe.AddTile(TileID.Anvils);
            
            recipe.Register();
        }
    }
}