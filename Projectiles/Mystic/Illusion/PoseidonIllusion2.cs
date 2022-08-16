using Laugicality.Buffs;
using Microsoft.Xna.Framework;
using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Laugicality.Projectiles.Mystic.Illusion
{
    public class PoseidonIllusion2 : IllusionProjectile
    {
        int delay = 0;
        public override void SetDefaults()
        {
            projectile.width = 28;
            projectile.height = 28;
            projectile.friendly = true;
            projectile.penetrate = -1;
            projectile.timeLeft = 90;
            projectile.tileCollide = false;
            projectile.ignoreWater = true;
            delay = 0;
            Main.projFrames[projectile.type] = 4;
            buffID = ModContent.BuffType<DepthBubbles>();
        }

        public override void AI()
        {
            projectile.frame = (int)(projectile.ai[1]);
            projectile.velocity *= .985f;
        }

        public override void Kill(int timeLeft)
        {
            for (int k = 0; k < 5; k++)
            {
                int dust = Dust.NewDust(projectile.position, projectile.width, projectile.height, 16, Main.rand.Next((int)-2f, (int)2f), Main.rand.Next((int)-2f, (int)2f), 0, Color.Aquamarine, 0.75f);
                Main.dust[dust].noGravity = true;
                Main.dust[dust].noLight = true;
            }
            Main.PlaySound(SoundID.Item54, projectile.position);
        }
    }
}