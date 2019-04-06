using Terraria;
using Terraria.ModLoader;

namespace Laugicality.Projectiles
{
	public class AncientRune : ModProjectile
	{
        public bool bitherial = true;
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Sandnado");
		}

		public override void SetDefaults()
        {
            LaugicalityVars.eProjectiles.Add(projectile.type);
            bitherial = true;
            projectile.width = 16;
			projectile.height = 16;
			//projectile.alpha = 255;
            projectile.timeLeft = 180;
            projectile.friendly = true;
            projectile.ignoreWater = true;
            projectile.tileCollide = false;
            //projectile.rotation = (float)(Main.rand.Next(5) * 3.14 / 4);
            projectile.penetrate = -1;
        }

		public override void AI()
        {
            bitherial = true;
            Dust.NewDust(projectile.position + projectile.velocity, projectile.width, projectile.height, mod.DustType("Sandy"), projectile.velocity.X * 0.05f, projectile.velocity.Y * 0.5f);
            
            projectile.rotation += 0.02f;
            LaugicalityPlayer modPlayer = Main.player[projectile.owner].GetModPlayer<LaugicalityPlayer>();
            if (Main.rand.Next(4) == 0 && Main.myPlayer == projectile.owner)
                Projectile.NewProjectile(projectile.Center.X, projectile.Center.Y, -4+Main.rand.Next(0,9), -Main.rand.Next(3,7),  mod.ProjectileType("AncientRuneUp"), (int)(12 * modPlayer.MysticDamage * modPlayer.mysticBurstDamage), 3, Main.myPlayer);
            
        }
        
    }
}