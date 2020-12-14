using Laugicality.Dusts;
using Microsoft.Xna.Framework;
using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Laugicality.Projectiles.Ranged
{
	public class FrostballProjectile : ModProjectile
	{
		public override void SetDefaults()
        {
            LaugicalityVars.SnowballProjectiles.Add(projectile.type);
            projectile.width = 14;
			projectile.height = 14;
			projectile.friendly = true;
			projectile.ranged = true;
            projectile.penetrate = 4;
			projectile.timeLeft = 600;
		}

		public override void AI()
        {
            projectile.velocity.Y += .4f;
            projectile.velocity.X *= .985f;
            Dust.NewDust(projectile.position + projectile.velocity, projectile.width, projectile.height, ModContent.DustType<Frost>(), projectile.velocity.X * 0.5f, projectile.velocity.Y * 0.5f);
        }

        public override void ModifyHitNPC(NPC target, ref int damage, ref float knockback, ref bool crit, ref int hitDirection)
        {
            if(Math.Abs(projectile.velocity.X) > Math.Abs(projectile.velocity.Y))
                projectile.velocity.X *= -1;
            else
                projectile.velocity.Y *= -1;
            projectile.velocity *= 0.8f;
            base.ModifyHitNPC(target, ref damage, ref knockback, ref crit, ref hitDirection);
        }

        public override bool OnTileCollide(Vector2 oldVelocity)
        {
            projectile.penetrate--;
            if (projectile.penetrate <= 0)
            {
                projectile.Kill();
            }
            else
            {
                if (projectile.velocity.X != oldVelocity.X)
                {
                    projectile.velocity.X = -oldVelocity.X;
                }
                if (projectile.velocity.Y != oldVelocity.Y)
                {
                    projectile.velocity.Y = -oldVelocity.Y;
                }
                projectile.velocity *= 0.8f;
                Main.PlaySound(2, (int)projectile.position.X, (int)projectile.position.Y, 50);
            }
            return false;
            return true;
		}

        public override void Kill(int timeLeft)
        {
            Main.PlaySound(2, (int)projectile.position.X, (int)projectile.position.Y, 51);
            base.Kill(timeLeft);
        }

        public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
        {
            target.AddBuff(BuffID.Frostburn, 3 * 60 + Main.rand.Next(60));
        }
    }
}