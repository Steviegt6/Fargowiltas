using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.Audio;
using Terraria.Chat;
using Terraria.GameContent.Events;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria;
using Terraria.Localization;
using static Terraria.ModLoader.ModContent;
using Fargowiltas.Projectiles;

namespace Fargowiltas.NPCs
{
    [AutoloadHead]
    public class Mutant : ModNPC
    {
        private static bool prehardmodeShop;
        private static bool hardmodeShop;
        private static int shopNum = 1;

        internal bool spawned;

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Mutant");
            Main.npcFrameCount[npc.type] = 25;
            NPCID.Sets.ExtraFramesCount[npc.type] = 9;
            NPCID.Sets.AttackFrameCount[npc.type] = 4;
            NPCID.Sets.DangerDetectRange[npc.type] = 700;
            NPCID.Sets.AttackType[npc.type] = 0;
            NPCID.Sets.AttackTime[npc.type] = 90;
            NPCID.Sets.AttackAverageChance[npc.type] = 30;
        }

        public override void SetDefaults()
        {
            npc.townNPC = true;
            npc.friendly = true;
            npc.width = 18;
            npc.height = 40;
            npc.aiStyle = 7;
            npc.damage = 10;
            npc.defense = NPC.downedMoonlord ? 50 : 15;
            npc.lifeMax = NPC.downedMoonlord ? 5000 : 250;
            npc.HitSound = SoundID.NPCHit1;
            npc.DeathSound = SoundID.NPCDeath1;
            npc.knockBackResist = 0.5f;
            animationType = NPCID.Guide;
            Main.npcCatchable[npc.type] = true;
            npc.catchItem = (short)ModContent.ItemType<Items.CaughtNPCs.Mutant>();
            npc.buffImmune[BuffID.Suffocation] = true;

            if (Fargowiltas.ModLoaded["FargowiltasSouls"] && (bool)Fargowiltas.FargosGetMod("FargowiltasSouls").Call("DownedMutant"))
            {
                npc.lifeMax = 7700000;
                npc.defense = 400;
            }
        }

        public override bool CanGoToStatue(bool toKingStatue) => toKingStatue;

        public override void AI()
        {
            npc.breath = 200;
            if (!spawned)
            {
                spawned = true;
                if (Fargowiltas.ModLoaded["FargowiltasSouls"] && (bool)Fargowiltas.FargosGetMod("FargowiltasSouls").Call("DownedMutant"))
                {
                    npc.lifeMax = 77000;
                    npc.life = npc.lifeMax;
                    npc.defense = 400;
                }
            }
        }

        public override bool CanTownNPCSpawn(int numTownnpcs, int money)
        {
            if (Fargowiltas.ModLoaded["FargowiltasSouls"] && (bool)Fargowiltas.FargosGetMod("FargowiltasSouls").Call("MutantAlive"))
            {
                return false;
            }
            return GetInstance<FargoConfig>().Mutant && FargoWorld.DownedBools["boss"] && !FargoGlobalNPC.AnyBossAlive();
        }

        public override string TownNPCName()
        {
            string[] names = { "Flacken", "Dorf", "Bingo", "Hans", "Fargo", "Grim", "Furgo", "Fargu", "Terrance", "Catty N. Pem", "Tom", "Weirdus", "Polly" };
            return Main.rand.Next(names);
        }

