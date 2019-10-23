using Laugicality.Dusts;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Laugicality.Projectiles.Mystic.Conjuration
{
    public class HermesConjuration1 : ConjurationProjectile
    {
        public override void SetDefaults()
        {
            projectile.width = 12;
            projectile.height = 12;
            projectile.friendly = true;
            projectile.timeLeft = 600;
            projectile.ignoreWater = true;
            projectile.aiStyle = 1;
        }

        public override void AI()
        {
            Dust.NewDust(projectile.position + projectile.velocity, projectile.width, projectile.height, ModContent.DustType<HermesDust>(), projectile.velocity.X * 0.5f, projectile.velocity.Y * 0.5f);
            projectile.tileCollide = true;
        }

        public override bool OnTileCollide(Vector2 oldVelocity)
        {
            for (int i = 0; i < 4; i++)
            {
                if (Main.netMode != 1)
                    Projectile.NewProjectile(projectile.Center.X, projectile.Center.Y, -4 + Main.rand.Next(8), -4 + Main.rand.Next(8), ModContent.ProjectileType<HermesConjurationHoming>(), projectile.damage, 3f, Main.myPlayer);
            }
            projectile.Kill();
            Main.PlaySound(SoundID.Item10, projectile.position);
            return false;
        }

        public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
        {
            for (int i = 0; i < 4; i++)
            {
                if (projectile.owner == Main.myPlayer)
                    Projectile.NewProjectile(projectile.Center.X, projectile.Center.Y, -4 + Main.rand.Next(8), -4 + Main.rand.Next(8), ModContent.ProjectileType<HermesConjurationHoming>(), projectile.damage, 3f, Main.myPlayer);
            }
            projectile.Kill();
            Main.PlaySound(SoundID.Item10, projectile.position);
        }
    }
}