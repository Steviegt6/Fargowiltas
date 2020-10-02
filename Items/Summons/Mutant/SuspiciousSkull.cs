using Microsoft.Xna.Framework;
using Terraria;
using Terraria.Audio;
using Terraria.Chat;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;
using Terraria;
using Fargowiltas.Projectiles;

namespace Fargowiltas.Items.Summons.Mutant
{
    public class SuspiciousSkull : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Suspicious Skull");
            Tooltip.SetDefault("Summons Skeletron without killing the Clothier" +
                               "\nSummons the Dungeon Guardian during the day");
        }

        public override void SetDefaults()
        {
            item.width = 20;
            item.height = 20;
            item.maxStack = 20;
            item.value = Item.sellPrice(0, 0, 2);
            item.rare = ItemRarityID.Blue;
            item.useAnimation = 30;
            item.useTime = 30;
            item.useStyle = ItemUseStyleID.HoldUp;
            item.consumable = true;
            item.shoot = ModContent.ProjectileType<SpawnProj>();
        }

        public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
        {
            Vector2 pos = new Vector2((int)player.position.X + Main.rand.Next(-800, 800), (int)player.position.Y + Main.rand.Next(-1000, -250));

            if (!Main.dayTime)
            {
                if (!NPC.downedBoss3)
                {
                    Main.dayTime = false;
                    Main.time = 0;

                    if (Main.netMode == NetmodeID.Server) //sync time
                        NetMessage.SendData(MessageID.WorldData, -1, -1, null, 0, 0f, 0f, 0f, 0, 0, 0);
                }

                Projectile.NewProjectile(pos, Vector2.Zero, ModContent.ProjectileType<SpawnProj>(), 0, 0, Main.myPlayer, NPCID.SkeletronHead);

                if (Main.netMode == NetmodeID.Server)
                {
                    ChatHelper.BroadcastChatMessage(NetworkText.FromLiteral("Skeletron has awoken!"), new Color(175, 75, 255));
                }
                else
                {
                    Main.NewText("Skeletron has awoken!", new Color(175, 75, 255));
                }
            }
            else
            {
                Projectile.NewProjectile(pos, Vector2.Zero, ModContent.ProjectileType<SpawnProj>(), 0, 0, Main.myPlayer, NPCID.DungeonGuardian);

                if (Main.netMode == NetmodeID.Server)
                {
                    ChatHelper.BroadcastChatMessage(NetworkText.FromLiteral("Dungeon Guardian has awoken!"), new Color(175, 75, 255));
                }
                else
                {
                    Main.NewText("Dungeon Guardian has awoken!", new Color(175, 75, 255));
                }
            }

            SoundEngine.PlaySound(SoundID.Roar, player.position, 0);

            return false;
        }

        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe();
            recipe.AddIngredient(ItemID.ClothierVoodooDoll);
            recipe.AddTile(TileID.WorkBenches);
            
            recipe.Register();
        }
    }
}