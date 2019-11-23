using System;
using Laugicality.Tiles;
using Terraria;
using Terraria.ModLoader;
using WebmilioCommons.Extensions;

namespace Laugicality.Projectiles
{
    public class LaugicalityGlobalProjectile : GlobalProjectile
    {
        public const int MIN_SPEED = 10, MAX_SPEED = 50;


        public override bool PreAI(Projectile projectile)
        {
            if (!projectile.active || (projectile.hostile && !projectile.friendly))
                return true;

            Tile tile = projectile.GetTileOnCenter();

            if (tile.type == ModContent.TileType<BrassFAN>() || tile.type == ModContent.TileType<BrassFANRight>())
            {
                HandleDirectionalFans(projectile, tile.type == ModContent.TileType<BrassFAN>());
            }

            return true;
        }

        private void HandleDirectionalFans(Projectile projectile, bool left)
        {
            int directionMultiplier = left ? -1 : 1;

            if (left && projectile.velocity.X < MAX_SPEED * directionMultiplier || !left && projectile.velocity.X > MAX_SPEED * directionMultiplier)
                return;

            if (!projectile.minion && projectile.aiStyle != 99)
            {
                projectile.hostile = true;
                projectile.friendly = true;
            }

            if (Math.Abs(projectile.velocity.X) < MIN_SPEED * directionMultiplier)
                projectile.velocity.X = MIN_SPEED * directionMultiplier;

            Main.PlaySound(SoundLoader.customSoundType, -1, -1, mod.GetSoundSlot(SoundType.Custom, "Sounds/BrassFAN"));

            projectile.velocity.X *= 2;

            if (Math.Abs(projectile.velocity.X) > MAX_SPEED)
                projectile.velocity.X = MAX_SPEED * directionMultiplier;
        }
    }
}