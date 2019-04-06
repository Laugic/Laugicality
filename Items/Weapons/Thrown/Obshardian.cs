using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.Graphics.Effects;
using Terraria.Graphics.Shaders;
using Terraria.ID;
using Terraria.ModLoader;

namespace Laugicality.Items.Weapons.Thrown
{
    public class Obshardian : ModItem
    {
        public override void SetDefaults()
        {
            item.damage = 34;           
            item.thrown = true;             
            item.noMelee = true;
            item.width = 14;
            item.height = 26;
            item.useTime = 10;       
            item.useAnimation = 10;   
            item.useStyle = 1;
            item.knockBack = 6;
            item.value = 10;
            item.rare = 3;
            //item.reuseDelay = 17;   
            item.UseSound = SoundID.Item1;
            item.autoReuse = true;       
            item.shoot = mod.ProjectileType("ObshardianP");  
            item.shootSpeed = 16f;     
            item.useTurn = true;
            item.maxStack = 999;       
            item.consumable = true;  
            item.noUseGraphic = true;

        }
        public override void AddRecipes()  //How to craft this item
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(null, "ObsidiumBar", 8);
            recipe.AddIngredient(null, "DarkShard", 1);
            recipe.AddTile(16);
            recipe.SetResult(this, 333);
            recipe.AddRecipe();
        }
    }
}