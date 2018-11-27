using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Laugicality.Projectiles
{
    public class Daggoritus : ModProjectile
    {
        public int delay = 20;
        public override void SetDefaults()
        {
            delay = 10;
            projectile.width = 24;
            projectile.height = 24;
            projectile.friendly = true;
            projectile.aiStyle = 0;
            projectile.thrown = true;
            projectile.penetrate = -1;      
            projectile.extraUpdates = 1;
            aiType = 48;
        }

        public override void AI()
        {

            projectile.rotation = (float)Math.Atan2((double)projectile.velocity.Y, (double)projectile.velocity.X) + 1.57f;
        }

        public override bool OnTileCollide(Vector2 oldVelocity)
        {                                                           
            {
                projectile.Kill();

                Main.PlaySound(0, (int)projectile.position.X, (int)projectile.position.Y, 10);
            }
            return false;
        }
    }
}