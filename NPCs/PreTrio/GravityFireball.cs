using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Laugicality.NPCs.PreTrio
{
    public class GravityFireball : ModProjectile
    {
        public int delay = 0;
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("a Fireball");
        }

        public override void SetDefaults()
        {
            Main.projFrames[projectile.type] = 3;
            LaugicalityVars.eProjectiles.Add(projectile.type);
            projectile.width = 42;
            projectile.height = 42;
            projectile.alpha = 0;
            projectile.timeLeft = 360;
            projectile.friendly = false;
            projectile.hostile = true;
            projectile.ignoreWater = true;
            projectile.tileCollide = false;

        }

        public override void AI()
        {
            Vector2 newVel = -projectile.velocity * 2 / 3f;
            float theta = Main.rand.Next(-30, 30) * (float)Math.PI / 180;
            float mag = Main.rand.Next(2, 6);
            newVel.X += (float)Math.Cos(theta) * mag;
            newVel.Y += (float)Math.Sin(theta) * mag;
            Dust.NewDust(projectile.position - projectile.velocity, projectile.width, projectile.height, mod.DustType("SuperMagma"), newVel.X, newVel.Y);
            projectile.rotation = (float)Math.Atan2((double)projectile.velocity.Y, (double)projectile.velocity.X) - 1.57f;
            delay++;
            if (delay > 30)
                projectile.velocity.Y += .1f;


            projectile.frameCounter++;
            if (projectile.frameCounter > 4)
            {
                projectile.frame++;
                projectile.frameCounter = 0;
            }
            if (projectile.frame > 2)
            {
                projectile.frame = 0;
            }
        }


        public override void OnHitPlayer(Player target, int dmgDealt, bool crit)
        {
            target.AddBuff(BuffID.OnFire, 4 * 60, true);
        }
    }
}