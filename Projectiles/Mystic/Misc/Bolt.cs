using Terraria;
using Microsoft.Xna.Framework;
using Terraria.ModLoader;
using System.Collections.Generic;
using Microsoft.Xna.Framework.Graphics;
using System;
using Laugicality.Buffs;

namespace Laugicality.Projectiles.Mystic.Misc
{
	public class Bolt : MysticProjectile
    {
        Vector2 projGoal;
        int delay = 0;
        int nextBolt = 0;
        List<Vector2> Trails { get; set; }
        public override void SetDefaults()
        {
            projectile.width = 14;
            projectile.height = 14;
            projectile.penetrate = -1;
            projectile.timeLeft = 120;
			projectile.friendly = true;
            projectile.ignoreWater = true;
            projectile.extraUpdates = 5;
            Trails = new List<Vector2>();
            projGoal = projectile.Center;
            delay = 0;
            nextBolt = 0;
            projectile.tileCollide = false;
            //buffID = ModContent.BuffType<CosmicDisarray>();
        }

        public override void AI()
        {
            projectile.rotation = (float)Math.Atan2((double)projectile.velocity.Y, (double)projectile.velocity.X) + 1.57f;

            if (Trails.Count == 0)
                Prime();

            BoltMove();

            Dust.NewDust(projectile.position + projectile.velocity, projectile.width, projectile.height, 228, 0, 0);
        }

        private void BoltMove()
        {
            delay--;
            if (delay <= 0)
            {
                Trails.Add(projectile.Center);

                if (projectile.ai[0] != 0)
                {
                    nextBolt--;
                    if (nextBolt <= 0)
                        SpawnBolt();
                }

                projectile.velocity = projGoal - projectile.Center;
                projectile.velocity.Normalize();
                projectile.velocity *= 12;
                projectile.velocity = projectile.velocity.RotatedByRandom(3);
                var rand = new Random();
                delay = rand.Next(6, 16);
            }
        }

        private void SpawnBolt()
        {
            if(Main.myPlayer == projectile.owner)
            {
                int p = Projectile.NewProjectile(projectile.position.X, projectile.position.Y, projectile.velocity.X, projectile.velocity.Y, ModContent.ProjectileType<Bolt>(), (int)(projectile.damage), 8, Main.myPlayer);
                Main.projectile[p].timeLeft = projectile.timeLeft;
            }
            nextBolt = (int)projectile.ai[0];
        }

        private void Prime()
        {
            Trails.Add(projectile.Center);
            projectile.velocity.Normalize();
            projectile.velocity *= 12;
            projGoal = projectile.Center + projectile.velocity * 6000;

            projectile.velocity = projGoal - projectile.Center;
            projectile.velocity.Normalize();
            projectile.velocity *= 12;
            projectile.velocity.RotatedByRandom(2);
            var rand = new Random();
            delay = rand.Next(6, 16);

            if (projectile.ai[0] != 0)
                nextBolt = (int)projectile.ai[0];

            if(projectile.ai[1] == 1)
                buffID = ModContent.BuffType<ThunderCharged>();
        }

        public override void Kill(int timeLeft)
		{

        }

        public override bool PreDraw(SpriteBatch spriteBatch, Color lightColor)
        {
            if(Trails.Count > 0)
            {
                var curPos = Trails[0];
                Vector2 nextPos = projectile.Center;
                for (int i = 0; i < Trails.Count; i++)
                {
                    curPos = Trails[i];
                    if (i == Trails.Count - 1)
                        nextPos = projectile.Center;
                    else
                        nextPos = Trails[i + 1];
                    Laugicality.DrawChain(spriteBatch, mod.GetTexture("Projectiles/Mystic/Misc/BoltChain"), curPos, nextPos, .5f, Color.White);
                }
            }
            return true;
        }
    }
}