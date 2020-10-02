using Microsoft.Xna.Framework;
using Terraria;
using Terraria.Audio;
using Terraria.Chat;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria;

namespace Fargowiltas.Items.Summons.Abom
{
    public class SlimyBarometer : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Slimy Barometer");
            Tooltip.SetDefault("Starts the Slime Rain");
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

        public override bool CanUseItem(Player player)
        {
            return !Main.slimeRain;
        }

        public override bool UseItem(Player player)
        {
            Main.StartSlimeRain();
            Main.slimeWarningDelay = 1;
            Main.slimeWarningTime = 1;
            SoundEngine.PlaySound(SoundID.Roar, player.position, 0);

            return true;
        }
    }
}