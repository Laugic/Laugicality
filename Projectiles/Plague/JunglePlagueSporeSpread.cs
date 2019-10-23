using Laugicality.Buffs;
using Laugicality.NPCs;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Laugicality.Projectiles.Plague
{
    public class JunglePlagueSporeSpread : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Jungle Plague Spore");
        }
        public override void SetDefaults()
        {
            projectile.width = 16;
            projectile.height = 16;
            projectile.friendly = true;
            projectile.tileCollide = false;
            projectile.ignoreWater = true;
            projectile.penetrate = -1;
            projectile.timeLeft = 90;
        }

        public override void AI()
        {
            projectile.velocity *= .98f;
            projectile.alpha += 3;
            if (projectile.alpha > 250)
                projectile.Kill();
        }

        public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
        {
            int rand = Main.rand.Next(5);
            if (target.GetGlobalNPC<LaugicalGlobalNPCs>().JunglePlagueDuration < 180 + 60 * rand)
            {
                target.AddBuff(ModContent.BuffType<JunglePlagueBuff>(), (int)((180 + 60 * rand)), false);
                target.AddBuff(BuffID.Poisoned, (int)(3 * 60 + 60 * rand), false);
            }
        }
    }
}