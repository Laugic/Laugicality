using Laugicality.Dusts;
using Microsoft.Xna.Framework;
using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Laugicality.NPCs.PreTrio
{
    public class Snowbomb : ModProjectile
    {
        float rot;

        public override void SetDefaults()
        {
            LaugicalityVars.eProjectiles.Add(projectile.type);
            projectile.width = 24;
            projectile.height = 24;
            projectile.friendly = false;
            projectile.hostile = true;
            projectile.timeLeft = 3 * 60;
            rot = (.02f + Main.rand.NextFloat()) * (Main.rand.NextBool()?-1:1);
        }

        public override void AI()
        {
            Movement();

            projectile.rotation += rot / 30f;
        }

        private void Movement()
        {
            projectile.velocity.Y += .08f;
        }

        public override bool OnTileCollide(Vector2 oldVelocity)
        {
            projectile.Kill();
            return false;
        }

        public override void Kill(int timeLeft)
        {
            Main.PlaySound(2, projectile.Center, 14);
            for (int k = 0; k < (Main.expertMode?12:8); k++)
            {
                var theta = Main.rand.NextDouble() * Math.PI;
                float mag = -5 - Main.rand.NextFloat() * 3;
                Projectile.NewProjectile(projectile.Center, new Vector2((float)Math.Cos(theta) * mag, (float)Math.Sin(theta) * mag), ModContent.ProjectileType<Snowball>(), projectile.damage, 7);
            }
        }

        public override void OnHitPlayer(Player target, int dmgDealt, bool crit)
        {
            if (!Main.expertMode)
                return;
            target.AddBuff(BuffID.Frostburn, 2 * 60 + Main.rand.Next(60));
            target.AddBuff(BuffID.Chilled, 2 * 60 + Main.rand.Next(60));
        }
    }
}
