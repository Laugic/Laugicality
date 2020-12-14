using System;
using Laugicality.Dusts;
using Laugicality.NPCs.RockTwins;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Laugicality.Projectiles.Mystic.Conjuration
{
	public class GaiaConjuration : PrimaryConjurationProjectile
    {
        public Color colorType;
        public int vMax = 0;
        public float vAccel = 0;
        public float tVel = 0;
        public float vMag = 0;
        float theta = 0;
        int index = 0;
        public override void SetDefaults()
        {
            index = 0;
            theta = 0;
            vMax = 28;
            vAccel = .1f;
            projectile.width = 22;
            projectile.height = 22;
            projectile.friendly = true;
            projectile.penetrate = -1;
            projectile.timeLeft = 12 * 60;
            projectile.ignoreWater = true;
            projectile.tileCollide = false;
            Main.projFrames[projectile.type] = 6;
        }

        public override void AI()
        {
            Visuals();
            Movement();
            Effects();
        }

        private void Effects()
        {

        }

        private void Movement()
        {
            Player player = Main.player[projectile.owner];

            if (projectile.ai[0] == 0)
                projectile.ai[0] = player.ownedProjectileCounts[ModContent.ProjectileType<GaiaConjuration>()];

            theta += (float)(Math.PI / 40);
            float mag = 48 + projectile.ai[0] * 2;
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

        private void Visuals()
        {
            projectile.frame = (int)(projectile.ai[1]);

            if (projectile.ai[1] == 0) { colorType = new Color(255, 0, 0); }
            if (projectile.ai[1] == 1) { colorType = new Color(255, 226, 0); }
            if (projectile.ai[1] == 2) { colorType = new Color(8, 255, 0); }
            if (projectile.ai[1] == 3) { colorType = new Color(0, 217, 255); }
            if (projectile.ai[1] == 4) { colorType = new Color(209, 0, 255); }
            if (projectile.ai[1] == 5) { colorType = new Color(255, 255, 255); }

            if (projectile.timeLeft < 80)
            {
                projectile.alpha += 2;
            }
            if (projectile.timeLeft < 2 && projectile.ai[1] == 0)
            {
                Burst();
                projectile.Kill();
            }
        }

        public override void Kill(int timeLeft)
        {
            for (int i = 0; i < 1000; i++)
            {
                if (Main.projectile[i].owner == projectile.owner && Main.projectile[i].type == ModContent.ProjectileType<GaiaConjuration>() && Main.projectile[i].ai[0] > projectile.ai[0])
                    Main.projectile[i].ai[0]--;
            }

            base.Kill(timeLeft);
        }

        public void Burst()
        {
            if(Main.myPlayer == projectile.owner)
            {
                for (int i = 0; i < 20; i++)
                {
                    theta = (float)(Math.PI * Main.rand.NextDouble() * 2);
                    Vector2 newVel = new Vector2((float)Math.Cos(theta), (float)Math.Sin(theta));
                    newVel *= 10;
                    int id = Projectile.NewProjectile(projectile.Center.X, projectile.Center.Y, newVel.X, newVel.Y, ModContent.ProjectileType<GemShard>(), projectile.damage, 3, Main.myPlayer);
                    Main.projectile[id].ai[1] = 3;
                }
            }
        }
    }
}