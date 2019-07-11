using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;
using System;
using Laugicality.Dusts;

namespace Laugicality.Projectiles
{
    public class BysmalBlast : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Bysmal Blast");
        }
        public bool stopped = false;
        public override void SetDefaults()
        {
            stopped = false;
            projectile.width = 18;
            projectile.height = 36;
            projectile.aiStyle = -1;
            projectile.friendly = true;
            projectile.hostile = false;
            projectile.ranged = true;
            projectile.penetrate = 1;
            projectile.timeLeft = 120;
            projectile.ignoreWater = true;
            projectile.tileCollide = false;
        }


        public override void AI()
        {
            if(Main.rand.Next(8) == 0)Dust.NewDust(projectile.position + projectile.velocity, projectile.width, projectile.height, mod.DustType<EtherialDust>(), projectile.velocity.X * 0f, projectile.velocity.Y * 0f);
            if (!stopped)
            {
                projectile.velocity.X *= .9f;
                projectile.velocity.Y *= .9f;
            }

            if (Math.Abs(projectile.velocity.X) <= .2 && Math.Abs(projectile.velocity.Y) <= .2)
            {
                if (!stopped)
                {
                    stopped = true;
                    Vector2 targetPos;
                    targetPos.X = Main.MouseWorld.X;
                    targetPos.Y = Main.MouseWorld.Y;
                    projectile.velocity = projectile.DirectionTo(targetPos) * 22f;
                }
            }
            projectile.rotation = (float)Math.Atan2((double)projectile.velocity.Y, (double)projectile.velocity.X);
        }
    }
}
