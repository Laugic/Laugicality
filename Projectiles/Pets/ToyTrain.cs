using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using System;
using Microsoft.Xna.Framework;

namespace Laugicality.Projectiles.Pets
{
	public class ToyTrain : ModProjectile
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Toy Train");
			Main.projFrames[projectile.type] = 16;
			Main.projPet[projectile.type] = true;
		}

		public override void SetDefaults()
		{
			projectile.CloneDefaults(ProjectileID.BabyGrinch);
            projectile.height = 62;
            projectile.width = 98;
            aiType = ProjectileID.BabyGrinch;
		}

		public override bool PreAI()
		{
			Player player = Main.player[projectile.owner];
			player.grinch = false; // Relic from aiType
			return true;
		}

		public override void AI()
		{
			Player player = Main.player[projectile.owner];
			LaugicalityPlayer modPlayer = player.GetModPlayer<LaugicalityPlayer>(mod);
			if (player.dead)
			{
				modPlayer.toyTrain = false;
			}
			if (modPlayer.toyTrain)
			{
				projectile.timeLeft = 2;
			}
            if (Math.Abs(projectile.velocity.Y) < 1f && Math.Abs(projectile.velocity.X) > 1f)
            {
                Rectangle rect = projectile.getRect();
                Dust.NewDust(new Vector2(rect.X + projectile.width / 2, rect.Y), 0, 0, mod.DustType("TrainSteam"));
            }
            if (Math.Abs(projectile.velocity.Y) > 1f)
            {
                Rectangle rect = projectile.getRect();
                Dust.NewDust(new Vector2(rect.X, rect.Y+projectile.height), projectile.width, 0, mod.DustType("Steam"));
            }
        }
        
    }
}