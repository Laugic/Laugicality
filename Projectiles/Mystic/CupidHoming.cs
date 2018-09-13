using System.Collections.Generic;
using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Laugicality;


namespace Laugicality.Projectiles.Mystic
{
	public class CupidHoming : ModProjectile
    {
        public float mystDmg = 0;
        public float mystDur = 0;

        public override void SetDefaults()
        {
            //mystDmg = (float)projectile.damage;
            //mystDur = 1f + projectile.knockBack;
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
            projectile.rotation = (float)Math.Atan2((double)projectile.velocity.Y, (double)projectile.velocity.X);
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
                        int mag = 2;
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
            mystDur = modPlayer.mysticDuration;*/
            if(Main.rand.Next(4) == 0)
                Dust.NewDust(projectile.position + projectile.velocity, projectile.width, projectile.height, mod.DustType("Pink"), projectile.velocity.X * 0.5f, projectile.velocity.Y * 0.5f);

        }
        
    }
}