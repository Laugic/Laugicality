using System;
using System.Collections.Generic;
using System.IO;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Laugicality.Items.Accessories;

namespace Laugicality.Items.SoulStone
{
    public class NecroticSoulCrystal : ModItem
    {
        public override void SetStaticDefaults()
        {
            Tooltip.SetDefault("A part of Skeletron's Soul.");
        }
        public override void SetDefaults()
        {
            item.width = 32;
            item.height = 30;
            item.maxStack = 20;
            item.rare = 3;
            item.useAnimation = 45;
            item.useTime = 45;
            item.useStyle = 4;
            item.UseSound = SoundID.Item9;
        }
        
        
        public override void AddRecipes()
        {

            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(null, "BonafideNecroticSoulCrystal");
            recipe.SetResult(this);
            recipe.AddRecipe();

            ModRecipe Rrecipe = new ModRecipe(mod);
            Rrecipe.AddIngredient(null, "UndeadNecroticSoulCrystal");
            Rrecipe.SetResult(this);
            Rrecipe.AddRecipe();
            /*
            ModRecipe Mrecipe = new ModRecipe(mod);
            Mrecipe.AddIngredient(null, "MagicNecroticSoulCrystal");
            Mrecipe.SetResult(this);
            Mrecipe.AddRecipe();

            ModRecipe Srecipe = new ModRecipe(mod);
            Srecipe.AddIngredient(null, "SummonNecroticSoulCrystal");
            Srecipe.SetResult(this);
            Srecipe.AddRecipe();

            ModRecipe Trecipe = new ModRecipe(mod);
            Trecipe.AddIngredient(null, "ThrowingNecroticSoulCrystal");
            Trecipe.SetResult(this);
            Trecipe.AddRecipe();*/
        }
    }
}