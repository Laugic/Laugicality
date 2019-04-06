using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Laugicality.Projectiles
{
    public class Antarctica : ModProjectile
    {
        bool stuck = false;
        int npcIndex = -1;
        Vector2 relPos;
        bool justSpawned = false;
        int duration = 1;
        bool seaking = false;
        float rotPos = 0;
        bool targetFound = false;
        int npcTarget = -1;
        float npcDistance = 8000;
        Vector2 targetPos;
        int delay = 0;
        int range = 600;
        int origDmg = 150;

        public override void SetDefaults()
        {
            projectile.width = 30;
            projectile.height = 30;
            projectile.friendly = true;
            projectile.aiStyle = 0;
            projectile.thrown = true;
            projectile.penetrate = -1;
            projectile.timeLeft = 7 * 60;
            projectile.tileCollide = true;
        }

        public override void AI()
        {
            if(npcIndex != -1)
            {
                if(!Main.npc[npcIndex].active)
                {
                    npcIndex = -1;
                    stuck = false;
                    seaking = true;
                }
            }

            if(!justSpawned)
            {
                justSpawned = true;
                if ((Main.player[projectile.owner].GetModPlayer<LaugicalityPlayer>(mod).Etherable > 2 || LaugicalityWorld.downedEtheria) && LaugicalityWorld.downedTrueEtheria)
                    duration = 2;
                projectile.timeLeft = 7 * 60 * duration;
                origDmg = projectile.damage;
            }
            if (stuck)
                Stuck();
            else if (seaking)
                Seaking();
            else
                Fall();
        }

        private void Stuck()
        {
            if(npcIndex != -1)
            {
                projectile.position = Main.npc[npcIndex].Center + relPos;
                projectile.rotation = rotPos;
                projectile.knockBack = 0;
                projectile.damage = 0;
                projectile.tileCollide = false;
            }
        }

        private void Seaking()
        {
            projectile.knockBack = 8;
            projectile.damage = origDmg;
            projectile.tileCollide = true;
            GetTarget();
            MoveToTarget();
            projectile.rotation = (float)Math.Atan2((double)projectile.velocity.Y, (double)projectile.velocity.X) + 1.57f / 2f;
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
                if (dist != 0)
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
        
        private void Fall()
        {
            projectile.ai[0] += .02f;
            projectile.velocity.Y += projectile.ai[0];
            projectile.rotation = (float)Math.Atan2((double)projectile.velocity.Y, (double)projectile.velocity.X) + 1.57f / 2f;
        }
        public override bool OnTileCollide(Vector2 oldVelocity)
        {
            if (!stuck)
            {
                projectile.Kill();
                Main.PlaySound(0, (int)projectile.position.X, (int)projectile.position.Y, 10);
            }
            return false;
        }

        public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
        {
            if(!stuck)
                npcIndex = target.whoAmI;
            if (npcIndex != -1 && npcIndex == target.whoAmI && !stuck)
            {
                relPos = projectile.position - Main.npc[npcIndex].Center;
                stuck = true;
                projectile.timeLeft = 7 * 60 * duration;
                seaking = false;
                rotPos = projectile.rotation;
            }
        }

        public override bool PreDraw(SpriteBatch spriteBatch, Color lightColor)
        {
            Texture2D texture2D13 = Main.projectileTexture[projectile.type];
            int imageHeight = Main.projectileTexture[projectile.type].Height;
            int y6 = imageHeight * projectile.frame;
            Main.spriteBatch.Draw(texture2D13, projectile.Center - Main.screenPosition + new Vector2(0f, projectile.gfxOffY), new Microsoft.Xna.Framework.Rectangle?(new Microsoft.Xna.Framework.Rectangle(0, y6, texture2D13.Width, imageHeight)), projectile.GetAlpha(Color.White), projectile.rotation, new Vector2((float)texture2D13.Width / 2f, (float)imageHeight / 2f) + new Vector2(16, -16), projectile.scale, projectile.spriteDirection == 1 ? SpriteEffects.None : SpriteEffects.FlipHorizontally, 0f);
            return false;
        }
    }
}