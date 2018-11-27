using System;
using System.Collections.Generic;
using System.IO;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Laugicality;

namespace Laugicality.Projectiles.Mystic
{
    public class HallowsEveIllusion1 : ModProjectile
    {
        public float theta = 0;
		public int timer = 0;
        public int power = 1;
        public float mystDur = 1f;

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Hallow's Eve Illusion");
        }
        public override void SetDefaults()
        {
            LaugicalityVars.EProjectiles.Add(projectile.type);
            //mystDmg = (float)projectile.damage;
            //mystDur = 1f + projectile.knockBack;
            projectile.width = 24;
            projectile.height = 24;
            projectile.penetrate = -1;
            projectile.friendly = true;
            projectile.timeLeft = 300;
            projectile.ignoreWater = true;
            projectile.tileCollide = true;
        }

		public override Color? GetAlpha(Color lightColor)
		{
            return ((Color.White * 0.0f) * (0.025f * projectile.timeLeft));
		}
		
		public override void OnHitNPC(NPC npc, int damage, float knockback, bool crit)
		{
            npc.AddBuff(mod.BuffType("Spooked"), (int)(160 * mystDur * power));
        }

        public override void AI()
        {
			Vector2 origin = projectile.Center;
			theta -= 3.14f / 20;
            Player player = Main.player[projectile.owner];
            LaugicalityPlayer modPlayer = player.GetModPlayer<LaugicalityPlayer>(mod);
            power = modPlayer.illusionPower;
            mystDur = modPlayer.mysticDuration;

            for (int i = 0; i < 2; i++)
            {
			    double targetX = origin.X + Math.Cos(theta + i * 3.14f / 1) * 10;
			    double targetY = origin.Y + Math.Sin(theta + i * 3.14f / 1) * 10;
				int dust = Dust.NewDust(projectile.position, projectile.width, projectile.height, 6, 0f, 0f, 0, default(Color), 2.25f);
				Main.dust[dust].position.X = (float)targetX;
				Main.dust[dust].position.Y = (float)targetY;
				Main.dust[dust].velocity *= 0f;
				Main.dust[dust].noGravity = true;
			}
			
			timer++;
			if (timer > 8)
			{
				Projectile.NewProjectile(projectile.position.X, projectile.position.Y, Main.rand.NextFloat(-2f, 2f), Main.rand.NextFloat(-2f, -1f), mod.ProjectileType("HallowsEveIllusion2"), (int)(projectile.damage * 0.35f), 1f, Main.myPlayer);
				timer = 0;
			}
        }
		
		public override void Kill(int timeLeft)
		{
			for (int k = 0; k < 2; k++)
			{
				float num102 = 20f;
				int num103 = 0;
				while ((float)num103 < num102)
				{
					Vector2 vector12 = Vector2.UnitX * 0f;
					vector12 += -Vector2.UnitY.RotatedBy((double)((float)num103 * (6.28318548f / num102)), default(Vector2)) * new Vector2(8f, 8f);
					vector12 = vector12.RotatedBy((double)projectile.velocity.ToRotation(), default(Vector2));
					int num104 = Dust.NewDust(projectile.Center, 0, 0, 6, 0f, 0f, 0, default(Color), 1.25f);
					Main.dust[num104].noGravity = true;
					Main.dust[num104].position = projectile.Center + vector12;
					Main.dust[num104].velocity = projectile.velocity * 0f + vector12.SafeNormalize(Vector2.UnitY) * 1.25f;
					int num = num103;
					num103 = num + 1;
				}
			}
		}
    }
}