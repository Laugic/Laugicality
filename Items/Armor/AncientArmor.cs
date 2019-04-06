using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Laugicality.Items.Armor
{
    [AutoloadEquip(EquipType.Body)]
    public class AncientArmor : ModItem
    {
        public override void SetStaticDefaults()
        {
            Tooltip.SetDefault("Your damage increases based on your Movement Speed.");
        }

        public override void SetDefaults()
        {
            item.width = 34;
            item.height = 22;
            item.value = 10000;
            item.rare = 3;
            item.defense = 5;
        }

        public override void UpdateEquip(Player player)
        {
            float moveSpeed = 0;
            moveSpeed = (float)Math.Abs(player.velocity.X) / 30f;
            if (moveSpeed > .2f)
                moveSpeed = .2f;
            player.thrownDamage += moveSpeed;
            player.rangedDamage += moveSpeed;
            player.magicDamage += moveSpeed;
            player.minionDamage += moveSpeed;
            player.meleeDamage += moveSpeed;
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