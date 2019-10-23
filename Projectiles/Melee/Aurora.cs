using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using System;

namespace Laugicality.Projectiles.Melee
{
	public class Aurora : ModProjectile
    {
        public bool powered = false;
        public int power = 1;
        public int damage = 0;

        public override void SetDefaults()
        {
            power = 3;
            powered = false;
            projectile.width = 20;
            projectile.height = 20;
            projectile.friendly = true;
            projectile.penetrate = 1;
            projectile.timeLeft = 600;
            projectile.ignoreWater = true;
        }
        
        public override void AI()
        {
            if (!powered)
            {
                power = Main.rand.Next(3, 6);
                powered = true;
            }
            projectile.rotation = (float)Math.Atan2((double)projectile.velocity.Y, (double)projectile.velocity.X) + 1.57f;
            
            if (Main.rand.Next(2) == 0) Dust.NewDust(projectile.position + projectile.velocity, projectile.width, projectile.height, ModContent.DustType("Frost"), projectile.velocity.X * 0.5f, projectile.velocity.Y * 0.5f);
        }

        public override bool OnTileCollide(Vector2 oldVelocity)
        {
            while (power > 0)
            {
                power -= 1;
                float theta = (Main.rand.NextFloat() * .4f + 1.3f) * (float)Math.PI;
                float mag = Main.rand.NextFloat() * 4 + 5;
                if (Main.myPlayer == projectile.owner)
                    Projectile.NewProjectile(projectile.Center.X, projectile.Center.Y, mag * (float)Math.Cos(theta), mag * (float)Math.Sin(theta), ModContent.ProjectileType("AuroraShard"), projectile.damage, 3f, Main.myPlayer);
            }
            projectile.Kill();
            Main.PlaySound(SoundID.Item10, projectile.position);

            return false;
        }

        public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
        {
            target.AddBuff(BuffID.Frostburn, 120);
            while (power > 0)
            {
                power -= 1;
                float theta = (Main.rand.NextFloat() * .4f + 1.3f) * (float)Math.PI;
                float mag = Main.rand.NextFloat() * 4 + 5;
                if (Main.myPlayer == projectile.owner)
                    Projectile.NewProjectile(projectile.Center.X, projectile.Center.Y, mag * (float)Math.Cos(theta), mag * (float)Math.Sin(theta), ModContent.ProjectileType("AuroraShard"), projectile.damage, 3f, Main.myPlayer);
            }
            projectile.Kill();
            Main.PlaySound(SoundID.Item10, projectile.position);
        }
    }
}