using System;
using Laugicality.Dusts;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Laugicality.Projectiles.Pets
{
	public class ObsidiumHeartProjectile : ModProjectile
    {

        public float vAccel = 0;
        public float tVel = 0;
        public float vMag = 0;
        public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Obsidium Heart");
			Main.projFrames[projectile.type] = 1;
			Main.projPet[projectile.type] = true;
			ProjectileID.Sets.TrailingMode[projectile.type] = 2;
			ProjectileID.Sets.LightPet[projectile.type] = true;
		}

		public override void SetDefaults()
        {
            vAccel = .1f;
            projectile.width = 28;
			projectile.height = 28;
			projectile.penetrate = -1;
			projectile.netImportant = true;
			projectile.timeLeft *= 5;
			projectile.friendly = true;
			projectile.ignoreWater = true;
			projectile.scale = 1f;
			projectile.tileCollide = false;
		}
        

		public override void AI()
		{
			Player player = Main.player[projectile.owner];
			LaugicalityPlayer modPlayer = LaugicalityPlayer.Get(player);
            if (Main.rand.Next(30) == 0) Dust.NewDust(projectile.position + projectile.velocity, projectile.width, projectile.height, ModContent.DustType<Magma>(), projectile.velocity.X * 0.5f, projectile.velocity.Y * 0.5f);
            if (!player.active)
			{
				projectile.active = false;
				return;
			}
			if (player.dead)
			{
				modPlayer.obsHeart = false;
			}
			if (modPlayer.obsHeart)
			{
				projectile.timeLeft = 2;
			}
            else
            {
                projectile.active = false;
            }

            float mag = 128;
            Vector2 rot = projectile.position;
            rot.X = (float)Math.Cos(modPlayer.theta) * mag;
            rot.Y = (float)Math.Sin(modPlayer.theta) * mag;
            Vector2 targetPos = player.Center + rot;
            float dist = Vector2.Distance(targetPos, projectile.Center);
            tVel = dist / 15;
            if (vMag < tVel)
            {
                vMag += vAccel;
            }

            if (vMag > tVel)
            {
                vMag = tVel;
            }

            if (dist != 0)
            {
                projectile.velocity = projectile.DirectionTo(targetPos) * vMag;
            }

            Lighting.AddLight(projectile.Center, ((255 - projectile.alpha) * 0.8f) / 255f, ((255 - projectile.alpha) * 0.4f) / 255f, 0);
        }
	}
}