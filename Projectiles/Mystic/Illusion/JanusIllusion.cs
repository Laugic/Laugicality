using Laugicality.Buffs;
using Laugicality.Dusts;
using Microsoft.Xna.Framework;
using System;
using Terraria;
using Terraria.ModLoader;

namespace Laugicality.Projectiles.Mystic.Illusion
{
    public class JanusIllusion : IllusionProjectile
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Janus Arrow");
        }

        public override void SetDefaults()
        {
            projectile.width = 18;
            projectile.height = 18;
            projectile.aiStyle = 1;
            projectile.friendly = true;
            projectile.hostile = false;
            projectile.ranged = true;
            projectile.penetrate = 1;
            projectile.timeLeft = 600;
            projectile.ignoreWater = true;
            projectile.tileCollide = true;
            buffID = ModContent.BuffType<SandyBuff>();
        }
        public override void AI()
        {
            Vector2 newVel = -projectile.velocity * 2 / 3f;
            float theta = Main.rand.Next(-30, 30) * (float)Math.PI / 180;
            float mag = Main.rand.Next(3, 7);
            newVel.X += (float)Math.Cos(theta) * mag;
            newVel.Y += (float)Math.Sin(theta) * mag;
            Dust.NewDust(projectile.position - projectile.velocity, projectile.width, projectile.height, ModContent.DustType<White>(), newVel.X, newVel.Y);
        }

        public override void Kill(int timeLeft)
        {
            Player player = Main.player[projectile.owner];
            Burst(player.Center);
            Vector2 dist = projectile.Center - player.Center;
            if(player.active && dist.Length() < 2000)
            {
                var telepos = projectile.position;
                telepos.Y -= 32;
                player.Teleport(telepos);
                Burst(player.Center);
                player.immune = true;
                player.immuneTime = 15;
            }
        }

        private void Burst(Vector2 pos)
        {
            if (Main.myPlayer == projectile.owner)
            {
                for (int i = 0; i < 20; i++)
                {
                    var theta = (float)(Math.PI * -Main.rand.NextDouble());
                    Vector2 newVel = new Vector2((float)Math.Cos(theta), (float)Math.Sin(theta));
                    newVel *= 12;
                    Projectile.NewProjectile(pos.X, pos.Y, newVel.X, newVel.Y, ModContent.ProjectileType<JanusIllusionSandball>(), projectile.damage / 2, 3, Main.myPlayer);
                }
            }
        }
    }
}
