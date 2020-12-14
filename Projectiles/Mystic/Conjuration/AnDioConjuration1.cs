using System;
using Laugicality.Dusts;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;

namespace Laugicality.Projectiles.Mystic.Conjuration
{
	public class AnDioConjuration1 : PrimaryConjurationProjectile
    {

        public int vMax = 0;
        public float vAccel = 0;
        public float tVel = 0;
        public float vMag = 0;
        public int delay = 0;
        float theta = 0;
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Energy Ball");
        }

        public override void SetDefaults()
        {
            LaugicalityVars.eProjectiles.Add(projectile.type);
            projectile.width = 20;
            projectile.height = 20;
            projectile.penetrate = -1;
            projectile.friendly = true;
            projectile.timeLeft = 10 * 60;
            projectile.ignoreWater = true;
            projectile.tileCollide = false;
            theta = 0;
            vMax = 28;
            vAccel = .1f;
            delay = 0;
        }


        public override void AI()
        {
            if(Main.rand.Next(4) == 0)
                Dust.NewDust(projectile.position + projectile.velocity, projectile.width, projectile.height, ModContent.DustType<Blue>(), projectile.velocity.X * 0.5f, projectile.velocity.Y * 0.5f);
            projectile.tileCollide = false;

            Player player = Main.player[projectile.owner];

            if (projectile.ai[0] == 0)
                projectile.ai[0] = player.ownedProjectileCounts[ModContent.ProjectileType<AnDioConjuration1>()];

            projectile.tileCollide = false;
            theta += (float)(Math.PI / 40);
            float mag = 32 + projectile.ai[0] * 4;
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

            CreateStalags();
        }

        private void CreateStalags()
        {
            delay++;
            Player player = Main.player[projectile.owner];
            if (delay > 90)
            {
                if(Main.myPlayer == projectile.owner)
                {
                    Projectile.NewProjectile(player.Center.X - 400 + Main.rand.Next(800), player.Center.Y - 500, 0, 0, ModContent.ProjectileType<AnDioStalactite>(), projectile.damage, 5f, projectile.owner);
                    Projectile.NewProjectile(player.Center.X - 400 + Main.rand.Next(800), player.Center.Y + 500, 0, 0, ModContent.ProjectileType<AnDioStalagmite>(), projectile.damage, 5f, projectile.owner);
                }
                delay = 0;
            }
        }

        public override void Kill(int timeLeft)
        {
            base.Kill(timeLeft);

            for (int i = 0; i < 1000; i++)
            {
                if (Main.projectile[i].owner == projectile.owner && Main.projectile[i].type == ModContent.ProjectileType<AnDioConjuration1>() && Main.projectile[i].ai[0] > projectile.ai[0])
                    Main.projectile[i].ai[0]--;
            }
        }
    }
}