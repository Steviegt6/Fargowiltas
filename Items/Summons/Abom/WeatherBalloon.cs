using Microsoft.Xna.Framework;
using Terraria;
using Terraria.Audio;
using Terraria.ID;
using Terraria.ModLoader;

namespace Fargowiltas.Items.Summons.Abom
{
    public class WeatherBalloon : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Weather Balloon");
            Tooltip.SetDefault("Starts the Rain");
        }

        public override void SetDefaults()
        {
            item.width = 20;
            item.height = 20;
            item.maxStack = 20;
            item.value = Item.sellPrice(0, 0, 2);
            item.rare = ItemRarityID.Blue;
            item.useAnimation = 30;
            item.useTime = 30;
            item.useStyle = ItemUseStyleID.HoldUp;
            item.consumable = true;
        }

        public override bool CanUseItem(Player player) => !Main.raining;

        public override bool UseItem(Player player)
        {
            Main.StartRain();
            Main.cloudAlpha = 1f;
            Main.maxRaining = 1f;

            NetMessage.SendData(MessageID.WorldData);
            Main.NewText("Rain clouds cover the sky.", new Color(175, 75, 255));
            SoundEngine.PlaySound(SoundID.Roar, player.position, 0);

            return true;
        }
    }
}