using Terraria;
using Terraria.ID;
using Terraria.ModLoader;


namespace Laugicality.NPCs.PreTrio
{
    public class Lava : ModProjectile
    {
        public override void SetDefaults()
        {
            projectile.width = 16;
            projectile.height = 16;
            projectile.friendly = false;
            projectile.hostile = true;
            projectile.ignoreWater = true;
            projectile.tileCollide = false;
            projectile.timeLeft = 160;
        }

        public override void AI()
        {
            if (Main.rand.Next(4) == 0) Dust.NewDust(projectile.position + projectile.velocity, projectile.width, projectile.height, mod.DustType("Magma"), projectile.velocity.X * 0.5f, projectile.velocity.Y * 0.5f);
        }
        
        public override void Kill(int timeLeft)
        {
            for (int k = 0; k < 5; k++)
            {
                Dust.NewDust(projectile.position + projectile.velocity, projectile.width, projectile.height, mod.DustType("Magma"), projectile.oldVelocity.X * 0.5f, projectile.oldVelocity.Y * 0.5f);
            }
        }

        public override void OnHitPlayer(Player target, int dmgDealt, bool crit)
        {
            target.AddBuff(BuffID.OnFire, 4 * 60, true);
        }
    }
}