using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;

namespace Laugicality.NPCs.Ameldera
{
    public class ElderShardRock : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Elder Shard Rock");
        }

        public override void SetDefaults()
        {
            LaugicalityVars.eProjectiles.Add(projectile.type);
            projectile.width = 24;
            projectile.height = 24;
            projectile.timeLeft = 180;
            projectile.friendly = false;
            projectile.hostile = true;
            projectile.ignoreWater = true;
            projectile.tileCollide = true;
        }

        public override void AI()
        {
            projectile.rotation = (float)Math.Atan2((double)projectile.velocity.Y, (double)projectile.velocity.X) + 1.57f / 2;
        }


        public override bool OnTileCollide(Vector2 oldVelocity)
        {
            float theta, mag;
            for(int i = 0; i < 5; i++)
            {
                theta = Main.rand.NextFloat() * (float)Math.PI;
                mag = Main.rand.NextFloat() * 3 + 3; 
                Projectile.NewProjectile(projectile.Center, new Vector2((float)Math.Cos(theta) * mag, (float)Math.Sin(theta) * -mag), ModContent.ProjectileType<ElderCrystalShard>(), projectile.damage / 2, 3f);
            }
            projectile.Kill();
            return base.OnTileCollide(oldVelocity);
        }
    }
}