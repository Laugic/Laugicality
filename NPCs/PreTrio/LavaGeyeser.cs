using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;

namespace Laugicality.NPCs.PreTrio
{
    class LavaGeyeser : ModProjectile
    {
        int delay = 0;
        public override void SetDefaults()
        {
            delay = 0;
            LaugicalityVars.eProjectiles.Add(projectile.type);
            projectile.width = 42;
            projectile.height = 42;
            projectile.alpha = 0;
            projectile.timeLeft = 480;
            projectile.friendly = false;
            projectile.hostile = true;
            projectile.ignoreWater = true;
            projectile.tileCollide = false;
        }

        public override void AI()
        {
            Vector2 velocity;
            velocity.Y = -20;
            velocity.X = -1 + (float)Main.rand.NextDouble() * 2;
            if (Main.rand.Next(4) == 0)// && Main.myPlayer == projectile.owner)
                Projectile.NewProjectile(projectile.Center, velocity, ModContent.ProjectileType<Lava>(), projectile.damage, 5f);
            delay++;
            if(delay == 60)
            {
                velocity.Y = -16;
                velocity.X = -3;
                //if (Main.myPlayer == projectile.owner)
                    Projectile.NewProjectile(projectile.Center, velocity, ModContent.ProjectileType<GravityFireball>(), projectile.damage, 5f);
                velocity.X = 3;
                //if (Main.myPlayer == projectile.owner)
                    Projectile.NewProjectile(projectile.Center, velocity, ModContent.ProjectileType<GravityFireball>(), projectile.damage, 5f);
            }
            if(delay > 119)
            {
                delay = 0;
                velocity.Y = -18;
                velocity.X = -2;
                //if (Main.myPlayer == projectile.owner)
                    Projectile.NewProjectile(projectile.Center, velocity, ModContent.ProjectileType<GravityFireball>(), projectile.damage, 5f);
                velocity.X = 2;
                //if (Main.myPlayer == projectile.owner)
                    Projectile.NewProjectile(projectile.Center, velocity, ModContent.ProjectileType<GravityFireball>(), projectile.damage, 5f);
                velocity.Y = -16;
                velocity.X = -5;
                //if (Main.myPlayer == projectile.owner)
                    Projectile.NewProjectile(projectile.Center, velocity, ModContent.ProjectileType<GravityFireball>(), projectile.damage, 5f);
                velocity.X = 5;
                //if (Main.myPlayer == projectile.owner)
                    Projectile.NewProjectile(projectile.Center, velocity, ModContent.ProjectileType<GravityFireball>(), projectile.damage, 5f);
            }
        }
    }
}