        public override string GetChat()
        {
            List<string> dialogue = new List<string>
            {
                "Savagery, barbarism, bloodthirst, that's what I like seeing in people.",
                "The stronger you get, the more stuff I sell. Makes sense, right?",
                "There's something all of you have that I don't... Death perception, I think it's called?",
                "It would be pretty cool if I sold a summon for myself...",
                "The only way to get stronger is to keep buying from me and in bulk too!",
                "Why are you looking at me like that, all I did was eat an apple.",
                "Don't bother with anyone else, all you'll ever need is right here.",
                "You're lucky I'm on your side.",
                "Thanks for the house, I guess.",
                "Why yes I would love a ham and swiss sandwich.",
                "Should I start wearing clothes? ...Nah.",
                "It's not like I can actually use all the gold you're spending.",
                "Violence for violence is the law of the beast.",
                "Those guys really need to get more creative. All of their first bosses are desert themed!",
                "You say you want to know how a Mutant and Abominationn are brothers? You're better off not knowing.",
                "I'm all you need for a calamity.",
                "Everything shall bow before me! ...after you make this purchase.",
                "It's clear that I'm helping you out, but uh.. what's in this for me? A house you say? I eat zombies for breakfast.",
                "Can I jump? No, I don't have something called a 'spacebar'.",
                "Got your nose, I needed one to replace mine.",
                "What's a Terry?",
                "Why do so many creatures carry around a weird looking blue doll? The world may never know.",
                "Impending doom approaches. ...If you don't buy anything of course.",
                "I've heard of a '3rd dimension', I wonder what that looks like.",
                "Boy don't I look fabulous today.",
                "You have fewer friends than I do eyes.",
                "The ocean is a dangerous place, I wonder where Diver is?",
                "Do you know what an Ee-arth is?",
                "I can't even spell 'apotheosis', do you expect me to know what it is?",
                "Where do monsters get their gold from? ...I don't have pockets you know.",
                "Dogs are cool and all, but cats don't try to bite my brain.",
                "Beware the green dragon... What's that face mean?",
                "Where is this O-hi-o I keep hearing about.",
                "I've told you 56 times already, I'm busy... Oh wait you want to buy something, I suppose I have time.",
                "I've heard of a 'Soul of Souls' that only exists in 2015.",
                "Adding EX after everything makes it way more difficult.",
                "I think that all modern art looks great, especially the bloody stuff.",
                "How many guides does it take to change a lightbulb? ... I don't know, how about you ask him.",
                "Good thing I don't have a bed, I'd probably never leave it.",
                "What's this about an update? Sounds rare.",
                "If you need me I'll be slacking off somewhere.",
                "What do you mean who is Fargo!",
                "Have you seen the ech cat?",
                "I don't understand music nowadays, I prefer some smooth jazz... or the dying screams of monsters.",
                "Cthulhu's got nothing on me!",
            };

            if (Fargowiltas.ModLoaded["FargowiltasSouls"])
            {
                dialogue.AddWithCondition("Now that you've defeated the big guy, I'd say it's time to start collecting those materials!", NPC.downedMoonlord);

                if ((bool)Fargowiltas.FargosGetMod("FargowiltasSouls").Call("DownedMutant"))
                {
                    dialogue.Add("What's that? You want to fight me? ...sure, I guess.");
                }
                else if ((bool)Fargowiltas.FargosGetMod("FargowiltasSouls").Call("DownedFishronEX") || (bool)Fargowiltas.FargosGetMod("FargowiltasSouls").Call("DownedAbom"))
                {
                    dialogue.Add("What's that? You want to fight me? ...maybe if I had a reason.");
                }
            }
            else
            {
                dialogue.Add("What's that? You want to fight me? ...you're not worthy you rat.");
            }

            dialogue.AddWithCondition("Why would you do this.", Fargowiltas.ModLoaded["CalamityMod"]);
            dialogue.AddWithCondition("I feel a great imbalance in this world.", Fargowiltas.ModLoaded["CalamityMod"] && Fargowiltas.ModLoaded["ThoriumMod"]);
            dialogue.AddWithCondition("A great choice, shame about that first desert boss thing though.", Fargowiltas.ModLoaded["ThoriumMod"]);
            dialogue.AddWithCondition("A bit spooky tonight, isn't it.", Main.pumpkinMoon);
            dialogue.AddWithCondition("I'd ask for a coat, but I don't think you have any my size.", Main.snowMoon);
            dialogue.AddWithCondition("Weather seems odd today, wouldn't you agree?", Main.slimeRain);
            dialogue.AddWithCondition("Lovely night, isn't it?", Main.bloodMoon);
            dialogue.AddWithCondition("I hope the constant arguing I'm hearing isn't my fault.", Main.bloodMoon);
            dialogue.AddWithCondition("I'd follow and help, but I'd much rather sit around right now.", !Main.dayTime);

            int partyGirl = NPC.FindFirstNPC(NPCID.PartyGirl);
            if (BirthdayParty.PartyIsUp)
            {
                if (partyGirl >= 0)
                {
                    dialogue.Add($"{Main.npc[partyGirl].GivenName} is the one who invited me, I don't understand why though.");
                }
                
                dialogue.Add("I don't know what everyone's so happy about, but as long as nobody mistakes me for a Pigronata, I'm happy too.");
            }

            int lumberJack = NPC.FindFirstNPC(ModContent.NPCType<LumberJack>());
            if (lumberJack >= 0)
            {
                dialogue.Add($"It's okay {Main.npc[npc.whoAmI].GivenName}, just don't look straight into {Main.npc[lumberJack].GivenName}'s eyes. He can't scare you that way...");
            }

            int nurse = NPC.FindFirstNPC(NPCID.Nurse);
            if (nurse >= 0)
            {
                dialogue.Add($"Whenever we're alone, {Main.npc[nurse].GivenName} keeps throwing syringes at me, no matter how many times I tell her to stop!");
            }

            int witchDoctor = NPC.FindFirstNPC(NPCID.WitchDoctor);
            if (witchDoctor >= 0)
            {
                dialogue.Add($"Please go tell {Main.npc[witchDoctor].GivenName} to drop the 'mystical' shtick, I mean, come on! I get it, you make tainted water or something.");
            }

            int dryad = NPC.FindFirstNPC(NPCID.Dryad);
            if (dryad >= 0)
            {
                dialogue.Add($"Why does {Main.npc[dryad].GivenName}'s outfit make my wings flutter?");
            }

            int stylist = NPC.FindFirstNPC(NPCID.Stylist);
            if (stylist >= 0)
            {
                dialogue.Add($"{Main.npc[stylist].GivenName} once gave me a wig... I look hideous with long hair.");
            }

            int truffle = NPC.FindFirstNPC(NPCID.Truffle);
            if (truffle >= 0)
            {
                dialogue.Add("That mutated mushroom seems like my type of fella.");
            }

            int tax = NPC.FindFirstNPC(NPCID.TaxCollector);
            if (tax >= 0)
            {
                dialogue.Add($"{Main.npc[tax].GivenName} keeps asking me for money, but he won't accept my spawners!");
            }

            int guide = NPC.FindFirstNPC(NPCID.Guide);
            if (guide >= 0)
            {
                dialogue.Add($"Any idea why {Main.npc[guide].GivenName} is always cowering in fear when I get near him?");
            }

            int cyborg = NPC.FindFirstNPC(NPCID.Cyborg);
            if (truffle >= 0 && witchDoctor >= 0 && cyborg >= 0 && Main.rand.NextBool(52))
            {
                dialogue.Add($"If any of us could play instruments, I'd totally start a band with {Main.npc[witchDoctor].GivenName}, {Main.npc[truffle].GivenName}, and {Main.npc[cyborg].GivenName}.");
            }

            if (partyGirl >= 0)
            {
                dialogue.Add($"Man, {Main.npc[partyGirl].GivenName}'s confetti keeps getting stuck to my wings");
            }

            int demoman = NPC.FindFirstNPC(NPCID.Demolitionist);
            if (demoman >= 0)
            {
                dialogue.Add($"I'm surprised {Main.npc[demoman].GivenName} hasn't blown a hole in the floor yet, on second thought that sounds fun.");
            }

            int tavernkeep = NPC.FindFirstNPC(NPCID.DD2Bartender);
            if (tavernkeep >= 0)
            {
                dialogue.Add($"{Main.npc[tavernkeep].GivenName} keeps suggesting I drink some beer, something tells me he wouldn't like me when I'm drunk though.");
            }

            int dyeTrader = NPC.FindFirstNPC(NPCID.DyeTrader);
            if (dyeTrader >= 0)
            {
                dialogue.Add($"{Main.npc[dyeTrader].GivenName} wants to see what I would look like in blue... I don't know how to feel.");
            }

            return Main.rand.Next(dialogue);
        }

