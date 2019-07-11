using Laugicality.NPCs;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Laugicality.Projectiles
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
            if (projectile.velocity.Y > -3)
                projectile.velocity.Y -= .05f;
        }

        public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
        {
            int rand = Main.rand.Next(5);
            if (target.GetGlobalNPC<LaugicalGlobalNPCs>().JunglePlagueDuration < 180 + 60 * rand)
                target.GetGlobalNPC<LaugicalGlobalNPCs>().JunglePlagueDuration = 180 + 60 * rand;
        }
    }
}