using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Laugicality;
using Laugicality.NPCs;

namespace Laugicality.Projectiles.Mystic
{
	public class HadesExplosion : ModProjectile
    {
        

        public override void SetDefaults()
        {
            //mystDmg = (float)projectile.damage;
            //mystDur = 1f + projectile.knockBack;
            projectile.width = 128;
            projectile.height = 128;
            projectile.friendly = true;
            projectile.penetrate = 999;
            projectile.timeLeft = 24;
            projectile.ignoreWater = true;
            projectile.tileCollide = false;
            Main.projFrames[projectile.type] = 6;
        }

        
        
        public override void AI()
        {
            projectile.velocity.X = 0;
            projectile.velocity.Y = 0;

            projectile.frameCounter++;
            if (projectile.frameCounter > 4)
            {
                projectile.frame++;
                projectile.frameCounter = 0;
            }
            if (projectile.frame > 6)
            {
                projectile.frame = 6;
            }
        }

        /*
        public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
        {
            target.AddBuff(mod.BuffType("Electrified"), (int)(120*mystDur));
            //if (target.GetGlobalNPC<LaugicalGlobalNPCs>(mod).mysticDamage < mystDmg)target.GetGlobalNPC<LaugicalGlobalNPCs>(mod).mysticDamage = mystDmg;
        }*/
        
    }
}