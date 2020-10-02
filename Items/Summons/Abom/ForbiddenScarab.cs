using Microsoft.Xna.Framework;
using System.Reflection;
using Terraria;
using Terraria.Audio;
using Terraria.Chat;
using Terraria.GameContent.Events;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria;

namespace Fargowiltas.Items.Summons.Abom
{
    public class ForbiddenScarab : ModItem
    {
        private static MethodInfo startSandstormMethod;

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Forbidden Scarab");
            Tooltip.SetDefault("Starts a Sandstorm");
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
            return player.ZoneDesert && !Sandstorm.Happening;
        }

        public override bool UseItem(Player player)
        {
            startSandstormMethod = typeof(Sandstorm).GetMethod("StartSandstorm", BindingFlags.NonPublic | BindingFlags.Static);
            startSandstormMethod.Invoke(null, null);

            NetMessage.SendData(MessageID.WorldData);
            Main.NewText("A sandstorm has begun.", new Color(175, 75, 255));
            SoundEngine.PlaySound(SoundID.Roar, player.position, 0);

            return true;
        }
    }
}