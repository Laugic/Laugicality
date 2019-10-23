using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ModLoader;

namespace Laugicality.Projectiles.Thrown
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
        int counter = 0;

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
            Hail();
        }

        private void Hail()
        {
            counter++;
            if(stuck)
            {
                if (counter > 20 || ((LaugicalityWorld.downedEtheria || Main.player[projectile.owner].GetModPlayer<LaugicalityPlayer>(mod).Etherable > 0) && LaugicalityWorld.downedTrueEtheria && counter > 10))
                {
                    counter = 0;
                    Projectile.NewProjectile(projectile.Center, new Vector2(0, 0), ModContent.ProjectileType("Hail"), origDmg, 0, projectile.owner);
                }
            }
            else if(counter > 10 || ((LaugicalityWorld.downedEtheria || Main.player[projectile.owner].GetModPlayer<LaugicalityPlayer>(mod).Etherable > 0) && LaugicalityWorld.downedTrueEtheria && counter > 5))
            {
                counter = 0;
                Projectile.NewProjectile(projectile.Center, new Vector2(0, 0), ModContent.ProjectileType("Hail"), origDmg, 0, projectile.owner);
            }
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
            projectile.rotation = (float)Math.Atan2((double)projectile.velocity.Y, (double)projectile.velocity.X) + 1.57f / 2f;
            projectile.ai[0] += .01f;
            projectile.velocity.Y += projectile.ai[0];
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