using Terraria;

namespace Laugicality.Projectiles.Mystic.Conjuration
{
    public class ConjurationProjectile : MysticProjectile
    {
    }

    public class PrimaryConjurationProjectile : ConjurationProjectile
    {
        public override void Durationed(float dur)
        {
            projectile.timeLeft = (int)(projectile.timeLeft * dur);
        }
    }
}
