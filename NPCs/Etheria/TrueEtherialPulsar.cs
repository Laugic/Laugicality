using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Laugicality.NPCs.Etheria
{
	public class TrueEtherialPulsar : ModProjectile
	{
        public int delay = 0;
        public int damage = 0;
        public bool bitherial = true;

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Etherial Pulsar");
            //ProjectileID.Sets.Homing[projectile.type] = true;
			//ProjectileID.Sets.MinionShot[projectile.type] = true;
		}

		public override void SetDefaults()
        {
            LaugicalityVars.EProjectiles.Add(projectile.type);
            bitherial = true;
            projectile.width = 44;
			projectile.height = 44;
			//projectile.alpha = 255;
            projectile.timeLeft = 240;
            projectile.friendly = false;
            projectile.hostile = true;
            projectile.ignoreWater = true;
            projectile.tileCollide = false;
            delay = 0;
            damage = 50;
            projectile.scale = 2f;
        }

        public override void AI()
        {
            bitherial = true;
            if (Main.rand.Next(0, 14) == 0) Dust.NewDust(projectile.position + projectile.velocity, projectile.width, projectile.height, mod.DustType("Etherial"), 0f, 0f);
            delay += 1;
            if (delay > 80)
                projectile.velocity *= .95f;
            if(delay == 140)
            {
                Projectile.NewProjectile(projectile.Center.X, projectile.Center.Y, 7, 0, mod.ProjectileType("TrueEtherialPulse"), damage, 3f, Main.myPlayer);
                Projectile.NewProjectile(projectile.Center.X, projectile.Center.Y, -7, 0, mod.ProjectileType("TrueEtherialPulse"), damage, 3f, Main.myPlayer);
                Projectile.NewProjectile(projectile.Center.X, projectile.Center.Y, 0, -7, mod.ProjectileType("TrueEtherialPulse"), damage, 3f, Main.myPlayer);
                Projectile.NewProjectile(projectile.Center.X, projectile.Center.Y, 0, 7, mod.ProjectileType("TrueEtherialPulse"), damage, 3f, Main.myPlayer);
                Projectile.NewProjectile(projectile.Center.X, projectile.Center.Y, 5, 5, mod.ProjectileType("TrueEtherialPulse"), damage, 3f, Main.myPlayer);
                Projectile.NewProjectile(projectile.Center.X, projectile.Center.Y, 5, -5, mod.ProjectileType("TrueEtherialPulse"), damage, 3f, Main.myPlayer);
                Projectile.NewProjectile(projectile.Center.X, projectile.Center.Y, -5, -5, mod.ProjectileType("TrueEtherialPulse"), damage, 3f, Main.myPlayer);
                Projectile.NewProjectile(projectile.Center.X, projectile.Center.Y, -5, 5, mod.ProjectileType("TrueEtherialPulse"), damage, 3f, Main.myPlayer);
                projectile.Kill();
            }
        }

        public override void OnHitPlayer(Player player, int dmgDealt, bool crit)
        {
            player.AddBuff(BuffID.Chilled, 90, true);
        }
    }
}