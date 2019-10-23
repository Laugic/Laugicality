using Laugicality.Dusts;
using Laugicality.Projectiles.Accessory;
using Microsoft.Xna.Framework;
using System;
using Terraria;
using Terraria.Graphics.Shaders;
using Terraria.ID;
using Terraria.ModLoader;

namespace Laugicality.Items.Equipables
{
    public class HyperlightDrifters : LaugicalityItem
    {
        int dashDelay = 0;
        int dashCooldown = 0;
        int trail = 0;
        int rocketBootTime = 0;
        int rocketBootTimeMax = 7 * 60;
        float rocketAccel = .25f;
        int dashDir = 0;
        float maxVel = 14;

        public override void SetStaticDefaults()
        {
            Tooltip.SetDefault("Light speed\nDominion over everything\nGrants the ability to hyper-dash\nBecome immune for a time while dashing\nLeave a Cosmic trail\n+10% Damage");
        }

        public override void SetDefaults()
        {
            item.width = 28;
            item.height = 28;
            item.value = 100;
            item.rare = ItemRarityID.Red;
            item.accessory = true;
            item.defense = 10;
        }

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            player.jumpSpeedBoost += 7;
            player.moveSpeed += .75f;
            player.maxRunSpeed += 7.5f;
            player.iceSkate = true;
            player.doubleJumpBlizzard = true;
            player.noFallDmg = true;
            player.waterWalk = true;
            player.fireWalk = true;
            player.lavaImmune = true;
            player.buffImmune[24] = true;
            player.gills = true;
            player.ignoreWater = true;
            player.accFlipper = true;
            player.GetModPlayer<LaugicalityPlayer>().BysmalTrail = true;
            player.GetModPlayer<LaugicalityPlayer>().DamageBoost(.1f);
            Run(player);
            GetRocketBoots(player);
            Dashes(player);
            Delays(player);
        }

        private void Run(Player player)
        {
            if (Main.tileSolid[Main.tile[(int)(player.Center.X / 16), (int)(player.Center.Y / 16) + 2].type] && Main.tile[(int)(player.Center.X / 16), (int)(player.Center.Y / 16) + 2].type != 0 && Math.Abs(player.velocity.X) > 4 && Main.rand.Next(3) == 0)
            {
                int newDust = Dust.NewDust(new Vector2(player.Center.X + player.velocity.X, player.position.Y + 4 + player.height - 10f + player.velocity.Y), 8, 8, ModContent.DustType<EtherialDust>(), 0f, 0f, 0, default(Color), 1.5f);
                Main.dust[newDust].scale = 4;
            }
        }

        private void GetRocketBoots(Player player)
        {
            float accelMax = .7f;

            if (player.controlJump && rocketBootTime < rocketBootTimeMax)
            {
                if (rocketAccel < accelMax)
                    rocketAccel += .075f;
                if (player.velocity.Y > -maxVel)
                    player.velocity.Y -= rocketAccel;
                if (player.velocity.Y > 0)
                    player.velocity.Y *= .75f;
                RocketDust(player);
                rocketBootTime++;
                player.fallStart = (int)player.position.Y / 16;
                if (player.rocketDelay2 <= 0)
                {
                    Main.PlaySound(SoundID.Item24, player.position);
                    player.rocketDelay2 = 15;
                }
            }
            else
                rocketAccel = .75f;
        }

        private void RocketDust(Player player)
        {
            int alpha = 0;
            for (int i = 0; i < 2; i++)
            {
                if (i == 0)
                {
                    int newDust = Dust.NewDust(new Vector2(player.position.X - 4f + player.velocity.X, player.position.Y + (float)player.height - 10f + player.velocity.Y), 8, 8, ModContent.DustType<EtherialDust>(), 0f, 0f, alpha, default(Color), 1.5f);
                    Main.dust[newDust].shader = GameShaders.Armor.GetSecondaryShader(player.cShoe, player);
                    Main.dust[newDust].velocity.X = (Main.dust[newDust].velocity.X * 1f - 2f - player.velocity.X * 0.3f) / 2;
                    Main.dust[newDust].velocity.Y = (Main.dust[newDust].velocity.Y * 1f + 2f * player.gravDir - player.velocity.Y * 0.3f) / 2;
                    Main.dust[newDust].noGravity = true;
                }
                else
                {
                    int newDust = Dust.NewDust(new Vector2(player.position.X + (float)player.width - 4f + player.velocity.X, player.position.Y + (float)player.height - 10f + player.velocity.Y), 8, 8, ModContent.DustType<EtherialDust>(), 0f, 0f, alpha, default(Color), 1.5f);
                    Main.dust[newDust].shader = GameShaders.Armor.GetSecondaryShader(player.cShoe, player);
                    Main.dust[newDust].velocity.X = (Main.dust[newDust].velocity.X * 1f + 2f - player.velocity.X * 0.3f) / 2;
                    Main.dust[newDust].velocity.Y = (Main.dust[newDust].velocity.Y * 1f + 2f * player.gravDir - player.velocity.Y * 0.3f) / 2;
                    Main.dust[newDust].noGravity = true;
                }
            }
        }

