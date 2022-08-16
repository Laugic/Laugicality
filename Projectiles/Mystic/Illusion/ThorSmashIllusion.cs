using Terraria;
using Terraria.ID;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Laugicality.Buffs;
using Terraria.ModLoader;
using System;
using WebmilioCommons.Extensions;
using Laugicality.Projectiles.Mystic.Misc;

namespace Laugicality.Projectiles.Mystic.Illusion
{
    public class ThorSmashIllusion : IllusionProjectile
    {
        public Texture2D Smash;
        public override void SetDefaults()
        {
            projectile.width = 222;
            projectile.height = 242;
            projectile.friendly = true;
            projectile.penetrate = -1;
            projectile.timeLeft = 180;
            projectile.ignoreWater = true;
            projectile.tileCollide = false;
            Main.projFrames[projectile.type] = 7;
            buffID = ModContent.BuffType<ThunderCharged>();
            if (!Main.dedServ)
            {
                Smash = mod.GetTexture(this.GetType().GetRootPath() + "/ThorSmashIllusion");
            }
        }
        public override void PostAI()
        {
            projectile.frameCounter++;
            if (projectile.frameCounter > 3)
            {
                projectile.frame++;
                if(projectile.frame == 3 && Main.myPlayer == projectile.owner)
                {
                    for (int i = 0; i < 4; i++)
                    {
                        double theta = Main.rand.NextDouble() * Math.PI * 2;
                        float mag = 12;
                        int p = Projectile.NewProjectile(projectile.Center.X + 2 * mag * (float)Math.Cos(theta), projectile.Center.Y + 60 + 2 * mag * (float)Math.Sin(theta), (float)Math.Cos(theta) * mag, (float)Math.Sin(theta) * mag, ModContent.ProjectileType<Bolt>(), (int)(projectile.damage), 8, Main.myPlayer);
                        Main.projectile[p].ai[0] = 4;
                        Main.projectile[p].ai[1] = 1;
                    }
                }
                projectile.frameCounter = 0;
            }
            if (projectile.frame >= 7)
            {
                projectile.Kill();
            }
        }
    }
}
