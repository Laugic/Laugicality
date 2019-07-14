using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text.RegularExpressions;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria.ModLoader.IO;
using Laugicality;
using Laugicality.Projectiles;
using Laugicality.Projectiles.Special;

namespace Laugicality.Items.Weapons.Mystic
{
    public class OrionsGate : MysticItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Orion's Gate");
            Tooltip.SetDefault("'Open the path to the stars'\nIllusion inflicts 'Cosmic Disarray', which drains life and makes enemies take more damage.\nFires different projectiles based on Mysticism\nConsuming enemies increases the Gate's power.");
        }
        
        public override void SetMysticDefaults()
        {
            item.damage = 40;
            item.width = 56;
            item.height = 56;
            item.useTime = 18;
            item.useAnimation = 18;
            item.useStyle = 1;
            item.noMelee = true;
            item.knockBack = 2;
            item.value = 10000;
            item.rare = ItemRarityID.Lime;
            item.UseSound = SoundID.Item105;
            item.autoReuse = true;
            item.shootSpeed = 6f;
        }

        public override bool MysticShoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
        {
            Vector2 muzzleOffset = Vector2.Normalize(new Vector2(speedX, speedY)) * 50f;

            LaugicalityPlayer modPlayer = player.GetModPlayer<LaugicalityPlayer>(mod);
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
                    Projectile.NewProjectile((int)(Main.MouseWorld.X) + (int)(mag * Math.Cos(theta)) - 32 - modPlayer.OrionCharge + Main.rand.Next(64 + 2 * modPlayer.OrionCharge), (int)(Main.MouseWorld.Y) + (int)(mag * Math.Sin(theta)) - 32 - modPlayer.OrionCharge + Main.rand.Next(64 + 2 * modPlayer.OrionCharge), -25 * (float)Math.Cos(theta), -25 * (float)Math.Sin(theta), mod.ProjectileType("OrionDestruction"), damage, 3, Main.myPlayer);
                }
            }
            if(modPlayer.MysticMode == 2)
            {
                Projectile.NewProjectile(player.position.X, player.position.Y - 600, -4, 0, mod.ProjectileType("OrionIllusionSpawn"), damage, 3, Main.myPlayer);
                Projectile.NewProjectile(player.position.X, player.position.Y - 600, 4, 0, mod.ProjectileType("OrionIllusionSpawn"), damage, 3, Main.myPlayer);
            }
            if (modPlayer.MysticMode == 3)
            {
                bool projExists = false;
                foreach( Projectile projectile in Main.projectile)
                {
                    if(projectile.type == mod.ProjectileType("OrionConjuration"))
                    {
                        projectile.timeLeft = 90;
                        modPlayer.UsingMysticItem = 90;
                        projExists = true;
                    }
                }
                if(!projExists)
                {
                    Projectile.NewProjectile((int)(Main.MouseWorld.X), (int)(Main.MouseWorld.Y), 0, 0, mod.ProjectileType("OrionConjuration"), damage, 3, Main.myPlayer);
                }
            }
            return true;
        }
        
        public override void Destruction(LaugicalityPlayer modPlayer)
        {
            item.useStyle = ItemUseStyleID.HoldingUp;
            item.damage = 48;
            item.useTime = 20;
            item.useAnimation = item.useTime;
            item.knockBack = 4;
            item.shootSpeed = 12f;
            item.shoot = mod.ProjectileType<Nothing>();
            item.noUseGraphic = false;
        }

        public override void Illusion(LaugicalityPlayer modPlayer)
        {
            item.useStyle = ItemUseStyleID.HoldingUp;
            item.damage = 42;
            item.useTime = 90;
            item.useAnimation = item.useTime;
            item.knockBack = 1;
            item.shootSpeed = 22f;
            item.shoot = mod.ProjectileType<Nothing>();
            item.noUseGraphic = false;
        }

        public override void Conjuration(LaugicalityPlayer modPlayer)
        {
            item.useStyle = ItemUseStyleID.HoldingUp;
            item.damage = 35;
            item.useTime = 40;
            item.useAnimation = item.useTime;
            item.knockBack = 2;
            item.shootSpeed = 0f;
            item.shoot = mod.ProjectileType<Nothing>();
            item.noUseGraphic = false;
        }
        /*
        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.Pearlwood, 24);
            recipe.AddRecipeGroup("SilverBars", 8);
            recipe.AddIngredient(ItemID.SoulofLight, 6);
            recipe.AddIngredient(mod, nameof(SoulOfSought), 4);
            recipe.AddIngredient(ItemID.CrystalShard, 4);
            recipe.AddTile(TileID.MythrilAnvil);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }*/
    }
}