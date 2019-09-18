using Terraria;

namespace Laugicality.Projectiles.Mystic.Illusion
{
    public class OrionIllusionSpawn : IllusionProjectile
    {
        int damage = 0;
        int delay = 0;
        int hSpeed = 0;
        int distance = 0;

        public override void SetDefaults()
        {
            distance = 0;
            hSpeed = 0;
            delay = 0;
            damage = projectile.damage;
            projectile.width = 12;
            projectile.height = 12;
            projectile.friendly = true;
            projectile.penetrate = 2;
            projectile.timeLeft = 240;
            projectile.ignoreWater = true;
            projectile.alpha = 200;
        }

        public override void AI()
        {
            delay++;
            if (delay >= 3)
            {
                delay = 0;
                if (Main.myPlayer == projectile.owner)
                {
                    Projectile.NewProjectile(projectile.Center.X, projectile.Center.Y, 0, 24, mod.ProjectileType("OrionIllusion"), projectile.damage, 3f, Main.myPlayer);
                }
            }
        }
    }
}