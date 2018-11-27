using System;
using System.Collections.Generic;
using System.IO;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Laugicality;

namespace Laugicality.Projectiles.Mystic
{
	public class AnDioConjuration1 : ModProjectile
    {
        public bool bitherial = true;
        public int delay = 0;
        public int power = 0;

        public override void SetDefaults()
        {
            power = 0;
            LaugicalityVars.EProjectiles.Add(projectile.type);
            delay = 0;
            projectile.width = 24;
            projectile.height = 24;
            projectile.penetrate = 2;
            projectile.friendly = true;
            projectile.timeLeft = 320;
            projectile.ignoreWater = true;
            projectile.tileCollide = false;
        }

        public override void Kill(int timeLeft)
        {
            if (Main.myPlayer == projectile.owner)
            {
				float num102 = 30f;
				int num103 = 0;
				while ((float)num103 < num102)
				{
					Vector2 vector12 = Vector2.UnitX * 0f;
					vector12 += -Vector2.UnitY.RotatedBy((double)((float)num103 * (6.28318548f / num102)), default(Vector2)) * new Vector2(10f, 10f);
					vector12 = vector12.RotatedBy((double)projectile.velocity.ToRotation(), default(Vector2));
					int num104 = Dust.NewDust(projectile.Center, 0, 0, mod.DustType("White"), 0f, 0f, 75, default(Color), 1.25f);
					Main.dust[num104].scale = 1.75f;
					Main.dust[num104].noGravity = true;
					Main.dust[num104].position = projectile.Center + vector12;
					Main.dust[num104].velocity = -1 * (projectile.velocity * 0f + vector12.SafeNormalize(Vector2.UnitY) * 2.5f);
					int num = num103;
					num103 = num + 1;
				}
				
                Projectile.NewProjectile(projectile.Center.X, projectile.Center.Y, 7, 0, mod.ProjectileType("AnDioConjuration2"), (int)(projectile.damage / 1.2f), 3, Main.myPlayer);
                Projectile.NewProjectile(projectile.Center.X, projectile.Center.Y, -7, 0, mod.ProjectileType("AnDioConjuration2"), (int)(projectile.damage / 1.2f), 3, Main.myPlayer);
                Projectile.NewProjectile(projectile.Center.X, projectile.Center.Y, 0, 7, mod.ProjectileType("AnDioConjuration2"), (int)(projectile.damage / 1.2f), 3, Main.myPlayer);
                Projectile.NewProjectile(projectile.Center.X, projectile.Center.Y, 0, -7, mod.ProjectileType("AnDioConjuration2"), (int)(projectile.damage / 1.2f), 3, Main.myPlayer);
                Projectile.NewProjectile(projectile.Center.X, projectile.Center.Y, 5, 5, mod.ProjectileType("AnDioConjuration2"), (int)(projectile.damage / 1.2f), 3, Main.myPlayer);
                Projectile.NewProjectile(projectile.Center.X, projectile.Center.Y, 5, -5, mod.ProjectileType("AnDioConjuration2"), (int)(projectile.damage / 1.2f), 3, Main.myPlayer);
                Projectile.NewProjectile(projectile.Center.X, projectile.Center.Y, -5, -5, mod.ProjectileType("AnDioConjuration2"), (int)(projectile.damage / 1.2f), 3, Main.myPlayer);
                Projectile.NewProjectile(projectile.Center.X, projectile.Center.Y, -5, 5, mod.ProjectileType("AnDioConjuration2"), (int)(projectile.damage / 1.2f), 3, Main.myPlayer);
            }
        }

        public override void AI()
        {
            bitherial = true;
            Dust.NewDust(projectile.position + projectile.velocity, projectile.width, projectile.height, mod.DustType("White"), 0f, 0f);
            delay++;
            Player player = Main.player[projectile.owner];
            LaugicalityPlayer modPlayer = player.GetModPlayer<LaugicalityPlayer>(mod);
            if (delay > 15)
            {
                    delay = 0;
                    power++;
                if (Main.myPlayer == projectile.owner)
                {
                    Projectile.NewProjectile(projectile.Center.X, projectile.Center.Y, 7, 0, mod.ProjectileType("AnDioConjuration2"), (int)(projectile.damage / 1.2f), 3, Main.myPlayer);
                    Projectile.NewProjectile(projectile.Center.X, projectile.Center.Y, -7, 0, mod.ProjectileType("AnDioConjuration2"), (int)(projectile.damage / 1.2f), 3, Main.myPlayer);
                    Projectile.NewProjectile(projectile.Center.X, projectile.Center.Y, 0, 7, mod.ProjectileType("AnDioConjuration2"), (int)(projectile.damage / 1.2f), 3, Main.myPlayer);
                    Projectile.NewProjectile(projectile.Center.X, projectile.Center.Y, 0, -7, mod.ProjectileType("AnDioConjuration2"), (int)(projectile.damage / 1.2f), 3, Main.myPlayer);
                    Projectile.NewProjectile(projectile.Center.X, projectile.Center.Y, 5, 5, mod.ProjectileType("AnDioConjuration2"), (int)(projectile.damage / 1.2f), 3, Main.myPlayer);
                    Projectile.NewProjectile(projectile.Center.X, projectile.Center.Y, 5, -5, mod.ProjectileType("AnDioConjuration2"), (int)(projectile.damage / 1.2f), 3, Main.myPlayer);
                    Projectile.NewProjectile(projectile.Center.X, projectile.Center.Y, -5, -5, mod.ProjectileType("AnDioConjuration2"), (int)(projectile.damage / 1.2f), 3, Main.myPlayer);
                    Projectile.NewProjectile(projectile.Center.X, projectile.Center.Y, -5, 5, mod.ProjectileType("AnDioConjuration2"), (int)(projectile.damage / 1.2f), 3, Main.myPlayer);
                }
                if (power >= modPlayer.conjurationPower)
                    projectile.Kill();
            }
        }
        // Dust.NewDust(projectile.position + projectile.velocity, projectile.width, projectile.height, mod.DustType("Pink"), projectile.velocity.X * 0.5f, projectile.velocity.Y * 0.5f);

    }


        
    
}