        public override void SetChatButtons(ref string button, ref string button2)
        {
            switch (shopNum)
            {
                case 1:
                    button = "Pre Hardmode";
                    break;

                case 2:
                    button = "Hardmode";
                    break;

                default:
                    button = "Post Moon Lord";
                    break;
            }

            if (Main.hardMode)
            {
                button2 = "Cycle Shop";
            }

            if (NPC.downedMoonlord)
            {
                if (shopNum >= 4)
                {
                    shopNum = 1;
                }
            }
            else
            {
                if (shopNum >= 3)
                {
                    shopNum = 1;
                }
            }
        }

        public override void OnChatButtonClicked(bool firstButton, ref bool shop)
        {
            if (firstButton)
            {
                shop = true;

                switch (shopNum)
                {
                    case 1:
                        prehardmodeShop = true;
                        hardmodeShop = false;
                        break;
                    case 2:
                        hardmodeShop = true;
                        prehardmodeShop = false;
                        break;
                    default:
                        prehardmodeShop = false;
                        hardmodeShop = false;
                        break;
                }
            }
            else if (!firstButton && Main.hardMode)
            {
                shopNum++;
            }
        }

        public static void AddItem(bool check, string mod, string item, int price, ref Chest shop, ref int nextSlot)
        {
            if (!check || shop is null)
            {
                return;
            }

            // TODO: tML hates its users
            //shop.item[nextSlot].SetDefaults(Fargowiltas.FargosGetMod(mod).ItemType(item));
            //shop.item[nextSlot].value = price;

            // Lowered prices with discount card and pact
            if (Fargowiltas.ModLoaded["FargowiltasSouls"])
            {
                float modifier = 1f;
                if ((bool)Fargowiltas.FargosGetMod("FargowiltasSouls").Call("MutantDiscountCard"))
                {
                    modifier -= 0.2f;
                }

                if ((bool)Fargowiltas.FargosGetMod("FargowiltasSouls").Call("MutantPact"))
                {
                    modifier -= 0.3f;
                }

                shop.item[nextSlot].value = (int)(shop.item[nextSlot].value * modifier);
            }

            nextSlot++;
        }

