namespace Laugicality.Projectiles.Mystic.Conjuration
{
	public class CupidConjuration2 : ConjurationProjectile
    {
        public override void SetDefaults()
        {
            projectile.width = 8;
            projectile.height = 8;
            projectile.friendly = true;
            projectile.penetrate = 4;
            projectile.timeLeft = 200;
            projectile.ignoreWater = true;
            projectile.tileCollide = false;
        }
    }
}