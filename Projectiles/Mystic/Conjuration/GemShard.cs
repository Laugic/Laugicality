using Microsoft.Xna.Framework;
using Terraria;

namespace Laugicality.Projectiles.Mystic.Conjuration
{
	public class GemShard : ConjurationProjectile
    {
		public Color colorType;
		
        public override void SetDefaults()
        {
            projectile.width = 12;
            projectile.height = 12;
            projectile.friendly = true;
            projectile.penetrate = 1;
            projectile.timeLeft = 60;
            projectile.ignoreWater = true;
            projectile.tileCollide = false;
			Main.projFrames[projectile.type] = 6;
        }
        
		public override void AI()
        {
			projectile.frame = (int)(projectile.ai[1]);
			
			projectile.velocity *= 0.95f;
			
			if (projectile.velocity.X > 0f)
			{
				projectile.rotation += 0.25f;
			}
			else
			{
				projectile.rotation -= 0.25f;
			}

			if (projectile.ai[1] == 0){colorType = new Color(255,0,0);}
			if (projectile.ai[1] == 1){colorType = new Color(255,226,0);}
			if (projectile.ai[1] == 2){colorType = new Color(8,255,0);}
			if (projectile.ai[1] == 3){colorType = new Color(0,217,255);}
			if (projectile.ai[1] == 4){colorType = new Color(209,0,255);}
			if (projectile.ai[1] == 5){colorType = new Color(255,255,255);}
			
			if (projectile.timeLeft < 20)
			{
				projectile.alpha += 8;
			}
		}
		
		public override void Kill(int timeLeft)
		{
			for (int k = 0; k < 5; k++)
			{
				int dust = Dust.NewDust(projectile.position, projectile.width, projectile.height, 16, Main.rand.Next((int)-2f, (int)2f), Main.rand.Next((int)-2f, (int)2f), 0, colorType, 0.75f);
				Main.dust[dust].noGravity = true;
				Main.dust[dust].noLight = true;
			}
		}
    }
}