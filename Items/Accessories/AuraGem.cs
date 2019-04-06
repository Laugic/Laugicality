using Terraria;
using Terraria.ModLoader;

namespace Laugicality.Items.Accessories
{
    public class AuraGem : ModItem
    {
        public override void SetStaticDefaults()
        {
            Tooltip.SetDefault("+10% Max Life");
        }

        public override void SetDefaults()
        {
            item.width = 16;
            item.height = 28;
            item.value = 100;
            item.rare = 2;
            item.accessory = true;
        }

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            player.statLifeMax2 = (int)(player.statLifeMax2 * 1.1f);
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(null, "LiquidAura", 4);
            recipe.AddTile(null, "AlchemicalInfuser");
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}