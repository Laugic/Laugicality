using Microsoft.Xna.Framework;
using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Laugicality.Projectiles.Melee
{
	public class ObsidiumYoyoProjectile : ModProjectile
    {
        public override void SetStaticDefaults()
		{
			ProjectileID.Sets.YoyosLifeTimeMultiplier[projectile.type] = 9f;
			ProjectileID.Sets.YoyosMaximumRange[projectile.type] = 240f;
			ProjectileID.Sets.YoyosTopSpeed[projectile.type] = 14f;
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
		}

        public override void AI()
        {
            LaugicalityPlayer modPlayer = LaugicalityPlayer.Get(Main.player[projectile.owner]);
            if (modPlayer.ObsidiumHeart > 0 && Main.rand.Next(4 * 60 - (3 * 60 * (int)(modPlayer.ObsidiumHeart / 5f))) == 0 && Main.myPlayer == projectile.owner)
            {
                float theta = Main.rand.NextFloat() * (float)Math.PI;
                float mag = Main.rand.NextFloat() * 4 + 8;
                if (Main.myPlayer == projectile.owner)
                    Projectile.NewProjectile(projectile.Center.X, projectile.Center.Y, (float)Math.Cos(theta) * mag, (float)Math.Sin(theta) * mag, ModContent.ProjectileType<ObsidiumYoyoFireball>(), projectile.damage, 3f, Main.myPlayer);
            }
            base.AI();
        }

        public Vector2 GetPosition()
        {
            return projectile.position;
        }

        public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
        {
            LaugicalityPlayer modPlayer = LaugicalityPlayer.Get(Main.player[projectile.owner]);
            if (modPlayer.ObsidiumHeart > 0)
                target.AddBuff(BuffID.OnFire, 2 * 60 + Main.rand.Next(60));
        }
    }
}
