using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Laugicality.Extensions;


namespace Laugicality.Projectiles.SoulStone
{
    public class FriendlyDungeonGuardianPrime : ModProjectile
    {
        Vector2 targetPos;
        int counter = 0;

        public override void SetDefaults()
        {
            projectile.width = 42;
            projectile.height = 42;
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
                if (npc.life < 1)
                    projectile.ai[0] = 0;
                else
                    HomeIn(npc);
            }
            else
                Wander();

            if (!Main.player[projectile.owner].active)
                projectile.Kill();

            LaugicalityPlayer laugicalityPlayer = LaugicalityPlayer.Get(Main.player[projectile.owner]);

            if (!laugicalityPlayer.Focus.IsCapacity() || !laugicalityPlayer.SkeletronPrimeEffect)
                projectile.Kill();
        }
        
        public void CheckActive()
        {
            if (Main.player[projectile.owner].statLife <= Main.player[projectile.owner].statLifeMax2 / 2 + 1)
                projectile.timeLeft = 4;
        }

        public void GetTarget()
        {
            float dist = 500;

            foreach(NPC npc in Main.npc)
            {
                if(npc.damage > 0 && npc.type != NPCID.TargetDummy && !npc.townNPC)
                {
                    if (npc.Distance(projectile.Center) < dist)
                    {
                        dist = npc.Distance(projectile.Center);
                        projectile.ai[0] = npc.whoAmI;
                    }
                    if (npc.Distance(Main.player[projectile.owner].Center) < dist / 2)
                    {
                        dist = npc.Distance(Main.player[projectile.owner].Center);
                        projectile.ai[0] = npc.whoAmI;
                    }
                }
            }
            if (projectile.Distance(Main.player[projectile.owner].Center) > 800)
            {
                projectile.ai[0] = 0;
                Wander();
            }
        }

        public void HomeIn(NPC npc)
        {
            projectile.rotation += .08f;
            projectile.velocity = projectile.DirectionTo(npc.Center) * 6;
            counter = 0;
            if (!npc.active || npc.life < 1 || npc.type == NPCID.TargetDummy)
                projectile.ai[0] = 0;
        }

        public void Wander()
        {
            Player player = Main.player[projectile.owner];
            projectile.rotation += .06f;
            if(counter <= 0)
            {
                counter = Main.rand.Next(60, 120);
                float wanderTheta = Main.rand.NextFloat() * 2 * (float)Math.PI;
                float mag = Main.rand.NextFloat() * 60 + 60;
                targetPos.X = (float)Math.Cos(wanderTheta) * mag;
                targetPos.Y = (float)Math.Sin(wanderTheta) * mag / 2;
            }
            counter--;

            float dist = Vector2.Distance(player.Center + targetPos, projectile.position);
            if (dist >= 4)
            {
                float tVel = dist / 25;
                if (tVel > 12)
                    tVel = 12;
                projectile.velocity = projectile.DirectionTo(Main.player[projectile.owner].Center + targetPos) * tVel;
            }
        }
    }
}