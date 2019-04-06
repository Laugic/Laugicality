using Terraria;
using Terraria.ModLoader;

namespace Laugicality.NPCs.PreTrio
{
	public class SandnadoUp : ModProjectile
	{

        public bool bitherial = true;
        public override void SetDefaults()
        {
            LaugicalityVars.EProjectiles.Add(projectile.type);
            bitherial = true;
            projectile.width = 16;
			projectile.height = 16;
			//projectile.alpha = 255;
            projectile.timeLeft = 50;
            projectile.friendly = false;
            projectile.hostile = true;
            projectile.ignoreWater = true;
            projectile.tileCollide = false;
        }
        public override void AI()
        {
            bitherial = true;
            if (Main.rand.Next(4) == 0) Dust.NewDust(projectile.position + projectile.velocity, projectile.width, projectile.height, mod.DustType("Sandy"), projectile.velocity.X * 0.05f, projectile.velocity.Y * 0.5f);
            projectile.rotation += 0.02f;

        }

        public override void OnHitPlayer(Player target, int dmgDealt, bool crit)
        {
            target.velocity.Y = -26f;
        }
    }
}