        public override void SetupShop(Chest shop, ref int nextSlot)
        {
            AddItem(Main.expertMode, "Fargowiltas", "Overloader", 400000, ref shop, ref nextSlot);

            if (prehardmodeShop)
            {
                AddItem(true, "Fargowiltas", "ExpertToggle", 100000, ref shop, ref nextSlot);

                if (Fargowiltas.ModLoaded["FargowiltasSouls"])
                {
                    AddItem(true, "FargowiltasSouls", "Masochist", 10000, ref shop, ref nextSlot); // mutants gift, dam meme namer
                }

                foreach (MutantSummonInfo summon in Fargowiltas.summonTracker.SortedSummons)
                {
                    //phm
                    if (summon.progression <= 6f)
                    {
                        AddItem(summon.downed(), summon.modSource, summon.itemName, summon.price, ref shop, ref nextSlot);
                    }
                }
            }
            else if (hardmodeShop)
            {
                foreach (MutantSummonInfo summon in Fargowiltas.summonTracker.SortedSummons)
                {
                    //hm
                    if (summon.progression > 6f && summon.progression <= 14)
                    {
                        AddItem(summon.downed(), summon.modSource, summon.itemName, summon.price, ref shop, ref nextSlot);
                    }
                }
            }
            else
            {
                foreach (MutantSummonInfo summon in Fargowiltas.summonTracker.SortedSummons)
                {
                    //post ml
                    if (summon.progression > 14f)
                    {
                        AddItem(summon.downed(), summon.modSource, summon.itemName, summon.price, ref shop, ref nextSlot);
                    }
                }

                AddItem(true, "Fargowiltas", "AncientSeal", 100000000, ref shop, ref nextSlot);
            }
        }

