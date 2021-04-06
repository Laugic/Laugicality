using Laugicality.Dusts;
using Microsoft.Xna.Framework;
using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Laugicality.NPCs.PreTrio
{
    public class QuietSnowball : ModProjectile
    {
        public override void SetDefaults()
        {
            LaugicalityVars.eProjectiles.Add(projectile.type);
            projectile.width = 18;
            projectile.height = 18;
            projectile.friendly = false;
            projectile.hostile = true;
            projectile.timeLeft = 5 * 60;
        }

        public override void AI()
        {
            if (projectile.scale != 1)
                return;
            Movement();

            projectile.rotation += projectile.velocity.X / 40f;
        }

        private void Movement()
        {
            projectile.velocity.Y += .08f;
            projectile.velocity.X *= .99f;
        }

        public override bool OnTileCollide(Vector2 oldVelocity)
        {
            projectile.Kill();
            return false;
        }

        public override void OnHitPlayer(Player target, int dmgDealt, bool crit)
        {
            if (!Main.expertMode)
                return;
            target.AddBuff(BuffID.Frostburn, 2 * 60 + Main.rand.Next(60));
        }
    }
}
