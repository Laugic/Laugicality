using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using System;
using System.Collections.Generic;

namespace Laugicality.Projectiles.Mystic
{
	public class HermesConjuration1 : ModProjectile
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Hermes Conjuration");     
		}
        public int damage = 0;
        public int power = 0;
        public bool powered = false;
		public override void SetDefaults()
		{
            powered = false;
            power = 0;
            damage = projectile.damage;
			projectile.width = 14;               
			projectile.height = 34;              
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

        public override void AI()
        {
            damage = projectile.damage;
            Player player = Main.player[projectile.owner];
            LaugicalityPlayer modPlayer = player.GetModPlayer<LaugicalityPlayer>(mod);
            //power = modPlayer.conjurationPower;

            Dust.NewDust(projectile.position + projectile.velocity, projectile.width, projectile.height, mod.DustType("Hermes"), projectile.velocity.X * 0.5f, projectile.velocity.Y * 0.5f);
            
            if (!powered)
            {
                powered = true;
                while (modPlayer.conjurationPower > power)
                {
                    power++;
                }
                power += 2;
            }
        }

        public override bool OnTileCollide(Vector2 oldVelocity)
        {

            while (power > 0)
            {
                power -= 1;
                if (Main.myPlayer == projectile.owner)
                    Projectile.NewProjectile(projectile.Center.X, projectile.Center.Y, -4 + Main.rand.Next(8), -4 + Main.rand.Next(8), mod.ProjectileType("HermesConjurationHoming"), damage, 3f, Main.myPlayer);
            }

            projectile.Kill();
            Main.PlaySound(SoundID.Item10, projectile.position);

            return false;
        }

        public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
        {
            while (power > 0)
            {
                power -= 1;
                if (Main.myPlayer == projectile.owner)
                    Projectile.NewProjectile(projectile.Center.X, projectile.Center.Y, -4 + Main.rand.Next(8), -4 + Main.rand.Next(8), mod.ProjectileType("HermesConjurationHoming"), damage, 3f, Main.myPlayer);
            }

            projectile.Kill();
            Main.PlaySound(SoundID.Item10, projectile.position);
        }
    }
}
