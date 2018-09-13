using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Laugicality;
using Laugicality.NPCs;

namespace Laugicality.Projectiles.Mystic
{
	public class MarsConjuration : ModProjectile
    {
        public int damage = 0;
        public override void SetDefaults()
        {
            //mystDmg = (float)projectile.damage;
            //mystDur = 1f + projectile.knockBack;
            projectile.width = 16;
            projectile.height = 16;
            projectile.friendly = true;
            projectile.penetrate = 1;
            projectile.timeLeft = 47;
            projectile.ignoreWater = true;
            projectile.scale *= 1.5f;
        }

        
        public override void AI()
        {
            projectile.rotation = (float)Math.Atan2((double)projectile.velocity.Y, (double)projectile.velocity.X) + .785f;
            if(Main.rand.Next(4) == 0)Dust.NewDust(projectile.position + projectile.velocity, projectile.width, projectile.height, mod.DustType("Magma"), projectile.velocity.X * 0.5f, projectile.velocity.Y * 0.5f);
            if(projectile.timeLeft <= 2)
            {
                damage = (int)projectile.damage;
                if (Main.myPlayer == projectile.owner)
                    Projectile.NewProjectile(projectile.Center.X, projectile.Center.Y, 0, 0, mod.ProjectileType("MarsGeyeser"), damage, 3f, Main.myPlayer);
                projectile.Kill();
            }
        }


        public override bool OnTileCollide(Vector2 oldVelocity)
        {
            damage = (int)projectile.damage;
            if (Main.myPlayer == projectile.owner)
                Projectile.NewProjectile(projectile.Center.X, projectile.Center.Y, 0, 0, mod.ProjectileType("MarsGeyeser"), damage, 3f, Main.myPlayer);
            projectile.Kill();
            return false;
        }

        public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
        {
            damage = (int)projectile.damage;
            if (Main.myPlayer == projectile.owner)
                Projectile.NewProjectile(projectile.Center.X, projectile.Center.Y, 0, 0, mod.ProjectileType("MarsGeyeser"), damage, 3f, Main.myPlayer);
            projectile.Kill();
        }
    }
}