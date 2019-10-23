using System;
using Laugicality.Dusts;
using Laugicality.Projectiles.Mystic.Illusion;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;


namespace Laugicality.Projectiles.Mystic.Conjuration
{
    public class CupidConjurationAngel : ConjurationProjectile
    {
        public int delay = 4;
        private int index = 0;
        private bool spawned = false;
        private float theta = 0f;
        private float vMag = 0f;
        private float vMax = 0f;
        private float vAccel = 0f;
        private float reloadMax = 0;
        private int reload = 60;
        private int attack = 0;

        public override void SetDefaults()
        {
            reloadMax = 0;
            reload = 60;
            vMag = 0;
            vMax = 20;
            vAccel = .2f;
            theta = 0f;
            index = 0;
            spawned = false;
            delay = 2;
            projectile.width = 20;
            projectile.height = 20;
            projectile.friendly = true;
            projectile.penetrate = -1;
            projectile.timeLeft = 800;
            projectile.ignoreWater = true;
            projectile.tileCollide = false;
            Main.projFrames[projectile.type] = 5;
        }

        public override void AI()
        {
            projectile.rotation = 0;
            
            if (!spawned)
            {
                spawned = true;
                projectile.frame = Main.rand.Next(5);
                if(projectile.frame == 0 || projectile.frame == 2)
                {
                    reloadMax = 120;
                    attack = 1;
                }
                if (projectile.frame == 1 || projectile.frame == 4)
                {
                    reloadMax = 120;
                    attack = 2;
                }
                if (projectile.frame == 3)
                {
                    reloadMax = 60;
                    attack = 3;
                }
            }

            //Movement
            Player player = Main.player[projectile.owner];
            if (index == 0)
                index = player.ownedProjectileCounts[ModContent.ProjectileType<CupidConjurationAngel>()];
            projectile.tileCollide = false;
            theta += (float)(Math.PI / 120);
            float mag = 48;
            Vector2 rot = projectile.position;
            rot.X = (float)Math.Cos(theta) * mag;
            rot.Y = (float)Math.Sin(theta) * mag;
            Vector2 targetPos = player.Center + rot;
            Vector2 direction = targetPos - projectile.Center;
            float dist = Vector2.Distance(targetPos, projectile.Center);
            float tVel = dist / 15;
            if (vMag < vMax && vMag < tVel)
            {
                vMag += vAccel;
            }

            if (vMag > tVel)
            {
                vMag = tVel;
            }

            if (dist != 0)
            {
                projectile.velocity = projectile.DirectionTo(targetPos) * vMag;
            }

            //Attack
            reload++;
            if(reload >= reloadMax)
            {
                if(attack == 1)
                {
                    if (Main.myPlayer == projectile.owner)
                    {
                        Projectile.NewProjectile(projectile.Center.X, projectile.Center.Y, 0, 0, ModContent.ProjectileType<CupidArrow>(), (int)(projectile.damage / 1f), 3, Main.myPlayer);
                    }
                    reload = 0;
                }
                if (attack == 2)
                {
                    if (Main.myPlayer == projectile.owner)
                    {
                        Projectile.NewProjectile(projectile.Center.X, projectile.Center.Y, 0, 0, ModContent.ProjectileType<CupidHoming>(), (int)(projectile.damage / 1f), 3, Main.myPlayer);
                    }
                    reload = 0;
                }
                if (attack == 3)
                {
                    if (Main.myPlayer == projectile.owner)
                    {
                        Projectile.NewProjectile(projectile.Center.X, projectile.Center.Y, 0, 0, ModContent.ProjectileType<CupidBurst>(), (int)(projectile.damage / 1f), 3, Main.myPlayer);
                    }
                    reload = 0;
                }
            }
            if(Main.rand.Next(8) == 0)
                Dust.NewDust(projectile.position + projectile.velocity, projectile.width, projectile.height, ModContent.DustType<Pink>(), 0, 0);
        }
    }
}