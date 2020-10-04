using Microsoft.Xna.Framework;
using Terraria;
using Terraria.Audio;
using Terraria.Chat;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace Fargowiltas.Items.Summons.SwarmSummons
{
    public class OverloadFrostMoon : ModItem
    {
        public override string Texture => "Terraria/Item_1958";

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Overloaded Naughty Present");
            Tooltip.SetDefault("Summons an Overloaded Frost Moon\nUse again to stop the event");
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

        public override bool CanUseItem(Player player)
        {
            return !Main.dayTime;
        }

        public override bool UseItem(Player player)
        {
            if (FargoWorld.OverloadFrostMoon)
            {
                // cancel it
                Main.snowMoon = false;
                FargoWorld.OverloadFrostMoon = false;

                if (Main.netMode == NetmodeID.Server)
                {
                    ChatHelper.BroadcastChatMessage(NetworkText.FromLiteral("The Frost Moon fades away!"), new Color(175, 75, 255));
                }
                else
                {
                    Main.NewText("The Frost Moon fades away!", 175, 75, 255);
                }
            }
            else
            {
                if (Main.netMode == NetmodeID.Server)
                {
                    ChatHelper.BroadcastChatMessage(NetworkText.FromLiteral("The Frost Moon is rising..."), new Color(50, 255, 130));
                }
                else
                {
                    Main.NewText("The Frost Moon is rising...", 50, 255, 130);
                }

                Main.snowMoon = true;
                Main.pumpkinMoon = false;
                Main.bloodMoon = false;
                if (Main.netMode != NetmodeID.MultiplayerClient)
                {
                    NPC.waveKills = 0f;
                    NPC.waveNumber = 20;

                    if (Main.netMode == NetmodeID.Server)
                    {
                        ChatHelper.BroadcastChatMessage(NetworkText.FromLiteral("Wave: 20: Everything"), new Color(175, 75, 255));
                    }
                    else
                    {
                        Main.NewText("Wave: 20: Everything", 175, 75, 255);
                    }
                }
                else
                {
                    NetMessage.SendData(MessageID.SpawnBoss, -1, -1, null, player.whoAmI, -5f);
                }

                FargoWorld.OverloadFrostMoon = true;
                SoundEngine.PlaySound(15, (int)player.position.X, (int)player.position.Y, 0);
            }

            return true;
        }

        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe();
            recipe.AddIngredient(ItemID.NaughtyPresent);
            recipe.AddIngredient(null, "Overloader", 10);
            recipe.AddTile(TileID.CrystalBall);
            recipe.Register();
        }
    }
}