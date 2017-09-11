using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Laugicality.NPCs.Slybertron
{
	public class XOut : ModProjectile
    {
        public int delay = 25;
        public int damage = 0;
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("X-Out");
            //ProjectileID.Sets.Homing[projectile.type] = true;
			//ProjectileID.Sets.MinionShot[projectile.type] = true;
		}

		public override void SetDefaults()
		{
			projectile.width = 48;
			projectile.height = 48;
			//projectile.alpha = 255;
            projectile.timeLeft = 120;
            projectile.friendly = false;
            projectile.hostile = true;
            projectile.ignoreWater = true;
            projectile.tileCollide = false;
            delay = 0;
            damage = 40;
        }

		public override void AI()
        {
            delay += 1;
            if (delay == 30)
            {
                Main.PlaySound(SoundID.Item33, (int)projectile.position.X, (int)projectile.position.Y);
                Projectile.NewProjectile(projectile.Center.X, projectile.Center.Y, projectile.velocity.X + 3, projectile.velocity.Y + 3, mod.ProjectileType("ElectroshockP2"), damage, 3f, Main.myPlayer);
                Projectile.NewProjectile(projectile.Center.X, projectile.Center.Y, projectile.velocity.X + 3, projectile.velocity.Y - 3, mod.ProjectileType("ElectroshockP2"), damage, 3f, Main.myPlayer);
                Projectile.NewProjectile(projectile.Center.X, projectile.Center.Y, projectile.velocity.X - 3, projectile.velocity.Y - 3, mod.ProjectileType("ElectroshockP2"), damage, 3f, Main.myPlayer);
                Projectile.NewProjectile(projectile.Center.X, projectile.Center.Y, projectile.velocity.X - 3, projectile.velocity.Y + 3, mod.ProjectileType("ElectroshockP2"), damage, 3f, Main.myPlayer);
                delay = 0;
            }
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