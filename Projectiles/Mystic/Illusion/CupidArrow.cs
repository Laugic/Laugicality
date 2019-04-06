using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Laugicality.Projectiles.Mystic.Illusion
{
	public class CupidArrow : IllusionProjectile
    {
        bool justSpawned = false;

        public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Heartburn Arrow");     
		}

		public override void SetDefaults()
        {
            justSpawned = false;
            projectile.width = 18;
			projectile.height = 18;
			projectile.aiStyle = 1;
			projectile.friendly = true;
			projectile.hostile = false;
			projectile.ranged = true;
			projectile.penetrate = 2;
			projectile.timeLeft = 600;
			projectile.ignoreWater = true;
			projectile.tileCollide = false;
            buffID = mod.BuffType("Lovestruck");
        }

        public override void AI()
        {
            if (!justSpawned)
            {
                justSpawned = true;
                Vector2 targetPos;
                targetPos.X = Main.MouseWorld.X;
                targetPos.Y = Main.MouseWorld.Y;
                projectile.velocity = projectile.DirectionTo(targetPos) * 12f;
            }
        }

        public override bool OnTileCollide(Vector2 oldVelocity)
		{
			projectile.Kill();
			return false;
		}
    }
}
