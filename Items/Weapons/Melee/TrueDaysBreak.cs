using Microsoft.Xna.Framework;
using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Laugicality.Items.Weapons.Melee
{
    public class TrueDaysBreak : LaugicalityItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("True Sunrise");
            Tooltip.SetDefault("'Bring the sky'\nStriking enemies makes them emit True Sparks\nEnemies explode into True Sparks on death, spreading the Redemption.");
        }

        public override void SetDefaults()
        {
            item.damage = 48;
            item.melee = true;
            item.width = 58;
            item.height = 58;
            item.useTime = 40;
            item.useAnimation = 20;
            item.useStyle = 1;
            item.knockBack = 4;
            item.value = 10000;
            item.rare = ItemRarityID.LightRed;
            item.UseSound = SoundID.Item1;
            item.autoReuse = true;
            item.shootSpeed = 16f;
            item.shoot = ModContent.ProjectileType("TrueGoldenSword");
            item.scale *= 1.25f;
        }


        public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
        {
            for(int i = 0; i < 3; i++)
            {
                float theta = (float)Main.rand.NextDouble() * 3.14f / 6 + 3.14f * 255f / 180f;
                float mag = 600 + Main.rand.Next(200);
                Projectile.NewProjectile((int)(Main.MouseWorld.X) + (int)(mag * Math.Cos(theta)), (int)(Main.MouseWorld.Y) + (int)(mag * Math.Sin(theta)), -25 * (float)Math.Cos(theta), -25 * (float)Math.Sin(theta), ModContent.ProjectileType("TrueDawnStar"), damage, 3, Main.myPlayer);
            }
            int numberProjectiles = Main.rand.Next(1, 4);
            for (int i = 0; i < numberProjectiles; i++)
            {
                Vector2 perturbedSpeed = new Vector2(speedX, speedY).RotatedByRandom(MathHelper.ToRadians(15));
                float scale = 1.1f - (Main.rand.NextFloat() * .3f);
                perturbedSpeed = perturbedSpeed * scale;
                Projectile.NewProjectile(position.X, position.Y, perturbedSpeed.X, perturbedSpeed.Y, ModContent.ProjectileType("TrueGoldenSword"), damage, knockBack, player.whoAmI);
            }
            return true;
        }

        public override void OnHitNPC(Player player, NPC target, int damage, float knockback, bool crit)
        {
            target.AddBuff(ModContent.BuffType("TrueDawn"), 12 * 60 + Main.rand.Next(8 * 60));
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType("DaysBreak"));
            recipe.AddRecipeGroup("TitaniumBars", 12);
            recipe.AddIngredient(ItemID.HallowedBar, 10);
            recipe.AddIngredient(ItemID.LargeDiamond, 1);
            recipe.AddTile(TileID.MythrilAnvil);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}