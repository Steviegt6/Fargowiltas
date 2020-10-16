using Fargowiltas.Tiles;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.Audio;
using Terraria.ID;
using Terraria.ModLoader;

namespace Fargowiltas.Projectiles
{
    public class AutoHouseProj : ModProjectile
    {
        public override void SetDefaults()
        {
            projectile.width = 1;
            projectile.height = 1;
            projectile.timeLeft = 1;
        }

        public static void PlaceHouse(int x, int y, Vector2 position, int side, Player player)
        {
            int xPosition = (int)((side * -1) + x + position.X / 16.0f);
            int yPosition = (int)(y + position.Y / 16.0f);
            Tile tile = Main.tile[xPosition, yPosition];

            // Testing for blocks that should not be destroyed
            bool noFossil = tile.type == TileID.DesertFossil && !NPC.downedBoss2;
            bool noDungeon = (tile.type == TileID.BlueDungeonBrick || tile.type == TileID.GreenDungeonBrick || tile.type == TileID.PinkDungeonBrick) && !NPC.downedBoss3;
            bool noHMOre = (tile.type == TileID.Cobalt || tile.type == TileID.Palladium || tile.type == TileID.Mythril || tile.type == TileID.Orichalcum || tile.type == TileID.Adamantite || tile.type == TileID.Titanium) && !NPC.downedMechBossAny;
            bool noChloro = tile.type == TileID.Chlorophyte && (!NPC.downedMechBoss1 || !NPC.downedMechBoss2 || NPC.downedMechBoss3);
            bool noLihzahrd = tile.type == TileID.LihzahrdBrick && !NPC.downedGolemBoss;

            if (noFossil && noDungeon && noHMOre && noChloro && noLihzahrd)
            {
                FargoGlobalTile.ClearEverything(xPosition, yPosition);

                /*// Tile destroy
                WorldGen.KillTile(xPosition, yPosition, false, false, false);
                WorldGen.KillWall(xPosition, yPosition);
                Dust.NewDust(position, 22, 22, DustID.Smoke, Alpha: 120);

                // Kill liquids
                if (tile != null)
                {
                    tile.liquid = 0;
                    tile.lava(false);
                    tile.honey(false);
                    if (Main.netMode == NetmodeID.Server)
                    {
                        NetMessage.sendWater(xPosition, yPosition);
                    }
                }*/

                int wallType = WallID.Wood;
                int tileType = TileID.WoodBlock;

                if (player.ZoneDesert && !player.ZoneBeach)
                {
                    wallType = WallID.Cactus;
                    tileType = TileID.CactusBlock;
                }
                else if (player.ZoneSnow)
                {
                    wallType = WallID.BorealWood;
                    tileType = TileID.BorealWood;
                }
                else if (player.ZoneJungle)
                {
                    wallType = WallID.RichMaogany;
                    tileType = TileID.RichMahogany;
                }
                else if (player.ZoneCorrupt)
                {
                    wallType = WallID.Ebonwood;
                    tileType = TileID.Ebonwood;
                }
                else if (player.ZoneCrimson)
                {
                    wallType = WallID.Shadewood;
                    tileType = TileID.Shadewood;
                }
                else if (player.ZoneBeach)
                {
                    wallType = WallID.PalmWood;
                    tileType = TileID.PalmWood;
                }
                else if (player.ZoneHallow)
                {
                    wallType = WallID.Pearlwood;
                    tileType = TileID.Pearlwood;
                }
                else if (player.ZoneGlowshroom)
                {
                    wallType = WallID.Mushroom;
                    tileType = TileID.MushroomBlock;
                }
                else if (player.ZoneSkyHeight)
                {
                    wallType = WallID.DiscWall;
                    tileType = TileID.Sunplate;
                }
                else if (player.ZoneUnderworldHeight)
                {
                    wallType = WallID.ObsidianBrick;
                    tileType = TileID.ObsidianBrick;
                }

                // Spawn walls
                if (y != -6 && y != -1 && x != (10 * side) && x != (1 * side))
                {
                    WorldGen.PlaceWall(xPosition, yPosition, wallType);
                }

                // Spawn border
                if ((y == -6) || (y == -1) || (x == (10 * side)) || (x == (1 * side) && y == -5))
                {
                    WorldGen.PlaceTile(xPosition, yPosition, tileType);
                }
            }
        }

