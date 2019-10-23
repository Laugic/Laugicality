using System;
using Laugicality.Buffs;
using Laugicality.Dusts;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;

namespace Laugicality.NPCs.RockTwins
{
    public class AnDioEnergy : ModProjectile
    {
        public bool bitherial = true;
        public bool stopped = false;
        public int power = 0;
        public bool spawned = false;
        public int time = 0;
        public bool zImmune = true;

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("AnDio Energy");
        }
        public override void SetDefaults()
        {
            zImmune = true;
            time = 0;
            LaugicalityVars.eProjectiles.Add(projectile.type);
            power = 0;
            stopped = false;
            spawned = false;
            //mystDmg = (float)projectile.damage;
            //mystDur = 1f + projectile.knockBack;
            projectile.width = 24;
            projectile.height = 24;
            projectile.penetrate = -1;
            projectile.hostile = true;
            projectile.timeLeft = 320;
            projectile.ignoreWater = true;
            projectile.tileCollide = false;
            projectile.scale = 1.25f;
        }


        public override void AI()
        {
            bitherial = true;
            Dust.NewDust(projectile.position + projectile.velocity, projectile.width, projectile.height, ModContent.DustType<Red>(), 0f, 0f);
            Dust.NewDust(projectile.position + projectile.velocity, projectile.width, projectile.height, ModContent.DustType<Blue>(), 0f, 0f);
            projectile.rotation = (float)Math.Atan2((double)projectile.velocity.Y, (double)projectile.velocity.X);
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
                projectile.velocity = (20 * projectile.velocity + move) / 2f;
                AdjustMagnitude(ref projectile.velocity);
            }
            time++;
            if (time > 180 && Main.netMode != 1)
            {
                int dist = 3;
                Projectile.NewProjectile(projectile.Center.X, projectile.Center.Y, 7, 0, ModContent.ProjectileType<DioBall>(), (int)(projectile.damage / 1.2f), 3, Main.myPlayer);
                Projectile.NewProjectile(projectile.Center.X, projectile.Center.Y, -7, 0, ModContent.ProjectileType<DioBall>(), (int)(projectile.damage / 1.2f), 3, Main.myPlayer);
                Projectile.NewProjectile(projectile.Center.X, projectile.Center.Y, 0, 7, ModContent.ProjectileType<DioBall>(), (int)(projectile.damage / 1.2f), 3, Main.myPlayer);
                Projectile.NewProjectile(projectile.Center.X, projectile.Center.Y, 0, -7, ModContent.ProjectileType<DioBall>(), (int)(projectile.damage / 1.2f), 3, Main.myPlayer);
                Projectile.NewProjectile(projectile.Center.X, projectile.Center.Y, 5, 5, ModContent.ProjectileType<DioBall>(), (int)(projectile.damage / 1.2f), 3, Main.myPlayer);
                Projectile.NewProjectile(projectile.Center.X, projectile.Center.Y, 5, -5, ModContent.ProjectileType<DioBall>(), (int)(projectile.damage / 1.2f), 3, Main.myPlayer);
                Projectile.NewProjectile(projectile.Center.X, projectile.Center.Y, -5, -5, ModContent.ProjectileType<DioBall>(), (int)(projectile.damage / 1.2f), 3, Main.myPlayer);
                Projectile.NewProjectile(projectile.Center.X, projectile.Center.Y, -5, 5, ModContent.ProjectileType<DioBall>(), (int)(projectile.damage / 1.2f), 3, Main.myPlayer);
                Projectile.NewProjectile(projectile.Center.X, projectile.Center.Y, 0, 0, ModContent.ProjectileType<DioBallShot>(), (int)(projectile.damage / 1.2f), 3, Main.myPlayer);
                /*Projectile.NewProjectile(projectile.position.X + 140 * dist, projectile.position.Y + 000 * dist, -.7f, 0.0f, ModContent.ProjectileType<AndeBall>(), (int)(projectile.damage / 1.2f), 3f, Main.myPlayer);
                Projectile.NewProjectile(projectile.position.X + 100 * dist, projectile.position.Y - 100 * dist, -.5f, 0.5f, ModContent.ProjectileType<AndeBall>(), (int)(projectile.damage / 1.2f), 3f, Main.myPlayer);
                Projectile.NewProjectile(projectile.position.X + 000 * dist, projectile.position.Y - 140 * dist, -.0f, 0.7f, ModContent.ProjectileType<AndeBall>(), (int)(projectile.damage / 1.2f), 3f, Main.myPlayer);
                Projectile.NewProjectile(projectile.position.X - 100 * dist, projectile.position.Y - 100 * dist, 0.5f, 0.5f, ModContent.ProjectileType<AndeBall>(), (int)(projectile.damage / 1.2f), 3f, Main.myPlayer);
                Projectile.NewProjectile(projectile.position.X - 140 * dist, projectile.position.Y + 000 * dist, 0.7f, 0.0f, ModContent.ProjectileType<AndeBall>(), (int)(projectile.damage / 1.2f), 3f, Main.myPlayer);
                Projectile.NewProjectile(projectile.position.X - 100 * dist, projectile.position.Y + 100 * dist, 0.5f, -.5f, ModContent.ProjectileType<AndeBall>(), (int)(projectile.damage / 1.2f), 3f, Main.myPlayer);
                Projectile.NewProjectile(projectile.position.X + 000 * dist, projectile.position.Y + 140 * dist, -.0f, -.7f, ModContent.ProjectileType<AndeBall>(), (int)(projectile.damage / 1.2f), 3f, Main.myPlayer);
                Projectile.NewProjectile(projectile.position.X + 100 * dist, projectile.position.Y + 100 * dist, -.5f, -.5f, ModContent.ProjectileType<AndeBall>(), (int)(projectile.damage / 1.2f), 3f, Main.myPlayer);*/
                projectile.Kill();
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


        public override void OnHitPlayer(Player player, int dmgDealt, bool crit)
        {
            player.AddBuff(ModContent.BuffType<ForHonor>(), 300, true);
            player.AddBuff(ModContent.BuffType<ForGlory>(), 300, true);
        }
    }
}