        private void Dashes(Player player)
        {
            float dashSpeed = 30;
            int dashCooldownMax = 45;
            int trailLength = 45;
            int verticalCooldownMax = 45;
            int immuneTime = 22;
            float warpDist = 0;

            if (!player.mount.Active && player.grappling[0] == -1 && dashCooldown <= 0)
            {
                if (player.controlRight && player.releaseRight)
                {
                    if (dashDelay > 0 && dashDir == 1)
                    {
                        dashCooldown = dashCooldownMax;
                        trail = trailLength;
                        player.velocity.X = dashSpeed;
                        player.position.X += warpDist;
                        player.GetModPlayer<LaugicalityPlayer>().DustBurst(ModContent.DustType<EtherialDust>(), 40);
                        dashDir = 0;
                        player.immune = true;
                        player.immuneTime = immuneTime;
                        DashBurst(player);
                    }
                    else
                    {
                        dashDelay = 15;
                        dashDir = 1;
                    }
                }
                if (player.controlLeft && player.releaseLeft)
                {
                    if (dashDelay > 0 && dashDir == 2)
                    {
                        dashCooldown = dashCooldownMax;
                        trail = trailLength;
                        player.velocity.X = -dashSpeed;
                        player.position.X += -warpDist;
                        player.GetModPlayer<LaugicalityPlayer>().DustBurst(ModContent.DustType<EtherialDust>(), 40);
                        dashDir = 0;
                        player.immune = true;
                        player.immuneTime = immuneTime;
                        DashBurst(player);
                    }
                    else
                    {
                        dashDelay = 15;
                        dashDir = 2;
                    }
                }
                if (player.controlDown && player.releaseDown)
                {
                    if (dashDelay > 0 && dashDir == 3)
                    {
                        dashCooldown = verticalCooldownMax;
                        trail = trailLength;
                        player.velocity.Y = 2 * dashSpeed;
                        player.position.Y += warpDist;
                        player.GetModPlayer<LaugicalityPlayer>().DustBurst(ModContent.DustType<EtherialDust>(), 50);
                        dashDir = 0;
                        player.fallStart = (int)player.position.Y / 16;
                        player.immune = true;
                        player.immuneTime = immuneTime;
                        DashBurst(player);
                    }
                    else
                    {
                        dashDelay = 15;
                        dashDir = 3;
                    }
                }
                if (player.controlUp && player.releaseUp)
                {
                    if (dashDelay > 0 && dashDir == 4)
                    {
                        dashCooldown = verticalCooldownMax;
                        trail = trailLength;
                        player.velocity.Y = -dashSpeed;
                        player.position.Y += -warpDist;
                        player.GetModPlayer<LaugicalityPlayer>().DustBurst(ModContent.DustType<EtherialDust>(), 50);
                        dashDir = 0;
                        player.fallStart = (int)player.position.Y / 16;
                        player.immune = true;
                        player.immuneTime = immuneTime;
                        DashBurst(player);
                    }
                    else
                    {
                        dashDelay = 15;
                        dashDir = 4;
                    }
                }
            }
        }

        private void DashBurst(Player player)
        {
            int numProj = Main.rand.Next(2) + 4;
            for (int i = 0; i < numProj; i++)
            {
                float mag = Main.rand.NextFloat() * 4 + 2;
                float theta = Main.rand.NextFloat() * 2 * (float)Math.PI;
                Projectile.NewProjectile(player.Center.X, player.Center.Y, mag * (float)Math.Cos(theta), mag * (float)Math.Sin(theta), ModContent.ProjectileType<BysmalTrailProj>(), (int)(36 * player.GetModPlayer<LaugicalityPlayer>().GetGlobalDamage()), 0, player.whoAmI);
            }
        }

        private void Delays(Player player)
        {
            if (dashDelay > 0)
                dashDelay--;
            if (dashCooldown > 0)
                dashCooldown--;
            if (trail > 0)
            {
                trail--;
                player.GetModPlayer<LaugicalityPlayer>().DustTrail(ModContent.DustType<EtherialDust>(), 2);
            }
            if (Main.tileSolid[Main.tile[(int)(player.Center.X / 16), (int)(player.Center.Y / 16) + 2].type] && Main.tile[(int)(player.Center.X / 16), (int)(player.Center.Y / 16) + 2].type != 0 && Math.Abs(player.velocity.Y) < .25f)
            {
                rocketBootTime = 0;
            }
            if (player.grappling[0] != -1)
            {
                rocketBootTime = 0;
            }
        }
        /*
        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<BysmaliteWarpers>(), 1);
            recipe.AddIngredient(ItemID.LunarBar, 16);
            recipe.AddIngredient(ModContent.ItemType<GalacticFragment>(), 12);
            recipe.AddTile(TileID.LunarCraftingStation);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }*/
    }
}