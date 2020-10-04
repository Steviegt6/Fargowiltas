using Microsoft.Xna.Framework;
using Terraria;
using Terraria.Audio;
using Terraria.Chat;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace Fargowiltas.Items.Summons.SwarmSummons
{
    public class OverloadGoblins : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Goblin War Banner");
            Tooltip.SetDefault("Summons an Overloaded Goblin Invasion\nUse again to stop the event");
        }

        public override void SetDefaults()
        {
            item.width = 20;
            item.height = 20;
            item.maxStack = 1;
            item.value = 1000;
            item.rare = ItemRarityID.Blue;
            item.useAnimation = 30;
            item.useTime = 30;
            item.useStyle = ItemUseStyleID.HoldUp;
            item.consumable = false;
        }

        public override bool UseItem(Player player)
        {
            if (FargoWorld.OverloadGoblins)
            {
                // cancel it
                Main.invasionSize = 1;
                FargoWorld.OverloadGoblins = false;

                if (Main.netMode == NetmodeID.Server)
                {
                    ChatHelper.BroadcastChatMessage(NetworkText.FromLiteral("The goblins have calmed down!"), new Color(175, 75, 255));
                }
                else
                {
                    Main.NewText("The goblins have calmed down!", 175, 75, 255);
                }
            }
            else
            {
                if (Main.netMode != NetmodeID.MultiplayerClient)
                {
                    Main.invasionDelay = 0;

                    Main.StartInvasion(1);

                    Main.invasionSize = 15000;
                    Main.invasionSizeStart = 15000;
                }
                else
                {
                    NetMessage.SendData(MessageID.SpawnBoss, -1, -1, null, player.whoAmI, -1f);
                }

                FargoWorld.OverloadGoblins = true;

                SoundEngine.PlaySound(15, (int)player.position.X, (int)player.position.Y, 0);
            }

            return true;
        }

        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe();
            recipe.AddIngredient(ItemID.GoblinBattleStandard);
            recipe.AddIngredient(null, "Overloader", 10);
            recipe.AddTile(TileID.CrystalBall);            recipe.Register();
        }
    }
}