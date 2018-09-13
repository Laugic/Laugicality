using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using System;

namespace Laugicality.Projectiles.Mystic
{
	public class GreatGladiusConjuration1 : ModProjectile
	{
		public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Great Gladius Conjuration");
            //ProjectileID.Sets.Homing[projectile.type] = true;
			//ProjectileID.Sets.MinionShot[projectile.type] = true;
		}
        private int delay = 0;
        private int delMax = 0;
        bool spawned = false;
        int power = 1;
		public override void SetDefaults()
		{
            spawned = false;
            delay = 0;
            delMax = 0;
			projectile.width = 2;
			projectile.height = 2;
			//projectile.alpha = 255;
            projectile.timeLeft = 18000;
            projectile.friendly = true;
            projectile.hostile = false;
            projectile.ignoreWater = true;
            projectile.tileCollide = false;
            projectile.penetrate = -1;
        }
        
        public override void AI()
        {
            Player player = Main.player[projectile.owner];
            LaugicalityPlayer modPlayer = player.GetModPlayer<LaugicalityPlayer>(mod);
            if (!spawned)
            {
                spawned = true;
                power = modPlayer.conjurationPower;
            }
            if (Main.rand.Next(4) == 0)
            {
                if (Main.netMode != 1)
                    Projectile.NewProjectile(projectile.Center.X - 64, projectile.Center.Y, -4 + Main.rand.Next(9), -Main.rand.Next(6, 9), mod.ProjectileType("GreatGladiusConjuration2"), (int)(projectile.damage) / 4, 3, Main.myPlayer);
            }
            delay++;
            if(delay >= 90 + 60 * power)
            {
                projectile.Kill();
            }
        }
    }
}