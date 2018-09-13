using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Laugicality.Projectiles
{
    public class AndesiaStaff : ModProjectile
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
            delay = 180;
            projectile.width = 88;
            projectile.height = 88;
            projectile.friendly = false;
            projectile.thrown = true;
            projectile.tileCollide = false;
            projectile.penetrate = -1;
            projectile.aiStyle = 0;
            projectile.timeLeft = 400;
        }
        
        public override void AI()
        {
            projectile.rotation =  -1.57f / 2;
            Player projOwner = Main.player[projectile.owner];
            projOwner.AddBuff(mod.BuffType("ForHonor"), 120);
            delay -= 1;
            if (delay % 10 == 0 && !reverse && Main.myPlayer == projectile.owner)
            {
                    Projectile.NewProjectile(projectile.Center.X - 3 + Main.rand.Next(0, 6), projectile.Center.Y - 360 - 3 + Main.rand.Next(0, 6), 0, 0, mod.ProjectileType("Dioritite"), (int)(projectile.damage), 3, Main.myPlayer);
                Projectile.NewProjectile(projectile.Center.X - 3 + Main.rand.Next(0, 6), projectile.Center.Y + 360 - 3 + Main.rand.Next(0, 6), 0, 0, mod.ProjectileType("Andesimite"), (int)(projectile.damage), 3, Main.myPlayer);
            }
            if(delay <= 0 && reverse == false)
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
        /*
        public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
        {
            target.AddBuff(mod.BuffType("Steamy"), 120);       //Add Onfire buff to the NPC for 1 second
        }*/
    }
}