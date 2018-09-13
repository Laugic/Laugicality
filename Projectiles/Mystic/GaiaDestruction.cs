using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Laugicality;
using Laugicality.NPCs;

namespace Laugicality.Projectiles.Mystic
{
	public class GaiaDestruction : ModProjectile
    {
        float distanceTo = 800;
        public override void SetDefaults()
        {
            distanceTo = 800;
            //mystDmg = (float)projectile.damage;
            //mystDur = 1f + projectile.knockBack;
            projectile.width = 18;
            projectile.height = 18;
            projectile.friendly = true;
            projectile.penetrate = -1;
            projectile.timeLeft = 600;
            projectile.ignoreWater = true;
            projectile.tileCollide = false;
        }

        

        public override void AI()
        {
            //projectile.velocity.Y += .5f + projectile.ai[0];
            Player player = Main.player[projectile.owner];
            LaugicalityPlayer modPlayer = player.GetModPlayer<LaugicalityPlayer>(mod);
            if(projectile.penetrate == -1)
            {
                projectile.penetrate = 1 + modPlayer.destructionPower;
            }
            Dust.NewDust(projectile.position + projectile.velocity, projectile.width, projectile.height, mod.DustType("Rainbow"), projectile.velocity.X * 0.5f, projectile.velocity.Y * 0.5f);
            for (int i = 0; i < 200; i++)
            {
                NPC target = Main.npc[i];
                //If the npc is hostile
                if (!target.friendly && target.damage > 0)
                {
                    //Get the shoot trajectory from the projectile and target
                    float shootToX = target.position.X + (float)target.width * 0.5f - projectile.Center.X;
                    float shootToY = target.position.Y - projectile.Center.Y;
                    float distance = (float)System.Math.Sqrt((double)(shootToX * shootToX + shootToY * shootToY));

                    //If the distance between the live targeted npc and the projectile is less than 480 pixels
                    if (distance < 480f && distance < distanceTo && !target.friendly && target.active && target.damage > 0)
                    {
                        distanceTo = distance;
                        //Divide the factor, 3f, which is the desired velocity
                        distance = 1f / distance;

                        //Multiply the distance by a multiplier if you wish the projectile to have go faster
                        shootToX *= distance * 5;
                        shootToY *= distance * 5;

                        //Set the velocities to the shoot values
                        int mag = 5;
                        if (projectile.velocity.X < shootToX)
                        {
                            projectile.velocity.X += (shootToX - projectile.velocity.X) / mag;
                        }
                        if (projectile.velocity.Y < shootToY)
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
        }
    }
}