        public override void TownNPCAttackStrength(ref int damage, ref float knockback)
        {
            if (Fargowiltas.ModLoaded["FargowiltasSouls"] && (bool)Fargowiltas.FargosGetMod("FargowiltasSouls").Call("DownedMutant"))
            {
                damage = 720;
                knockback = 10f;
            }
            else if (NPC.downedMoonlord)
            {
                damage = 250;
                knockback = 10f;
            }
            else if (Main.hardMode)
            {
                damage = 60;
                knockback = 5f;
            }
            else
            {
                damage = 20;
                knockback = 4f;
            }
        }

        public override void TownNPCAttackCooldown(ref int cooldown, ref int randExtraCooldown)
        {
            if (NPC.downedMoonlord)
            {
                cooldown = 1;
            }
            else if (Main.hardMode)
            {
                cooldown = 20;
                randExtraCooldown = 25;
            }
            else
            {
                cooldown = 30;
                randExtraCooldown = 30;
            }
        }

        public override void TownNPCAttackProj(ref int projType, ref int attackDelay)
        {
            /*if (Fargowiltas.ModLoaded["FargowiltasSouls"] && (bool)Fargowiltas.FargosGetMod("FargowiltasSouls").Call("DownedMutant"))
            {
                projType = Fargowiltas.FargosGetMod("FargowiltasSouls").ProjectileType("MutantSpearThrownFriendly");
            }*/
            if (NPC.downedMoonlord)
            {
                projType = ModContent.ProjectileType<PhantasmalEyeProjectile>();
            }
            else if (Main.hardMode)
            {
                projType = ModContent.ProjectileType<MechEyeProjectile>();
            }
            else
            {
                projType = ModContent.ProjectileType<EyeProjectile>();
            }

            attackDelay = 1;
        }

        public override void TownNPCAttackProjSpeed(ref float multiplier, ref float gravityCorrection, ref float randomOffset)
        {
            if (Fargowiltas.ModLoaded["FargowiltasSouls"] && (bool)Fargowiltas.FargosGetMod("FargowiltasSouls").Call("DownedMutant"))
            {
                multiplier = 25f;
                randomOffset = 0f;
            }
            else
            {
                multiplier = 12f;
                randomOffset = 2f;
            }
        }

        public override void HitEffect(int hitDirection, double damage)
        {
            if (npc.life <= 0)
            {
                for (int k = 0; k < 8; k++)
                {
                    Dust.NewDust(npc.position, npc.width, npc.height, 5, 2.5f * hitDirection, -2.5f, Scale: 0.8f);
                }

                Vector2 pos = npc.position + new Vector2(Main.rand.Next(npc.width - 8), Main.rand.Next(npc.height / 2));
                Gore.NewGore(pos, npc.velocity, Mod.GetGoreSlot("Gores/MutantGore3"));

                pos = npc.position + new Vector2(Main.rand.Next(npc.width - 8), Main.rand.Next(npc.height / 2));
                Gore.NewGore(pos, npc.velocity, Mod.GetGoreSlot("Gores/MutantGore2"));

                pos = npc.position + new Vector2(Main.rand.Next(npc.width - 8), Main.rand.Next(npc.height / 2));
                Gore.NewGore(pos, npc.velocity, Mod.GetGoreSlot("Gores/MutantGore1"));
            }
            else
            {
                for (int k = 0; k < damage / npc.lifeMax * 50.0; k++)
                {
                    Dust.NewDust(npc.position, npc.width, npc.height, 5, hitDirection, -1f, Scale: 0.6f);
                }
            }
        }
    }
}
