using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Laugicality.Items.Accessories
{
    public class RubrumGem : LaugicalityItem
    {
        public override void SetStaticDefaults()
        {
            Tooltip.SetDefault("+10% Damage");
        }

        public override void SetDefaults()
        {
            item.width = 16;
            item.height = 28;
            item.value = 100;
            item.rare = ItemRarityID.Green;
            item.accessory = true;
        }

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            player.allDamage += 0.1f;
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(null, "LiquidRubrum", 4);
            recipe.AddTile(null, "AlchemicalInfuser");
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}