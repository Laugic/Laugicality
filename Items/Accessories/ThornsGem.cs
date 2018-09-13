using Terraria;
using Terraria.ModLoader;

namespace Laugicality.Items.Accessories
{
    public class ThornsGem : ModItem
    {
        public override void SetStaticDefaults()
        {
            Tooltip.SetDefault("Attackers also take damage");
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
            if (player.thorns < 1f)
            {
                player.thorns = 0.333333343f;
            }

        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(301, 4);
            recipe.AddTile(null, "AlchemicalInfuser");
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}