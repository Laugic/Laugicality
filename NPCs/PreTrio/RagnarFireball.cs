using Laugicality.Dusts;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using WebmilioCommons.Extensions;

namespace Laugicality.NPCs.PreTrio
{
    public class RagnarFireball : ModProjectile
    {
        public Texture2D Fireball;
        public override void SetDefaults()
        {
            projectile.width = 40;
            projectile.height = 40;
            projectile.friendly = false;
            projectile.hostile = true;
            /*projectile.friendly = true;
            projectile.hostile = false;*/
            projectile.ignoreWater = true;
            projectile.tileCollide = false;
            projectile.timeLeft = 300;

            if (!Main.dedServ)
            {
                Fireball = mod.GetTexture(this.GetType().GetRootPath() + "/RagnarFireballLayers");
            }
        }

        public override void AI()
        {
            if(projectile.ai[0] == 1) // Gravity
                projectile.velocity.Y += .2f;
            if (projectile.ai[0] == 2)
                SlowAI();
            if (projectile.ai[0] == 3)
                SpiralAI();
            projectile.rotation += .01f;
        }

        private void SpiralAI()
        {
            projectile.velocity = new Vector2(projectile.velocity.Length() * (float)Math.Cos(projectile.velocity.ToRotation() + .015),
                projectile.velocity.Length() * (float)Math.Sin(projectile.velocity.ToRotation() + .015));
        }

        private void SlowAI()
        {
            projectile.velocity *= .98f;
            projectile.timeLeft = 3 * 60;
            if (projectile.velocity.Length() < 1)
            {
                int npc = 0;
                if (projectile.ai[1] < 0 || projectile.ai[1] >= Main.npc.Length)
                    return;

                npc = (int)projectile.ai[1];

                if(Main.npc[npc].type == ModContent.NPCType<Ragnar>() && Main.player[Main.npc[npc].target].active && Main.player[Main.npc[npc].target].statLife > 0)
                {
                    projectile.velocity = projectile.position - Main.player[Main.npc[npc].target].position;
                    projectile.velocity.Normalize();
                    projectile.velocity *= -12;
                    projectile.ai[1] = 0;
                    projectile.ai[0] = 0;
                }
            }
        }

        public override bool PreDraw(SpriteBatch spriteBatch, Color lightColor)
        {
            var drawPos = new Vector2();
            var drawMult = new Vector2(-1f, -1f);
            drawMult *= projectile.velocity;
            Vector2 rotOffset = new Vector2(Main.projectileTexture[projectile.type].Width / 2, Main.projectileTexture[projectile.type].Width / 2);
            var spriteFX = SpriteEffects.None;
            var imageRot = (float)Math.Atan2((double)projectile.velocity.Y, (double)projectile.velocity.X) + 1.57f;
            for (int i = 0; i < 10; i++)
            {
                Rectangle rect = new Rectangle(0, i / 2 * 40, 40, 40);
                int sign = 1;
                if (i / 2 == 2)
                {
                    spriteFX = SpriteEffects.FlipHorizontally;
                    sign = -1;
                }
                float rot = projectile.rotation * (i / 2 + 1) / 2 * sign;
                spriteBatch.Draw(Fireball, projectile.position - Main.screenPosition + rotOffset + drawPos * (i%2==0?2:1), rect, Color.White, (i==0? imageRot:rot), rotOffset, projectile.scale, spriteFX, 0f);
                if(i % 2 == 0)
                    drawPos += drawMult;
                if (i == 0)
                    i++;
            }
            return false;
        }

        public override void Kill(int timeLeft)
        {
            for (int k = 0; k < 5; k++)
            {
                Dust.NewDust(projectile.position + projectile.velocity, projectile.width, projectile.height, ModContent.DustType<Magma>(), projectile.oldVelocity.X * 0.5f, projectile.oldVelocity.Y * 0.5f);
            }
        }

        public override void OnHitPlayer(Player target, int dmgDealt, bool crit)
        {
            target.AddBuff(BuffID.OnFire, 4 * 60, true);
        }
    }
}