using Laugicality.Dusts;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Laugicality.Projectiles.Ranged
{
    public class SootballProjectile : ModProjectile
    {
        public override void SetDefaults()
        {
            LaugicalityVars.SnowballProjectiles.Add(projectile.type);
            projectile.width = 14;
            projectile.height = 14;
            projectile.friendly = true;
            projectile.ranged = true;
            projectile.timeLeft = 600;
        }

        public override void AI()
        {
            projectile.velocity.Y += .5f;
            projectile.velocity.X *= .98f;
            if(Main.rand.NextBool(8)) Dust.NewDust(projectile.position + projectile.velocity, projectile.width, projectile.height, ModContent.DustType<Magma>(), projectile.velocity.X * 0.5f, projectile.velocity.Y * 0.5f);
        }

        public override bool OnTileCollide(Vector2 oldVelocity)
        {
            projectile.Kill();
            return true;
        }

        public override void Kill(int timeLeft)
        {
            Main.PlaySound(0, (int)projectile.position.X, (int)projectile.position.Y);
            base.Kill(timeLeft);
        }

        public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
        {
            target.AddBuff(BuffID.OnFire, 3 * 60 + Main.rand.Next(60));
        }
    }
}