using System;
using Terraria;
using Terraria.ModLoader;


namespace Laugicality.Projectiles.SoulStone
{
    public class FriendlyDungeonGuardian : ModProjectile
    {
        float theta = 0;
        bool collided = false;

        public override void SetDefaults()
        {
            projectile.width = 42;
            projectile.height = 42;
            projectile.friendly = true;
            projectile.penetrate = -1;
            projectile.timeLeft = 800;
            projectile.ignoreWater = true;
            projectile.tileCollide = false;
        }

        public override void AI()
        {
            NPC npc = Main.npc[(int)projectile.ai[0]];
            if (!npc.active || collided || projectile.damage == 0)
                Despawn();
            else
                HomeIn(npc);
        }

        public void Despawn()
        {
            projectile.damage = 0;
            projectile.velocity.X *= .95f;
            projectile.velocity.Y += .05f;
            if (projectile.position.Y - Main.player[projectile.owner].position.Y > 500)
                projectile.Kill();
        }

        public void HomeIn(NPC npc)
        {
            projectile.rotation += (float)Math.PI / 15;

            projectile.velocity = projectile.DirectionTo(npc.Center) * 6;
        }

        public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
        {
            if (target.whoAmI == projectile.ai[0])
                collided = true;
            base.OnHitNPC(target, damage, knockback, crit);
        }
    }
}