using System;
using Terraria;
using Terraria.ModLoader;

namespace Laugicality.Projectiles.Mystic
{
    public class MysticProjectile : ModProjectile
    {
        bool durationed = false;
        public float duration = 1;
        public bool overflowed = false;
        public int buffID = 0;
        public int baseDuration = 4 * 60;


        public override void SetDefaults()
        {
            overflowed = false;
            durationed = false;
            duration = 1;
        }

        public override bool PreAI()
        {
            if (!durationed)
            {
                duration = Main.player[projectile.owner].GetModPlayer<LaugicalityPlayer>().MysticDuration;
                durationed = true;
                projectile.timeLeft = (int)(projectile.timeLeft * duration);
                overflowed = CheckOverflow();
            }
            if (overflowed)
            {
                OverflowEffects();
            }
            return true;
        }

        private bool CheckOverflow()
        {
            LaugicalityPlayer modPlayer = Main.player[projectile.owner].GetModPlayer<LaugicalityPlayer>();
            if (modPlayer.MysticMode == 1 && modPlayer.lux + modPlayer.currentLuxCost > modPlayer.luxMax + modPlayer.luxMaxPermaBoost)
                return true;
            if (modPlayer.MysticMode == 2 && modPlayer.vis + modPlayer.currentVisCost > modPlayer.visMax + modPlayer.visMaxPermaBoost)
                return true;
            if (modPlayer.MysticMode == 3 && modPlayer.mundus + modPlayer.currentMundusCost > modPlayer.mundusMax + modPlayer.mundusMaxPermaBoost)
                return true;
            return false;
        }
        
        private void OverflowEffects()
        {
            LaugicalityPlayer modPlayer = Main.player[projectile.owner].GetModPlayer<LaugicalityPlayer>();
            if (modPlayer.shroomOverflow > 0)
                projectile.tileCollide = false;
        }

        public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
        {
            target.AddBuff(buffID, (int)(baseDuration * duration) + Main.rand.Next(1 * 60));

            LaugicalityPlayer modPlayer = Main.player[projectile.owner].GetModPlayer<LaugicalityPlayer>();
            if (modPlayer.incineration > 0)
                target.AddBuff(mod.BuffType("Incineration"), (int)(4 * 60 * duration) + Main.rand.Next(1 * 60));
            if (modPlayer.sporeShard > 0)
                target.AddBuff(mod.BuffType("Spored"), (int)(4 * 60 * duration) + Main.rand.Next(1 * 60));
        }
    }
}
