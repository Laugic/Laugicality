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
            projectile.width = 12;
            projectile.height = 12;
            projectile.friendly = true;
            projectile.penetrate = -1;
            projectile.timeLeft = 200;
            projectile.ignoreWater = true;
            projectile.tileCollide = false;
        }

        
        
        public override void AI()
        {
            projectile.rotation = (float)Math.Atan2((double)projectile.velocity.Y, (double)projectile.velocity.X) + 1.57f;

            Player player = Main.player[projectile.owner];
            LaugicalityPlayer modPlayer = player.GetModPlayer<LaugicalityPlayer>(mod);
            power = modPlayer.illusionPower;
            mystDur = modPlayer.mysticDuration;
            if (Math.Abs(projectile.velocity.X) <= 16 && Math.Abs(projectile.velocity.Y) <= 16)
            {
                projectile.velocity.X *= 1.02f;
                projectile.velocity.Y *= 1.02f;
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