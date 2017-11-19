using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Laugicality.NPCs.Etheria
{
	public class EtherialPulse : ModProjectile
    {
        public bool bitherial = true;
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Etherial Pulse");
            //ProjectileID.Sets.Homing[projectile.type] = true;
			//ProjectileID.Sets.MinionShot[projectile.type] = true;
		}

		public override void SetDefaults()
        {
            LaugicalityVars.EProjectiles.Add(projectile.type);
            bitherial = true;
            projectile.width = 22;
			projectile.height = 22;
			//projectile.alpha = 255;
            projectile.timeLeft = 80;
            projectile.friendly = false;
            projectile.hostile = true;
            projectile.ignoreWater = true;
            projectile.tileCollide = false;
        }

        public override void AI()
        {
            if (Main.rand.Next(0, 14) == 0) Dust.NewDust(projectile.position + projectile.velocity, projectile.width, projectile.height, mod.DustType("Etherial"), 0f, 0f);

            bitherial = true;
        }
        public override void OnHitPlayer(Player player, int dmgDealt, bool crit)
        {
            player.AddBuff(BuffID.Chilled, 90, true);
        }
    }
}