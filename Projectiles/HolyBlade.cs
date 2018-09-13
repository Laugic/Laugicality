using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Laugicality.Projectiles
{
    public class HolyBlade : ModProjectile
    {
        public int rot = 0;
        public int delay = 0;
        public bool reverse = false;

        public int vMax = 0;
        public float vAccel = 0;
        public float tVel = 0; //Target Velocity
        public float vMag = 0;

        public override void SetDefaults()
        {
            vMax = 14;
            vAccel = .2f;
            reverse = false;
            delay = 20;
            projectile.width = 40;
            projectile.height = 40;
            projectile.friendly = true;
            projectile.thrown = true;
            projectile.tileCollide = false;
            projectile.penetrate = -1;
            projectile.aiStyle = 0;
            projectile.timeLeft = 400;
            projectile.scale = 1.5f;
        }

        public override void AI()
        {
            projectile.rotation = (float)Math.Atan2((double)projectile.velocity.Y, (double)projectile.velocity.X) + 1.57f / 2;
            Player projOwner = Main.player[projectile.owner];
            //projOwner.AddBuff(mod.BuffType("ForGlory"), 120);
            delay -= 1;
            if (delay <= 0 && reverse == false)
            {
                projectile.velocity.X *= .965f;
                projectile.velocity.Y *= .965f;
                if (Math.Abs(projectile.velocity.X) < 4f && Math.Abs(projectile.velocity.Y) < 4f)
                {
                    projectile.velocity.X = -projectile.velocity.X;
                    projectile.velocity.Y = -projectile.velocity.Y;
                    reverse = true;
                }
            }
            if (reverse)
            {
                Vector2 delta = Main.player[Main.myPlayer].Center - projectile.Center;
                float dist = Vector2.Distance(Main.player[Main.myPlayer].Center, projectile.Center);
                tVel = dist / 15;
                if (vMag < vMax && vMag < tVel)
                {
                    vMag += vAccel;
                }
                /*
                if (vMag > tVel)
                {
                    vMag -= vAccel;
                }*/

                if (dist != 0)
                {
                    projectile.velocity = projectile.DirectionTo(Main.player[Main.myPlayer].Center) * vMag;
                }
                //Return
                if (Math.Abs(delta.X) < 16 && Math.Abs(delta.Y) < 16)
                    projectile.Kill();
            }
        }

        public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
        {
            Projectile.NewProjectile(projectile.Center.X, projectile.Center.Y, 0, 0, 466, (int)(projectile.damage), 3, Main.myPlayer);
        }
    }
}