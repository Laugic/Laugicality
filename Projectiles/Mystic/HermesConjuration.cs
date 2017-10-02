using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Laugicality;
using Laugicality.NPCs;

namespace Laugicality.Projectiles.Mystic
{
	public class HermesConjuration : ModProjectile
    {
        public float mystDmg = 0;
        public float mystDur = 0;
        public int damage = 0;

        public override void SetDefaults()
        {
            damage = 8;
            //mystDmg = (float)projectile.damage;
            //mystDur = 1f + projectile.knockBack;
            projectile.width = 12;
            projectile.height = 12;
            projectile.friendly = true;
            //projectile.penetrate = 2;
            projectile.timeLeft = 600;
            projectile.ignoreWater = true;
        }

        

        public override void AI()
        {
            Dust.NewDust(projectile.position + projectile.velocity, projectile.width, projectile.height, mod.DustType("Hermes"), projectile.velocity.X * 0.5f, projectile.velocity.Y * 0.5f);

        }
        
        public override bool OnTileCollide(Vector2 oldVelocity)
        {
            Projectile.NewProjectile(projectile.Center.X, projectile.Center.Y, -4 + Main.rand.Next(8), -4 + Main.rand.Next(8), mod.ProjectileType("HermesConjurationHoming"), damage, 3f, Main.myPlayer);
            Projectile.NewProjectile(projectile.Center.X, projectile.Center.Y, -4 + Main.rand.Next(8), -4 + Main.rand.Next(8), mod.ProjectileType("HermesConjurationHoming"), damage, 3f, Main.myPlayer);
            Projectile.NewProjectile(projectile.Center.X, projectile.Center.Y, -4 + Main.rand.Next(8), -4 + Main.rand.Next(8), mod.ProjectileType("HermesConjurationHoming"), damage, 3f, Main.myPlayer);
            
            projectile.Kill();
            Main.PlaySound(SoundID.Item10, projectile.position);
            
            return false;
        }
        
        public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
        {
            Projectile.NewProjectile(projectile.Center.X, projectile.Center.Y, -4 + Main.rand.Next(8), -4 + Main.rand.Next(8), mod.ProjectileType("HermesConjurationHoming"), damage, 3f, Main.myPlayer);
            Projectile.NewProjectile(projectile.Center.X, projectile.Center.Y, -4 + Main.rand.Next(8), -4 + Main.rand.Next(8), mod.ProjectileType("HermesConjurationHoming"), damage, 3f, Main.myPlayer);
            Projectile.NewProjectile(projectile.Center.X, projectile.Center.Y, -4 + Main.rand.Next(8), -4 + Main.rand.Next(8), mod.ProjectileType("HermesConjurationHoming"), damage, 3f, Main.myPlayer);

            projectile.Kill();
            Main.PlaySound(SoundID.Item10, projectile.position);
        }
    }
}