using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.Graphics.Effects;
using Terraria.Graphics.Shaders;
using Terraria.ID;
using Terraria.ModLoader;

namespace Laugicality.Items.Weapons
{
    public class Andeshiard : ModItem
    {
        public override void SetDefaults()
        {
            item.damage = 36;           
            item.thrown = true;            
            item.noMelee = true;
            item.width = 30;
            item.height = 30;
            item.useTime = 24;      
            item.useAnimation = 24;   
            item.useStyle = 1;
            item.knockBack = 6;
            item.value = 10;
            item.rare = 3;
            item.UseSound = SoundID.Item1;
            item.autoReuse = true;       
            item.shoot = mod.ProjectileType("Andeshiard");  
            item.shootSpeed = 16f;     
            item.useTurn = true;
            item.maxStack = 1;       
            item.consumable = false;  
            item.noUseGraphic = true;

        }
        public override void AddRecipes()  
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(null, "AndesiaCore", 1);
            recipe.AddIngredient(3081, 25);
            recipe.AddIngredient(3086, 25);
            recipe.AddTile(16);
            recipe.SetResult(this, 1);
            recipe.AddRecipe();
        }
    }
}