using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;

namespace Laugicality.NPCs.RockTwins
{
	public class DioEnergy : ModProjectile
    {
        public bool bitherial = true;
        public bool stopped = false;
        public int power = 0;
        public bool spawned = false;

        public override void SetDefaults()
        {
            LaugicalityVars.eProjectiles.Add(projectile.type);
            power = 0;
            stopped = false;
            spawned = false;
            //mystDmg = (float)projectile.damage;
            //mystDur = 1f + projectile.knockBack;
            projectile.width = 22;
            projectile.height = 22;
            projectile.penetrate = -1;
            projectile.hostile = true;
            projectile.timeLeft = 320;
            projectile.ignoreWater = true;
            projectile.tileCollide = false;
        }


        public override void AI()
        {
            bitherial = true;
            Dust.NewDust(projectile.position + projectile.velocity, projectile.width, projectile.height, ModContent.DustType("Red"), 0f, 0f);
            if (!spawned)
            {
                if (projectile.localAI[0] == 0f)
                {
                    AdjustMagnitude(ref projectile.velocity);
                    projectile.localAI[0] = 1f;
                }
                Vector2 move = Vector2.Zero;
                float distance = 1400f;
                bool target = false;
                for (int k = 0; k < 8; k++)
                {
                    if (Main.player[k].active)
                    {
                        Vector2 newMove = Main.player[k].Center - projectile.Center;
                        float distanceTo = (float)Math.Sqrt(newMove.X * newMove.X + newMove.Y * newMove.Y);
                        if (distanceTo < distance)
                        {
                            move = newMove;
                            distance = distanceTo;
                            target = true;
                        }
                    }
                }
                if (target)
                {
                    AdjustMagnitude(ref move);
                    projectile.velocity = (10 * projectile.velocity + move) / 11f;
                    AdjustMagnitude(ref projectile.velocity);
                }
                projectile.velocity *= 24;
                spawned = true;
            }
            projectile.rotation = (float)Math.Atan2((double)projectile.velocity.Y, (double)projectile.velocity.X);
            projectile.velocity.X *= .94f;
            projectile.velocity.Y *= .94f;
            if(Math.Abs(projectile.velocity.X) <= .2 && Math.Abs(projectile.velocity.X) <= .2)
            {
                stopped = true;
            }
            if (stopped && Main.netMode != 1)
            {
                    Projectile.NewProjectile(projectile.Center.X, projectile.Center.Y, 7, 0, ModContent.ProjectileType("DioBall"), (int)(projectile.damage / 1.2f), 3, Main.myPlayer);
                    Projectile.NewProjectile(projectile.Center.X, projectile.Center.Y, -7, 0, ModContent.ProjectileType("DioBall"), (int)(projectile.damage / 1.2f), 3, Main.myPlayer);
                    Projectile.NewProjectile(projectile.Center.X, projectile.Center.Y, 0, 7, ModContent.ProjectileType("DioBall"), (int)(projectile.damage / 1.2f), 3, Main.myPlayer);
                    Projectile.NewProjectile(projectile.Center.X, projectile.Center.Y, 0, -7, ModContent.ProjectileType("DioBall"), (int)(projectile.damage / 1.2f), 3, Main.myPlayer);
                    Projectile.NewProjectile(projectile.Center.X, projectile.Center.Y, 5, 5, ModContent.ProjectileType("DioBall"), (int)(projectile.damage / 1.2f), 3, Main.myPlayer);
                    Projectile.NewProjectile(projectile.Center.X, projectile.Center.Y, 5, -5, ModContent.ProjectileType("DioBall"), (int)(projectile.damage / 1.2f), 3, Main.myPlayer);
                    Projectile.NewProjectile(projectile.Center.X, projectile.Center.Y, -5, -5, ModContent.ProjectileType("DioBall"), (int)(projectile.damage / 1.2f), 3, Main.myPlayer);
                    Projectile.NewProjectile(projectile.Center.X, projectile.Center.Y, -5, 5, ModContent.ProjectileType("DioBall"), (int)(projectile.damage / 1.2f), 3, Main.myPlayer);
                    projectile.Kill();
                }
            }
        // Dust.NewDust(projectile.position + projectile.velocity, projectile.width, projectile.height, ModContent.DustType("Pink"), projectile.velocity.X * 0.5f, projectile.velocity.Y * 0.5f);



        private void AdjustMagnitude(ref Vector2 vector)
        {
            float magnitude = (float)Math.Sqrt(vector.X * vector.X + vector.Y * vector.Y);
            if (magnitude > 6f)
            {
                vector *= 6f / magnitude;
            }
        }


        public override void OnHitPlayer(Player player, int dmgDealt, bool crit)
        {
            player.AddBuff(ModContent.BuffType("ForGlory"), 300, true);
        }


    }


        
    
}