using Laugicality.Buffs;
using Laugicality.Dusts;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Laugicality.Projectiles.Mystic.Illusion
{
	public class CharonIllusion : IllusionProjectile
    {
        public override void SetDefaults()
        {
            projectile.width = 36;
            projectile.height = 36;
            projectile.friendly = true;
            projectile.penetrate = 8;
            projectile.timeLeft = 600;
            projectile.ignoreWater = true;
            projectile.tileCollide = true;
            buffID = ModContent.BuffType<UndeathBuff>();
            baseDuration = 12 * 60;
        }

        public override bool OnTileCollide(Vector2 oldVelocity)
        {
            if (projectile.velocity.X != oldVelocity.X)
            {
                projectile.velocity.X = -oldVelocity.X;
            }
            if (projectile.velocity.Y != oldVelocity.Y)
            {
                projectile.velocity.Y = -oldVelocity.Y;
            }
            return false;
        }

        public override void AI()
        {
            projectile.rotation += .1f;
            projectile.velocity.Y += .1f;
            //if (Main.rand.Next(2) == 0)
                Dust.NewDust(projectile.position + projectile.velocity, projectile.width, projectile.height, ModContent.DustType<Black>(), projectile.velocity.X * 0.5f, projectile.velocity.Y * 0.5f);
        }
    }
}