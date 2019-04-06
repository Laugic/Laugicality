using Microsoft.Xna.Framework;
using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Laugicality.Projectiles
{
    public class GearIO : ModProjectile
    {
        public int reload = 30;
        public override void SetStaticDefaults()
        {
            ProjectileID.Sets.YoyosLifeTimeMultiplier[projectile.type] = 16f;
            ProjectileID.Sets.YoyosMaximumRange[projectile.type] = 340f;
            ProjectileID.Sets.YoyosTopSpeed[projectile.type] = 18f;
        }

        public override void SetDefaults()
        {
            projectile.extraUpdates = 0;
            projectile.width = 16;
            projectile.height = 16;
            projectile.aiStyle = 99;
            projectile.friendly = true;
            projectile.penetrate = -1;
            projectile.melee = true;
            projectile.scale = 1f;
            reload = 30;
        }

        public Vector2 getPosition()
        {
            return projectile.position;
        }

        public override void PostAI()
        {
            reload -= 1;
            if (reload <= 0)
            {
                reload = 15;
                float theta = Main.rand.NextFloat() * (float)Math.PI;
                float mag = Main.rand.NextFloat() * 4 + 8;
                if (Main.myPlayer == projectile.owner)
                    Projectile.NewProjectile(projectile.Center.X, projectile.Center.Y, (float)Math.Cos(theta) * mag, (float)Math.Sin(theta) * mag, mod.ProjectileType("GearIO2"), projectile.damage, 3f, Main.myPlayer);
            }
        }
    }
}
