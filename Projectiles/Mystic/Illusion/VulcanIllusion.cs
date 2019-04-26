using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Laugicality;
using Laugicality.Dusts;
using Laugicality.NPCs;

namespace Laugicality.Projectiles.Mystic.Illusion
{
	public class VulcanIllusion : IllusionProjectile
    {
        public override void SetDefaults()
        {
            projectile.width = 40;
            projectile.height = 40;
            projectile.friendly = true;
            projectile.penetrate = 2;
            projectile.timeLeft = 100;
            projectile.ignoreWater = true;
            projectile.tileCollide = false;
            buffID = mod.BuffType("Steamy");
        }

        public override void AI()
        {
            Dust.NewDust(projectile.position + projectile.velocity, projectile.width, projectile.height, mod.DustType<Steam>(), projectile.velocity.X * 0.5f, projectile.velocity.Y * 0.5f);
        }
        
    }
}