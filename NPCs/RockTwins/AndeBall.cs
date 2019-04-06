using Terraria;
using Terraria.ModLoader;

namespace Laugicality.NPCs.RockTwins
{
	public class AndeBall : ModProjectile
    {
        public bool bitherial = true;
        public bool stopped = false;
        public int power = 0;
        public int damage = 0;
        public int delay = 0;
        public bool spawned = false;
        public bool zImmune = true;

        public override void SetDefaults()
        {
            zImmune = true;
            LaugicalityVars.eProjectiles.Add(projectile.type);
            power = 0;
            stopped = false;
            damage = 20;
            spawned = false;
            //mystDmg = (float)projectile.damage;
            //mystDur = 1f + projectile.knockBack;
            projectile.width = 16;
            projectile.height = 16;
            projectile.penetrate = -1;
            projectile.hostile = true;
            projectile.timeLeft = 100;
            projectile.ignoreWater = true;
            projectile.tileCollide = false;
        }


        public override void AI()
        {
            bitherial = true;
            Dust.NewDust(projectile.position + projectile.velocity, projectile.width, projectile.height, mod.DustType("Blue"), 0f, 0f);
            projectile.velocity *= 1.05f;
        }

        public override void OnHitPlayer(Player player, int dmgDealt, bool crit)
        {
            player.AddBuff(mod.BuffType("ForHonor"), 300, true);
        }

    }
}