using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Laugicality.Extensions;
using Microsoft.Xna.Framework.Graphics;
using Laugicality.Dusts;

namespace Laugicality.Projectiles.Mystic.Conjuration
{
    public class UndeathSkull : PrimaryConjurationProjectile
    {
        Vector2 targetPos;
        int counter = 0;
        double theta = 0;
        int movementType = 0;

        public override void SetDefaults()
        {
            counter = -1;
            movementType = 0;
            projectile.width = 24;
            projectile.height = 24;
            projectile.friendly = true;
            projectile.penetrate = -1;
            projectile.timeLeft = 30 * 60;
            projectile.ignoreWater = true;
            projectile.tileCollide = false;
        }

        public override bool PreDraw(SpriteBatch spriteBatch, Color lightColor)
        {
            projectile.rotation = (float)Math.Atan2((double)projectile.velocity.Y, (double)projectile.velocity.X) + 1.57f;

            Vector2 drawOrigin = new Vector2(Main.projectileTexture[projectile.type].Width * 0.5f, projectile.height * 0.5f);
            for (int k = 0; k < projectile.oldPos.Length; k++)
            {
                Vector2 drawPos = projectile.oldPos[k] - Main.screenPosition + drawOrigin + new Vector2(0f, projectile.gfxOffY);
                Color color = projectile.GetAlpha(lightColor * 0.35f) * ((float)(projectile.oldPos.Length - k) / (float)projectile.oldPos.Length);
                if (projectile.velocity.X < 0f)
                {
                    spriteBatch.Draw(Main.projectileTexture[projectile.type], drawPos, null, color, projectile.rotation, drawOrigin, projectile.scale, SpriteEffects.None, 0f);
                }
                else
                {
                    spriteBatch.Draw(Main.projectileTexture[projectile.type], drawPos, null, color, projectile.rotation, drawOrigin, projectile.scale, SpriteEffects.FlipHorizontally, 0f);
                }
            }
            return true;
        }

        public override void AI()
        {
            CheckActive();
            GetTarget();
            CheckTarget();
            Movement();
            RunCounter();
            MakeDust();
        }

        private void MakeDust()
        {
            for (int i = 0; i < 2; i++)
            {
                float speedX = projectile.velocity.X / 2.5f * (float)i;
                float speedY = projectile.velocity.Y / 2.5f * (float)i;
                int dust = Dust.NewDust(projectile.position, projectile.width, projectile.height, ModContent.DustType<Black>(), 0f, 0f, 75, default(Color));
                Main.dust[dust].position.X = projectile.Center.X - speedX;
                Main.dust[dust].position.Y = projectile.Center.Y - speedY;
                Main.dust[dust].velocity *= 0f;
                Main.dust[dust].noGravity = true;
            }
        }

        private void ResetCounter()
        {
            counter = 0;
            movementType++;
            targetPos = projectile.position;
        }

        private void RunCounter()
        {
            if (counter == -1)
                counter = 60 * (int)projectile.ai[0];

            counter++;
            theta += Math.PI / 60;

            if (movementType == 0 && counter > 3 * 60)
                ResetCounter();
            if (movementType == 1 && counter > 4 * 60)
                ResetCounter();
            if (movementType >= 2)
                movementType = 0;
        }

        private void Movement()
        {
            if (projectile.ai[1] != -1)
                GetMovementType();
            else
                CirclePlayer();
        }

        private void GetMovementType()
        {
            switch (movementType)
            {
                case 0:
                    CirclePlayer();
                    break;
                default:
                    GrabNPC();
                    break;
            }
        }
        private void CheckTarget()
        {
            if (projectile.ai[1] != -1)
            {
                if (Main.npc[(int)projectile.ai[1]].life < 1 || !Main.npc[(int)projectile.ai[1]].active)
                    projectile.ai[1] = -1;
            }
        }

        public void CheckActive()
        {
            if (!Main.player[projectile.owner].active || Main.player[projectile.owner].statLife == 0)
                projectile.Kill();
        }

        public void GetTarget()
        {
            float dist = 1400;

            foreach (NPC npc in Main.npc)
            {
                if (npc.damage > 0 && npc.type != NPCID.TargetDummy && !npc.townNPC && !npc.dontTakeDamage && !npc.friendly)
                {
                    if (npc.Distance(projectile.Center) < dist)
                    {
                        dist = npc.Distance(projectile.Center);
                        projectile.ai[1] = npc.whoAmI;
                    }
                    if (npc.Distance(Main.player[projectile.owner].Center) < dist * .67)
                    {
                        dist = npc.Distance(Main.player[projectile.owner].Center);
                        projectile.ai[1] = npc.whoAmI;
                    }
                }
            }
            if (projectile.Distance(Main.player[projectile.owner].Center) > 2000)
                projectile.ai[1] = -1;
        }

        private void CirclePlayer()
        {
            targetPos = Main.player[(int)projectile.owner].Center;
            targetPos.X += 80 * (float)Math.Cos(theta + Math.PI * projectile.ai[0]);
            targetPos.Y += 80 * (float)Math.Sin(theta + Math.PI * projectile.ai[0]);
            MoveToTargetPos(99);
        }

        private void GrabNPC()
        {
            if(projectile.Distance(targetPos) < 10)
            {
                float dashDist = 80;
                targetPos = Main.npc[(int)projectile.ai[1]].Center;
                var shift = targetPos - projectile.position;
                shift.Normalize();
                shift *= dashDist;
                shift.RotatedByRandom(MathHelper.ToRadians(45));
                targetPos += shift;
            }
            MoveToTargetPos(6);
        }

        private void MoveToTargetPos(float max)
        {
            Vector2 newVel = Vector2.Normalize(targetPos - projectile.Center);
            newVel *= Math.Min(Vector2.Distance(projectile.Center, targetPos) / 4, Math.Min(projectile.velocity.Length() + .6f, max));
            projectile.velocity = newVel;
        }
    }
}
