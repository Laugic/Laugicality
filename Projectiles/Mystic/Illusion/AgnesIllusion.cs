using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;
using Microsoft.Xna.Framework.Graphics;
using Laugicality.Items.Weapons.Mystic;
using Laugicality.Buffs;

namespace Laugicality.Projectiles.Mystic.Illusion
{
    public class AgnesIllusion : IllusionProjectile
    {
        bool shoot = false;
        public override void SetDefaults()
        {
            projectile.width = 30;
            projectile.height = 30;
            projectile.scale = 2f;
            projectile.aiStyle = 19;
            projectile.friendly = true;
            projectile.penetrate = -1;
            projectile.tileCollide = false;
            projectile.hide = true;
            projectile.ownerHitCheck = true;
            shoot = false;
            buffID = ModContent.BuffType<InfernalBuff>();
        }

        public override void AI()
        {
            Player player = Main.player[projectile.owner];
            player.direction = projectile.direction;
            player.heldProj = projectile.whoAmI;
            player.itemTime = Main.player[projectile.owner].itemAnimation;
            projectile.position.X = Main.player[projectile.owner].position.X + (float)(Main.player[projectile.owner].width / 2) - (float)(projectile.width / 2);
            projectile.position.Y = Main.player[projectile.owner].position.Y + (float)(Main.player[projectile.owner].height / 2) - (float)(projectile.height / 2);
            projectile.position += projectile.velocity * projectile.ai[0];

            if (projectile.ai[0] == 0f)
            {
                projectile.ai[0] = 3f;
                projectile.netUpdate = true;
            }
            if (player.itemAnimation < player.itemAnimationMax / 3)
            {
                projectile.ai[0] -= 2.4f;
                if (projectile.localAI[0] == 0f && Main.myPlayer == projectile.owner)
                {
                    projectile.localAI[0] = 1f;
                }
                if (!shoot)
                {
                    if (Main.myPlayer == projectile.owner)
                        Projectile.NewProjectile(projectile.Center.X, projectile.Center.Y, projectile.velocity.X, projectile.velocity.Y, ModContent.ProjectileType<AgnesIllusion2>(), projectile.damage, projectile.knockBack, player.whoAmI);
                    shoot = true;
                }
            }
            else
            {
                projectile.ai[0] += 1.25f;
            }

            if (Main.player[projectile.owner].itemAnimation == 0 || LaugicalityPlayer.Get(Main.player[projectile.owner]).MysticMode != 2)
            {
                projectile.Kill();
            }

            projectile.rotation = (float)Math.Atan2((double)projectile.velocity.Y, (double)projectile.velocity.X) + 1.57f / 2;
            if (projectile.spriteDirection == -1)
            {
                projectile.rotation += 1.57f;
            }
        }

        public override bool PreDraw(SpriteBatch spriteBatch, Color lightColor)
        {
            Texture2D texture2D13 = Main.projectileTexture[projectile.type];
            int imageHeight = Main.projectileTexture[projectile.type].Height;
            int y6 = imageHeight * projectile.frame;
            Main.spriteBatch.Draw(texture2D13, projectile.Center - Main.screenPosition + new Vector2(0f, projectile.gfxOffY), new Microsoft.Xna.Framework.Rectangle?(new Microsoft.Xna.Framework.Rectangle(0, y6, texture2D13.Width, imageHeight)), projectile.GetAlpha(Color.White), projectile.rotation, new Vector2((float)texture2D13.Width / 2f, (float)imageHeight / 2f) + new Vector2(40, -40), projectile.scale, projectile.spriteDirection == 1 ? SpriteEffects.None : SpriteEffects.FlipHorizontally, 0f);
            return false;
        }
    }
}
