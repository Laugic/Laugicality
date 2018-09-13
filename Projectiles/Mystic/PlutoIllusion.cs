using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Laugicality;
using Laugicality.NPCs;

namespace Laugicality.Projectiles.Mystic
{
	public class PlutoIllusion : ModProjectile
    {
        public int damage = 0;
        public bool powered = false;
        public int power = 1;
        public float mystDur = 0f;

        public override void SetDefaults()
        {
            power = 1;
            powered = false;
            projectile.width = 22;
            projectile.height = 16;
            projectile.friendly = true;
            //projectile.penetrate = 2;
            projectile.timeLeft = 100;
            projectile.ignoreWater = true;
        }

        
        public override void AI()
        {
            Player player = Main.player[projectile.owner];
            LaugicalityPlayer modPlayer = player.GetModPlayer<LaugicalityPlayer>(mod);
            power = modPlayer.illusionPower;
            mystDur = modPlayer.mysticDuration;
            projectile.rotation = (float)Math.Atan2((double)projectile.velocity.Y, (double)projectile.velocity.X);
            Dust.NewDust(projectile.position + projectile.velocity, projectile.width, projectile.height, mod.DustType("Frost"), projectile.velocity.X * 0.5f, projectile.velocity.Y * 0.5f);

        }

        public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
        {
            if(target.boss == false && !LaugicalityVars.FrigImmune.Contains(target.type))
                target.AddBuff(mod.BuffType("Frigid"), (int)(140 * mystDur * power));
            //if (target.GetGlobalNPC<LaugicalGlobalNPCs>(mod).mysticDamage < mystDmg)target.GetGlobalNPC<LaugicalGlobalNPCs>(mod).mysticDamage = mystDmg;
        }

        public override bool OnTileCollide(Vector2 oldVelocity)
        {
           Main.PlaySound(SoundID.Item30, projectile.position);
           return true;
        }
    }
}