using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Laugicality.Projectiles.Thrown
{
    public class ObshardianP : ModProjectile
    {
        bool boosted = false;
        public override void SetDefaults()
        {
            projectile.width = 14;
            projectile.height = 26;
            projectile.friendly = true;
            projectile.aiStyle = 1;
            projectile.thrown = true;
            projectile.penetrate = 2;
            projectile.extraUpdates = 1;
            aiType = 48;
            boosted = false;
        }

        public override void AI()
        {
            projectile.ai[0] += 1f;
            if (!boosted)
            {
                projectile.penetrate += (int)projectile.ai[1];
                boosted = true;
            }
            if (projectile.ai[0] >= 150f)
            {
                projectile.velocity.Y = projectile.velocity.Y + 0.15f;
                projectile.velocity.X = projectile.velocity.X * 0.99f;
            }
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
                projectile.velocity *= 0.85f;
            }
            Main.PlaySound(0, (int)projectile.position.X, (int)projectile.position.Y, 10);
            return false;
        }


        public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
        {
            target.AddBuff(BuffID.OnFire, 2 * 60 + Main.rand.Next(60));
        }
    }
}