using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.Graphics.Effects;
using Terraria.Graphics.Shaders;
using Terraria.ID;
using Terraria.ModLoader;

namespace Laugicality.Items.Weapons.Thrown
{
    public class Coginator : ModItem
    {
        public override void SetDefaults()
        {
            item.damage = 80;
            item.thrown = true;
            item.noMelee = true;
            item.width = 24;
            item.height = 24;
            item.useTime = 12;
            item.useAnimation = 12;
            item.useStyle = 1;
            item.knockBack = 6;
            item.value = 10;
            item.rare = 3;
            item.UseSound = SoundID.Item1;
            item.autoReuse = true;
            item.shoot = mod.ProjectileType("CoginatorP");
            item.shootSpeed = 16f;
            item.useTurn = true;
            item.maxStack = 999;
            item.consumable = true;
            item.noUseGraphic = true;

        }
        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(null, "SteamBar", 4);
            recipe.AddTile(134);
            recipe.SetResult(this, 75);
            recipe.AddRecipe();
        }
    }
}