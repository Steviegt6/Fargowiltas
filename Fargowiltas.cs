using System;
using System.Collections.Generic;
using System.IO;
using Fargowiltas.NPCs;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.Audio;
using Terraria.Chat;
using Terraria.GameContent.Events;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;
using Terraria;
using Fargowiltas.Items.Misc;
using Fargowiltas.Items.Tiles;
using Terraria.Chat;
using Fargowiltas.Items.Vanity;
using Fargowiltas.Items.Summons.SwarmSummons.AA;
using Fargowiltas.Items.Summons.SwarmSummons.Thorium;
using Fargowiltas.Items.Summons.Deviantt;

namespace Fargowiltas
{
    public class Fargowiltas : Mod
    {
        internal static MutantSummonTracker summonTracker;

        // Hotkeys
        internal static ModHotKey CustomKey;
        internal static ModHotKey HomeKey;
        internal static ModHotKey RodKey;

        // Swarms
        internal static bool SwarmActive;
        internal static int SwarmKills;
        internal static int SwarmTotal;
        internal static int SwarmSpawned;

        // Mod loaded bools
        internal static Dictionary<string, bool> ModLoaded;
        internal static Dictionary<int, string> ModRareEnemies = new Dictionary<int, string>();
        private string[] mods;

        internal static Fargowiltas Instance;

        public Fargowiltas()
        {
            Properties = new ModProperties()
            {
                Autoload = true,
                AutoloadGores = true,
                AutoloadSounds = true,
            };
        }

        public void AddToggle(string toggle, string name, int item, string color)
        {
            ModTranslation text = CreateTranslation(toggle);
            text.SetDefault("[i:" + item + "][c/" + color + ": " + name + "]");
            AddTranslation(text);
        }

        public override void Load()
        {
            Instance = this;

            summonTracker = new MutantSummonTracker();

            HomeKey = RegisterHotKey("Quick Recall/Mirror", "Home");
            RodKey = RegisterHotKey("Quick Rod of Discord", "E");
            CustomKey = RegisterHotKey("Quick Use Custom (Bottom Left Inventory Slot)", "K");

            mods = new string[]
            {
                "FargowiltasSouls", // Fargo's Souls
                "Bluemagic", // Elemental Unleash / Blushiemagic's Mod
                "CalamityMod", // Calamity
                "CookieMod", // Cookie Mod
                "CrystiliumMod", // Crystilium
                "GRealm", // GRealm
                "JoostMod", // JoostMod
                "TrueEater", // Nightmares Unleashed
                "SacredTools", // SacredTools / Shadows of Abaddon
                "SpiritMod", // Spirit
                "ThoriumMod", // Thorium
                "W1KModRedux", // W1K's Mod Redux
                "EchoesoftheAncients", // Echoes of the Ancients
                "ForgottenMemories", // Beyond the Forgotten Ages
                "Disarray", // Disarray
                "ElementsAwoken", // Elements Awoken
                "Laugicality", // Enigma
                "Split", // Split
                "Antiaris", // Antiaris
                "AAMod", // Ancients Awakened
                "TrelamiumMod", // Trelamium
                "pinkymod", // Pinkymod
                "Redemption", // Mod of Redemption
                "Jetshift", // Jetshift
                "Ocram", // Ocram 'n Stuff
                "CSkies", // Celestial Skies
            };

            ModLoaded = new Dictionary<string, bool>();
            foreach (string mod in mods)
            {
                ModLoaded.Add(mod, false);
            }

            AddToggle("Mutant", "Mutant Can Spawn", ModContent.ItemType<MutantMask>(), "ffffff");
            AddToggle("Abom", "Abominationn Can Spawn", ModContent.ItemType<AbominationnMask>(), "ffffff");
            AddToggle("Devi", "Deviantt Can Spawn", ModContent.ItemType<DevianttMask>(), "ffffff");
            AddToggle("Lumber", "Lumberjack Can Spawn", ModContent.ItemType<LumberjackMask>(), "ffffff");

            LoadCrossModContent();

            // DD2 Banner Effect hack
            ItemID.Sets.BannerStrength = ItemID.Sets.Factory.CreateCustomSet(new ItemID.BannerEffect(1f));
        }

        public override void Unload()
        {
            summonTracker = null;

            HomeKey = null;
            RodKey = null;
            CustomKey = null;
            mods = null;
            ModLoaded = null;
        }

