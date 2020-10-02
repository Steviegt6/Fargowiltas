using Microsoft.Xna.Framework;
using Terraria;
using Terraria.Audio;
using Terraria.Chat;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;
using Terraria;
using Fargowiltas.Projectiles;

namespace Fargowiltas.Items.Summons.Mutant
{
    public class DeathBringerFairy : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Death Bringer Fairy");
            Tooltip.SetDefault("Summons all pre-hardmode bosses" +
                               "\nCertain bosses will only spawn if you're in their specific biome");
        }

        public override void SetDefaults()
        {
            item.width = 20;
            item.height = 20;
            item.maxStack = 20;
            item.value = Item.sellPrice(0, 0, 2);
            item.rare = ItemRarityID.Green;
            item.useAnimation = 30;
            item.useTime = 30;
            item.useStyle = ItemUseStyleID.HoldUp;
            item.consumable = true;
            item.shoot = ModContent.ProjectileType<SpawnProj>();
        }

        public override bool CanUseItem(Player player)
        {
            return !Main.dayTime;
        }

        public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
        {
            Vector2 pos = new Vector2((int)player.position.X + Main.rand.Next(-800, 800), (int)player.position.Y + Main.rand.Next(-1000, -250));
            Projectile.NewProjectile(pos, Vector2.Zero, ModContent.ProjectileType<SpawnProj>(), 0, 0, Main.myPlayer, 1, 2);

            if (Main.netMode == NetmodeID.Server)
            {
                ChatHelper.BroadcastChatMessage(NetworkText.FromLiteral("Several bosses have awoken!"), new Color(175, 75, 255));
            }
            else
            {
                Main.NewText("Several bosses have awoken!", new Color(175, 75, 255));
            }

            SoundEngine.PlaySound(SoundID.Roar, player.position, 0);

            return false;
        }
    }
}