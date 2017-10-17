using System.Collections.Generic;
using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Laugicality;

namespace Laugicality.NPCs.PreTrio
{
    public class RockLoose : ModProjectile
    {
        public int spawned = 0;
        public int delay = 0;
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("a Loose Rock");
        }

        public override void SetDefaults()
        {
            delay = 0;
            spawned = 0;
            projectile.width = 32;
            projectile.height = 32;
            projectile.alpha = 0;
            projectile.timeLeft = 240;
            projectile.friendly = false;
            projectile.hostile = true;
            projectile.ignoreWater = true;
            projectile.tileCollide = false;
            
        }

        public override void AI()
        {
            Dust.NewDust(projectile.position + projectile.velocity, projectile.width, projectile.height, 127, 0f, 0f);
            projectile.rotation -= 0.02f;
            if (spawned == 0) { 
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
                projectile.velocity = (16 * projectile.velocity + move) / 11f;
                AdjustMagnitude(ref projectile.velocity);
            }
                projectile.velocity *= 24;
                spawned = 1;
            }

            if (Main.expertMode)
                delay += 1;
            if (delay >= 60)
            {
                {
                    Projectile.NewProjectile(projectile.Center.X, projectile.Center.Y, 8, 0, mod.ProjectileType("MiniRock"), (int)(projectile.damage / 2f), 3, Main.myPlayer);
                    Projectile.NewProjectile(projectile.Center.X, projectile.Center.Y, -8, 0, mod.ProjectileType("MiniRock"), (int)(projectile.damage / 2f), 3, Main.myPlayer);
                    Projectile.NewProjectile(projectile.Center.X, projectile.Center.Y, 0, 8, mod.ProjectileType("MiniRock"), (int)(projectile.damage / 2f), 3, Main.myPlayer);
                    Projectile.NewProjectile(projectile.Center.X, projectile.Center.Y, 0, -8, mod.ProjectileType("MiniRock"), (int)(projectile.damage / 2f), 3, Main.myPlayer);
                    Projectile.NewProjectile(projectile.Center.X, projectile.Center.Y, 4, 4, mod.ProjectileType("MiniRock"), (int)(projectile.damage / 2f), 3, Main.myPlayer);
                    Projectile.NewProjectile(projectile.Center.X, projectile.Center.Y, 4, -4, mod.ProjectileType("MiniRock"), (int)(projectile.damage / 2f), 3, Main.myPlayer);
                    Projectile.NewProjectile(projectile.Center.X, projectile.Center.Y, -4, -4, mod.ProjectileType("MiniRock"), (int)(projectile.damage / 2f), 3, Main.myPlayer);
                    Projectile.NewProjectile(projectile.Center.X, projectile.Center.Y, -4, 4, mod.ProjectileType("MiniRock"), (int)(projectile.damage / 2f), 3, Main.myPlayer);
                    projectile.Kill();
                }
            }
        }



        private void AdjustMagnitude(ref Vector2 vector)
        {
            float magnitude = (float)Math.Sqrt(vector.X * vector.X + vector.Y * vector.Y);
            if (magnitude > 6f)
            {
                vector *= 6f / magnitude;
            }
        }

        public override void OnHitPlayer(Player target, int dmgDealt, bool crit)
        {
            //NPCs.Slybertron.Slybertron.coginatorHits += 1;
            int debuff = BuffID.OnFire;
            if (debuff >= 0)
            {
                target.AddBuff(debuff, 90, true);
            }      //Add Onfire buff to the NPC for 1 second
        }
    }
}