using Terraria;
using Terraria.Audio;
using Terraria.ID;
using Terraria.ModLoader;

namespace Fargowiltas.Projectiles
{
    public class Explosion : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Explosion");
            ProjectileID.Sets.TrailCacheLength[projectile.type] = 5;
            ProjectileID.Sets.TrailingMode[projectile.type] = 0;
        }

        public override void SetDefaults()
        {
            projectile.width = 10;
            projectile.height = 10;
            projectile.aiStyle = 0;
            projectile.friendly = true;
            projectile.ranged = true;
            projectile.penetrate = -1;
            projectile.timeLeft = 10;
            projectile.tileCollide = false;
            projectile.light = 0.75f;
            projectile.ignoreWater = true;
            projectile.extraUpdates = 1;
            aiType = ProjectileID.Bullet;
        }

        public override void Kill(int timeLeft)
        {
            SoundEngine.PlaySound(SoundID.Item, projectile.position, 14);
            projectile.position = projectile.Center;
            projectile.width = 100;
            projectile.height = 100;
            projectile.Center = projectile.position;

            for (int i = 0; i < 30; i++)
            {
                int num616 = Dust.NewDust(projectile.position, projectile.width, projectile.height, DustID.Smoke, Alpha: 100, Scale: 1.5f);
                Main.dust[num616].velocity *= 1.4f;
            }

            for (int i = 0; i < 20; i++)
            {
                int num618 = Dust.NewDust(projectile.position, projectile.width, projectile.height, DustID.Torch, Alpha: 100, Scale: 3.5f);
                Main.dust[num618].noGravity = true;
                Main.dust[num618].velocity *= 7f;

                num618 = Dust.NewDust(projectile.position, projectile.width, projectile.height, DustID.Torch, Alpha: 100, Scale: 1.5f);
                Main.dust[num618].velocity *= 3f;
            }

            for (int i = 0; i < 2; i++)
            {
                float scaleFactor = 0.4f;
                if (i == 1)
                {
                    scaleFactor = 0.8f;
                }

                int num620 = Gore.NewGore(projectile.position, default, Main.rand.Next(61, 64));
                Main.gore[num620].velocity *= scaleFactor;

                Gore gore97 = Main.gore[num620];
                gore97.velocity.X += 1f;

                Gore gore98 = Main.gore[num620];
                gore98.velocity.Y += 1f;

                num620 = Gore.NewGore(projectile.position, default, Main.rand.Next(61, 64));
                Main.gore[num620].velocity *= scaleFactor;

                Gore gore99 = Main.gore[num620];
                gore99.velocity.X -= 1f;

                Gore gore100 = Main.gore[num620];
                gore100.velocity.Y += 1f;

                num620 = Gore.NewGore(projectile.position, default, Main.rand.Next(61, 64));
                Main.gore[num620].velocity *= scaleFactor;

                Gore gore101 = Main.gore[num620];
                gore101.velocity.X += 1f;

                Gore gore102 = Main.gore[num620];
                gore102.velocity.Y -= 1f;

                num620 = Gore.NewGore(projectile.position, default, Main.rand.Next(61, 64));
                Main.gore[num620].velocity *= scaleFactor;

                Gore gore103 = Main.gore[num620];
                gore103.velocity.X -= 1f;

                Gore gore104 = Main.gore[num620];
                gore104.velocity.Y -= 1f;
            }
        }
    }
}