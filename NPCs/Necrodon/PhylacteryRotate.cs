using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.ModLoader;

namespace Laugicality.NPCs.Necrodon
{
    public class PhylacteryRotate : ModProjectile
    {
        private Vector2 origin;
        private bool Spawned = false;
        private int counter = 0;
        private float mag = 0;
        private float magGoal = 0;
        public float magCel = 0;
        private double theta = 0;
        private double thetaGoal = 0;
        private double thetCel = 0;
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("the Groove");
        }

        public override void SetDefaults()
        {
            LaugicalityVars.eProjectiles.Add(projectile.type);
            projectile.width = 32;
            projectile.height = 32;
            projectile.timeLeft = 16 * 60;
            projectile.friendly = false;
            projectile.hostile = true;
            projectile.ignoreWater = true;
            projectile.tileCollide = false;
            origin = projectile.position;
            magGoal = 80;
            counter = 0;
            magCel = 0;
            theta = thetaGoal = thetCel = 0;
            Spawned = false;
        }

        public override void AI()
        {
            float light = 0.8f;
            Lighting.AddLight(projectile.Center + projectile.velocity, light, light, light);
            if (!Spawned)
            {
                origin = projectile.Center;
                counter = (int)Main.npc[(int)projectile.ai[0]].ai[2];
                theta = thetaGoal = Math.PI * 2 * projectile.ai[1] / 16;
                Spawned = true;
            }
            if (!(Main.npc[(int)projectile.ai[0]].type == ModContent.NPCType<Phylactery>() && Main.npc[(int)projectile.ai[0]].active))
            {
                projectile.Kill();
                return;
            }

            projectile.rotation = (float)Math.Atan2((double)projectile.position.Y - origin.Y, (double)projectile.position.X - origin.X) - 1.57f;

            GetGoals();
            GetMovement();

            if (projectile.timeLeft < 30)
            {
                projectile.alpha += 4;
                projectile.scale *= .98f;
            }
        }

        private void GetMovement()
        {
            if (mag < magGoal)
            {
                magCel += .6f;
                mag = Math.Min(magGoal, mag + magCel);
            }
            else
                magCel = 0;
            if(theta < thetaGoal)
            {
                thetCel += .01;
                theta = Math.Min(thetaGoal, theta + thetCel);
            }
            else if (theta > thetaGoal)
            {
                thetCel -= .01;
                theta = Math.Max(thetaGoal, theta + thetCel);
            }
            else
                thetCel = 0;
            projectile.position.X = origin.X + (float)Math.Cos(theta) * mag;
            projectile.position.Y = origin.Y + (float)Math.Sin(theta) * mag;
        }

        private void GetGoals()
        {
            if(counter < (int)Main.npc[(int)projectile.ai[0]].ai[2])
            {
                counter++;
                if(counter % 2 == 0)
                {
                    magGoal += 200;
                }
                else
                {
                    if (counter % 4 == 1)
                        thetaGoal += Math.PI / 2;
                    else
                        thetaGoal -= Math.PI / 2;
                }
            }
        }
    }
}
