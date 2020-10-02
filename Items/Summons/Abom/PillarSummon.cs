using Fargowiltas.Projectiles;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.Audio;
using Terraria.Chat;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace Fargowiltas.Items.Summons.Abom
{
    public class PillarSummon : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Outsider's Portal");
            Tooltip.SetDefault("Summons the Celestial Pillars");
        }

        public override void SetDefaults()
        {
            item.width = 20;
            item.height = 20;
            item.maxStack = 20;
            item.value = Item.sellPrice(0, 0, 2);
            item.rare = ItemRarityID.Cyan;
            item.useAnimation = 30;
            item.useTime = 30;
            item.useStyle = ItemUseStyleID.HoldUp;
            item.consumable = true;
            item.shoot = ModContent.ProjectileType<SpawnProj>();
        }

        public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
        {
            int[] pillars = new int[] { NPCID.LunarTowerNebula, NPCID.LunarTowerSolar, NPCID.LunarTowerStardust, NPCID.LunarTowerVortex };

            for (int i = 0; i < pillars.Length; i++)
            {
                Vector2 pos = new Vector2((int)player.position.X + (400 * i) - 600, (int)player.position.Y - 200);
                Projectile.NewProjectile(pos, Vector2.Zero, type, 0, 0, Main.myPlayer, pillars[i]);
            }

            if (Main.netMode == NetmodeID.Server)
            {
                ChatHelper.BroadcastChatMessage(NetworkText.FromLiteral("The Celestial Pillars have awoken!"), new Color(175, 75, 255));
            }
            else
            {
                Main.NewText("The Celestial Pillars have awoken!", new Color(175, 75, 255));
            }

            SoundEngine.PlaySound(SoundID.Roar, player.position, 0);

            return false;
        }
    }
}