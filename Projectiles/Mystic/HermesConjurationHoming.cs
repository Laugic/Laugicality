using System.Collections.Generic;
using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Laugicality;


namespace Laugicality.Projectiles.Mystic
{
	public class HermesConjurationHoming : ModProjectile
    {
        public float mystDmg = 0;
        public float mystDur = 0;

        public override void SetDefaults()
        {
            //mystDmg = (float)projectile.damage;
            //mystDur = 1f + projectile.knockBack;
            projectile.width = 6;
            projectile.height = 6;
            projectile.friendly = true;
            //projectile.penetrate = 2;
            projectile.timeLeft = 200;
            projectile.ignoreWater = true;
        }

        

        public override void AI()
        {

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
                    if (distance < 480f && !target.friendly && target.active)
                    {
                        //Divide the factor, 3f, which is the desired velocity
                        distance = 1f / distance;

                        //Multiply the distance by a multiplier if you wish the projectile to have go faster
                        shootToX *= distance * 5;
                        shootToY *= distance * 5;

                        //Set the velocities to the shoot values
                        if(projectile.velocity.X < shootToX)
                        {
                            projectile.velocity.X += (shootToX - projectile.velocity.X)/10;
                        }
                        if(projectile.velocity.Y < shootToY)
                        {
                            projectile.velocity.Y += (shootToY - projectile.velocity.Y) / 10;
                        }
                        if (projectile.velocity.X > shootToX)
                        {
                            projectile.velocity.X -= (projectile.velocity.X - shootToX) / 10;
                        }
                        if (projectile.velocity.Y > shootToY)
                        {
                            projectile.velocity.Y -= (projectile.velocity.Y - shootToY) / 10;
                        }
                    }
                }
            }
            /*Player player = Main.player[projectile.owner];
            LaugicalityPlayer modPlayer = player.GetModPlayer<LaugicalityPlayer>(mod);
            mystDur = modPlayer.mysticDuration;*/
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
                projectile.ai[0] += 0.1f;
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
        /*
        public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
        {
            target.AddBuff(mod.BuffType("Electrified"), (int)(120*mystDur));
            //if (target.GetGlobalNPC<LaugicalGlobalNPCs>(mod).mysticDamage < mystDmg)target.GetGlobalNPC<LaugicalGlobalNPCs>(mod).mysticDamage = mystDmg;
        }*/
    }
}