        public override void PostSetupContent()
        {
            try
            {
                foreach (string mod in mods)
                {
                    ModLoaded[mod] = Fargowiltas.FargosGetMod(mod) != null;
                }
            }
            catch (Exception e)
            {
                Logger.Error("Fargowiltas PostSetupContent Error: " + e.StackTrace + e.Message);
            }

            Mod censusMod = Fargowiltas.FargosGetMod("Census");
            if (censusMod != null)
            {
                censusMod.Call("TownNPCCondition", ModContent.NPCType<Deviantt>(), "Defeat any rare enemy or... embrace eternity");
                censusMod.Call("TownNPCCondition", ModContent.NPCType<Mutant>(), "Defeat any boss or miniboss");
                censusMod.Call("TownNPCCondition", ModContent.NPCType<LumberJack>(), $"Have a Wooden Token ([i:{ModContent.ItemType<WoodenToken>()}]) in your inventory");
                censusMod.Call("TownNPCCondition", ModContent.NPCType<Abominationn>(), "Clear any event");

                // TODO: FargowiltasSouls Cross-Mod
                /*Mod fargoSouls = Fargowiltas.FargosGetMod("FargowiltasSouls");
                if (fargoSouls != null)
                {
                    censusMod.Call("TownNPCCondition", ModContent.NPCType<Squirrel>(), $"Have a Top Hat Squirrel ([i:{soulsMod.ItemType("TophatSquirrel")}]) in your inventory");
                }*/
            }

            // TODO: FargowiltasSouls Cross-Mod
            /*Mod soulsMod = Fargowiltas.FargosGetMod("FargowiltasSouls");
            if (soulsMod != null)
            {
                if (!ModRareEnemies.ContainsKey(soulsMod.NPCType("BabyGuardian")))
                    ModRareEnemies.Add(soulsMod.NPCType("BabyGuardian"), "babyGuardian");
            }*/
        }

        public override object Call(params object[] args)
        {
            try
            {
                string code = args[0].ToString();

                switch (code)
                {
                    case "SwarmActive":
                        return SwarmActive;

                    case "AddSummon":
                        if (summonTracker.SummonsFinalized)
                            throw new Exception($"Call Error: Summons must be added before AddRecipes");

                        summonTracker.AddSummon(
                            Convert.ToSingle(args[1]), 
                            args[2] as string,
                            args[3] as string,
                            args[4] as Func<bool>,
                            Convert.ToInt32(args[5])
                        );
                        break;

                    case "AddEventSummon":
                        if (summonTracker.SummonsFinalized)
                            throw new Exception($"Call Error: Event summons must be added before AddRecipes");

                        summonTracker.AddEventSummon(
                            Convert.ToSingle(args[1]),
                            args[2] as string,
                            args[3] as string,
                            args[4] as Func<bool>,
                            Convert.ToInt32(args[5])
                        );
                        break;

                    case "GetDownedEnemy":
                        if (FargoWorld.DownedBools.ContainsKey(args[1] as string) && FargoWorld.DownedBools[args[1] as string])
                            return true;
                        return false;
                }

            }
            catch (Exception e)
            {
                Logger.Error("Call Error: " + e.StackTrace + e.Message);
            }

            return base.Call(args);
        }

        public override void AddRecipes()
        {
            summonTracker.FinalizeSummonData();

            FargoRecipes.AddRecipes();
        }

        public override void AddRecipeGroups()
        {
            FargoRecipes.AddRecipeGroups();
        }

        public override void HandlePacket(BinaryReader reader, int whoAmI)
        {
            byte messageType = reader.ReadByte();

            switch (messageType)
            {
                // Regal statue
                case 1:
                    FargoWorld.CurrentSpawnRateTile[whoAmI] = reader.ReadBoolean();
                    break;

                // Abominationn clear events
                case 2:
                    if (Main.netMode == NetmodeID.Server)
                    {
                        bool eventOccurring = false;
                        if (ClearEvents(ref eventOccurring))
                        {
                            NetMessage.SendData(MessageID.WorldData);
                            ChatHelper.BroadcastChatMessage(NetworkText.FromLiteral("The event has been cancelled!"), new Color(175, 75, 255));
                        }
                    }

                    break;

                // Angler reset
                case 3:
                    if (Main.netMode == NetmodeID.Server)
                    {
                        Main.AnglerQuestSwap();
                    }

                    break;

                default:
                    break;
            }
        }

