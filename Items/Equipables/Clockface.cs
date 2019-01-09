using Terraria;
using Terraria.ModLoader;

namespace Laugicality.Items.Equipables
{
    public class Clockface : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Clockface");
            Tooltip.SetDefault("Reduces the cooldown between Time Stops");
        }

        public override void SetDefaults()
        {
            item.width = 32;
            item.height = 32;
            item.value = 100;
            item.rare = 6;
            item.accessory = true;
        }

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            LaugicalityPlayer modPlayer = player.GetModPlayer<LaugicalityPlayer>(mod);
            modPlayer.zCoolDown -= 10 * 60;
        }
        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(null, "AndesiaCore", 1);
            recipe.AddIngredient(null, "DioritusCore", 1);
            recipe.AddIngredient(null, "Pipeworks", 1);
            recipe.AddIngredient(3086, 32);
            recipe.AddIngredient(3081, 32);
            recipe.AddTile(134);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}