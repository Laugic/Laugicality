using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework.Graphics;

namespace Laugicality.Projectiles
{
    public class ArcticHydraHead : ModProjectile
    {
        public float dust = 0f;
        bool justSpawned = false;
        Vector2 offSet;
        float mag = 20;
        float range = 200;
        Vector2 targetPos;
        bool targetFound = false;
        int npcTarget = -1;
        float npcDistance = 8000;
        float theta = 0;
        int delay = 0;
        int index = 0;
        float vMag = 0;
        int shootDelay = 0;
        public override void SetDefaults()
        {
            justSpawned = false;
            projectile.width = 38;
            projectile.height = 38;
            projectile.netImportant = true;
            projectile.friendly = true;
            projectile.ignoreWater = true;
            projectile.minionSlots = 1;
            projectile.timeLeft = 18000;
            ProjectileID.Sets.MinionSacrificable[projectile.type] = true;
            projectile.penetrate = -1;
            projectile.tileCollide = false;
            projectile.timeLeft *= 5;
            projectile.minion = true;
        }

        private void CheckActive()
        {
            Player player = Main.player[projectile.owner];
            LaugicalityPlayer modPlayer = player.GetModPlayer<LaugicalityPlayer>(mod);
            if (player.dead)
            {
                modPlayer.ArcticHydraSummon = false;
            }
            if (modPlayer.ArcticHydraSummon)
            {
                projectile.timeLeft = 2;
            }
            if (!justSpawned)
            {
                justSpawned = true;
                GetMinionSlots(player.ownedProjectileCounts[mod.ProjectileType("ArcticHydraHead")]);
                range = 200 + 50 * player.ownedProjectileCounts[mod.ProjectileType("ArcticHydraHead")];
                projectile.damage += index * 20;
                if ((Main.player[projectile.owner].GetModPlayer<LaugicalityPlayer>(mod).etherable > 2 || LaugicalityWorld.downedEtheria) && LaugicalityWorld.downedTrueEtheria)
                {
                    projectile.damage += 20 * index;
                    range = range * 2;
                }
                targetPos.X = player.Center.X;
                targetPos.Y = player.Center.Y;
                theta = (float)(Main.rand.NextDouble() * Math.PI * 2);
                index = player.ownedProjectileCounts[mod.ProjectileType("ArcticHydraHead")];
                offSet.X = 10 * index * (float)Math.Cos(Math.PI / 4 * index);
                if (index == 1)
                    offSet.X = 20;
                offSet.Y = -30 - (8 * index * Math.Abs((float)Math.Sin(Math.PI / 4 * index)));
            }
        }

        public override void AI()
        {
            CheckActive();
            GetTarget();
            Movement();
            if(npcTarget != -1)
                Shoot();
            GetDirection();
        }

        private void GetTarget()
        {
            targetFound = false;
            npcTarget = -1;
            npcDistance = 8000;
            foreach (NPC npc in Main.npc)
            {
                if (npc.damage > 0)
                {
                    Vector2 newMove = npc.Center - projectile.Center;
                    float distanceTo = (float)Math.Sqrt(newMove.X * newMove.X + newMove.Y * newMove.Y);
                    if (Main.player[projectile.owner].Distance(npc.Center) <= range && projectile.Distance(npc.Center) < npcDistance)
                    {
                        npcTarget = npc.whoAmI;
                        targetPos = npc.Center;
                        npcDistance = projectile.Distance(npc.Center);
                    }
                }
            }
            if (npcTarget != -1)
            {
                if (!Main.npc[npcTarget].active)
                {
                    npcTarget = -1;
                    npcDistance = 8000;
                }
            }
        }

        private void Movement()
        {
            //if(npcTarget == -1 || index % 2 == 0)
            //{
                targetPos = Main.player[projectile.owner].Center;
                targetPos += offSet;
            //}
            theta += (float)Math.PI / 60f;
            targetPos.Y = targetPos.Y + 8 * (float)Math.Sin(theta);
            MoveToTarget();
        }

        private void MoveToTarget()
        {
            delay++;
            if (Main.myPlayer == projectile.owner && delay > 10 && npcDistance != 8000)
            {
                float mag = 12f;

                float diffX = targetPos.X - projectile.Center.X;
                float diffY = targetPos.Y - projectile.Center.Y;
                float dist = (float)Math.Sqrt((double)(diffX * diffX + diffY * diffY));
                if(dist != 0)
                    dist = mag / dist;
                diffX *= dist;
                diffY *= dist;

                projectile.velocity.X = (projectile.velocity.X * 20f + diffX) / 21f;
                projectile.velocity.Y = (projectile.velocity.Y * 20f + diffY) / 21f;
                if (Math.Abs(projectile.velocity.X) <= .1f && Math.Abs(diffX) <= .1f)
                    projectile.velocity.X = 0;
                if (Math.Abs(projectile.velocity.Y) <= .1f && Math.Abs(diffY) <= .1f)
                    projectile.velocity.Y = 0;
            }
            else if (Main.myPlayer == projectile.owner && delay > 10 && npcDistance == 8000)
            {
                projectile.velocity = projectile.DirectionTo(targetPos) * (projectile.Distance(targetPos) / 8);
            }
            GetDust();
        }

        private void GetMinionSlots(int numHeads)
        {
            switch((int)numHeads / 2)
            {
                case 0:
                    projectile.minionSlots = 1;
                    break;
                case 1:
                    projectile.minionSlots = .5f;
                    break;
                case 2:
                    projectile.minionSlots = .33f;
                    break;
                default:
                    projectile.minionSlots = .25f;
                    break;
            }
        }

        private void GetDust()
        {
            if (Main.rand.Next(8) == 0)
                Dust.NewDust(projectile.Center, 0, 0, mod.DustType("ArcticHydraSummon"));
        }

        private void Shoot()
        {
            shootDelay++;
            Vector2 vector = Main.npc[npcTarget].Center - projectile.Center;
            float speed = 16f;
            float mag = (float)Math.Sqrt(vector.X * vector.X + vector.Y * vector.Y);
            if (mag > speed && mag != 0)
            {
                mag = speed / mag;
            }
            vector *= mag;
            if (shootDelay >= 60 && Main.myPlayer == projectile.owner && npcDistance != 8000 && npcTarget != -1)
            {
                shootDelay = 0;
                Projectile.NewProjectile(projectile.Center.X, projectile.Center.Y, vector.X, vector.Y, mod.ProjectileType("BysmalBlast2"), projectile.damage, 3f, projectile.owner);
            }
        }

        private void GetDirection()
        {
            if (npcDistance == 8000)
            {
                if (Main.player[projectile.owner].velocity.X > 0f)
                {
                    projectile.spriteDirection = -1;
                }
                if (Main.player[projectile.owner].velocity.X < 0f)
                {
                    projectile.spriteDirection = 1;
                }
            }
            else
            {
                if (projectile.velocity.X > 0f)
                {
                    projectile.spriteDirection = -1;
                }
                if (projectile.velocity.X < 0f)
                {
                    projectile.spriteDirection = 1;
                }
            }
        }
    }
}