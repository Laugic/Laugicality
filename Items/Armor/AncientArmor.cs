using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Laugicality.Items.Armor
{
    [AutoloadEquip(EquipType.Body)]
    public class AncientArmor : LaugicalityItem
    {
        public override void SetStaticDefaults()
        {
            Tooltip.SetDefault("Your damage increases based on your Movement Speed.");
        }

        public override void SetDefaults()
        {
            item.width = 34;
            item.height = 22;
            item.value = Item.sellPrice(silver: 50);
            item.rare = ItemRarityID.Blue;
            item.defense = 5;
        }

        public override void UpdateEquip(Player player)
        {
            float moveSpeed = 0;
            moveSpeed = (float)player.velocity.Length() / 50f;
            if (moveSpeed > .25f)
                moveSpeed = .25f;
            player.allDamage += moveSpeed;
        }
        
        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(null, "Crystilla", 4);
            recipe.AddIngredient(null, "AncientShard", 1);
            recipe.AddIngredient(ItemID.DesertFossil, 16);
            recipe.AddTile(16);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}