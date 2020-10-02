using Microsoft.Xna.Framework;
using Terraria;
using Terraria.Audio;
using Terraria.Chat;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria;

namespace Fargowiltas.Projectiles
{
    public class EyeProjectile : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("EyeProjectile");
        }

        public override void SetDefaults()
        {
            projectile.width = 8;
            projectile.height = 13;
            projectile.aiStyle = 1;
            projectile.friendly = true;
            projectile.ranged = true;
            projectile.penetrate = 2;
            projectile.timeLeft = 600;
            aiType = ProjectileID.Bullet;
        }

        public override void Kill(int timeLeft)
        {
            for (int i = 0; i < 20; i++)
            {
                int num469 = Dust.NewDust(projectile.Center, projectile.width, projectile.height, 60, -projectile.velocity.X * 0.2f, -projectile.velocity.Y * 0.2f, 100, Scale: 2f);
                Main.dust[num469].noGravity = true;
                Main.dust[num469].velocity *= 2f;

                num469 = Dust.NewDust(projectile.Center, projectile.width, projectile.height, 60, -projectile.velocity.X * 0.2f, -projectile.velocity.Y * 0.2f, 100, Scale: 1f);
                Main.dust[num469].velocity *= 2f;
            }
        }
    }
}