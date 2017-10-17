using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Laugicality;
using Laugicality.NPCs;

namespace Laugicality.Projectiles.Mystic
{
	public class HadesIllusion : ModProjectile
    {
        public int damage = 0;
        public bool powered = false;
        public int power = 1;
        public float mystDur = 0f;

        public override void SetDefaults()
        {
            power = 1;
            powered = false;
            projectile.width = 16;
            projectile.height = 16;
            projectile.friendly = true;
            projectile.penetrate = 3;
            projectile.timeLeft = 100;
            projectile.ignoreWater = true;
            projectile.scale *= 1.5f;
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
            projectile.rotation = (float)Math.Atan2((double)projectile.velocity.Y, (double)projectile.velocity.X) + .785f;
            Dust.NewDust(projectile.position + projectile.velocity, projectile.width, projectile.height, mod.DustType("Hades"), projectile.velocity.X * 0.5f, projectile.velocity.Y * 0.5f);

        }

        public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
        {
            target.AddBuff(153, (int)(140 * mystDur * power));
            //if (target.GetGlobalNPC<LaugicalGlobalNPCs>(mod).mysticDamage < mystDmg)target.GetGlobalNPC<LaugicalGlobalNPCs>(mod).mysticDamage = mystDmg;
        }
    }
}