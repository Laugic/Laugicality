using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;
using System;
using Laugicality.Dusts;

namespace Laugicality.Projectiles.Accessory
{
    public class GoodFireball : ModProjectile
    {
        public bool stopped = false;

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Fireball");
        }

        public override void SetDefaults()
        {
            stopped = false;
            projectile.width = 12;
            projectile.height = 12;
            projectile.aiStyle = -1;
            projectile.friendly = true;
            projectile.penetrate = -1;
            projectile.timeLeft = 160;
            projectile.ignoreWater = true;
            projectile.tileCollide = true;
        }

        public override void AI()
        {
            if (Main.rand.Next((int)(8 / projectile.scale)) == 0)
                Dust.NewDust(projectile.position + projectile.velocity, projectile.width, projectile.height, ModContent.DustType<Magma>(), -2 + Main.rand.NextFloat() * 4, -Main.rand.NextFloat() * 4);
            if (stopped)
            {
                projectile.velocity.X *= .8f;
                projectile.velocity.Y = 0;
                projectile.scale *= .98f;
                if (projectile.scale <= .05f)
                    projectile.Kill();
                projectile.rotation = 0;
            }
            else
            {
                projectile.velocity.Y += projectile.ai[0];
                projectile.ai[0] += .01f;
                projectile.velocity.X *= .99f;
                projectile.rotation = (float)Math.Atan2((double)projectile.velocity.Y, (double)projectile.velocity.X) - (float)Math.PI / 2;
            }

        }

        public override bool OnTileCollide(Vector2 oldVelocity)
        {
            stopped = true;
            return false;
        }
    }
}
