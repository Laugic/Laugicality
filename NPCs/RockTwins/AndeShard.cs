using Terraria.ModLoader;

namespace Laugicality.NPCs.RockTwins
{
	public class AndeShard : ModProjectile
    {
        public bool bitherial = true;
        public bool stopped = false;
        public int power = 0;
        public int damage = 0;
        public int delay = 0;

        public override void SetDefaults()
        {
            LaugicalityVars.eProjectiles.Add(projectile.type);
            projectile.width = 18;
            projectile.height = 60;
            projectile.penetrate = -1;
            projectile.hostile = true;
            projectile.timeLeft = 200;
            projectile.ignoreWater = true;
            projectile.tileCollide = false;
        }

        public override void AI()
        {
            bitherial = true;
            projectile.velocity.Y -= .1f;
        }
    }
}