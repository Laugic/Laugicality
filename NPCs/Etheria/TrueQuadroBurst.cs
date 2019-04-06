using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;

namespace Laugicality.NPCs.Etheria
{
	public class TrueQuadroBurst : ModProjectile
    {
        public bool bitherial = true;
        int delay = 0;
        int spawned = 0;
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("True Etherial Pulse");
            //ProjectileID.Sets.Homing[projectile.type] = true;
			//ProjectileID.Sets.MinionShot[projectile.type] = true;
		}

		public override void SetDefaults()
        {
            spawned = 0;
            delay = 0;
            LaugicalityVars.EProjectiles.Add(projectile.type);
            bitherial = true;
            projectile.width = 44;
			projectile.height = 44;
			//projectile.alpha = 255;
            projectile.timeLeft = 160;
            projectile.friendly = false;
            projectile.hostile = true;
            projectile.ignoreWater = true;
            projectile.tileCollide = false;
        }

        public override void AI()
        {
            if (Main.rand.Next(0, 14) == 0) Dust.NewDust(projectile.position + projectile.velocity, projectile.width, projectile.height, mod.DustType("Etherial"), 0f, 0f);

            bitherial = true;
            delay++;
            if(delay > 20)
            {
                spawned++;
                delay = 0;
                if (Main.myPlayer == projectile.owner)
                    Projectile.NewProjectile(projectile.Center.X, projectile.Center.Y, -projectile.velocity.X / 4, -projectile.velocity.Y / 4, mod.ProjectileType("TrueEtherialPulsar"), (int)(projectile.damage), 3, Main.myPlayer);
            }
            if(spawned >=5)
                projectile.Kill();
        }
        public override void OnHitPlayer(Player player, int dmgDealt, bool crit)
        {
            player.AddBuff(44, 300, true);//Frostburn
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
    }
}