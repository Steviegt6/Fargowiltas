﻿using Fargowiltas.Tiles;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Fargowiltas.Projectiles.Explosives
{
    public class MiniInstabridgeProj : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Mini Instabridge");
        }

        public override void SetDefaults()
        {
            projectile.width = 20;
            projectile.height = 36;
            projectile.aiStyle = 16;
            projectile.friendly = true;
            projectile.penetrate = -1;
            projectile.timeLeft = 1;
        }

        public override void Kill(int timeLeft)
        {
            Vector2 position = projectile.Center;
            Main.PlaySound(SoundID.Item14, (int)position.X, (int)position.Y);

            if (Main.netMode == NetmodeID.MultiplayerClient)
            {
                return;
            }

            // All the way across
            for (int x = -200; x < 200; x++)
            {
                int xPosition = (int)(x + position.X / 16.0f);
                int yPosition = (int)(position.Y / 16.0f);

                if (xPosition < 0 || xPosition >= Main.maxTilesX || yPosition < 0 || yPosition >= Main.maxTilesY)
                    continue;

                Tile tile = Main.tile[xPosition, yPosition];

                if (tile == null)
                {
                    continue;
                }

                if (tile.type == TileID.Trees || tile.type == TileID.Cactus)
                {
                    FargoGlobalTile.ClearEverything(xPosition, yPosition);
                }

                // Spawn platforms
                WorldGen.PlaceTile(xPosition, yPosition, TileID.Platforms);

                NetMessage.SendTileSquare(-1, xPosition, yPosition, 1);
            }
        }
    }
}