        internal static bool ClearEvents(ref bool eventOccurring)
        {
            bool canClearEvent = FargoWorld.AbomClearCD <= 0;
            if (Main.invasionType != 0)
            {
                eventOccurring = true;
                if (canClearEvent)
                {
                    Main.invasionType = 0;
                }
            }

            if (Main.pumpkinMoon)
            {
                eventOccurring = true;
                if (canClearEvent)
                {
                    Main.pumpkinMoon = false;
                }
            }

            if (Main.snowMoon)
            {
                eventOccurring = true;
                if (canClearEvent)
                {
                    Main.snowMoon = false;
                }
            }

            if (Main.eclipse)
            {
                eventOccurring = true;
                if (canClearEvent)
                {
                    Main.eclipse = false;
                }
            }

            if (Main.bloodMoon)
            {
                eventOccurring = true;
                if (canClearEvent)
                {
                    Main.bloodMoon = false;
                }
            }

            if (Main.raining)
            {
                eventOccurring = true;
                if (canClearEvent)
                {
                    Main.raining = false;
                }
            }

            if (Main.slimeRain)
            {
                eventOccurring = true;
                if (canClearEvent)
                {
                    Main.StopSlimeRain();
                    Main.slimeWarningDelay = 1;
                    Main.slimeWarningTime = 1;
                }
            }

            if (BirthdayParty.PartyIsUp)
            {
                eventOccurring = true;
                if (canClearEvent)
                {
                    BirthdayParty.WorldClear();
                }
            }

            if (DD2Event.Ongoing)
            {
                eventOccurring = true;
                if (canClearEvent)
                {
                    DD2Event.StopInvasion();
                }
            }

            if (Sandstorm.Happening)
            {
                eventOccurring = true;
                if (canClearEvent)
                {
                    Sandstorm.Happening = false;
                    Sandstorm.TimeLeft = 0;
                }
            }

            if (NPC.LunarApocalypseIsUp || NPC.ShieldStrengthTowerNebula > 0 || NPC.ShieldStrengthTowerSolar > 0 || NPC.ShieldStrengthTowerStardust > 0 || NPC.ShieldStrengthTowerVortex > 0)
            {
                eventOccurring = true;
                if (canClearEvent)
                {
                    NPC.LunarApocalypseIsUp = false;
                    NPC.ShieldStrengthTowerNebula = 0;
                    NPC.ShieldStrengthTowerSolar = 0;
                    NPC.ShieldStrengthTowerStardust = 0;
                    NPC.ShieldStrengthTowerVortex = 0;

                    // Purge all towers
                    for (int i = 0; i < Main.maxNPCs; i++)
                    {
                        if (Main.npc[i].active
                            && (Main.npc[i].type == NPCID.LunarTowerNebula || Main.npc[i].type == NPCID.LunarTowerSolar
                            || Main.npc[i].type == NPCID.LunarTowerStardust || Main.npc[i].type == NPCID.LunarTowerVortex))
                        {
                            Main.npc[i].dontTakeDamage = false;
                            Main.npc[i].GetGlobalNPC<FargoGlobalNPC>().NoLoot = true;
                            Main.npc[i].StrikeNPCNoInteraction(int.MaxValue, 0f, 0);
                        }
                    }
                }
            }

            foreach (MutantSummonInfo summon in summonTracker.EventSummons)
            {
                if ((bool)Fargowiltas.FargosGetMod(summon.modSource).Call("AbominationnClearEvents", canClearEvent))
                {
                    eventOccurring = true;
                }
            }

            if (eventOccurring && canClearEvent)
            {
                FargoWorld.AbomClearCD = 7200;
            }

            return eventOccurring && canClearEvent;
        }

        // SpawnBoss(player, ModContent.NPCType<MyBoss>(), true, 0, 0, "DerpyBoi 2", false);
        internal static void SpawnBoss(Player player, int bossType, bool spawnMessage = true, int overrideDirection = 0, int overrideDirectionY = 0, string overrideDisplayName = "", bool namePlural = false)
        {
            if (overrideDirection == 0)
            {
                overrideDirection = Main.rand.NextBool(2) ? -1 : 1;
            }

            if (overrideDirectionY == 0)
            {
                overrideDirectionY = -1;
            }

            Vector2 npcCenter = player.Center + new Vector2(MathHelper.Lerp(500f, 800f, (float)Main.rand.NextDouble()) * overrideDirection, 800f * overrideDirectionY);
            SpawnBoss(player, bossType, spawnMessage, npcCenter, overrideDisplayName, namePlural);
        }