        public static void PlaceFurniture(int x, int y, Vector2 position, int side, Player player)
        {
            int xPosition = (int)((side * -1) + x + position.X / 16.0f);
            int yPosition = (int)(y + position.Y / 16.0f);

            if (y == -2)
            {
                if (x == (1 * side))
                {
                    int placeStyle = 0;

                    if (player.ZoneDesert && !player.ZoneBeach)
                    {
                        placeStyle = 4;
                    }
                    else if (player.ZoneSnow)
                    {
                        placeStyle = 30;
                    }
                    else if (player.ZoneJungle)
                    {
                        placeStyle = 2;
                    }
                    else if (player.ZoneCorrupt)
                    {
                        placeStyle = 1;
                    }
                    else if (player.ZoneCrimson)
                    {
                        placeStyle = 10;
                    }
                    else if (player.ZoneBeach)
                    {
                        placeStyle = 29;
                    }
                    else if (player.ZoneHallow)
                    {
                        placeStyle = 3;
                    }
                    else if (player.ZoneGlowshroom)
                    {
                        placeStyle = 6;
                    }
                    else if (player.ZoneSkyHeight)
                    {
                        placeStyle = 9;
                    }
                    else if (player.ZoneUnderworldHeight)
                    {
                        placeStyle = 19;
                    }

                    WorldGen.PlaceTile(xPosition, yPosition, TileID.ClosedDoor, style: placeStyle);
                }

                if (x == (5 * side))
                {
                    int placeStyle = 0;

                    if (player.ZoneDesert && !player.ZoneBeach)
                    {
                        placeStyle = 6;
                    }
                    else if (player.ZoneSnow)
                    {
                        placeStyle = 30;
                    }
                    else if (player.ZoneJungle)
                    {
                        placeStyle = 3;
                    }
                    else if (player.ZoneCorrupt)
                    {
                        placeStyle = 2;
                    }
                    else if (player.ZoneCrimson)
                    {
                        placeStyle = 11;
                    }
                    else if (player.ZoneBeach)
                    {
                        placeStyle = 29;
                    }
                    else if (player.ZoneHallow)
                    {
                        placeStyle = 4;
                    }
                    else if (player.ZoneGlowshroom)
                    {
                        placeStyle = 9;
                    }
                    else if (player.ZoneSkyHeight)
                    {
                        placeStyle = 10;
                    }
                    else if (player.ZoneUnderworldHeight)
                    {
                        placeStyle = 16;
                    }

                    WorldGen.PlaceObject(xPosition, yPosition, TileID.Chairs, direction: side, style: placeStyle);
                }

                if (x == (7 * side))
                {
                    int placeStyle = 0;

                    if (player.ZoneDesert && !player.ZoneBeach)
                    {
                        placeStyle = 30;
                    }
                    else if (player.ZoneSnow)
                    {
                        placeStyle = 28;
                    }
                    else if (player.ZoneJungle)
                    {
                        placeStyle = 2;
                    }
                    else if (player.ZoneCorrupt)
                    {
                        placeStyle = 1;
                    }
                    else if (player.ZoneCrimson)
                    {
                        placeStyle = 8;
                    }
                    else if (player.ZoneBeach)
                    {
                        placeStyle = 26;
                    }
                    else if (player.ZoneHallow)
                    {
                        placeStyle = 3;
                    }
                    else if (player.ZoneGlowshroom)
                    {
                        placeStyle = 27;
                    }
                    else if (player.ZoneSkyHeight)
                    {
                        placeStyle = 7;
                    }
                    else if (player.ZoneUnderworldHeight)
                    {
                        placeStyle = 13;
                    }

                    WorldGen.PlaceTile(xPosition, yPosition, TileID.Tables, style: placeStyle);
                }
            }

            if (x == (7 * side) && y == -5)
            {
                WorldGen.PlaceTile(xPosition, yPosition, TileID.Torches);
            }
        }

        public override void Kill(int timeLeft)
        {
            Vector2 position = projectile.Center;
            SoundEngine.PlaySound(SoundID.Item14, (int)position.X, (int)position.Y);
            Player player = Main.player[projectile.owner];

            if (player.Center.X < position.X)
            {
                for (int i = 0; i < 2; i++)
                {
                    // Ten wide
                    for (int x = 10; x > 0; x--)
                    {
                        // Six tall
                        for (int y = -6; y < 0; y++)
                        {
                            if (i == 0)
                            {
                                PlaceHouse(x, y, position, 1, player);
                            }
                            else
                            {
                                PlaceFurniture(x, y, position, 1, player);
                            }
                        }
                    }
                }
            }
            else
            {
                for (int i = 0; i < 2; i++)
                {
                    // Ten wide
                    for (int x = -10; x < 0; x++)
                    {
                        // Six tall
                        for (int y = -6; y < 0; y++)
                        {
                            if (i == 0)
                            {
                                PlaceHouse(x, y, position, -1, player);
                            }
                            else
                            {
                                PlaceFurniture(x, y, position, -1, player);
                            }
                        }
                    }
                }
            }
        }
    }
}