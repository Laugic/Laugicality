using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using System;
using Laugicality.Dusts;
using Microsoft.Xna.Framework;

namespace Laugicality.Projectiles.Pets
{
	public class ToyTrainProjectile : ModProjectile
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Toy Train");
			Main.projFrames[projectile.type] = 18;
			Main.projPet[projectile.type] = true;
		}

		public override void SetDefaults()
		{
			projectile.CloneDefaults(ProjectileID.BabyGrinch);
            projectile.height = 92;
            projectile.width = 168;
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
			LaugicalityPlayer modPlayer = LaugicalityPlayer.Get(player);

			if (player.dead)
				modPlayer.ToyTrain = false;

			if (modPlayer.ToyTrain)
				projectile.timeLeft = 2;

            if (Math.Abs(projectile.velocity.Y) < 1f && Math.Abs(projectile.velocity.X) > 1f)
            {
                float dist = 0;
                Rectangle rect = projectile.getRect();
                if (projectile.spriteDirection == 1)
                    dist = -24;
                else
                    dist = 24;
                Dust.NewDust(new Vector2(rect.X + projectile.width / 2 + dist, rect.Y), 0, 0, ModContent.DustType<TrainSteam>());
            }
            /*if (Math.Abs(projectile.velocity.Y) > 1f)
            {
                Rectangle rect = projectile.getRect();
                Dust.NewDust(new Vector2(rect.X, rect.Y+projectile.height), projectile.width, 0, ModContent.DustType<Steam>());
            }*/
        }
        
    }
}