using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Laugicality;
using Laugicality.NPCs;

namespace Laugicality.Projectiles.Mystic
{
	public class GaiaIllusion : ModProjectile
    {
        public bool powered = false;
        public int power = 1;
        public int rand = 0;
        public float mystDur = 0f;

        public override void SetDefaults()
        {
            power = 1;
            powered = false;
            projectile.width = 18;
            projectile.height = 18;
            projectile.friendly = true;
            projectile.penetrate = 2;
            projectile.timeLeft = 600;
            projectile.ignoreWater = true;
        }

        

        public override void AI()
        {
            Player player = Main.player[projectile.owner];
            LaugicalityPlayer modPlayer = player.GetModPlayer<LaugicalityPlayer>(mod);
            if (!powered)
            {
                powered = true;
                while (modPlayer.illusionPower > power)
                {
                    power++;
                }
            }
            mystDur = modPlayer.mysticDuration;
            Dust.NewDust(projectile.position + projectile.velocity, projectile.width, projectile.height, mod.DustType("Rainbow"), projectile.velocity.X * 0.5f, projectile.velocity.Y * 0.5f);

        }

        public override bool OnTileCollide(Vector2 oldVelocity)
        {
            projectile.penetrate--;
            if (projectile.penetrate <= 0)
            {
                projectile.Kill();
            }
            else
            {
                projectile.ai[0] += 0.1f;
                if (projectile.velocity.X != oldVelocity.X)
                {
                    projectile.velocity.X = -oldVelocity.X;
                }
                if (projectile.velocity.Y != oldVelocity.Y)
                {
                    projectile.velocity.Y = -oldVelocity.Y;
                }
                Main.PlaySound(SoundID.Item10, projectile.position);
            }
            return false;
        }
        
        public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
        {
            rand = Main.rand.Next(1, 6);
            if (rand == 1)
                target.AddBuff(24, (int)(140 * mystDur * power));
            if (rand == 2)
                target.AddBuff(20, (int)(140 * mystDur * power));
            if (rand == 3)
                target.AddBuff(70, (int)(140 * mystDur * power));
            if (rand == 4)
                target.AddBuff(39, (int)(140 * mystDur * power));
            if (rand == 5)
                target.AddBuff(69, (int)(140 * mystDur * power));
            rand += 1;
            if (rand == 6)
                rand = 1;
            if (rand == 1)
                target.AddBuff(24, (int)(140 * mystDur * power));
            if (rand == 2)
                target.AddBuff(20, (int)(140 * mystDur * power));
            if (rand == 3)
                target.AddBuff(70, (int)(140 * mystDur * power));
            if (rand == 4)
                target.AddBuff(39, (int)(140 * mystDur * power));
            if (rand == 5)
                target.AddBuff(69, (int)(140 * mystDur * power));
            //if (target.GetGlobalNPC<LaugicalGlobalNPCs>(mod).mysticDamage < mystDmg)target.GetGlobalNPC<LaugicalGlobalNPCs>(mod).mysticDamage = mystDmg;
        }
    }
}