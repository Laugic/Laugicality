using Laugicality.Dusts;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Laugicality.Projectiles.Mystic.Destruction
{
	public class HadesDestruction : DestructionProjectile
    {
		public override void SetDefaults()
		{
			projectile.width = 16;
			projectile.height = 16;
			projectile.friendly = true;
			projectile.penetrate = -1;
			projectile.timeLeft = 30;
		}

		public override void AI()
		{
            if(projectile.velocity.Y < 12)
                projectile.velocity.Y += .15f;
			if(Main.rand.Next(6) == 0)Dust.NewDust(projectile.position + projectile.velocity, projectile.width, projectile.height, ModContent.DustType<Magma>(), projectile.velocity.X * 0.5f, projectile.velocity.Y * 0.5f);

        }

		public override bool OnTileCollide(Vector2 oldVelocity)
		{
			if (projectile.velocity.X != oldVelocity.X)
			{
				projectile.velocity.X = -oldVelocity.X;
			}
			if (projectile.velocity.Y != oldVelocity.Y)
			{
				projectile.velocity.Y = -oldVelocity.Y;
			}
            projectile.velocity.Y *= .9f;
            return false;
		}

		public override void Kill(int timeLeft)
        {
            for (int k = 0; k < 9; k++)
            {
                Dust.NewDust(projectile.position + projectile.velocity, projectile.width, projectile.height, ModContent.DustType<Magma>(), projectile.oldVelocity.X * 0.5f, projectile.oldVelocity.Y * 0.5f);
            }
        }
	}
}