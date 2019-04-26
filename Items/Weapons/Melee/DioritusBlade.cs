using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.Graphics.Effects;
using Terraria.Graphics.Shaders;
using Terraria.ID;
using Terraria.ModLoader;

namespace Laugicality.Items.Weapons.Melee
{
    public class DioritusBlade : LaugicalityItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Blade of Glory");
            Tooltip.SetDefault("Right click to throw \n'Into Battle!'");
        }
        public override void SetDefaults()
        {
            item.damage = 50;           
            item.melee = true;             
            item.noMelee = false;
            item.width = 60;
            item.height = 60;
            item.useTime = 20;       
            item.useAnimation = 20;   
            item.useStyle = 1;
            item.knockBack = 6;
            item.value = 100000;
            item.rare = ItemRarityID.Green;
            //item.reuseDelay = 20;    
            item.UseSound = SoundID.Item1;
            item.autoReuse = true;       
            //item.shoot = mod.ProjectileType("EnginatorP");  
            item.shootSpeed = 16f;     
            item.useTurn = true;
            item.maxStack = 1;      
            item.consumable = false;  
            //item.noUseGraphic = true;

        }

        public override bool AltFunctionUse(Player player)
        {
            return true;
        }

        public override bool CanUseItem(Player player)
        {
            if (player.altFunctionUse == 2)
            {
                item.shoot = mod.ProjectileType("DioritusBlade");
                item.noUseGraphic = true;
            }
            else
            {
                item.shoot = 0;
                item.noUseGraphic = false;
            }
            return player.ownedProjectileCounts[mod.ProjectileType("DioritusBlade")] < 1;
        }
        

        public override void AddRecipes()  
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(null, "DioritusCore", 1);
            recipe.AddIngredient(3081, 32);
            recipe.AddTile(16);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}