using Microsoft.Xna.Framework;
using System;
using Terraria;
using Terraria.Audio;
using Terraria.Chat;
using Terraria.Audio;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria;

namespace Fargowiltas.Projectiles
{
    public class RenewalBaseProj : ModProjectile
    {
        private readonly string name;
        private readonly int projType;
        private readonly int convertType;
        private readonly bool supreme;

        protected RenewalBaseProj(string name, int projType, int convertType, bool supreme)
        {
            this.name = name;
            this.projType = projType;
            this.convertType = convertType;
            this.supreme = supreme;
        }

        public override string Texture => "Fargowiltas/Items/Renewals/" + name;

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault(name);
        }

        public override void SetDefaults()
        {
            projectile.width = 20;
            projectile.height = 20;
            projectile.aiStyle = 2;
            projectile.friendly = true;
            projectile.penetrate = -1;
            projectile.timeLeft = 170;
        }

        public override bool OnTileCollide(Vector2 oldVelocity)
        {
            projectile.Kill();
            return true;
        }

        public override void Kill(int timeLeft)
        {
            SoundEngine.PlaySound(SoundID.Shatter, projectile.Center);

            int radius = 150;
            float[] speedX = { 0, 0, 5, 5, 5, -5, -5, -5 };
            float[] speedY = { 5, -5, 0, 5, -5, 0, 5, -5 };

            for (int i = 0; i < 8; i++)
            {
                Projectile.NewProjectile(projectile.Center.X, projectile.Center.Y, speedX[i], speedY[i], projType, 0, 0, Main.myPlayer);
            }

            if (supreme)
            {
                for (int x = -Main.maxTilesX; x < Main.maxTilesX; x++)
                {
                    for (int y = -Main.maxTilesY; y < Main.maxTilesY; y++)
                    {
                        int xPosition = (int)(x + projectile.Center.X / 16.0f);
                        int yPosition = (int)(y + projectile.Center.Y / 16.0f);

                        WorldGen.Convert(xPosition, yPosition, convertType, 1); 
                    }
                }
            }
            else
            {
                for (int x = -radius; x <= radius; x++)
                {
                    for (int y = -radius; y <= radius; y++)
                    {
                        int xPosition = (int)(x + projectile.Center.X / 16.0f);
                        int yPosition = (int)(y + projectile.Center.Y / 16.0f);

                        // Circle
                        if (Math.Sqrt(x * x + y * y) <= radius + 0.5)
                        {
                            WorldGen.Convert(xPosition, yPosition, convertType, 1);
                        }
                    }
                }
            }
        }
    }
}
