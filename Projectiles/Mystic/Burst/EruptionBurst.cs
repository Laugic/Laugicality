using Terraria;
using Terraria.ModLoader;

namespace Laugicality.Projectiles.Mystic.Burst
{
	public class EruptionBurst : ModProjectile
	{
        public bool bitherial = true;
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Eruption Burst");
		}

		public override void SetDefaults()
        {
            LaugicalityVars.eProjectiles.Add(projectile.type);
            bitherial = true;
            projectile.width = 16;
			projectile.height = 16;
            projectile.timeLeft = 180;
            projectile.friendly = true;
            projectile.ignoreWater = true;
            projectile.tileCollide = false;
            projectile.penetrate = -1;
        }

		public override void AI()
        {
            bitherial = true;
            Dust.NewDust(projectile.position + projectile.velocity, projectile.width, projectile.height, ModContent.DustType<Magma>(), projectile.velocity.X * 0.05f, projectile.velocity.Y * 0.5f);
            
            projectile.rotation += 0.02f;
            LaugicalityPlayer modPlayer = Main.player[projectile.owner].GetModPlayer<LaugicalityPlayer>();
            if (Main.rand.Next(2) == 0 && Main.myPlayer == projectile.owner)
                Projectile.NewProjectile(projectile.Center.X, projectile.Center.Y, projectile.velocity.X + -5+Main.rand.Next(0,11), -Main.rand.Next(5,10),  ModContent.ProjectileType("EruptionBurstUp"), (int)(30 * modPlayer.MysticDamage * modPlayer.MysticBurstDamage), 3, Main.myPlayer);
            
        }
        
    }
}