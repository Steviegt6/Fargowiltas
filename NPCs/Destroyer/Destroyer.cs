using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.Audio;
using Terraria.Chat;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria;

namespace Fargowiltas.NPCs.Destroyer
{
    [AutoloadBossHead]
    public class Destroyer : ModNPC
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("The Destroyer");
        }

        public override void SetDefaults()
        {
            npc.CloneDefaults(NPCID.TheDestroyer);
            npc.lifeMax /= 4; 
            npc.aiStyle = -1;
        }

        public override void AI()
        {
            if (npc.ai[3] > 0f)
            {
                npc.realLife = (int)npc.ai[3];
            }

            if (npc.target < 0 || npc.target == 255 || Main.player[npc.target].dead)
            {
                npc.TargetClosest(true);
            }

            npc.velocity.Length();
            if (npc.alpha != 0)
            {
                for (int i = 0; i < 2; i++)
                {
                    int num = Dust.NewDust(new Vector2(npc.position.X, npc.position.Y), npc.width, npc.height, 182, 0f, 0f, 100, default, 2f);
                    Main.dust[num].noGravity = true;
                    Main.dust[num].noLight = true;
                }
            }

            npc.alpha -= 42;
            if (npc.alpha < 0)
            {
                npc.alpha = 0;
            }

            if (Main.netMode != NetmodeID.MultiplayerClient)
            {
                if (npc.ai[0] == 0f)
                {
                    npc.ai[3] = npc.whoAmI;
                    npc.realLife = npc.whoAmI;
                    int num2 = npc.whoAmI;
                    int bodySegments = 8;
                    for (int j = 0; j <= bodySegments; j++)
                    {
                        int num4 = ModContent.NPCType<DestroyerBody>();
                        if (j == bodySegments)
                        {
                            num4 = ModContent.NPCType<DestroyerTail>();
                        }

                        int num5 = NPC.NewNPC((int)(npc.position.X + (float)(npc.width / 2)), (int)(npc.position.Y + npc.height), num4, npc.whoAmI, 0f, 0f, 0f, 0f, 255);
                        Main.npc[num5].ai[3] = (float)npc.whoAmI;
                        Main.npc[num5].realLife = npc.whoAmI;
                        Main.npc[num5].ai[1] = (float)num2;
                        Main.npc[num2].ai[0] = (float)num5;
                        NetMessage.SendData(MessageID.SyncNPC, -1, -1, null, num5, 0f, 0f, 0f, 0, 0, 0);
                        num2 = num5;
                    }
                }
            }

            int num13 = (int)(npc.position.X / 16f) - 1;
            int num14 = (int)((npc.position.X + (float)npc.width) / 16f) + 2;
            int num15 = (int)(npc.position.Y / 16f) - 1;
            int num16 = (int)((npc.position.Y + (float)npc.height) / 16f) + 2;
            if (num13 < 0)
            {
                num13 = 0;
            }

            if (num14 > Main.maxTilesX)
            {
                num14 = Main.maxTilesX;
            }

            if (num15 < 0)
            {
                num15 = 0;
            }

            if (num16 > Main.maxTilesY)
            {
                num16 = Main.maxTilesY;
            }

            bool flag2 = false;
            if (!flag2)
            {
                for (int k = num13; k < num14; k++)
                {
                    for (int l = num15; l < num16; l++)
                    {
                        if (Main.tile[k, l] != null && ((Main.tile[k, l].nactive() && (Main.tileSolid[(int)Main.tile[k, l].type] || (Main.tileSolidTop[(int)Main.tile[k, l].type] && Main.tile[k, l].frameY == 0))) || Main.tile[k, l].liquid > 64))
                        {
                            Vector2 vector2;
                            vector2.X = (float)(k * 16);
                            vector2.Y = (float)(l * 16);
                            if (npc.position.X + (float)npc.width > vector2.X && npc.position.X < vector2.X + 16f && npc.position.Y + (float)npc.height > vector2.Y && npc.position.Y < vector2.Y + 16f)
                            {
                                flag2 = true;
                                break;
                            }
                        }
                    }
                }
            }

            if (!flag2)
            {
                Lighting.AddLight((int)((npc.position.X + (float)(npc.width / 2)) / 16f), (int)((npc.position.Y + (float)(npc.height / 2)) / 16f), 0.3f, 0.1f, 0.05f);

                npc.localAI[1] = 1f;
                Rectangle rectangle = new Rectangle((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height);
                int num17 = 1000;
                bool flag3 = true;
                if (npc.position.Y > Main.player[npc.target].position.Y)
                {
                    for (int m = 0; m < 255; m++)
                    {
                        if (Main.player[m].active)
                        {
                            Rectangle rectangle2 = new Rectangle((int)Main.player[m].position.X - num17, (int)Main.player[m].position.Y - num17, num17 * 2, num17 * 2);
                            if (rectangle.Intersects(rectangle2))
                            {
                                flag3 = false;
                                break;
                            }
                        }
                    }

                    if (flag3)
                    {
                        flag2 = true;
                    }
                }
            }
            else
            {
                npc.localAI[1] = 0f;
            }

            float num18 = 16f;
            if (Main.dayTime || Main.player[npc.target].dead)
            {
                flag2 = false;
                npc.velocity.Y = npc.velocity.Y + 1f;
                if ((double)npc.position.Y > Main.worldSurface * 16.0)
                {
                    npc.velocity.Y = npc.velocity.Y + 1f;
                    num18 = 32f;
                }

                if (npc.position.Y > Main.rockLayer * 16.0)
                {
                    for (int n = 0; n < 200; n++)
                    {
                        if (Main.npc[n].aiStyle == npc.aiStyle)
                        {
                            Main.npc[n].active = false;
                        }
                    }
                }
            }

            float num19 = 0.1f;
            float num20 = 0.15f;
            Vector2 vector3 = new Vector2(npc.position.X + (float)npc.width * 0.5f, npc.position.Y + (float)npc.height * 0.5f);
            float num21 = Main.player[npc.target].position.X + (float)(Main.player[npc.target].width / 2);
            float num22 = Main.player[npc.target].position.Y + (float)(Main.player[npc.target].height / 2);
            num21 = (int)(num21 / 16f) * 16;
            num22 = (int)(num22 / 16f) * 16;
            vector3.X = (int)(vector3.X / 16f) * 16;
            vector3.Y = (int)(vector3.Y / 16f) * 16;
            num21 -= vector3.X;
            num22 -= vector3.Y;
            float num23 = (float)Math.Sqrt(num21 * num21 + num22 * num22);
            if (npc.ai[1] > 0f && npc.ai[1] < Main.npc.Length)
            {
                try
                {
                    vector3 = new Vector2(npc.position.X + npc.width * 0.5f, npc.position.Y + (float)npc.height * 0.5f);
                    num21 = Main.npc[(int)npc.ai[1]].position.X + (Main.npc[(int)npc.ai[1]].width / 2) - vector3.X;
                    num22 = Main.npc[(int)npc.ai[1]].position.Y + (Main.npc[(int)npc.ai[1]].height / 2) - vector3.Y;
                }
                catch
                {
                }

                npc.rotation = (float)Math.Atan2((double)num22, (double)num21) + 1.57f;
                num23 = (float)Math.Sqrt((double)(num21 * num21 + num22 * num22));
                int num24 = (int)(44f * npc.scale);
                num23 = (num23 - (float)num24) / num23;
                num21 *= num23;
                num22 *= num23;
                npc.velocity = Vector2.Zero;
                npc.position.X = npc.position.X + num21;
                npc.position.Y = npc.position.Y + num22;
                return;
            }

            if (!flag2)
            {
                npc.TargetClosest(true);
                npc.velocity.Y = npc.velocity.Y + 0.15f;
                if (npc.velocity.Y > num18)
                {
                    npc.velocity.Y = num18;
                }

                if ((double)(Math.Abs(npc.velocity.X) + Math.Abs(npc.velocity.Y)) < (double)num18 * 0.4)
                {
                    if (npc.velocity.X < 0f)
                    {
                        npc.velocity.X = npc.velocity.X - num19 * 1.1f;
                    }
                    else
                    {
                        npc.velocity.X = npc.velocity.X + num19 * 1.1f;
                    }
                }
                else if (npc.velocity.Y == num18)
                {
                    if (npc.velocity.X < num21)
                    {
                        npc.velocity.X = npc.velocity.X + num19;
                    }
                    else if (npc.velocity.X > num21)
                    {
                        npc.velocity.X = npc.velocity.X - num19;
                    }
                }
                else if (npc.velocity.Y > 4f)
                {
                    if (npc.velocity.X < 0f)
                    {
                        npc.velocity.X = npc.velocity.X + num19 * 0.9f;
                    }
                    else
                    {
                        npc.velocity.X = npc.velocity.X - num19 * 0.9f;
                    }
                }
            }
            else
            {
                if (npc.soundDelay == 0)
                {
                    float num25 = num23 / 40f;
                    if (num25 < 10f)
                    {
                        num25 = 10f;
                    }

                    if (num25 > 20f)
                    {
                        num25 = 20f;
                    }

                    npc.soundDelay = (int)num25;
                    SoundEngine.PlaySound(15, (int)npc.position.X, (int)npc.position.Y, 1, 1f, 0f);
                }

                num23 = (float)Math.Sqrt((double)(num21 * num21 + num22 * num22));
                float num26 = Math.Abs(num21);
                float num27 = Math.Abs(num22);
                float num28 = num18 / num23;
                num21 *= num28;
                num22 *= num28;
                if (((npc.velocity.X > 0f && num21 > 0f) || (npc.velocity.X < 0f && num21 < 0f)) && ((npc.velocity.Y > 0f && num22 > 0f) || (npc.velocity.Y < 0f && num22 < 0f)))
                {
                    if (npc.velocity.X < num21)
                    {
                        npc.velocity.X = npc.velocity.X + num20;
                    }
                    else if (npc.velocity.X > num21)
                    {
                        npc.velocity.X = npc.velocity.X - num20;
                    }

                    if (npc.velocity.Y < num22)
                    {
                        npc.velocity.Y = npc.velocity.Y + num20;
                    }
                    else if (npc.velocity.Y > num22)
                    {
                        npc.velocity.Y = npc.velocity.Y - num20;
                    }
                }

                if ((npc.velocity.X > 0f && num21 > 0f) || (npc.velocity.X < 0f && num21 < 0f) || (npc.velocity.Y > 0f && num22 > 0f) || (npc.velocity.Y < 0f && num22 < 0f))
                {
                    if (npc.velocity.X < num21)
                    {
                        npc.velocity.X = npc.velocity.X + num19;
                    }
                    else if (npc.velocity.X > num21)
                    {
                        npc.velocity.X = npc.velocity.X - num19;
                    }

                    if (npc.velocity.Y < num22)
                    {
                        npc.velocity.Y = npc.velocity.Y + num19;
                    }
                    else if (npc.velocity.Y > num22)
                    {
                        npc.velocity.Y = npc.velocity.Y - num19;
                    }

                    if ((double)Math.Abs(num22) < (double)num18 * 0.2 && ((npc.velocity.X > 0f && num21 < 0f) || (npc.velocity.X < 0f && num21 > 0f)))
                    {
                        if (npc.velocity.Y > 0f)
                        {
                            npc.velocity.Y = npc.velocity.Y + num19 * 2f;
                        }
                        else
                        {
                            npc.velocity.Y = npc.velocity.Y - num19 * 2f;
                        }
                    }

                    if ((double)Math.Abs(num21) < (double)num18 * 0.2 && ((npc.velocity.Y > 0f && num22 < 0f) || (npc.velocity.Y < 0f && num22 > 0f)))
                    {
                        if (npc.velocity.X > 0f)
                        {
                            npc.velocity.X = npc.velocity.X + num19 * 2f;
                        }
                        else
                        {
                            npc.velocity.X = npc.velocity.X - num19 * 2f;
                        }
                    }
                }
                else if (num26 > num27)
                {
                    if (npc.velocity.X < num21)
                    {
                        npc.velocity.X = npc.velocity.X + num19 * 1.1f;
                    }
                    else if (npc.velocity.X > num21)
                    {
                        npc.velocity.X = npc.velocity.X - num19 * 1.1f;
                    }

                    if ((double)(Math.Abs(npc.velocity.X) + Math.Abs(npc.velocity.Y)) < (double)num18 * 0.5)
                    {
                        if (npc.velocity.Y > 0f)
                        {
                            npc.velocity.Y = npc.velocity.Y + num19;
                        }
                        else
                        {
                            npc.velocity.Y = npc.velocity.Y - num19;
                        }
                    }
                }
                else
                {
                    if (npc.velocity.Y < num22)
                    {
                        npc.velocity.Y = npc.velocity.Y + num19 * 1.1f;
                    }
                    else if (npc.velocity.Y > num22)
                    {
                        npc.velocity.Y = npc.velocity.Y - num19 * 1.1f;
                    }

                    if ((double)(Math.Abs(npc.velocity.X) + Math.Abs(npc.velocity.Y)) < (double)num18 * 0.5)
                    {
                        if (npc.velocity.X > 0f)
                        {
                            npc.velocity.X = npc.velocity.X + num19;
                        }
                        else
                        {
                            npc.velocity.X = npc.velocity.X - num19;
                        }
                    }
                }
            }

            npc.rotation = (float)Math.Atan2((double)npc.velocity.Y, (double)npc.velocity.X) + 1.57f;
            if (flag2)
            {
                if (npc.localAI[0] != 1f)
                {
                    npc.netUpdate = true;
                }

                npc.localAI[0] = 1f;
            }
            else
            {
                if (npc.localAI[0] != 0f)
                {
                    npc.netUpdate = true;
                }

                npc.localAI[0] = 0f;
            }

            if (((npc.velocity.X > 0f && npc.oldVelocity.X < 0f) || (npc.velocity.X < 0f && npc.oldVelocity.X > 0f) || (npc.velocity.Y > 0f && npc.oldVelocity.Y < 0f) || (npc.velocity.Y < 0f && npc.oldVelocity.Y > 0f)) && !npc.justHit)
            {
                npc.netUpdate = true;
            }
        }
    }
}