        // SpawnBoss(player, ModContent.NPCType<MyBoss>(), true, player.Center + new Vector2(0, 800f), "DerpFromBelow", false);
        internal static int SpawnBoss(Player player, int bossType, bool spawnMessage = true, Vector2 npcCenter = default, string overrideDisplayName = "", bool namePlural = false)
        {
            if (npcCenter == default)
            {
                npcCenter = player.Center;
            }

            if (Main.netMode != NetmodeID.MultiplayerClient)
            {
                int npcID = NPC.NewNPC((int)npcCenter.X, (int)npcCenter.Y, bossType);
                Main.npc[npcID].Center = npcCenter;
                Main.npc[npcID].netUpdate2 = true;

                if (spawnMessage)
                {
                    string npcName = !string.IsNullOrEmpty(Main.npc[npcID].GivenName) ? Main.npc[npcID].GivenName : overrideDisplayName;
                    if ((npcName == null || string.IsNullOrEmpty(npcName)) && Main.npc[npcID].modNPC != null)
                    {
                        npcName = Main.npc[npcID].modNPC.DisplayName.GetDefault();
                    }

                    if (namePlural)
                    {
                        if (Main.netMode == NetmodeID.SinglePlayer)
                        {
                            Main.NewText(npcName + " have awoken!", 175, 75);
                        }
                        else
                        if (Main.netMode == NetmodeID.Server)
                        {
                            ChatHelper.BroadcastChatMessage(NetworkText.FromLiteral(npcName + " have awoken!"), new Color(175, 75, 255));
                        }
                    }
                    else
                    {
                        if (Main.netMode == NetmodeID.SinglePlayer)
                        {
                            Main.NewText(Language.GetTextValue("Announcement.HasAwoken", npcName), 175, 75);
                        }
                        else
                        if (Main.netMode == NetmodeID.Server)
                        {
                            ChatHelper.BroadcastChatMessage(NetworkText.FromKey("Announcement.HasAwoken", new object[] { NetworkText.FromLiteral(npcName) }), new Color(175, 75, 255));
                        }
                    }
                }
            }
            else
            {
                // I have no idea how to convert this to the standard system so im gonna post this method too lol
                FargoNet.SendNetMessage(FargoNet.SummonNPCFromClient, (byte)player.whoAmI, (short)bossType, spawnMessage, npcCenter.X, npcCenter.Y, overrideDisplayName, namePlural);
            }

            return 200;
        }

        public void LoadCrossModContent()
        {
            if (Fargowiltas.FargosGetMod("FargowiltasSouls") != null)
            {
                AddContent<Squirrel>();
                AddContent<InnocuousSkull>();
            }

            if (Fargowiltas.FargosGetMod("Thorium") != null)
            {
                AddContent<OmnistationPlus>();
                AddContent<OverloadStrider>();
                AddContent<OverloadCoznix>();
                AddContent<Buffs.OmnistationPlus>();
                AddContent<OverloadAbyssion>();
                AddContent<OverloadJelly>();
                AddContent<OverloadLich>();
                AddContent<OverloadSaucer>();
                AddContent<OverloadThunderbird>();
                AddContent<OverloadViscount>();
                //AddContent<OverloadChampion>();
                //AddContent<OverloadGranite>();
                //AddContent<OverloadRag>();
            }

            if (Fargowiltas.FargosGetMod("CalamityMod") != null)
            {
                if (Fargowiltas.FargosGetMod("Thorium") == null)
                {
                    AddContent<Buffs.OmnistationPlus>();
                    AddContent<OmnistationPlus>();
                }
            }

            if (Fargowiltas.FargosGetMod("AAMod") != null)
            {
                AddContent<Clawbomination>();
                AddContent<GlowingMasshroom>();
                AddContent<Masshroom>();
            }
        }

        public static Mod FargosGetMod(string modName)
        {
            // Does nothing
            // Too lazy to go through and comment out GetMod shit

            return null;
        }
    }
}
