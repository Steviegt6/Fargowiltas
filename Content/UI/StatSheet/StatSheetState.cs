using System;
using System.Linq;
using Fargowiltas.Content.UI.Shared.Panels;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.GameContent.UI.Elements;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.UI;

namespace Fargowiltas.Content.UI.StatSheet
{
    public class StatSheetState : UIState
    {
        public const int BackWidth = 660;
        public const int BackHeight = 251 + 28; // 28 = search bar height (26) + padding (2)
        public const int HowManyPerColumn = 10;
        public const int HowManyColumns = 3;

        public int LineCounter;
        public int ColumnCounter;

        public Shared.Elements.UISearchBar SearchBar;
        public UIDragPanel BackPanel;
        public UIPanel InnerPanel;

        public override void OnInitialize()
        {
            Vector2 offset = new(Main.screenWidth / 2f - BackWidth * 0.75f, Main.screenHeight / 2f - BackHeight * 0.75f);

            BackPanel = new UIDragPanel();
            BackPanel.Left.Set(offset.X, 0f);
            BackPanel.Top.Set(offset.Y, 0f);
            BackPanel.Width.Set(BackWidth, 0f);
            BackPanel.Height.Set(BackHeight, 0f);
            BackPanel.PaddingLeft = BackPanel.PaddingRight = BackPanel.PaddingTop = BackPanel.PaddingBottom = 0f;
            // BackPanel.BackgroundColor = new Color(29f, 33f, 70f) * 0.7f;
            Append(BackPanel);

            SearchBar = new Shared.Elements.UISearchBar(BackWidth - 8, 26);
            SearchBar.Left.Set(4f, 0f);
            SearchBar.Top.Set(6f, 0f); // 6 so padding lines up
            BackPanel.Append(SearchBar);

            InnerPanel = new UIPanel();
            InnerPanel.Left.Set(6f, 0f);
            InnerPanel.Top.Set(6f + 28f, 0f); // 28 for search bar
            InnerPanel.Width.Set(BackWidth - 12f, 0f);
            InnerPanel.Height.Set(BackHeight - 12f - 28f, 0f);
            InnerPanel.PaddingLeft = InnerPanel.PaddingRight = InnerPanel.PaddingTop = InnerPanel.PaddingBottom = 0f;
            // InnerPanel.BackgroundColor = new Color(73f, 94f, 171f) * 0.9f;
            BackPanel.Append(InnerPanel);

            base.OnInitialize();
        }

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);

            if (Main.GameUpdateCount % (!SearchBar.IsEmpty ? 2 : 4) == 0) // 15 times a second, or 30 times a second if search bar has text
                RebuildStatList();
        }

        public void RebuildStatList()
        {
            Player player = Main.LocalPlayer;

            InnerPanel.RemoveAllChildren();
            ColumnCounter = LineCounter = 0;

            AddStat($"Melee Damage: {(int)(player.GetDamage(DamageClass.Melee) * 100)}%", ItemID.CopperBroadsword);
            AddStat($"Melee Crit: {player.GetCritChance(DamageClass.Melee)}%", ItemID.CopperBroadsword);
            AddStat($"Melee Speed: {(int)(player.meleeSpeed * 100)}%", ItemID.CopperBroadsword);
            AddStat($"Ranged Damage: {(int)(player.GetDamage(DamageClass.Ranged) * 100)}%", ItemID.CopperBow);
            AddStat($"Ranged Crit: {player.GetCritChance(DamageClass.Ranged)}%", ItemID.CopperBow);
            AddStat($"Magic Damage: {(int)(player.GetDamage(DamageClass.Magic) * 100)}%", ItemID.WandofSparking);
            AddStat($"Magic Crit: {player.GetCritChance(DamageClass.Magic)}%", ItemID.WandofSparking);
            AddStat($"Summon Damage: {(int)(player.GetDamage(DamageClass.Summon) * 100)}%", ItemID.SlimeStaff);
            AddStat($"Max Minions: {player.maxMinions}", ItemID.SlimeStaff);
            AddStat($"Max Sentries: {player.maxTurrets}", ItemID.SlimeStaff);


            AddStat($"HP: {player.statLifeMax2}", ItemID.LifeCrystal);
            AddStat($"Defense: {player.statDefense}", ItemID.CobaltShield);
            AddStat($"Damage Reduction: {(int)(player.endurance * 100)}%", ItemID.WormScarf);
            AddStat($"Life Regen: {player.lifeRegen} HP/second", ItemID.BandofRegeneration);
            AddStat($"Mana: {player.statManaMax2}", ItemID.ManaCrystal);
            AddStat($"Mana Regen: {player.manaRegen / 2}/second", ItemID.ManaCrystal);

            AddStat($"Armor Penetration: {player.armorPenetration}", ItemID.SharkToothNecklace);
            AddStat($"Aggro: {player.aggro}", ItemID.FleshKnuckles);
            AddStat($"Max Speed: {(int)((player.accRunSpeed + player.maxRunSpeed) / 2f * player.moveSpeed * 6)} mph", ItemID.HermesBoots);
            AddStat($"Wing Time: {player.wingTimeMax / 60} seconds", ItemID.AngelWings);

            AddStat($"Luck: {player.NormalizedLuck}", ItemID.LuckPotion);
            AddStat($"Minimum Luck: {player.luckMinimumCap}", ItemID.LuckPotionLesser);
            AddStat($"Maximum Luck: {player.luckMaximumCap}", ItemID.LuckPotionGreater);
        }

        public void AddStat(string text, int item = -1)
        {
            int left = 8 + ColumnCounter * ((BackWidth - 8) / HowManyColumns);
            int top = 8 + LineCounter * 23; // I don't know why but 23 works perfectly

            if (++LineCounter == HowManyPerColumn)
            {
                ColumnCounter++;
                LineCounter = 0;
            }

            UIText ui = new(item > -1 ? $"[i:{item}] {text}" : text);
            ui.Left.Set(left, 0f);
            ui.Top.Set(top, 0f);

            string[] words = text.Split(' ');

            if (!SearchBar.IsEmpty)
            {
                if (words.Any(s => s.StartsWith(SearchBar.Input, StringComparison.OrdinalIgnoreCase)))
                {
                    float fade = MathHelper.Lerp(0.1f, 0.9f, (float)(Math.Sin(Main.GameUpdateCount / 10f) + 1f) / 2f);
                    Color color = Color.Lerp(Color.Yellow, Color.Goldenrod, fade);
                    ui.TextColor = color;
                }
                else
                    // Gray out text when filtered by search
                    ui.TextColor = Color.Gray * 1.5f;
            }

            InnerPanel.Append(ui);
        }
    }
}