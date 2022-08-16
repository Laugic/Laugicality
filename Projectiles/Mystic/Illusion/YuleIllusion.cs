using Laugicality.Buffs;
using Laugicality.Dusts;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Laugicality.Projectiles.Mystic.Illusion
{
	public class YuleIllusion : IllusionProjectile
    {
        public override void SetDefaults()
        {
            projectile.width = 24;
            projectile.height = 24;
            projectile.friendly = true;
            projectile.penetrate = 8;
            projectile.timeLeft = 600;
            projectile.ignoreWater = true;
            projectile.tileCollide = true;
            buffID = ModContent.BuffType<BrittleBuff>();
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
            }
            return false;
        }

        public override void AI()
        {
            projectile.rotation += .1f;
            if (Main.rand.Next(2) == 0)Dust.NewDust(projectile.position + projectile.velocity, projectile.width, projectile.height, ModContent.DustType<Frost>(), projectile.velocity.X * 0.5f, projectile.velocity.Y * 0.5f);
        }

        public override void Kill(int timeLeft)
        {
            Main.PlaySound(SoundID.Item30, projectile.position);
        }
    }
}