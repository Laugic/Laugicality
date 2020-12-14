using Laugicality.Dusts;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Laugicality.Projectiles.Melee
{
	public class FlaranceProjectile : ModProjectile
	{
		public override void SetDefaults()
		{
			projectile.width = 16;
			projectile.height = 16;
			projectile.friendly = true;
			projectile.melee = true;
			projectile.penetrate = -1;
			projectile.timeLeft = 240;
		}

		public override void AI()
		{
            if(projectile.velocity.Y < 12)
                projectile.velocity.Y += .15f;
			if(Main.rand.Next(6) == 0)Dust.NewDust(projectile.position + projectile.velocity, projectile.width, projectile.height, ModContent.DustType<Magma>(), projectile.velocity.X * 0.5f, projectile.velocity.Y * 0.5f);

            if (projectile.owner == Main.myPlayer && projectile.timeLeft <= 1 && projectile.ai[0] >= 5 && projectile.ai[1] == 1)
            {
                projectile.velocity.X = 0f;
                projectile.velocity.Y = 0f;
                projectile.tileCollide = false;
                projectile.alpha = 255;
                projectile.position.X = projectile.position.X + (float)(projectile.width / 2);
                projectile.position.Y = projectile.position.Y + (float)(projectile.height / 2);
                projectile.width = 96;
                projectile.height = 96;
                projectile.position.X = projectile.position.X - (float)(projectile.width / 2);
                projectile.position.Y = projectile.position.Y - (float)(projectile.height / 2);
            }
        }

		public override bool OnTileCollide(Vector2 oldVelocity)
		{
            if (projectile.ai[0] == 0)
                projectile.Kill();
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
            if(projectile.ai[0] >= 5 && projectile.ai[1] == 1)
                Main.PlaySound(SoundID.Item14, projectile.position);
            for (int k = 0; k < 18; k++)
            {
                Dust.NewDust(projectile.position + projectile.velocity, projectile.width, projectile.height, ModContent.DustType<Magma>(), projectile.oldVelocity.X * 0.5f, projectile.oldVelocity.Y * 0.5f);
            }
        }
        public override void ModifyHitNPC(NPC target, ref int damage, ref float knockback, ref bool crit, ref int hitDirection)
        {
            if (projectile.ai[0] >= 5)
                damage = (int)(damage * 1.5);
        }
        public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
		{
            if(projectile.ai[0] >= 3)
			    target.AddBuff(BuffID.OnFire, 2 * 60 + Main.rand.Next(60));
            projectile.timeLeft = 2;
            projectile.ai[1] = 1;
        }
	}
}