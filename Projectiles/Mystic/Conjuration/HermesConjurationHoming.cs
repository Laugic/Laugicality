using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;


namespace Laugicality.Projectiles.Mystic.Conjuration
{
	public class HermesConjurationHoming : ConjurationProjectile
    {
        public override void SetDefaults()
        {
            projectile.width = 12;
            projectile.height = 12;
            projectile.friendly = true;
            projectile.penetrate = 2;
            projectile.timeLeft = 200;
            projectile.ignoreWater = true;
            projectile.tileCollide = false;
        }

        public override void AI()
        {
            projectile.rotation = (float)Math.Atan2((double)projectile.velocity.Y, (double)projectile.velocity.X) + 1.57f / 2;
            for (int i = 0; i < 200; i++)
            {
                NPC target = Main.npc[i];
                //If the npc is hostile
                if (!target.friendly)
                {
                    //Get the shoot trajectory from the projectile and target
                    float shootToX = target.position.X + (float)target.width * 0.5f - projectile.Center.X;
                    float shootToY = target.position.Y - projectile.Center.Y;
                    float distance = (float)System.Math.Sqrt((double)(shootToX * shootToX + shootToY * shootToY));

                    //If the distance between the live targeted npc and the projectile is less than 480 pixels
                    if (distance < 480f && !target.friendly && target.active && target.damage > 0)
                    {
                        //Divide the factor, 3f, which is the desired velocity
                        distance = 1f / distance;

                        //Multiply the distance by a multiplier if you wish the projectile to have go faster
                        shootToX *= distance * 5;
                        shootToY *= distance * 5;

                        //Set the velocities to the shoot values
                        int mag = 10;
                        if(projectile.velocity.X < shootToX)
                        {
                            projectile.velocity.X += (shootToX - projectile.velocity.X) / mag;
                        }
                        if(projectile.velocity.Y < shootToY)
                        {
                            projectile.velocity.Y += (shootToY - projectile.velocity.Y) / mag;
                        }
                        if (projectile.velocity.X > shootToX)
                        {
                            projectile.velocity.X -= (projectile.velocity.X - shootToX) / mag;
                        }
                        if (projectile.velocity.Y > shootToY)
                        {
                            projectile.velocity.Y -= (projectile.velocity.Y - shootToY) / mag;
                        }
                    }
                }
            }
            /*Player player = Main.player[projectile.owner];
            LaugicalityPlayer modPlayer = player.GetModPlayer<LaugicalityPlayer>(mod);
            mystDur = modPlayer.MysticDuration;*/
            Dust.NewDust(projectile.position + projectile.velocity, projectile.width, projectile.height, mod.DustType("Hermes"), projectile.velocity.X * 0.5f, projectile.velocity.Y * 0.5f);

        }

        public override bool OnTileCollide(Vector2 oldVelocity)
        {
            projectile.penetrate--;
            if (projectile.penetrate <= 0)
            {
                projectile.Kill();
            }
            else
            {
                //projectile.ai[0] += 0.1f;
                if (projectile.velocity.X != oldVelocity.X)
                {
                    projectile.velocity.X = -oldVelocity.X;
                }
                if (projectile.velocity.Y != oldVelocity.Y)
                {
                    projectile.velocity.Y = -oldVelocity.Y;
                }
                Main.PlaySound(SoundID.Item10, projectile.position);
            }
            return false;
        }
    }
}