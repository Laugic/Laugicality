using System;
using Terraria;
using Terraria.ModLoader;

namespace Laugicality.NPCs.RockTwins
{
	public class AndeEnergy : ModProjectile
    {
        public bool bitherial = true;
        public bool stopped = false;
        public int power = 0;
        public int damage = 0;
        public int delay = 0;
        public bool spawned = false;
        public float theta = 0;
        public float vel = 0;
        public bool zImmune = true;
        public override void SetDefaults()
        {
            zImmune = true;
            theta = 0;
            vel = 0;
            LaugicalityVars.EProjectiles.Add(projectile.type);
            power = 0;
            stopped = false;
            spawned = false;
            //mystDmg = (float)projectile.damage;
            //mystDur = 1f + projectile.knockBack;
            projectile.width = 20;
            projectile.height = 20;
            projectile.penetrate = -1;
            projectile.hostile = true;
            projectile.timeLeft = 320;
            projectile.ignoreWater = true;
            projectile.tileCollide = false;
        }


        public override void AI()
        {
            bitherial = true;
            Dust.NewDust(projectile.position + projectile.velocity, projectile.width, projectile.height, mod.DustType("Blue"), 0f, 0f);
            projectile.rotation = (float)Math.Atan2((double)projectile.velocity.Y, (double)projectile.velocity.X);
                theta -= 3.14f / 60;
            vel += .1f;
            vel *= 1.01f;
            projectile.velocity.X = (float)(Math.Cos(theta) * vel);
            projectile.velocity.Y = (float)(Math.Sin(theta) * vel);
        }

        public override void OnHitPlayer(Player player, int dmgDealt, bool crit)
        {
            player.AddBuff(mod.BuffType("ForHonor"), 300, true);
        }

    }
}