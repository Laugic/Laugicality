using System;
using System.Collections.Generic;
using System.IO;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Laugicality;

namespace Laugicality.Projectiles.Mystic.Conjuration
{
	public class YuleConjuration : ConjurationProjectile
    {
        public override void SetDefaults()
        {
            projectile.width = 18;
            projectile.height = 30;
            projectile.friendly = true;
            projectile.timeLeft = 120;
            projectile.ignoreWater = true;
            projectile.tileCollide = false;
        }

        public override void AI()
        {
            projectile.velocity.Y += .2f;
        }

        public override void Kill(int timeLeft)
        {
            Main.PlaySound(0, (int)projectile.position.X, (int)projectile.position.Y, 10);
        }
    }
}