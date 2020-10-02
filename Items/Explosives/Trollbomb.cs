using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Fargowiltas.Items.Explosives
{
    public class Trollbomb : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Troll Bomb");
            Tooltip.SetDefault("Summon a random bomb");
        }

        public override void SetDefaults()
        {
            item.width = 10;
            item.height = 32;
            item.consumable = false;
            item.useStyle = ItemUseStyleID.Shoot;
            item.mana = 10;
            item.rare = ItemRarityID.Green;
            item.UseSound = SoundID.Item18;
            item.autoReuse = true;
            item.useAnimation = 20;
            item.useTime = 20;
            item.value = Item.buyPrice(0, 0, 3);
            item.noMelee = true;
            item.shoot = ProjectileID.WoodenArrowFriendly;
            item.shootSpeed = 5f;
        }

        public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
        {
            int j = Main.rand.Next(10);

            switch (j)
            {
                case 0:
                    type = ProjectileID.Bomb;
                    break;

                case 1:
                    type = ProjectileID.BouncyBomb;
                    break;

                case 2:
                    type = ProjectileID.StickyBomb;
                    break;

                case 3:
                    type = ProjectileID.SmokeBomb;
                    break;

                case 4:
                    type = ProjectileID.Dynamite;
                    break;

                case 5:
                    type = ProjectileID.StickyDynamite;
                    break;

                case 6:
                    type = ProjectileID.BouncyDynamite;
                    break;

                case 7:
                    type = ProjectileID.Grenade;
                    break;

                case 8:
                    type = ProjectileID.StickyGrenade;
                    break;

                case 9:
                    type = ProjectileID.BouncyGrenade;
                    break;
            }

            Projectile.NewProjectile(position.X, position.Y, speedX, speedY, type, damage, knockBack, Main.myPlayer);

            return false;
        }

        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe();
            recipe.AddIngredient(ItemID.Bomb, 10);
            recipe.AddIngredient(ItemID.StickyBomb, 10);
            recipe.AddIngredient(ItemID.BouncyBomb, 10);
            recipe.AddIngredient(ItemID.Dynamite, 10);
            recipe.AddIngredient(ItemID.ManaCrystal);
            recipe.AddTile(TileID.Anvils);

            recipe.Register();
        }
    }
}