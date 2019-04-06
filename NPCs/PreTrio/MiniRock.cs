using Terraria;
using Terraria.ModLoader;

namespace Laugicality.NPCs.PreTrio
{
	public class MiniRock : ModProjectile
	{

        public bool bitherial = true;
        public override void SetDefaults()
        {
            LaugicalityVars.EProjectiles.Add(projectile.type);
            bitherial = true;
            projectile.width = 16;
			projectile.height = 16;
			//projectile.alpha = 255;
            projectile.timeLeft = 200;
            projectile.friendly = false;
            projectile.hostile = true;
            projectile.ignoreWater = true;
            projectile.tileCollide = false;
        }
        public override void AI()
        {
            bitherial = true;
            Dust.NewDust(projectile.position + projectile.velocity, projectile.width, projectile.height, 127, 0f, 0f);
            projectile.rotation += 0.02f;
        }
    }
}