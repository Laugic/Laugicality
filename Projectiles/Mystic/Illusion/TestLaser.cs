using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using Terraria;
using Terraria.Enums;
using Terraria.ModLoader;

namespace Laugicality.Projectiles.Mystic.Illusion
{
	public class TestLaser : ModProjectile
	{
		private const float MAX_CHARGE = 6;
		private const float MOVE_DISTANCE = 60f;
		public float Distance
		{
			get => projectile.ai[0];
			set => projectile.ai[0] = value;
		}

		public float Charge
		{
			get => projectile.localAI[0];
			set => projectile.localAI[0] = value;
		}

		public bool IsAtMaxCharge => Charge == MAX_CHARGE;

		public override void SetDefaults()
		{
			projectile.width = 42;
			projectile.height = 42;
			projectile.friendly = true;
			projectile.penetrate = -1;
			projectile.tileCollide = false;
			projectile.hide = true;
			Main.projFrames[projectile.type] = 1;
			//buffID = ModContent.BuffType<CosmicDisarray>();
		}

		public override bool PreDraw(SpriteBatch spriteBatch, Color lightColor)
		{
			if (IsAtMaxCharge)
			{
				DrawLaser(spriteBatch, Main.projectileTexture[projectile.type], Main.player[projectile.owner].Center,
					projectile.velocity, Main.projectileTexture[projectile.type].Height / 3, projectile.damage, -1.57f, 1f, 1000f, Color.White, (int)MOVE_DISTANCE);
			}
			return false;
		}

		public void DrawLaser(SpriteBatch spriteBatch, Texture2D texture, Vector2 start, Vector2 unit, float step, int damage, float rotation = 0f, float scale = 1f, float maxDist = 2000f, Color color = default(Color), int transDist = 50)
		{
			float r = unit.ToRotation() + rotation;

			// Draws the laser 'body'
			for (float i = transDist; i <= Distance; i += step)
			{
				Color c = Color.White;
				var origin = start + i * unit;
				spriteBatch.Draw(texture, origin - Main.screenPosition,
					new Rectangle(0, texture.Height / 3, texture.Width / Main.projFrames[projectile.type] * projectile.frame, texture.Height / 3), i < transDist ? Color.Transparent : c, r,
					new Vector2(texture.Width / Main.projFrames[projectile.type] * .5f, texture.Height / 3 * .5f), scale, 0, 0);
			}

			// Draws the laser 'tail'
			spriteBatch.Draw(texture, start + unit * (transDist - step) - Main.screenPosition,
				new Rectangle(0, 0, texture.Width / Main.projFrames[projectile.type] * projectile.frame, texture.Height / 3), Color.White, r, new Vector2(texture.Width / Main.projFrames[projectile.type] * .5f, texture.Height / 3 * .5f), scale, 0, 0);

			// Draws the laser 'head'
			spriteBatch.Draw(texture, start + (Distance) * unit - Main.screenPosition,
				new Rectangle(0, texture.Height / 3 * 2, texture.Width / Main.projFrames[projectile.type] * projectile.frame, texture.Height / 3), Color.White, r, new Vector2(texture.Width / Main.projFrames[projectile.type] * .5f, texture.Height / 3 * .5f), scale, 0, 0);
		}

		public override bool? Colliding(Rectangle projHitbox, Rectangle targetHitbox)
		{
			if (!IsAtMaxCharge) return false;

			Player player = Main.player[projectile.owner];
			Vector2 unit = projectile.velocity;
			float point = 0f;
			return Collision.CheckAABBvLineCollision(targetHitbox.TopLeft(), targetHitbox.Size(), player.Center,
				player.Center + unit * Distance, 22, ref point);
		}

		/*
		public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
		{
			target.immune[projectile.owner] = 5;
		}*/

		public override void AI()
		{
			Player player = Main.player[projectile.owner];
			projectile.position = player.Center + projectile.velocity * MOVE_DISTANCE;
			projectile.timeLeft = 2;

			UpdatePlayer(player);
			ChargeLaser(player);

			if (Charge < MAX_CHARGE) return;

			SetLaserPosition(player);
			SpawnDusts(player);
			CastLights();
		}

		public override void PostAI()
		{
			projectile.frameCounter++;
			if (projectile.frameCounter > 4)
			{
				projectile.frame++;
				projectile.frameCounter = 0;
			}
			if (projectile.frame >= 3)
			{
				projectile.frame = 0;
				return;
			}
		}

