using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text.RegularExpressions;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria.ModLoader.IO;
using Laugicality;

namespace Laugicality.Projectiles.Mystic.Conjuration
{
	public class PlutoConjuration3 : ConjurationProjectile
    {
        public override void SetDefaults()
        {
            projectile.width = 22;
            projectile.height = 16;
            projectile.friendly = true;
            projectile.timeLeft = 100;
            projectile.ignoreWater = true;
            projectile.tileCollide = true;
        }

        public override void AI()
        {
            projectile.rotation = (float)Math.Atan2((double)projectile.velocity.Y, (double)projectile.velocity.X);
        }
    }
}