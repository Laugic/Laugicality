﻿using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Laugicality.Items.Consumables.Potions
{
	public class MysticPowerPotion : ModItem
    {
        public override void SetStaticDefaults()
        {
            Tooltip.SetDefault("+10% Mystic Damage");
        }
        public override void SetDefaults()
		{
			item.width = 24;
			item.height = 24;
			item.maxStack = 30;
			item.rare = 1;
            item.useAnimation = 15;
            item.useTime = 15;
            item.useStyle = 2;
			item.UseSound = SoundID.Item3;
			item.consumable = true;
		}
        

        public override bool UseItem(Player player)
        {
            player.AddBuff(mod.BuffType("MysticPower"), 3*60*60, true);
            return true;
        }
        /*
        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.BottledWater, 1);
            recipe.AddIngredient(null, "AlbusDust", 1);
            recipe.AddIngredient(null, "AuraDust", 1);
            recipe.AddIngredient(null, "RubrumDust", 1);
            recipe.AddIngredient(null, "VerdiDust", 1);
            recipe.AddIngredient(null, "RegisDust", 1);
            recipe.AddIngredient(null, "AquosDust", 1);
            recipe.AddTile(13);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }*/
    }
}