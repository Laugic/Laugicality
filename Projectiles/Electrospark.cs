using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Laugicality.Projectiles
{
	public class Electrospark : ModProjectile
	{
        private int delay = 0;
        public int damage = 0;

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Electrospark");
            //ProjectileID.Sets.Homing[projectile.type] = true;
			//ProjectileID.Sets.MinionShot[projectile.type] = true;
		}

		public override void SetDefaults()
		{
			projectile.width = 48;
			projectile.height = 48;
			//projectile.alpha = 255;
            projectile.timeLeft = 240;
            projectile.friendly = true;
            projectile.hostile = false;
            projectile.ignoreWater = true;
            projectile.tileCollide = false;
            projectile.penetrate = 3;
            delay = 0;
            damage = 50;
        }

        public override void AI()
        {
            delay += 1;
            if(delay == 25 && Main.myPlayer == projectile.owner)
            {
                //Main.PlaySound(SoundID.Item33, (int)projectile.position.X, (int)projectile.position.Y);
                Projectile.NewProjectile(projectile.Center.X, projectile.Center.Y, projectile.velocity.X + 3, projectile.velocity.Y + 3, mod.ProjectileType("ElectrosparkP2"), damage, 3f, Main.myPlayer);
                Projectile.NewProjectile(projectile.Center.X, projectile.Center.Y, projectile.velocity.X + 3, projectile.velocity.Y - 3, mod.ProjectileType("ElectrosparkP2"), damage, 3f, Main.myPlayer);
                Projectile.NewProjectile(projectile.Center.X, projectile.Center.Y, projectile.velocity.X - 3, projectile.velocity.Y - 3, mod.ProjectileType("ElectrosparkP2"), damage, 3f, Main.myPlayer);
                Projectile.NewProjectile(projectile.Center.X, projectile.Center.Y, projectile.velocity.X - 3, projectile.velocity.Y + 3, mod.ProjectileType("ElectrosparkP2"), damage, 3f, Main.myPlayer);
            }
        }

        public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
        {
            //NPCs.Slybertron.Slybertron.electroShockHits += 1;
            int debuff = mod.BuffType("Steamy");
            if (debuff >= 0)
            {
                target.AddBuff(debuff, 90, true);
            }      //Add Onfire buff to the NPC for 1 second
        }
    }
}