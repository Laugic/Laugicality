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
        public bool powered = false;
        public int power = 1;
        public float mystDmg = 0;
        public float mystDur = 0;
        public int damage = 0;

        public override void SetDefaults()
        {
            power = 1;
            powered = false;
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

            Player player = Main.player[projectile.owner];
            LaugicalityPlayer modPlayer = player.GetModPlayer<LaugicalityPlayer>(mod);
            if (!powered)
            {
                powered = true;
                while (modPlayer.conjurationPower > power)
                {
                    power++;
                }
                power += 2;
            }
        }
        
        public override bool OnTileCollide(Vector2 oldVelocity)
        {

            while (power > 0)
            {
                power -= 1;
                if(Main.netMode != 1)
                    Projectile.NewProjectile(projectile.Center.X, projectile.Center.Y, -4 + Main.rand.Next(8), -4 + Main.rand.Next(8), mod.ProjectileType("HermesConjurationHoming"), damage, 3f, Main.myPlayer);
            }
            
            projectile.Kill();
            Main.PlaySound(SoundID.Item10, projectile.position);
            
            return false;
        }
        
        public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
        {
            while (power > 0)
            {
                power -= 1;
                if (Main.netMode != 1)
                    Projectile.NewProjectile(projectile.Center.X, projectile.Center.Y, -4 + Main.rand.Next(8), -4 + Main.rand.Next(8), mod.ProjectileType("HermesConjurationHoming"), damage, 3f, Main.myPlayer);
            }

            projectile.Kill();
            Main.PlaySound(SoundID.Item10, projectile.position);
        }
    }
}