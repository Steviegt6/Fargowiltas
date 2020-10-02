using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using ReLogic.Content;
using Terraria;
using Terraria.Audio;
using Terraria.Chat;
using Terraria.GameContent;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;
using Terraria;

namespace Fargowiltas.NPCs
{
    [Autoload(false)]
	[AutoloadHead]
	public class Squirrel : ModNPC
	{
		private readonly Mod fargosouls = Fargowiltas.FargosGetMod("FargowiltasSouls");

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Squirrel");
			Main.npcFrameCount[npc.type] = 6;
			NPCID.Sets.ExtraFramesCount[npc.type] = 9;
			NPCID.Sets.AttackFrameCount[npc.type] = 4;
			NPCID.Sets.DangerDetectRange[npc.type] = 700;
			NPCID.Sets.AttackType[npc.type] = 0;
			NPCID.Sets.AttackTime[npc.type] = 90;
			NPCID.Sets.AttackAverageChance[npc.type] = 30;
			NPCID.Sets.HatOffsetY[npc.type] = 4;
		}
		public override void SetDefaults()
		{
			npc.townNPC = true;
			npc.friendly = true;
			npc.width = 50;
			npc.height = 32;
			npc.damage = 0;
			npc.defense = 0;
			npc.lifeMax = 100;
			npc.HitSound = SoundID.NPCHit1;
			npc.DeathSound = SoundID.NPCDeath1;
			npc.knockBackResist = .25f;

			animationType = NPCID.Squirrel;
			npc.aiStyle = 7;

            // TODO: Souls crossmod
            /*if (Fargowiltas.ModLoaded["FargowiltasSouls"])
            {
                Main.npcCatchable[npc.type] = true;
                npc.catchItem = (short)Fargowiltas.FargosGetMod("FargowiltasSouls").ItemType("TophatSquirrel");
            }*/
        }

        public override void AI()
        {
            npc.dontTakeDamage = Main.bloodMoon;
        }

        public override bool CanTownNPCSpawn(int numTownNPCs, int money)
		{
            if (FargoWorld.DownedBools["squirrel"])
            {
                return true;
            }

			for (int k = 0; k < 255; k++)
			{
				Player player = Main.player[k];
				if (!player.active)
				{
					continue;
				}

				foreach (Item item in player.inventory)
				{
                    // TODO: Souls crossmod
					/*if (item.type == fargosouls.ItemType("TophatSquirrel"))
					{
						return true;
					}*/
				}
			}
			return false;
		}

        public override bool CanGoToStatue(bool toKingStatue) => toKingStatue;

        public override string TownNPCName()
		{
			switch (WorldGen.genRand.Next(3))
			{
				case 0:
					return "Rick";
				case 1:
					return "Acorn";
				default:
					return "Squeaks";
			}
		}

		public override string GetChat()
		{
            if (Main.bloodMoon)
                return "You will suffer.";

            switch (Main.rand.Next(3))
			{
				case 0:
					return "*squeak*";
				case 1:
					return "*chitter*";
				default:
					return "*crunch crunch*";
			}
		}

		public override void SetChatButtons(ref string button, ref string button2)
		{
			button = Language.GetTextValue("LegacyInterface.28");
		}

		public override void OnChatButtonClicked(bool firstButton, ref bool shop)
		{
			if (firstButton)
			{
				shop = true;
			}

		}

