using Fargowiltas.Tiles;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Fargowiltas.Projectiles.Explosives
{
    public class InstaProj : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Instavator");
        }

        public override void SetDefaults()
        {
            projectile.width = 20;
            projectile.height = 36;
            projectile.aiStyle = 16;
            projectile.friendly = true;
            projectile.penetrate = -1;
            projectile.timeLeft = 170;
        }

        public override bool CanDamage()
        {
            return false;
        }

        public override bool TileCollideStyle(ref int width, ref int height, ref bool fallThrough)
        {
            fallThrough = false;

            return base.TileCollideStyle(ref width, ref height, ref fallThrough);
        }

        public override bool OnTileCollide(Vector2 oldVelocity)
        {
            projectile.Kill();
            return true;
        }

        public override void Kill(int timeLeft)
        {
            Vector2 position = projectile.Center;
            Main.PlaySound(SoundID.Item14, (int)position.X, (int)position.Y);

            if (Main.netMode == NetmodeID.MultiplayerClient)
            {
                return;
            }

            // Seven across
            for (int x = -3; x <= 3; x++)
            {
                for (int y = (int)(1 + position.Y / 16.0f); y <= (Main.maxTilesY - 40); y++)
                {
                    int xPosition = (int)(x + position.X / 16.0f);

                    if (xPosition < 0 || xPosition >= Main.maxTilesX || y < 0 || y >= Main.maxTilesY)
                        continue;

                    Tile tile = Main.tile[xPosition, y];

                    if (tile == null)
                        continue;

                    if (!FargoGlobalProjectile.OkayToDestroyTile(tile))
                        continue;

                    FargoGlobalTile.ClearEverything(xPosition, y);

                    // Tile destroy

                    // WorldGen.KillTile(xPosition, y);
                    // WorldGen.KillWall(xPosition, y);
                    // Dust.NewDust(position, 22, 22, DustID.Smoke, 0.0f, 0.0f, 120);

                    // Kill liquids
                    /*if (tile != null)
                    {
                        tile.liquid = 0;
                        tile.lava(false);
                        tile.honey(false);
                        if (Main.netMode == NetmodeID.Server)
                        {
                            NetMessage.sendWater(xPosition, y);
                        }
                    }*/

                    // Spawn structure
                    WorldGen.PlaceWall(xPosition, y, WallID.Stone);

                    if ((x == -3) || (x == 3))
                    {
                        WorldGen.PlaceTile(xPosition, y, TileID.GrayBrick);
                    }

                    if ((x == -2 || x == 2) && (y % 10 == 0))
                    {
                        WorldGen.PlaceTile(xPosition, y, TileID.Torches);
                    }

                    if (x == 0)
                    {
                        WorldGen.PlaceTile(xPosition, y, TileID.Rope);
                    }

                    NetMessage.SendTileSquare(-1, xPosition, y, 1);
                }
            }
        }
    }
}