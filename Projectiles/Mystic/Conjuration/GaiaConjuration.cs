using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;

namespace Laugicality.Projectiles.Mystic.Conjuration
{
	public class GaiaConjuration : ConjurationProjectile
    {
        public override void SetDefaults()
        {
            projectile.width = 18;
            projectile.height = 18;
            projectile.friendly = true;
            projectile.penetrate = 2;
            projectile.timeLeft = 600;
            projectile.ignoreWater = true;
        }

        public override void AI()
        {
            Player player = Main.player[projectile.owner];
            LaugicalityPlayer modPlayer = player.GetModPlayer<LaugicalityPlayer>(mod);

            projectile.velocity.Y += .15f;

            Dust.NewDust(projectile.position + projectile.velocity, projectile.width, projectile.height, mod.DustType("Rainbow"), projectile.velocity.X * 0.5f, projectile.velocity.Y * 0.5f);
        }

        public override bool OnTileCollide(Vector2 oldVelocity)
        {
            if (Main.myPlayer == projectile.owner)
            {
                for (int k = 0; k < 8; k++)
				{
					Projectile.NewProjectile(projectile.Center.X, projectile.Center.Y, Main.rand.Next((int)-10f, (int)10f), Main.rand.Next((int)-10f, (int)10f), mod.ProjectileType("GemShard"), (int)(projectile.damage * 0.80f), 2f, projectile.owner, 0f, Main.rand.Next(6));
				}	
			}
            projectile.penetrate--;
            if (projectile.penetrate <= 1)
            {
                projectile.Kill();
            }
            else
            {
                projectile.ai[0] += 0.2f;
                if (projectile.velocity.X != oldVelocity.X)
                {
                    projectile.velocity.X = -oldVelocity.X;
                }
                if (projectile.velocity.Y != oldVelocity.Y)
                {
                    projectile.velocity.Y = -oldVelocity.Y;
                }
                projectile.velocity *= 0.75f;
                Main.PlaySound(SoundID.Item10, projectile.position);
            }
            
            return false;
        }
        
        public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
        {
            if (Main.myPlayer == projectile.owner)
            {
                projectile.ai[0] += 0.2f;
                for (int k = 0; k < 8; k++)
				{
					Projectile.NewProjectile(projectile.Center.X, projectile.Center.Y, Main.rand.Next((int)-10f, (int)10f), Main.rand.Next((int)-10f, (int)10f), mod.ProjectileType("GemShard"), (int)(projectile.damage * 0.80f), 2f, projectile.owner, 0f, Main.rand.Next(6));
				}
			}
            Main.PlaySound(SoundID.Item10, projectile.position);
        }
    }
}