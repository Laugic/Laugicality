using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.Graphics.Effects;
using Terraria.Graphics.Shaders;
using Terraria.ID;
using Terraria.ModLoader;

namespace Laugicality.Items.Weapons
{
    public class EnginatorM : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Enginator");
            Tooltip.SetDefault("CHOO CHOO");
        }
        public override void SetDefaults()
        {
            item.damage = 110;           //this is the item damage
            item.melee = true;             //this make the item do throwing damage
            item.noMelee = true;
            item.width = 106;
            item.height = 74;
            item.useTime = 20;       //this is how fast you use the item
            item.useAnimation = 20;   //this is how fast the animation when the item is used
            item.useStyle = 1;
            item.knockBack = 6;
            item.value = 10;
            item.rare = 3;
            item.reuseDelay = 20;    //this is the item delay
            item.UseSound = SoundID.Item1;
            item.autoReuse = true;       //this make the item auto reuse
            item.shoot = mod.ProjectileType("EnginatorP");  //javelin projectile
            item.shootSpeed = 16f;     //projectile speed
            item.useTurn = true;
            item.maxStack = 1;       //this is the max stack of this item
            item.consumable = false;  //this make the item consumable when used
            item.noUseGraphic = true;

        }
        public override void AddRecipes()  //How to craft this item
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(null, "SteamBar", 16);
            recipe.AddIngredient(null, "SoulOfFraught", 8);
            recipe.AddIngredient(null, "Gear", 8);
            recipe.AddTile(134);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}