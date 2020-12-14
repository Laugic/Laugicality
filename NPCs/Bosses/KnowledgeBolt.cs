using System;
using Laugicality.Buffs;
using Laugicality.Dusts;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Laugicality.NPCs.Bosses
{
    public class KnowledgeBolt : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Knowledge Bolt");
        }

        public override void SetDefaults()
        {
            LaugicalityVars.eProjectiles.Add(projectile.type);
            projectile.width = 16;
            projectile.height = 16;
            projectile.timeLeft = 300;
            projectile.friendly = false;
            projectile.hostile = true;
            projectile.ignoreWater = true;
        }

        public override void AI()
        {
            projectile.velocity.Y += projectile.ai[0];

            if (Main.rand.Next(6) == 0)
                Dust.NewDust(projectile.position + projectile.velocity, projectile.width, projectile.height, ModContent.DustType<White>(), -projectile.velocity.X * 0.5f, projectile.velocity.Y * 0.5f);
        }

        public override bool OnTileCollide(Vector2 oldVelocity)
        {
            if (projectile.velocity.X != oldVelocity.X)
            {
                projectile.velocity.X = -oldVelocity.X;
            }
            if (projectile.velocity.Y != oldVelocity.Y)
            {
                projectile.velocity.Y = -oldVelocity.Y;
            }
            projectile.velocity.Normalize();
            projectile.velocity *= 6f;
            return false;
        }

        public override void OnHitPlayer(Player target, int dmgDealt, bool crit)
        {
            target.AddBuff(ModContent.BuffType<Steamy>(), 2 * 60 + Main.rand.Next(60), true);
        }
    }
}