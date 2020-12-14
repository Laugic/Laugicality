using Laugicality.Buffs;
using Laugicality.Dusts;
using Microsoft.Xna.Framework;
using System;
using Terraria;
using Terraria.ModLoader;

namespace Laugicality.Projectiles.Mystic.Conjuration
{
    public class JanusConjuration : ConjurationProjectile
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Janus Arrow");
        }

        public override void SetDefaults()
        {
            projectile.width = 18;
            projectile.height = 18;
            projectile.aiStyle = 1;
            projectile.friendly = true;
            projectile.hostile = false;
            projectile.ranged = true;
            projectile.penetrate = -1;
            projectile.timeLeft = 1200;
            projectile.ignoreWater = true;
            projectile.tileCollide = true;
        }
        public override void AI()
        {
            if(Main.rand.Next(4) == 0)
            {
                Vector2 newVel = -projectile.velocity * 2 / 3f;
                float theta = Main.rand.Next(-30, 30) * (float)Math.PI / 180;
                float mag = Main.rand.Next(3, 7);
                newVel.X += (float)Math.Cos(theta) * mag;
                newVel.Y += (float)Math.Sin(theta) * mag;
                int dust = Dust.NewDust(projectile.position - projectile.velocity, projectile.width, projectile.height, ModContent.DustType<Sandy>(), newVel.X, newVel.Y);
                Main.dust[dust].scale *= .5f;
            }
        }

        public override void Kill(int timeLeft)
        {

            if (Main.myPlayer == projectile.owner)
                Projectile.NewProjectile(projectile.Center.X, projectile.Center.Y, 0, 0, ModContent.ProjectileType<JanusConjurationBottom>(), projectile.damage, 0, Main.myPlayer);
        }
    }
}
