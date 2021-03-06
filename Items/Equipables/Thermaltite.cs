﻿using Laugicality.Items.Materials;
using Laugicality.Items.Placeable;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;


namespace Laugicality.Items.Equipables
{
    public class Thermaltite : LaugicalityItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Thermaltite");
            Tooltip.SetDefault("+15% Overflow Damage");
        }

        public override void SetDefaults()
        {
            item.width = 32;
            item.height = 32;
            item.defense = 4;
            item.value = Item.sellPrice(gold: 1);
            item.rare = ItemRarityID.Orange;
            item.accessory = true;
        }

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            LaugicalityPlayer modPlayer = LaugicalityPlayer.Get(player);
            //modPlayer.Incineration = 2;
            modPlayer.OverflowDamage += .15f;
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<LavaGemItem>(), 15);
            recipe.AddIngredient(ModContent.ItemType<ObsidiumRock>(), 15);
            recipe.AddIngredient(ModContent.ItemType<ObsidiumBar>(), 4);
            recipe.AddTile(null, "AlchemicalInfuser");
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}