		private void SpawnDusts(Player player)
		{
			Vector2 unit = projectile.velocity * -1;
			Vector2 dustPos = player.Center + projectile.velocity * Distance;

			for (int i = 0; i < 2; ++i)
			{
				float num1 = projectile.velocity.ToRotation() + (Main.rand.Next(2) == 1 ? -1.0f : 1.0f) * 1.57f;
				float num2 = (float)(Main.rand.NextDouble() * 0.8f + 1.0f);
				Vector2 dustVel = new Vector2((float)Math.Cos(num1) * num2, (float)Math.Sin(num1) * num2);
				Dust dust = Main.dust[Dust.NewDust(dustPos, 0, 0, 226, dustVel.X, dustVel.Y)];
				dust.noGravity = true;
				dust.scale = 1.2f;
				dust = Dust.NewDustDirect(Main.player[projectile.owner].Center, 0, 0, 31,
					-unit.X * Distance, -unit.Y * Distance);
				dust.fadeIn = 0f;
				dust.noGravity = true;
				dust.scale = 0.88f;
				dust.color = Color.Cyan;
			}

			if (Main.rand.NextBool(5))
			{
				Vector2 offset = projectile.velocity.RotatedBy(1.57f) * ((float)Main.rand.NextDouble() - 0.5f) * projectile.width;
				Dust dust = Main.dust[Dust.NewDust(dustPos + offset - Vector2.One * 4f, 8, 8, 31, 0.0f, 0.0f, 100, new Color(), 1.5f)];
				dust.velocity *= 0.5f;
				dust.velocity.Y = -Math.Abs(dust.velocity.Y);
				unit = dustPos - Main.player[projectile.owner].Center;
				unit.Normalize();
				dust = Main.dust[Dust.NewDust(Main.player[projectile.owner].Center + 55 * unit, 8, 8, 31, 0.0f, 0.0f, 100, new Color(), 1.5f)];
				dust.velocity = dust.velocity * 0.5f;
				dust.velocity.Y = -Math.Abs(dust.velocity.Y);
			}
		}

		private void SetLaserPosition(Player player)
		{
			for (Distance = MOVE_DISTANCE; Distance <= 2200f; Distance += 5f)
			{
				var start = player.Center + projectile.velocity * Distance;
				if (!Collision.CanHit(player.Center, 1, 1, start, 1, 1))
				{
					Distance -= 5f;
					break;
				}
			}
		}

		private void ChargeLaser(Player player)
		{
			if (!player.channel)
			{
				projectile.Kill();
			}
			else
			{
				if (Main.time % 10 < 1 && !player.CheckMana(player.inventory[player.selectedItem].mana, true))
				{
					projectile.Kill();
				}
				Vector2 offset = projectile.velocity;
				offset *= MOVE_DISTANCE - 20;
				Vector2 pos = player.Center + offset - new Vector2(10, 10);
				if (Charge < MAX_CHARGE)
				{
					Charge++;
				}
				int chargeFact = (int)(Charge / 20f);
				Vector2 dustVelocity = Vector2.UnitX * 18f;
				dustVelocity = dustVelocity.RotatedBy(projectile.rotation - 1.57f);
				Vector2 spawnPos = projectile.Center + dustVelocity;
				for (int k = 0; k < chargeFact + 1; k++)
				{
					Vector2 spawn = spawnPos + ((float)Main.rand.NextDouble() * 6.28f).ToRotationVector2() * (12f - chargeFact * 2);
					Dust dust = Main.dust[Dust.NewDust(pos, 20, 20, 226, projectile.velocity.X / 2f, projectile.velocity.Y / 2f)];
					dust.velocity = Vector2.Normalize(spawnPos - spawn) * 1.5f * (10f - chargeFact * 2f) / 10f;
					dust.noGravity = true;
					dust.scale = Main.rand.Next(10, 20) * 0.05f;
				}
			}
		}

		private void UpdatePlayer(Player player)
		{
			if (projectile.owner == Main.myPlayer)
			{
				Vector2 diff = Main.MouseWorld - player.Center;
				diff.Normalize();
				projectile.velocity = diff;
				projectile.direction = Main.MouseWorld.X > player.position.X ? 1 : -1;
				projectile.netUpdate = true;
			}
			int dir = projectile.direction;
			player.ChangeDir(dir);
			player.heldProj = projectile.whoAmI;
			player.itemTime = 2;
			player.itemAnimation = 2;
			player.itemRotation = (float)Math.Atan2(projectile.velocity.Y * dir, projectile.velocity.X * dir);
		}

		private void CastLights()
		{
			DelegateMethods.v3_1 = new Vector3(0.8f, 0.8f, 1f);
			Utils.PlotTileLine(projectile.Center, projectile.Center + projectile.velocity * (Distance - MOVE_DISTANCE), 26, DelegateMethods.CastLight);
		}

		public override bool ShouldUpdatePosition() => false;

		public override void CutTiles()
		{
			DelegateMethods.tilecut_0 = TileCuttingContext.AttackProjectile;
			Vector2 unit = projectile.velocity;
			Utils.PlotTileLine(projectile.Center, projectile.Center + unit * Distance, (projectile.width + 16) * projectile.scale, DelegateMethods.CutTiles);
		}
	}
}
