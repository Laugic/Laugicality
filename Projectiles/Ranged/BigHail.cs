using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using System;
using Laugicality.Buffs;
using Laugicality.Dusts;

namespace Laugicality.Projectiles.Ranged
{
    public class BigHail : ModProjectile
    {
        int delay = 0;
        public override void SetDefaults()
        {
            LaugicalityVars.SnowballProjectiles.Add(projectile.type);
            projectile.width = 30;
            projectile.height = 30;
            projectile.friendly = true;
            projectile.penetrate = -1;
            projectile.timeLeft = 300;
            projectile.ranged = true;
            projectile.ignoreWater = true;
            delay = 0;
        }


        public override void AI()
        {
            delay++;
            if(delay > 15 || Main.rand.Next(30) == 0)
            {
                delay = 0;
                if(projectile.ai[0] > 0 && Main.myPlayer == projectile.owner)
                    Projectile.NewProjectile(projectile.position, new Vector2(0, 2), (int)projectile.ai[0], projectile.damage, projectile.knockBack, projectile.owner);
            }
            projectile.velocity.Y += .5f;
            Dust.NewDust(projectile.position + projectile.velocity, projectile.width, projectile.height, 33, projectile.velocity.X * -0.5f, projectile.velocity.Y * -0.5f);
            Dust.NewDust(projectile.position + projectile.velocity, projectile.width, projectile.height, 33, projectile.velocity.X * -0.5f, projectile.velocity.Y * -0.5f);

        }

        public override bool OnTileCollide(Vector2 oldVelocity)
        {
            projectile.Kill();
            Main.PlaySound(2, (int)projectile.position.X, (int)projectile.position.Y, 50);
            return false;
        }
    }
}