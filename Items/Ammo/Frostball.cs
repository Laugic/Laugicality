using Laugicality.Items.Loot;
using Terraria.ID;
using Terraria.ModLoader;

namespace Laugicality.Items.Ammo
{
    public class Frostball : LaugicalityItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Frostball");
            Tooltip.SetDefault("Inflicts 'Frostburn'");
        }

        public override void SetDefaults()
        {
            item.damage = 13;
            item.ranged = true;
            item.width = 8;
            item.height = 8;
            item.maxStack = 999;
            item.consumable = true;
            item.knockBack = 7f;
            item.value = 0;
            item.rare = ItemRarityID.White;
            item.shoot = mod.ProjectileType("Frostball");
            item.shootSpeed = 14f;
            item.ammo = AmmoID.Snowball;
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.SnowBlock, 5);
            recipe.AddIngredient(mod.ItemType<SoulOfSought>(), 1);
            recipe.SetResult(this, 50);
            recipe.AddRecipe();
        }
    }
}
