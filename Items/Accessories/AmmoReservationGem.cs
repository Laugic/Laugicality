using Terraria;
using Terraria.ModLoader;

namespace Laugicality.Items.Accessories
{
    public class AmmoReservationGem : ModItem
    {
        public override void SetStaticDefaults()
        {
            Tooltip.SetDefault("+20% Ammo Reduction");
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
            player.ammoCost80 = true;
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(2344, 4);
            recipe.AddTile(null, "AlchemicalInfuser");
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}