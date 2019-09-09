using System.Collections.Generic;
using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Laugicality;


namespace Laugicality.Projectiles.SoulStone
{
    public class FriendlyProbeProj : ModProjectile
    {
        float theta = 0;
        Vector2 targetPos;
        int counter = 0;

        public override void SetDefaults()
        {
            projectile.width = 24;
            projectile.height = 24;
            projectile.friendly = true;
            projectile.penetrate = -1;
            projectile.timeLeft = 800;
            projectile.ignoreWater = true;
            projectile.tileCollide = false;
        }

        public override void AI()
        {
            GetTarget();
            if (projectile.ai[0] != 0)
            {
                Move();
                NPC npc = Main.npc[(int)projectile.ai[0]];
                if (!npc.active)
                    projectile.ai[0] = 0;
                else
                    Shoot(npc);
            }
            else
                Wander();
        }

        public void GetTarget()
        {
            float dist = 700;

            foreach (NPC npc in Main.npc)
            {
                if (npc.damage > 0)
                {
                    if (npc.Distance(projectile.Center) < dist && npc.life > 0)
                    {
                        dist = npc.Distance(projectile.Center);
                        projectile.ai[0] = npc.whoAmI;
                    }
                    if (npc.Distance(Main.player[projectile.owner].Center) < dist / 2 && npc.life > 0)
                    {
                        dist = npc.Distance(Main.player[projectile.owner].Center);
                        projectile.ai[0] = npc.whoAmI;
                    }
                }
            }
            if (!Main.npc[(int)projectile.ai[0]].active || Main.npc[(int)projectile.ai[0]].life < 1)
                projectile.ai[0] = 0;
        }

        public void Shoot(NPC npc)
        {
            if (counter <= 0)
            {
                counter = Main.rand.Next(100, 160);
                Main.PlaySound(2, (int)projectile.position.X, (int)projectile.position.Y, 33, 1f, 0f);
                Projectile.NewProjectile(projectile.position, new Vector2(projectile.DirectionTo(npc.Center).X * 12, projectile.DirectionTo(npc.Center).Y * 12), mod.ProjectileType<FriendlyProbeLaserProj>(), projectile.damage, 4, projectile.owner);
            }
            else
                counter--;

            projectile.rotation = projectile.DirectionTo(Main.npc[(int)projectile.ai[0]].Center).ToRotation();
        }

        public void Move()
        {
            NPC npc = Main.npc[(int)projectile.ai[0]];

            theta += (float)Math.PI / 120;
            targetPos.X = (float)Math.Cos(theta) * 80;
            targetPos.Y = (float)Math.Sin(theta) * 80;

            float dist = Vector2.Distance(npc.Center + targetPos, projectile.position);
            if (dist != 0)
            {
                float tVel = dist / 15;
                projectile.velocity = projectile.DirectionTo(npc.Center + targetPos) * tVel;
            }
        }

        public void Wander()
        {
            Player player = Main.player[projectile.owner];
            theta += (float)Math.PI / 120;
            targetPos.X = (float)Math.Cos(theta) * 80;
            targetPos.Y = (float)Math.Sin(theta) * 80;

            float dist = Vector2.Distance(player.Center + targetPos, projectile.position);
            if (dist != 0)
            {
                float tVel = dist / 15;
                projectile.velocity = projectile.DirectionTo(player.Center + targetPos) * tVel;
            }
        }
    }
}