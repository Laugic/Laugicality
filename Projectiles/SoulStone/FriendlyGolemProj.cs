using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;
using Laugicality.Extensions;


namespace Laugicality.Projectiles.SoulStone
{
    public class FriendlyGolemProj : ModProjectile
    {
        float theta = 0;
        int cooldown = 0;
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
            CheckActive();
            GetTarget();

            if (projectile.ai[0] != 0)
            {
                NPC npc = Main.npc[(int)projectile.ai[0]];
                if (!npc.active)
                    projectile.ai[0] = 0;
                else
                    Shoot(npc);
            }
            else
            {
                if(projectile.velocity.X < 0)
                    projectile.spriteDirection = -1;
                else
                    projectile.spriteDirection = 1;
            }

            Wander();

            if (!Main.player[projectile.owner].active)
                projectile.Kill();

            LaugicalityPlayer laugicalityPlayer = LaugicalityPlayer.Get(Main.player[projectile.owner]);

            if (!laugicalityPlayer.Focus.IsCapacity() || !laugicalityPlayer.GolemEffect)
                projectile.Kill();
        }

        public void CheckActive()
        {
            if (Main.player[projectile.owner].statLife <= Main.player[projectile.owner].statLifeMax2 / 2 + 1)
                projectile.timeLeft = 4;
        }

        public void GetTarget()
        {
            float dist = 700;

            foreach (NPC npc in Main.npc)
            {
                if (npc.damage > 0)
                {
                    if (npc.Distance(projectile.Center) < dist)
                    {
                        dist = npc.Distance(projectile.Center);
                        projectile.ai[0] = npc.whoAmI;
                        if (npc.position.X < projectile.position.X)
                            projectile.spriteDirection = -1;
                        else
                            projectile.spriteDirection = 1;
                    }
                    if (npc.Distance(Main.player[projectile.owner].Center) < dist / 2)
                    {
                        dist = npc.Distance(Main.player[projectile.owner].Center);
                        projectile.ai[0] = npc.whoAmI;
                        if (npc.position.X < projectile.position.X)
                            projectile.spriteDirection = -1;
                        else
                            projectile.spriteDirection = 1;
                    }
                }
            }
            if (!Main.npc[(int)projectile.ai[0]].active)
                projectile.ai[0] = 0;
        }

        public void Shoot(NPC npc)
        {
            if (counter <= 0)
            {
                counter = Main.rand.Next(100, 160);
                Main.PlaySound(2, (int)projectile.position.X, (int)projectile.position.Y, 33, 1f, 0f);
                if (Main.myPlayer == projectile.owner)
                    Projectile.NewProjectile(projectile.position, new Vector2(projectile.DirectionTo(npc.Center).X * 12, projectile.DirectionTo(npc.Center).Y * 12), ModContent.ProjectileType<FriendlyEyeLaserProj>(), 150, 4, projectile.owner);
            }
            else
                counter--;
        }

        public void Wander()
        {
            Player player = Main.player[projectile.owner];
            theta += (float)Math.PI / 60;
            targetPos.X = 0;
            targetPos.Y = -45 + (float)Math.Sin(theta) * 20;

            float dist = Vector2.Distance(player.Center + targetPos, projectile.position);
            if (dist != 0)
            {
                float tVel = dist / 15;
                projectile.velocity = projectile.DirectionTo(Main.player[projectile.owner].Center + targetPos) * tVel;
            }
        }
    }
}