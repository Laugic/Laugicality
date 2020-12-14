using Terraria;
using Terraria.ID;
using System;
using Laugicality.Projectiles.Mystic.Conjuration;
using Laugicality.Projectiles.Mystic.Destruction;
using Laugicality.Projectiles.Mystic.Illusion;
using Microsoft.Xna.Framework;
using Laugicality.Projectiles.Special;
using Terraria.ModLoader;
using Laugicality.Items.Materials;

namespace Laugicality.Items.Weapons.Mystic
{
    public class OrionsGate : MysticItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Orion's Gate");
            Tooltip.SetDefault("'Open the path to the stars'\nIllusion inflicts 'Cosmic Disarray', which drains life and makes enemies take more damage.\nFires different projectiles based on Mysticism\nConsuming enemies increases the Gate's power.");
            Item.staff[item.type] = true;
        }
        
        public override void SetMysticDefaults()
        {
            item.damage = 40;
            item.width = 56;
            item.height = 56;
            item.useTime = 18;
            item.useAnimation = 18;
            item.useStyle = 5;
            item.noMelee = true;
            item.knockBack = 2;
            item.value = 10000;
            item.rare = ItemRarityID.Red;
            item.UseSound = SoundID.Item105;
            item.autoReuse = true;
            item.shootSpeed = 6f;
        }

        public override bool MysticShoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
        {
            Vector2 muzzleOffset = Vector2.Normalize(new Vector2(speedX, speedY)) * 50f;

            LaugicalityPlayer modPlayer = LaugicalityPlayer.Get(player);
            if (modPlayer.MysticMode == 1)
            {
                modPlayer.OrionCharge++;
                modPlayer.UsingMysticItem = 60;
                if (modPlayer.OrionCharge > 24)
                    modPlayer.OrionCharge = 24;
                for (int i = 0; i < modPlayer.OrionCharge / 2 + 1; i++)
                {
                    float theta = (float)Main.rand.NextDouble() * 3.14f / 6 + 3.14f * 255f / 180f;
                    theta += -modPlayer.OrionCharge / 24 * 3.14f / 6 + 2 * modPlayer.OrionCharge / 24 * (float)Main.rand.NextDouble() * 3.14f / 6;
                    float mag = 600 + Main.rand.Next(200 + 4 * modPlayer.OrionCharge);
                    Projectile.NewProjectile((int)(Main.MouseWorld.X) + (int)(mag * Math.Cos(theta)) - 32 - modPlayer.OrionCharge + Main.rand.Next(64 + 2 * modPlayer.OrionCharge), (int)(Main.MouseWorld.Y) + (int)(mag * Math.Sin(theta)) - 32 - modPlayer.OrionCharge + Main.rand.Next(64 + 2 * modPlayer.OrionCharge), -25 * (float)Math.Cos(theta), -25 * (float)Math.Sin(theta), ModContent.ProjectileType<OrionDestruction>(), damage, 3, Main.myPlayer);
                }
            }
            if(modPlayer.MysticMode == 2)
            {
                Projectile.NewProjectile(player.position.X, player.position.Y - 600, -4, 0, ModContent.ProjectileType<OrionIllusionSpawn>(), damage, 3, Main.myPlayer);
                Projectile.NewProjectile(player.position.X, player.position.Y - 600, 4, 0, ModContent.ProjectileType<OrionIllusionSpawn>(), damage, 3, Main.myPlayer);
            }
            if (modPlayer.MysticMode == 3)
            {
                bool projExists = false;
                foreach( Projectile projectile in Main.projectile)
                {
                    if(projectile.type == ModContent.ProjectileType<OrionConjuration>())
                    {
                        projectile.timeLeft = 90;
                        modPlayer.UsingMysticItem = 90;
                        projExists = true;
                    }
                }
                if(!projExists)
                {
                    Projectile.NewProjectile((int)(Main.MouseWorld.X), (int)(Main.MouseWorld.Y), 0, 0, ModContent.ProjectileType<OrionConjuration>(), damage, 3, Main.myPlayer);
                }
            }
            return true;
        }
        
        public override void Destruction(LaugicalityPlayer modPlayer)
        {
            item.damage = 48;
            item.useTime = 20;
            item.useAnimation = item.useTime;
            item.knockBack = 4;
            item.shootSpeed = 12f;
            item.shoot = ModContent.ProjectileType<Nothing>();
            item.noUseGraphic = false;
        }

        public override void Illusion(LaugicalityPlayer modPlayer)
        {
            item.damage = 42;
            item.useTime = 90;
            item.useAnimation = item.useTime;
            item.knockBack = 1;
            item.shootSpeed = 22f;
            item.shoot = ModContent.ProjectileType<Nothing>();
            item.noUseGraphic = false;
        }

        public override void Conjuration(LaugicalityPlayer modPlayer)
        {
            item.damage = 35;
            item.useTime = 40;
            item.useAnimation = item.useTime;
            item.knockBack = 2;
            item.shootSpeed = 0f;
            item.shoot = ModContent.ProjectileType<Nothing>();
            item.noUseGraphic = false;
        }
        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(mod, nameof(GalacticFragment), 15);
            recipe.AddTile(412);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}