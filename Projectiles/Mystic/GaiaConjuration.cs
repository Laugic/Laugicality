using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Laugicality;
using Laugicality.NPCs;

namespace Laugicality.Projectiles.Mystic
{
	public class GaiaConjuration : ModProjectile
    {
        public bool powered = false;
        public int power = 1;
        public int damage = 0;

        public override void SetDefaults()
        {
            power = 1;
            powered = false;
            //damage = projectile.damage;
            //mystDmg = (float)projectile.damage;
            //mystDur = 1f + projectile.knockBack;
            projectile.width = 18;
            projectile.height = 18;
            projectile.friendly = true;
            projectile.penetrate = 1;
            projectile.timeLeft = 600;
            projectile.ignoreWater = true;
        }


        public override void AI()
        {
            damage = (int)projectile.damage;
            Player player = Main.player[projectile.owner];
            LaugicalityPlayer modPlayer = player.GetModPlayer<LaugicalityPlayer>(mod);
            if(!powered)
            {
                powered = true;
                while(modPlayer.conjurationPower > power)
                {
                    power++;
                    projectile.penetrate++;
                }
            }

            projectile.velocity.Y += .15f;

            Dust.NewDust(projectile.position + projectile.velocity, projectile.width, projectile.height, mod.DustType("Rainbow"), projectile.velocity.X * 0.5f, projectile.velocity.Y * 0.5f);

        }

        public override bool OnTileCollide(Vector2 oldVelocity)
        {
            if (Main.myPlayer == projectile.owner)
            {
                Projectile.NewProjectile(projectile.Center.X, projectile.Center.Y, -6, 0, mod.ProjectileType("DiamondShard"), damage, 3f, Main.myPlayer);
                Projectile.NewProjectile(projectile.Center.X, projectile.Center.Y, 6, 0, mod.ProjectileType("TopazShard"), damage, 3f, Main.myPlayer);
                Projectile.NewProjectile(projectile.Center.X, projectile.Center.Y, 0, -6, mod.ProjectileType("AmethystShard"), damage, 3f, Main.myPlayer);
                Projectile.NewProjectile(projectile.Center.X, projectile.Center.Y, 0, 6, mod.ProjectileType("EmeraldShard"), damage, 3f, Main.myPlayer);
                Projectile.NewProjectile(projectile.Center.X, projectile.Center.Y, -4 + Main.rand.Next(8), -4 + Main.rand.Next(8), mod.ProjectileType("SapphireShard"), damage, 3f, Main.myPlayer);
                Projectile.NewProjectile(projectile.Center.X, projectile.Center.Y, -4 + Main.rand.Next(8), -4 + Main.rand.Next(8), mod.ProjectileType("RubyShard"), damage, 3f, Main.myPlayer);
            }
            projectile.penetrate--;
            if (projectile.penetrate <= 1)
            {
                projectile.Kill();
            }
            else
            {
                projectile.ai[0] += 0.2f;
                if (projectile.velocity.X != oldVelocity.X)
                {
                    projectile.velocity.X = -oldVelocity.X;
                }
                if (projectile.velocity.Y != oldVelocity.Y)
                {
                    projectile.velocity.Y = -oldVelocity.Y;
                }
                projectile.velocity *= 0.75f;
                Main.PlaySound(SoundID.Item10, projectile.position);
            }
            
            return false;
        }
        
        public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
        {
            if (Main.myPlayer == projectile.owner)
            {
                projectile.ai[0] += 0.2f;
                Projectile.NewProjectile(projectile.Center.X, projectile.Center.Y, -6, 0, mod.ProjectileType("DiamondShard"), damage, 3f, Main.myPlayer);
                Projectile.NewProjectile(projectile.Center.X, projectile.Center.Y, 6, 0, mod.ProjectileType("TopazShard"), damage, 3f, Main.myPlayer);
                Projectile.NewProjectile(projectile.Center.X, projectile.Center.Y, 0, -6, mod.ProjectileType("AmethystShard"), damage, 3f, Main.myPlayer);
                Projectile.NewProjectile(projectile.Center.X, projectile.Center.Y, 0, 6, mod.ProjectileType("EmeraldShard"), damage, 3f, Main.myPlayer);
                Projectile.NewProjectile(projectile.Center.X, projectile.Center.Y, -4 + Main.rand.Next(8), -4 + Main.rand.Next(8), mod.ProjectileType("SapphireShard"), damage, 3f, Main.myPlayer);
                Projectile.NewProjectile(projectile.Center.X, projectile.Center.Y, -4 + Main.rand.Next(8), -4 + Main.rand.Next(8), mod.ProjectileType("RubyShard"), damage, 3f, Main.myPlayer);
            }
            Main.PlaySound(SoundID.Item10, projectile.position);
        }
    }
}