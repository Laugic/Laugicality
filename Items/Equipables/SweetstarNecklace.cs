using Terraria;
using Terraria.ModLoader;

namespace Laugicality.Items.Equipables
{
    public class SweetstarNecklace : ModItem
    {
        public override void SetStaticDefaults()
        {
            Tooltip.SetDefault("Increased invincibility time and movement speed after taking damage \nRelease stars and bees after taking damage");
        }

        public override void SetDefaults()
        {
            item.width = 26;
            item.height = 36;
            item.value = 100;
            item.rare = 5;
            item.accessory = true;
        }

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            player.longInvince = true;
            player.starCloak = true;
            player.bee = true;
            player.panic = true;
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(862);
            recipe.AddIngredient(1578);
            recipe.AddTile(114);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}