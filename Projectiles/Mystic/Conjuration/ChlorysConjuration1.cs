using Laugicality.Items.Consumables.Buffs;
using Microsoft.Xna.Framework;
using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Laugicality.Projectiles.Mystic.Conjuration
{
    public class ChlorysConjuration1 : PrimaryConjurationProjectile
    {
        int delay = 0;
        bool right = false;
        public override void SetDefaults()
        {
            projectile.width = 20;
            projectile.height = 20;
            projectile.penetrate = -1;
            projectile.friendly = true;
            projectile.timeLeft = 360;
            projectile.ignoreWater = true;
            projectile.tileCollide = true;
            if (Main.rand.Next(2) == 0)
                right = false;
        }

        public override void AI()
        {
            projectile.rotation += right?.1f:-.2f;
            projectile.velocity.X *= .95f;
            projectile.velocity.Y *= .95f;

            delay++;
            if (delay > 45)
            {
                delay = 0;
                if (Main.myPlayer == projectile.owner)
                    Shoot();
            }
        }

        private void Shoot()
        {
            double theta = Main.rand.NextDouble() * Math.PI;
            float mag = 5;
            if (Main.rand.Next(16) != 0)
                Projectile.NewProjectile(projectile.Center.X, projectile.Center.Y, (int)(mag * Math.Cos(theta)), (int)(mag * Math.Sin(theta)), ModContent.ProjectileType<ChlorysConjuration2>(), (int)(projectile.damage / 1.2f), 3, Main.myPlayer);
            else
                Item.NewItem(projectile.Center, ModContent.ItemType<DryadSpore>());
        }

        public override bool OnTileCollide(Vector2 oldVelocity)
        {
            projectile.velocity.Y = 0;
            return false;
        }
    }
}