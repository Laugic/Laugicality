using Laugicality.Dusts;
using Microsoft.Xna.Framework;
using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Laugicality.Projectiles.Mystic.Conjuration
{
	public class HermesConjuration : PrimaryConjurationProjectile
    {
        public int vMax = 0;
        public float vAccel = 0;
        public float tVel = 0;
        public float vMag = 0;
        float theta = 0;
        public override void SetDefaults()
        {
            theta = 0;
            vMax = 28;
            vAccel = .1f;
            projectile.width = 12;
            projectile.height = 12;
            projectile.friendly = true;
            projectile.timeLeft = 10 * 60;
            projectile.ignoreWater = true;
            projectile.penetrate = 2;
        }

        public override void AI()
        {
            Dust.NewDust(projectile.position + projectile.velocity, projectile.width, projectile.height, ModContent.DustType<HermesDust>(), projectile.velocity.X * 0.5f, projectile.velocity.Y * 0.5f);
            projectile.tileCollide = false;


            projectile.rotation = (float)Math.Atan2((double)projectile.velocity.Y, (double)projectile.velocity.X) + 1.57f / 2;

            Player player = Main.player[projectile.owner];

            if(projectile.ai[0] == 0)
                projectile.ai[0] = player.ownedProjectileCounts[ModContent.ProjectileType<HermesConjuration>()];

            projectile.tileCollide = false;
            theta += (float)(Math.PI / 40);
            float mag = 48 + projectile.ai[0] * 8;
            Vector2 rot = projectile.position;
            rot.X = (float)Math.Cos(theta) * mag;
            rot.Y = (float)Math.Sin(theta) * mag;
            Vector2 targetPos = player.Center + rot;
            Vector2 direction = targetPos - projectile.Center;
            float dist = Vector2.Distance(targetPos, projectile.Center);
            tVel = dist / 15;
            if (vMag < vMax && vMag < tVel)
                vMag += vAccel;

            if (vMag > tVel)
                vMag = tVel;

            if (dist != 0)
                projectile.velocity = projectile.DirectionTo(targetPos) * vMag;
        }

        public override void Kill(int timeLeft)
        {
            base.Kill(timeLeft);

            for (int i = 0; i < 1000; i++)
            {
                if (Main.projectile[i].owner == projectile.owner && Main.projectile[i].type == ModContent.ProjectileType<HermesConjuration>() && Main.projectile[i].ai[0] > projectile.ai[0])
                    Main.projectile[i].ai[0]--;
            }
        }
    }
}