using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Laugicality;
using Laugicality.NPCs;

namespace Laugicality.Projectiles.Mystic
{
	public class FriggIllusion : ModProjectile
    {
        public float mystDur = 1;
        public int power = 1;
		
        public override void SetDefaults()
        {
            projectile.width = 32;
            projectile.height = 32;
			projectile.aiStyle = -1;
			projectile.alpha = 255;
            projectile.penetrate = -1;
            projectile.timeLeft = 120;
            projectile.friendly = true;
            projectile.ignoreWater = true;
            projectile.tileCollide = false;
        }

        public override void AI()
        {
            Player player = Main.player[projectile.owner];
            LaugicalityPlayer modPlayer = player.GetModPlayer<LaugicalityPlayer>(mod);
            power = modPlayer.illusionPower;
            mystDur = modPlayer.mysticDuration;
			
			if (projectile.timeLeft > 20 && projectile.alpha > 0)
			{
				projectile.alpha -= 15;
			}
			else
			{
				projectile.alpha += 15;
			}
			
			if (projectile.velocity.X > 0f)
			{
				projectile.rotation += 0.08f;
			}
			else
			{
				projectile.rotation -= 0.08f;
			}
			
            if (Math.Abs(projectile.velocity.X) <= 10f && Math.Abs(projectile.velocity.Y) <= 10f)
            {
                projectile.velocity.X *= 1.01f;
                projectile.velocity.Y *= 1.01f;
            }
        }

        public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
        {
            int debuff = BuffID.Poisoned;
            if (debuff >= 0)
            {
                target.AddBuff(debuff, (int)(120 * mystDur * power), true);
            }
        }
    }
}