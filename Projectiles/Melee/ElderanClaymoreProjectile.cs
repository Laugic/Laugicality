using System;
using Laugicality.Buffs;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Laugicality.Projectiles.Melee
{
    public class ElderanClaymoreProjectile : ModProjectile
    {
        public int rot = 0;
        public int delay = 0;
        public bool reverse = false;
        Vector2 targetPos;

        public override void SetDefaults()
        {
            reverse = false;
            delay = 20;
            projectile.width = 38;
            projectile.height = 38;
            projectile.friendly = true;
            projectile.thrown = true;
            projectile.penetrate = -1;
            projectile.aiStyle = 0;
            projectile.timeLeft = 400;
            targetPos = projectile.position;
        }

        public override void AI()
        {
            Player player = Main.player[projectile.owner];
            Vector2 toPlayer = player.Center - projectile.Center;

            projectile.rotation = toPlayer.ToRotation() - 1.57f;

            if (reverse)
            {
                targetPos = player.Center;
                if (toPlayer.Length() < 20)
                    projectile.Kill();
                toPlayer.Normalize();
                toPlayer *= 12;
                projectile.velocity = toPlayer;
            }
            else
            {
                if (projectile.Distance(player.Center) > 1000)
                    reverse = true;
                else
                {
                    projectile.ai[0] += .015f;
                    projectile.velocity.Y += projectile.ai[0];
                }
            }
        }

        public override bool OnTileCollide(Vector2 oldVelocity)
        {
            if(!reverse)
            {
                reverse = true;
                Main.PlaySound(0, projectile.position, 0);
            }
            projectile.tileCollide = false;
            return false;
        }

        public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
        {
            //target.AddBuff(ModContent.BuffType<Steamy>(), 120);
        }

        public override bool PreDraw(SpriteBatch spriteBatch, Color lightColor)
        {
            Laugicality.DrawChain(spriteBatch, mod.GetTexture("Projectiles/Melee/ElderanClaymoreChain"), Main.player[projectile.owner].MountedCenter, projectile.Center);
            /*Vector2 playerCenter = Main.player[projectile.owner].MountedCenter;
            Vector2 center = projectile.Center;
            Vector2 distToProj = playerCenter - projectile.Center;
            float projRotation = distToProj.ToRotation() + 1.57f;
            float distance = distToProj.Length();
            while (distance > 30f && !float.IsNaN(distance))
            {
                distToProj.Normalize();
                distToProj *= 24f;
                center += distToProj;
                distToProj = playerCenter - center;
                distance = distToProj.Length();
                Color drawColor = lightColor;

                //Draw chain
                Texture2D chainTexture = mod.GetTexture("Projectiles/Melee/ElderanClaymoreChain");
                spriteBatch.Draw(chainTexture, new Vector2(center.X - Main.screenPosition.X, center.Y - Main.screenPosition.Y),
                    new Rectangle(0, 0, chainTexture.Width, chainTexture.Height), drawColor, projRotation,
                    new Vector2(chainTexture.Width * 0.5f, chainTexture.Height * 0.5f), 1f, SpriteEffects.None, 0f);
            }*/
            return true;
        }
    }
}