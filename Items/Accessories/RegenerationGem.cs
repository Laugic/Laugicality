using Terraria.ModLoader;

namespace Laugicality.Items.Accessories
{
    public class RegenerationGem : ModItem
    {
        public override void SetStaticDefaults()
        {
            Tooltip.SetDefault("Increases life regeneration");
        }

        public override void SetDefaults()
        {
            item.width = 16;
            item.height = 28;
            item.value = 100;
            item.rare = 2;
            item.accessory = true;
            item.lifeRegen = 2;
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(289, 4);
            recipe.AddTile(null, "AlchemicalInfuser");
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}