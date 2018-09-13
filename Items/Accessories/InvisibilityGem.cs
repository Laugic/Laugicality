using Terraria;
using Terraria.ModLoader;

namespace Laugicality.Items.Accessories
{
    public class InvisibilityGem : ModItem
    {
        public override void SetStaticDefaults()
        {
            Tooltip.SetDefault("'You can't see me.'");
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
            player.invis = true;

        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(297, 4);
            recipe.AddTile(null, "AlchemicalInfuser");
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}