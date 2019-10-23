using Laugicality.Dusts;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;

namespace Laugicality.NPCs.Etheria
{
	public class QuadroBurst : ModProjectile
    {
        public bool bitherial = true;
        int _delay = 0;
        int _spawned = 0;
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Etherial Pulse");
            //ProjectileID.Sets.Homing[projectile.type] = true;
			//ProjectileID.Sets.MinionShot[projectile.type] = true;
		}

		public override void SetDefaults()
        {
            _spawned = 0;
            _delay = 0;
            LaugicalityVars.eProjectiles.Add(projectile.type);
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
            if (Main.rand.Next(0, 14) == 0) Dust.NewDust(projectile.position + projectile.velocity, projectile.width, projectile.height, ModContent.DustType<EtherialDust>(), 0f, 0f);

            bitherial = true;
            _delay++;
            if(_delay > 20)
            {
                _spawned++;
                _delay = 0;
                if (Main.myPlayer == projectile.owner)
                    Projectile.NewProjectile(projectile.Center.X, projectile.Center.Y, -projectile.velocity.X / 4, -projectile.velocity.Y / 4, ModContent.ProjectileType<EtherialPulsar>(), (int)(projectile.damage), 3, Main.myPlayer);
            }
            if(_spawned >=4)
                projectile.Kill();
        }
        public override void OnHitPlayer(Player player, int dmgDealt, bool crit)
        {
            player.AddBuff(44, 300, true);//Frostburn
        }

        public override Color? GetAlpha(Color drawColor)
        {
            int b = 125;
            int b2 = 225;
            int b3 = 255;
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