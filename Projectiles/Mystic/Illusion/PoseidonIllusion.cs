using System;
using Laugicality.Buffs;
using Laugicality.Dusts;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Laugicality.Projectiles.Mystic.Illusion
{
	public class PoseidonIllusion : IllusionProjectile
    {
        public int rot = 0;
        public int delay = 0;
        public bool reverse = false;
        Vector2 targetPos;
        int debugTimer = 0;
        public override void SetDefaults()
        {
            projectile.width = 32;
            projectile.height = 32;
            projectile.friendly = true;
            projectile.penetrate = -1;
            projectile.timeLeft = 6 * 60;
            projectile.ignoreWater = true;
            targetPos = projectile.position;
            buffID = ModContent.BuffType<DepthBubbles>();
            debugTimer = 0;
        }


        public override bool OnTileCollide(Vector2 oldVelocity)
        {
            if (!reverse)
            {
                reverse = true;
                Main.PlaySound(0, projectile.position, 0);
            }
            projectile.tileCollide = false;
            return false;
        }

        public override void AI()
        {
            projectile.rotation = (float)Math.Atan2((double)projectile.velocity.Y, (double)projectile.velocity.X) + .785f;
            Player player = Main.player[projectile.owner];
            Vector2 toPlayer = player.Center - projectile.Center;

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
                if (projectile.Distance(player.Center) > 800)
                    reverse = true;
                else
                {
                    projectile.ai[0] += .015f;
                    projectile.velocity.Y += projectile.ai[0];
                }
            }
        }
        public override bool PreDraw(SpriteBatch spriteBatch, Color lightColor)
        {
            Texture2D texture = mod.GetTexture("Projectiles/Mystic/Illusion/PoseidonIllusion");
            var origin = projectile.Center;
            //origin.X -= texture.Width / 2;
            //origin.Y -= texture.Height / 2;
            Laugicality.DrawChain(spriteBatch, mod.GetTexture("Projectiles/Mystic/Illusion/PoseidonChain"), Main.player[projectile.owner].MountedCenter, projectile.Center);
            spriteBatch.Draw(texture, origin - Main.screenPosition, new Rectangle(0, 0, texture.Width, texture.Height), Color.White, projectile.rotation, new Vector2(texture.Width / 2, texture.Height / 2), projectile.scale, SpriteEffects.None, 0 );
            return false;
        }

    }
}