        private void TryAddItem(Item item, Chest shop, ref int nextSlot)
        {
            const int maxShop = 40;

            // TODO: Souls crossmod
            /*if (item.modItem == null || !item.modItem.mod.Name.Equals("FargowiltasSouls") || nextSlot >= maxShop)
                return;*/

            return; // Souls doesn't even exist in 1.4 yet :GUN:

            bool duplicateItem = false;

            if (item.Name.EndsWith("Enchantment"))
            {
                foreach (Item item2 in shop.item)
                {
                    if (item2.type == item.type)
                    {
                        duplicateItem = true;
                        break;
                    }
                }
                if (duplicateItem == false && nextSlot < maxShop)
                {
                    shop.item[nextSlot].SetDefaults(item.type);
                    nextSlot++;
                }
            }
            else if (item.Name.Contains("Force"))
            {
                RecipeFinder finder = new RecipeFinder();
                finder.SetResult(item.type);
                Recipe exactRecipe = finder.SearchRecipes()[0];
                foreach (Item item2 in exactRecipe.requiredItem)
                {
                    foreach (Item item3 in shop.item)
                    {
                        if (item3.type == item2.type)
                        {
                            duplicateItem = true;
                            break;
                        }
                    }
                    if (duplicateItem == false && nextSlot < maxShop)
                    {
                        if (item2.Name.Contains("Enchantment"))
                        {
                            shop.item[nextSlot].SetDefaults(item2.type);
                            nextSlot++;
                        }
                    }
                }
            }
            else if (item.Name.StartsWith("Soul"))
            {
                RecipeFinder finder = new RecipeFinder();
                finder.SetResult(item.type);
                Recipe exactRecipe = finder.SearchRecipes()[0];
                foreach (Item item2 in exactRecipe.requiredItem)
                {
                    foreach (Item item3 in shop.item)
                    {
                        if (item3.type == item2.type)
                        {
                            duplicateItem = true;
                            break;
                        }
                    }
                    if (duplicateItem == false && nextSlot < maxShop)
                    {
                        if (item2.Name.Contains("Force") || item2.Name.Contains("Soul"))
                        {
                            shop.item[nextSlot].SetDefaults(item2.type);
                            nextSlot++;
                        }
                    }
                }
            }
            else if (item.Name.EndsWith("Essence"))
            {
                foreach (Item item2 in shop.item)
                {
                    if (item2.type == item.type)
                    {
                        duplicateItem = true;
                        break;
                    }
                }
                if (duplicateItem == false && nextSlot < maxShop)
                {
                    shop.item[nextSlot].SetDefaults(item.type);
                    nextSlot++;
                }
            }
            else if (item.Name.EndsWith("Soul"))
            {
                RecipeFinder finder = new RecipeFinder();
                finder.SetResult(item.type);
                Recipe exactRecipe = finder.SearchRecipes()[0];
                foreach (Item item2 in exactRecipe.requiredItem)
                {
                    foreach (Item item3 in shop.item)
                    {
                        if (item3.type == item2.type)
                        {
                            duplicateItem = true;
                            break;
                        }
                    }
                    if (duplicateItem == false && nextSlot < maxShop)
                    {
                        if (item2.Name.EndsWith("Essence"))
                        {
                            shop.item[nextSlot].SetDefaults(item2.type);
                            nextSlot++;
                        }
                    }
                }
                duplicateItem = false;
                foreach (Item item4 in shop.item)
                {
                    if (item4.type == item.type)
                    {
                        duplicateItem = true;
                        break;
                    }
                }
                if (duplicateItem == false && nextSlot < maxShop)
                {
                    shop.item[nextSlot].SetDefaults(item.type);
                    nextSlot++;
                }
            }
            // TODO: Souls crossmod
            /*else if (item.type == Fargowiltas.FargosGetMod("FargowiltasSouls").ItemType("AeolusBoots"))
            {
                foreach (Item item2 in shop.item)
                {
                    if (item2.type == ItemID.FrostsparkBoots || item2.type == ItemID.BalloonHorseshoeFart)
                    {
                        duplicateItem = true;
                        break;
                    }
                }
                if (duplicateItem == false && nextSlot < maxShop)
                {
                    shop.item[nextSlot].SetDefaults(ItemID.FrostsparkBoots);
                    nextSlot++;
                }
                if (duplicateItem == false && nextSlot < maxShop)
                {
                    shop.item[nextSlot].SetDefaults(ItemID.BalloonHorseshoeFart);
                    nextSlot++;
                }
            }*/
        }

		public override void SetupShop(Chest shop, ref int nextSlot)
		{
            if (Fargowiltas.ModLoaded["FargowiltasSouls"])
            {
                // TODO: Souls crossmod
                /*shop.item[nextSlot].SetDefaults(Fargowiltas.FargosGetMod("FargowiltasSouls").ItemType("TophatSquirrel"));
                shop.item[nextSlot].shopCustomPrice = 100000;
                nextSlot++;*/
            }

			for (int k = 0; k < 255; k++)
			{
				Player player = Main.player[k];
				if (!player.active)
				{
					continue;
				}

				foreach (Item item in player.inventory)
				{
                    TryAddItem(item, shop, ref nextSlot);
				}

				foreach (Item item in player.armor)
				{
                    TryAddItem(item, shop, ref nextSlot);
                }
			}
		}

        public override void NPCLoot()
        {
            FargoWorld.DownedBools["squirrel"] = true;
        }

        public override bool PreDraw(SpriteBatch spriteBatch, Color lightColor)
        {
            Asset<Texture2D> texture2D13 = TextureAssets.Npc[npc.type];;
            //int num156 = Main.npcTexture[npc.type].Height / Main.npcFrameCount[npc.type]; //ypos of lower right corner of sprite to draw
            //int y3 = num156 * npc.frame.Y; //ypos of upper left corner of sprite to draw
            Rectangle rectangle = npc.frame;//new Rectangle(0, y3, texture2D13.Width, num156);
            Vector2 origin2 = rectangle.Size() / 2f;

            Color color26 = lightColor;
            color26 = npc.GetAlpha(color26);

            SpriteEffects effects = npc.spriteDirection < 0 ? SpriteEffects.None : SpriteEffects.FlipHorizontally;

            if (Main.bloodMoon)
            {
                Texture2D texture2D14 = ModContent.GetTexture("Fargowiltas/NPCs/Squirrel_Glow").Value;
                float scale = (Main.mouseTextColor / 200f - 0.35f) * 0.3f + 0.9f;
                Main.spriteBatch.Draw(texture2D14, npc.Center - Main.screenPosition + new Vector2(0f, npc.gfxOffY), new Microsoft.Xna.Framework.Rectangle?(rectangle), Color.White * npc.Opacity, npc.rotation, origin2, scale, effects, 0f);
            }

            Main.spriteBatch.Draw(texture2D13.Value, npc.Center - Main.screenPosition + new Vector2(0f, npc.gfxOffY), new Microsoft.Xna.Framework.Rectangle?(rectangle), npc.GetAlpha(lightColor), npc.rotation, origin2, npc.scale, effects, 0f);

            if (Main.bloodMoon)
            {
                Texture2D texture2D14 = ModContent.GetTexture("Fargowiltas/NPCs/Squirrel_Eyes").Value;
                Main.spriteBatch.Draw(texture2D14, npc.Center - Main.screenPosition + new Vector2(0f, npc.gfxOffY), new Microsoft.Xna.Framework.Rectangle?(rectangle), Color.White * npc.Opacity, npc.rotation, origin2, npc.scale, effects, 0f);
            }
            return false;
        }
    }
}