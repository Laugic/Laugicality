using Terraria;
using Terraria.ModLoader;

namespace Laugicality.Projectiles.Mystic.Conjuration
{
	public class CupidBurst : ConjurationProjectile
    {
        public bool bitherial = true;
        public int delay = 0;
        public int power = 0;

        public override void SetDefaults()
        {
            power = 0;
            LaugicalityVars.eProjectiles.Add(projectile.type);
            delay = 0;
            projectile.width = 24;
            projectile.height = 24;
            projectile.penetrate = -1;
            projectile.friendly = true;
            projectile.timeLeft = 320;
            projectile.ignoreWater = true;
            projectile.tileCollide = false;
        }
        
        public override void AI()
        {
            projectile.rotation = (float)(3.14*3/2);
            bitherial = true;
            if(Main.rand.Next(4) == 0)
                Dust.NewDust(projectile.position + projectile.velocity, projectile.width, projectile.height, ModContent.DustType("Pink"), 0f, 0f);
            delay++;
            if (delay > 30)
            {
                    delay = 0;
                    power++;
                if (Main.myPlayer == projectile.owner)
                {
                    Projectile.NewProjectile(projectile.Center.X, projectile.Center.Y, 7, 0, ModContent.ProjectileType("CupidConjuration2"), (int)(projectile.damage / 1.2f), 3, Main.myPlayer);
                    Projectile.NewProjectile(projectile.Center.X, projectile.Center.Y, -7, 0, ModContent.ProjectileType("CupidConjuration2"), (int)(projectile.damage / 1.2f), 3, Main.myPlayer);
                    Projectile.NewProjectile(projectile.Center.X, projectile.Center.Y, 0, 7, ModContent.ProjectileType("CupidConjuration2"), (int)(projectile.damage / 1.2f), 3, Main.myPlayer);
                    Projectile.NewProjectile(projectile.Center.X, projectile.Center.Y, 0, -7, ModContent.ProjectileType("CupidConjuration2"), (int)(projectile.damage / 1.2f), 3, Main.myPlayer);
                    Projectile.NewProjectile(projectile.Center.X, projectile.Center.Y, 5, 5, ModContent.ProjectileType("CupidConjuration2"), (int)(projectile.damage / 1.2f), 3, Main.myPlayer);
                    Projectile.NewProjectile(projectile.Center.X, projectile.Center.Y, 5, -5, ModContent.ProjectileType("CupidConjuration2"), (int)(projectile.damage / 1.2f), 3, Main.myPlayer);
                    Projectile.NewProjectile(projectile.Center.X, projectile.Center.Y, -5, -5, ModContent.ProjectileType("CupidConjuration2"), (int)(projectile.damage / 1.2f), 3, Main.myPlayer);
                    Projectile.NewProjectile(projectile.Center.X, projectile.Center.Y, -5, 5, ModContent.ProjectileType("CupidConjuration2"), (int)(projectile.damage / 1.2f), 3, Main.myPlayer);
                }
                projectile.Kill();
            }
        }
    }
}