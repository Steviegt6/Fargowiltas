using Microsoft.Xna.Framework;
using Terraria;
using Terraria.Audio;
using Terraria.Chat;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria;

namespace Fargowiltas.Projectiles.Explosives
{
    public class ShurikenProj : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Shuriken");
        }

        public override void SetDefaults()
        {
            projectile.width = 11;
            projectile.height = 11;
            projectile.friendly = true;
            projectile.ranged = true;
            projectile.penetrate = 5;
            projectile.aiStyle = 2;
            projectile.timeLeft = 600;
            aiType = 48;
        }

        public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
        {
            projectile.Kill();
        }

        public override bool OnTileCollide(Vector2 oldVelocity)
        {
            projectile.Kill();
            return false;
        }

        public override void Kill(int timeLeft)
        {
            Projectile.NewProjectile(projectile.Center.X, projectile.Center.Y, 0, 0, ModContent.ProjectileType<Explosion>(), 0, projectile.knockBack, projectile.owner);

            Vector2 position = projectile.Center;
            SoundEngine.PlaySound(SoundID.Item14, (int)position.X, (int)position.Y);
            int radius = 16;     // bigger = boomer

            for (int x = -radius; x <= radius; x++)
            {
                for (int y = -radius; y <= radius; y++)
                {
                    int xPosition = (int)(x + position.X / 16.0f);
                    int yPosition = (int)(y + position.Y / 16.0f);

                    Tile tile = Main.tile[xPosition, yPosition];
                    Player player = Main.player[projectile.owner];
                    Item bestPickaxe = GetBestPickaxe(player);

                    // testing for blocks that should not be destroyed
                    /*bool noFossil = tile.type == TileID.DesertFossil && !NPC.downedBoss2;
                    bool noDungeon = (tile.type == TileID.BlueDungeonBrick || tile.type == TileID.GreenDungeonBrick || tile.type == TileID.PinkDungeonBrick) && !NPC.downedBoss3;
                    bool noHellstone = tile.type == TileID.Hellstone && !NPC.downedBoss3;
                    bool noHMOre = (tile.type == TileID.Cobalt || tile.type == TileID.Palladium || tile.type == TileID.Mythril || tile.type == TileID.Orichalcum || tile.type == TileID.Adamantite || tile.type == TileID.Titanium) && !NPC.downedMechBossAny;
                    bool noChloro = tile.type == TileID.Chlorophyte && (!NPC.downedMechBoss1 || !NPC.downedMechBoss2 || !NPC.downedMechBoss3);
                    bool noLihzahrd = tile.type == TileID.LihzahrdBrick && !NPC.downedGolemBoss;

                    if (noFossil || noDungeon || noHMOre || noChloro || noLihzahrd)
                    {
                        continue;
                    }*/

                    // Circle
                    if ((x * x + y * y) <= radius)
                    {
                        // Hit the tile 5 times, most tiles that you can break will break in 1-3 hits.
                        for (int i = 0; i < 5; i++)
                        {
                            if (!tile.active())
                            {
                                break;
                            }

                            player.PickTile(xPosition, yPosition, bestPickaxe != null ? bestPickaxe.pick : 35);
                        }

                        Dust.NewDust(position, 22, 22, DustID.Smoke, 0.0f, 0.0f, 120);
                    }

                    // NetMessage.SendTileSquare(-1, xPosition, yPosition, 1);
                }
            }
        }

        private Item GetBestPickaxe(Player player)
        {
            Item item = null;

            for (int i = 0; i < player.inventory.Length; i++)
            {
                Item invItem = player.inventory[i];

                if (invItem.stack > 0 && invItem.pick > 0 && (item == null || invItem.pick > item.pick))
                {
                    item = invItem;
                }
            }

            return item;
        }
    }
}