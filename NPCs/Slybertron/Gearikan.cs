using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Laugicality.NPCs.Slybertron
{
	public class Gearikan : ModProjectile
	{
        public int grounded = 0;
        public bool bitherial = true;
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Gearikan");
            //ProjectileID.Sets.Homing[projectile.type] = true;
			//ProjectileID.Sets.MinionShot[projectile.type] = true;
		}

		public override void SetDefaults()
        {
            LaugicalityVars.EProjectiles.Add(projectile.type);
            bitherial = true;
            grounded = 0;
            projectile.width = 22;
			projectile.height = 22;
			//projectile.alpha = 255;
            projectile.timeLeft = 600;
            projectile.friendly = false;
            projectile.hostile = true;
            projectile.ignoreWater = true;
            projectile.tileCollide = true;
        }

		public override void AI()
        {
            bitherial = true;
            projectile.rotation += projectile.velocity.X;
            projectile.velocity.Y += .5f;
        }

        public override bool OnTileCollide(Vector2 oldVelocity)
        {
            projectile.velocity.Y = 0;
            grounded = 1;
            return false;
        }
        public override void OnHitPlayer(Player player, int dmgDealt, bool crit)
        {
            //NPCs.Slybertron.Slybertron.gearikanHits += 1;
            int debuff = mod.BuffType("Electrified");
            if (debuff >= 0)
            {
                player.AddBuff(debuff, 90, true);
            }      //Add Onfire buff to the NPC for 1 second
        }
    }
}