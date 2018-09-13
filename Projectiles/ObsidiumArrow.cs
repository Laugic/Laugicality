using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using System;
using System.Collections.Generic;

namespace Laugicality.Projectiles
{
	public class ObsidiumArrow : ModProjectile
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Obsidium Arrow");     
		}

		public override void SetDefaults()
		{
			projectile.width = 18;               
			projectile.height = 36;              
			projectile.aiStyle = 1;             
			projectile.friendly = true;         
			projectile.hostile = false;         
			projectile.ranged = true;           
			projectile.penetrate = 3;           
			projectile.timeLeft = 600;            
			projectile.ignoreWater = true;         
			projectile.tileCollide = true;          
			//aiType = 1;           
		}

		public override bool OnTileCollide(Vector2 oldVelocity)
		{
			projectile.Kill();
			return false;
		}

        public override void Kill(int timeLeft)
        {
            Main.PlaySound(2, (int)projectile.position.X, (int)projectile.position.Y, 14);
            int damage = projectile.damage;
            float theta = (float)(Main.rand.NextDouble() * 2 * Math.PI);
            float mag = 6f;
            if(Main.rand.Next(2) == 0 && Main.myPlayer == projectile.owner)
                Projectile.NewProjectile(projectile.Center.X, projectile.Center.Y, (float)Math.Cos(theta) * mag, (float)Math.Sin(theta) * mag, mod.ProjectileType("ObsidiumArrowHead"), damage, 3f, Main.myPlayer);
            theta = (float)(Main.rand.NextDouble() * 2 * Math.PI);
            if (Main.myPlayer == projectile.owner)
                Projectile.NewProjectile(projectile.Center.X, projectile.Center.Y, (float)Math.Cos(theta) * mag, (float)Math.Sin(theta) * mag, mod.ProjectileType("ObsidiumArrowHead"), damage, 3f, Main.myPlayer);
            theta = (float)(Main.rand.NextDouble() * 2 * Math.PI);
            if (Main.myPlayer == projectile.owner)
                Projectile.NewProjectile(projectile.Center.X, projectile.Center.Y, (float)Math.Cos(theta) * mag, (float)Math.Sin(theta) * mag, mod.ProjectileType("ObsidiumArrowHead"), damage, 3f, Main.myPlayer);
        }

        public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
        {
                target.AddBuff(BuffID.OnFire, 120, true);
        }
    }
}
