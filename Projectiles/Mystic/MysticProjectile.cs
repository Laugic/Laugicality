using Laugicality.Buffs;
using Laugicality.Projectiles.Mystic.Overflow;
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
        public int baseDuration = 8 * 60;


        public override void SetDefaults()
        {
            overflowed = false;
            durationed = false;
            duration = 1;
            LaugicalityVars.eProjectiles.Add(projectile.type);
        }

        public override bool PreAI()
        {
            if (!durationed)
            {
                duration = Main.player[projectile.owner].GetModPlayer<LaugicalityPlayer>().MysticDuration;
                durationed = true;
                Durationed(duration);
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
            if (modPlayer.MysticMode == 1 && modPlayer.Lux + modPlayer.CurrentLuxCost > modPlayer.LuxMax + modPlayer.LuxMaxPermaBoost)
                return true;
            if (modPlayer.MysticMode == 2 && modPlayer.Vis + modPlayer.CurrentVisCost > modPlayer.VisMax + modPlayer.VisMaxPermaBoost)
                return true;
            if (modPlayer.MysticMode == 3 && modPlayer.Mundus + modPlayer.CurrentMundusCost > modPlayer.MundusMax + modPlayer.MundusMaxPermaBoost)
                return true;
            return false;
        }
        
        private void OverflowEffects()
        {
            LaugicalityPlayer modPlayer = Main.player[projectile.owner].GetModPlayer<LaugicalityPlayer>();
            //if (modPlayer.ShroomOverflow > 0)
            //    projectile.tileCollide = false;
        }

        public virtual void Durationed(float dur)
        {

        }

        public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
        {
            if(buffID != 0)
                target.AddBuff(buffID, (int)(baseDuration * duration) + Main.rand.Next(1 * 60));

            LaugicalityPlayer modPlayer = Main.player[projectile.owner].GetModPlayer<LaugicalityPlayer>();

            if (modPlayer.Incineration > 0)
                target.AddBuff(ModContent.BuffType<Incineration>(), (int)(baseDuration * duration) + Main.rand.Next(1 * 60));
            if (modPlayer.SporeShard > 0)
                target.AddBuff(ModContent.BuffType<Spored>(), (int)(baseDuration * duration) + Main.rand.Next(1 * 60));
            if (modPlayer.MysticShroomBurst && Main.myPlayer == projectile.owner && projectile.type != ModContent.ProjectileType<OverflowSpore>() && overflowed)
                Projectile.NewProjectile(projectile.Center.X, projectile.Center.Y, 0, -10f, ModContent.ProjectileType<OverflowSpore>(), (int)(projectile.damage / 1.2f), 3, Main.myPlayer);
        }
    }
}
