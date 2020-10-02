using Fargowiltas.Tiles;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.Audio;
using Terraria.Chat;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria;

namespace Fargowiltas.Projectiles.Explosives
{
    public class InstabridgeProj : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Instabridge");
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
            SoundEngine.PlaySound(SoundID.Item14, (int)position.X, (int)position.Y);

            if (Main.netMode == NetmodeID.MultiplayerClient)
            {
                return;
            }

            // All the way across
            for (int x = 1; x <= Main.maxTilesX; x++)
            {
                // Six down, last is platforms
                for (int y = -5; y <= 0; y++)
                {
                    int xPosition = x;
                    int yPosition = (int)(y + position.Y / 16.0f);

                    Tile tile = Main.tile[xPosition, yPosition];

                    if (tile == null)
                    {
                        continue;
                    }

                    // Testing for blocks that should not be destroyed
                    bool noFossil = tile.type == TileID.DesertFossil && !NPC.downedBoss2;
                    bool noDungeon = (tile.type == TileID.BlueDungeonBrick || tile.type == TileID.GreenDungeonBrick || tile.type == TileID.PinkDungeonBrick) && !NPC.downedBoss3;
                    bool noHMOre = (tile.type == TileID.Cobalt || tile.type == TileID.Palladium || tile.type == TileID.Mythril || tile.type == TileID.Orichalcum || tile.type == TileID.Adamantite || tile.type == TileID.Titanium) && !NPC.downedMechBossAny;
                    bool noChloro = tile.type == TileID.Chlorophyte && (!NPC.downedMechBoss1 || !NPC.downedMechBoss2 || !NPC.downedMechBoss3);
                    bool noLihzahrd = tile.type == TileID.LihzahrdBrick && !NPC.downedGolemBoss;

                    if (noFossil || noDungeon || noHMOre || noChloro || noLihzahrd)
                    {
                        continue;
                    }

                    FargoGlobalTile.ClearEverything(xPosition, yPosition);

                    if (y == 0)
                    {
                        // Spawn platforms
                        WorldGen.PlaceTile(xPosition, yPosition, TileID.Platforms);
                    }

                    NetMessage.SendTileSquare(-1, xPosition, yPosition, 1);
                }
            }
        }
    }
}