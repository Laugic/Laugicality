using System;
using Laugicality.Buffs;
using Laugicality.Dusts;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;

namespace Laugicality.NPCs.RockTwins
{
    public class AnDioSpiral2 : ModProjectile
    {
        public bool bitherial = true;
        public bool stopped = false;
        public int power = 0;
        public int damage = 0;
        public int delay = 0;
        public bool spawned = false;
        public float theta = 0;
        public float vel = 0;
        public bool zImmune = true;
        public float tVel = 0;
        public float distance = 0;
        public double targetX = 0;
        public double targetY = 0;

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("AnDio Spiral");
        }
        public override void SetDefaults()
        {
            zImmune = true;
            theta = 0;
            vel = 0;
            LaugicalityVars.eProjectiles.Add(projectile.type);
            power = 0;
            stopped = false;
            spawned = false;
            projectile.width = 20;
            projectile.height = 20;
            projectile.penetrate = -1;
            projectile.hostile = true;
            projectile.timeLeft = 10 * 60;
            projectile.ignoreWater = true;
            projectile.tileCollide = false;
            delay = 0;
        }


        public override void AI()
        {
            bitherial = true;
            Dust.NewDust(projectile.position + projectile.velocity, projectile.width, projectile.height, ModContent.DustType<Blue>(), 0f, 0f);
            projectile.rotation = (float)Math.Atan2((double)projectile.velocity.Y, (double)projectile.velocity.X);
            theta -= 3.14f / 60;
            int mag = 360;
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
                        distance = distanceTo;
                        targetX = Main.player[k].position.X + mag * Math.Cos(theta + 3.14) - projectile.width / 2;
                        targetY = Main.player[k].position.Y + mag * Math.Sin(theta + 3.14);
                    }
                }
            }
            distance = (float)Math.Sqrt((targetX - projectile.position.X) * (targetX - projectile.position.X) + (targetY - projectile.position.Y) * (targetY - projectile.position.Y));
            tVel = distance / 10;

            if (vel < tVel)
            {
                vel += .1f;
                vel *= 1.05f;
            }
            if (vel > tVel)
            {
                vel -= .1f;
                vel *= .95f;
            }
            projectile.velocity.X = (float)Math.Abs((projectile.position.X - targetX) / distance * vel);
            if (targetX < projectile.position.X)
                projectile.velocity.X *= -1;
            projectile.velocity.Y = (float)Math.Abs((projectile.position.Y - targetY) / distance * vel);
            if (targetY < projectile.position.Y)
                projectile.velocity.Y *= -1;
            delay++;
            if((delay > 6 * 60 && Main.rand.Next(10 * 60 - delay) == 0 && Main.rand.Next(2) == 0) || delay > 9 * 60 + 50)
            {   
                if (Main.netMode != 1)
                {
                    Projectile.NewProjectile(projectile.Center.X, projectile.Center.Y, 7, 0, ModContent.ProjectileType<DioBall>(), (int)(projectile.damage / 1.2f), 3, Main.myPlayer);
                    Projectile.NewProjectile(projectile.Center.X, projectile.Center.Y, -7, 0, ModContent.ProjectileType<DioBall>(), (int)(projectile.damage / 1.2f), 3, Main.myPlayer);
                    Projectile.NewProjectile(projectile.Center.X, projectile.Center.Y, 0, 7, ModContent.ProjectileType<DioBall>(), (int)(projectile.damage / 1.2f), 3, Main.myPlayer);
                    Projectile.NewProjectile(projectile.Center.X, projectile.Center.Y, 0, -7, ModContent.ProjectileType<DioBall>(), (int)(projectile.damage / 1.2f), 3, Main.myPlayer);
                    Projectile.NewProjectile(projectile.Center.X, projectile.Center.Y, 5, 5, ModContent.ProjectileType<DioBall>(), (int)(projectile.damage / 1.2f), 3, Main.myPlayer);
                    Projectile.NewProjectile(projectile.Center.X, projectile.Center.Y, 5, -5, ModContent.ProjectileType<DioBall>(), (int)(projectile.damage / 1.2f), 3, Main.myPlayer);
                    Projectile.NewProjectile(projectile.Center.X, projectile.Center.Y, -5, -5, ModContent.ProjectileType<DioBall>(), (int)(projectile.damage / 1.2f), 3, Main.myPlayer);
                    Projectile.NewProjectile(projectile.Center.X, projectile.Center.Y, -5, 5, ModContent.ProjectileType<DioBall>(), (int)(projectile.damage / 1.2f), 3, Main.myPlayer);
                }
                projectile.Kill();
            }
        }

        public override void OnHitPlayer(Player player, int dmgDealt, bool crit)
        {
            player.AddBuff(ModContent.BuffType<ForHonor>(), 300, true);
            player.AddBuff(ModContent.BuffType<ForGlory>(), 300, true);
        }
    }
}