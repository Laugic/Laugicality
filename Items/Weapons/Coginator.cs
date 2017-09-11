using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.Graphics.Effects;
using Terraria.Graphics.Shaders;
using Terraria.ID;
using Terraria.ModLoader;

namespace Laugicality.Items.Weapons
{
    public class Coginator : ModItem
    {
        public override void SetDefaults()
        {
            item.damage = 100;           //this is the item damage
            item.thrown = true;             //this make the item do throwing damage
            item.noMelee = true;
            item.width = 24;
            item.height = 24;
            item.useTime = 6;       //this is how fast you use the item
            item.useAnimation = 6;   //this is how fast the animation when the item is used
            item.useStyle = 1;
            item.knockBack = 6;
            item.value = 10;
            item.rare = 3;
            item.reuseDelay = 5;    //this is the item delay
            item.UseSound = SoundID.Item1;
            item.autoReuse = true;       //this make the item auto reuse
            item.shoot = mod.ProjectileType("CoginatorP");  //javelin projectile
            item.shootSpeed = 16f;     //projectile speed
            item.useTurn = true;
            item.maxStack = 999;       //this is the max stack of this item
            item.consumable = true;  //this make the item consumable when used
            item.noUseGraphic = true;

        }
        public override void AddRecipes()  //How to craft this item
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(null, "SteamBar", 4);
            recipe.AddIngredient(null, "SoulOfFraught", 1);
            recipe.AddTile(134);
            recipe.SetResult(this, 75);
            recipe.AddRecipe();
        }
    }
}