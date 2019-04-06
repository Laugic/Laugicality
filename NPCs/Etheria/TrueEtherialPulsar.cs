using Microsoft.Xna.Framework;
using System;
using Terraria;
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
            DisplayName.SetDefault("True Etherial Pulsar");
            //ProjectileID.Sets.Homing[projectile.type] = true;
			//ProjectileID.Sets.MinionShot[projectile.type] = true;
		}

		public override void SetDefaults()
        {
            LaugicalityVars.eProjectiles.Add(projectile.type);
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
            damage = 60;
        }

        public override void AI()
        {
            bitherial = true;
            if (Main.rand.Next(0, 14) == 0) Dust.NewDust(projectile.position + projectile.velocity, projectile.width, projectile.height, mod.DustType("Etherial"), 0f, 0f);
            delay += 1;
                projectile.velocity *= .95f;
            if(delay >= 100 && Main.netMode != 1)
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
            projectile.rotation = (float)Math.Atan2((double)projectile.velocity.Y, (double)projectile.velocity.X) + 1.57f / 2;
        }

        public override Color? GetAlpha(Color drawColor)
        {
            var b = 225;
            var b2 = 125;
            var b3 = 155;
            if (drawColor.R != (byte)b)
            {
                drawColor.R = (byte)b;
            }
            if (drawColor.G < (byte)b2)
            {
                drawColor.G = (byte)b2;
            }
            if (drawColor.B < (byte)b3)
            {
                drawColor.B = (byte)b3;
            }
            return drawColor;
        }

        public override void OnHitPlayer(Player player, int dmgDealt, bool crit)
        {
            player.AddBuff(44, 300, true);
        }
    }
}