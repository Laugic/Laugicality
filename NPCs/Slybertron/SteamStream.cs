using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Laugicality.NPCs.Slybertron
{
	public class SteamStream : ModProjectile
    {
        public bool bitherial = true;
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Steam Stream");
            //ProjectileID.Sets.Homing[projectile.type] = true;
			//ProjectileID.Sets.MinionShot[projectile.type] = true;
		}

		public override void SetDefaults()
        {
            LaugicalityVars.EProjectiles.Add(projectile.type);
            bitherial = true;
            projectile.width = 48;
			projectile.height = 48;
			projectile.alpha = 55;
            projectile.timeLeft = 80;
            projectile.friendly = false;
            projectile.hostile = true;
            projectile.ignoreWater = true;
            projectile.tileCollide = false;
        }

		public override void AI()
        {
            bitherial = true;
            Dust.NewDust(projectile.position + projectile.velocity, projectile.width, projectile.height, mod.DustType("Steam"), 0f, 0f);
        }

        public override void OnHitPlayer(Player player, int dmgDealt, bool crit)
        {
            //NPCs.Slybertron.Slybertron.steamStreamHits += 1;
            int debuff = mod.BuffType("Electrified");
            if (debuff >= 0)
            {
                player.AddBuff(debuff, 90, true);
            }      //Add Onfire buff to the NPC for 1 second
        }
    }
}