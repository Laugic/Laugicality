using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Laugicality;
using Laugicality.NPCs;

namespace Laugicality.Projectiles.Mystic.Conjuration
{
    public class OrionConjuration : ConjurationProjectile
    {
        int numAbsorbed = 0;
        float theta = 0;
        int lightRadius = 0;
        int darkRadius = 0;

        public override void SetDefaults()
        {
            darkRadius = 0;
            lightRadius = 0;
            theta = 0;
            numAbsorbed = 0;
            projectile.width = 120;
            projectile.height = 120;
            projectile.friendly = true;
            projectile.penetrate = -1;
            projectile.timeLeft = 9999;
            projectile.ignoreWater = true;
            projectile.tileCollide = false;
            projectile.alpha = 250;
        }

        public override void AI()
        {
            Player player = Main.player[projectile.owner];
            LaugicalityPlayer modPlayer = player.GetModPlayer<LaugicalityPlayer>(mod);
            if (modPlayer.usingMysticItem == 0 || modPlayer.mysticMode != 3)
            {
                projectile.Kill();
            }
            DustParticles();
        }

        private void DustParticles()
        {
            DustSpiral();
            DustDarkPulse();
            DustLightPulse();
        }

        private void DustSpiral()
        {
            theta += (float)Math.PI / 60;
            float radius = 120;
            Vector2 position;
            position.X = projectile.Center.X + (float)Math.Cos(theta) * radius;
            position.Y = projectile.Center.Y + (float)Math.Sin(theta) * radius;
            float speedX = (float)Math.Cos(theta + Math.PI) * 4;
            float speedY = (float)Math.Sin(theta + Math.PI) * 4;
            Dust.NewDust(position, 0, 0, mod.DustType("GalacticLight"), speedX, speedY);
            position.X = projectile.Center.X + (float)Math.Cos(theta + Math.PI) * radius;
            position.Y = projectile.Center.Y + (float)Math.Sin(theta + Math.PI) * radius;
            speedX = (float)Math.Cos(theta) * 4;
            speedY = (float)Math.Sin(theta) * 4;
            Dust.NewDust(position, 0, 0, mod.DustType("GalacticLight"), speedX, speedY);
        }

        private void DustDarkPulse()
        {
            darkRadius += 7;
            if (darkRadius > 0 && darkRadius < 480)
            {
                for (int i = 0; i < 24; i++)
                {
                    float thetaDark = (float)(Main.rand.NextDouble() * 2 * Math.PI);
                    Vector2 position;
                    position.X = projectile.Center.X + (float)Math.Cos(thetaDark) * darkRadius;
                    position.Y = projectile.Center.Y + (float)Math.Sin(thetaDark) * darkRadius;
                    Dust.NewDust(position, 0, 0, mod.DustType("GalacticDark"));
                }
            }
            else if (darkRadius > 540)
            {
                darkRadius = 0;
            }
        }

        private void DustLightPulse()
        {
            lightRadius -= 3;
            if(lightRadius > 0 && lightRadius < 240)
            {
                for(int i = 0; i < 12; i++)
                {
                    float thetaLight = (float)(Main.rand.NextDouble() * 2 * Math.PI);
                    Vector2 position;
                    position.X = projectile.Center.X + (float)Math.Cos(thetaLight) * lightRadius;
                    position.Y = projectile.Center.Y + (float)Math.Sin(thetaLight) * lightRadius;
                    Dust.NewDust(position, 0, 0, mod.DustType("GalacticLight"));
                }
            }
            else if(lightRadius <= 0)
            {
                lightRadius = 320;
            }
        }

        public override void Kill(int timeLeft)
        {
            
        }
    }
}