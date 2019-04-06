using Terraria;
using Terraria.ModLoader;

namespace Laugicality.NPCs.PreTrio
{
	public class RockFalling : ModProjectile
	{
        public int delay = 0;
        public int delMax = 200;
        public bool bitherial = true;
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Falling Rock");
		}

		public override void SetDefaults()
        {
            //LaugicalityVars.EProjectiles.Add(projectile.type);
            bitherial = true;
            delMax = 0;
            delay = 0;
            projectile.width = 32;
			projectile.height = 32;
			//projectile.alpha = 255;
            projectile.timeLeft = 500;
            projectile.friendly = false;
            projectile.hostile = true;
            projectile.ignoreWater = true;
            projectile.tileCollide = false;
            //projectile.rotation = (float)(Main.rand.Next(5) * 3.14 / 4);
        }

		public override void AI()
        {
            bitherial = true;
            Dust.NewDust(projectile.position + projectile.velocity, projectile.width, projectile.height, 127, 0f, 0f);

            if (delMax == 0)
                delMax = 20 + 20 * Main.rand.Next(0, 3);
            projectile.rotation += 0.02f;
            projectile.velocity.Y += .04f;
            if(Main.expertMode)
                delay += 1;
            if(delay >= delMax && Main.netMode != 1)
            {
                Projectile.NewProjectile(projectile.Center.X, projectile.Center.Y, 7, 0, mod.ProjectileType("MiniRock"), (int)(projectile.damage / 1.27f), 3, Main.myPlayer);
                Projectile.NewProjectile(projectile.Center.X, projectile.Center.Y, -7, 0, mod.ProjectileType("MiniRock"), (int)(projectile.damage / 1.27f), 3, Main.myPlayer);
                Projectile.NewProjectile(projectile.Center.X, projectile.Center.Y, 0, 7, mod.ProjectileType("MiniRock"), (int)(projectile.damage / 1.27f), 3, Main.myPlayer);
                Projectile.NewProjectile(projectile.Center.X, projectile.Center.Y, 0, -7, mod.ProjectileType("MiniRock"), (int)(projectile.damage / 1.27f), 3, Main.myPlayer);
                Projectile.NewProjectile(projectile.Center.X, projectile.Center.Y, 5, 5, mod.ProjectileType("MiniRock"), (int)(projectile.damage / 1.27f), 3, Main.myPlayer);
                Projectile.NewProjectile(projectile.Center.X, projectile.Center.Y, 5, -5, mod.ProjectileType("MiniRock"), (int)(projectile.damage / 1.27f), 3, Main.myPlayer);
                Projectile.NewProjectile(projectile.Center.X, projectile.Center.Y, -5, -5, mod.ProjectileType("MiniRock"), (int)(projectile.damage / 1.27f), 3, Main.myPlayer);
                Projectile.NewProjectile(projectile.Center.X, projectile.Center.Y, -5, 5, mod.ProjectileType("MiniRock"), (int)(projectile.damage / 1.27f), 3, Main.myPlayer);
                projectile.Kill();
            }
        }
        
    }
}