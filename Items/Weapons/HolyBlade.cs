using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.Graphics.Effects;
using Terraria.Graphics.Shaders;
using Terraria.ID;
using Terraria.ModLoader;

namespace Laugicality.Items.Weapons
{
    public class HolyBlade : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Blade of The Holy Knight");
            Tooltip.SetDefault("'Call down the sky'");
        }
        public override void SetDefaults()
        {
            item.damage = 600;           
            item.melee = true;             
            item.noMelee = false;
            item.width = 90;
            item.height = 90;
            item.useTime =10;       
            item.useAnimation = 10;   
            item.useStyle = 1;
            item.knockBack = 6;
            item.value = 100000;
            item.rare = 9;
            //item.reuseDelay = 20;    
            item.UseSound = SoundID.Item1;
            item.autoReuse = true;       
            //item.shoot = 461;  
            //item.shootSpeed = 16f;     
            item.useTurn = true;
            item.maxStack = 1;      
            item.consumable = false;
            //item.noUseGraphic = true;
            item.scale = 1.5f;

        }

        public override void OnHitNPC(Player player, NPC target, int damage, float knockback, bool crit)
        {
            if(player.ownedProjectileCounts[mod.ProjectileType("HolyOrigin")] == 0)
            {
                if (Main.player[Main.myPlayer] == player)
                {
                    Projectile.NewProjectile((int)(target.position.X), (int)(target.position.Y) - 1200, 0, 0, mod.ProjectileType("HolyOrigin"), (int)(item.damage), 3, Main.myPlayer);
                }
            }
        }/*
        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(3467, 16);
            recipe.AddIngredient(3458, 8);
            recipe.AddTile(412);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }*/
    }
}