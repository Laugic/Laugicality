using Terraria;
using Terraria.ModLoader;

namespace Laugicality.Items.Accessories
{
    public class ManaCrystal : ModItem
    {
        public override void SetStaticDefaults()
        {
            Tooltip.SetDefault("+60 Mana");
        }

        public override void SetDefaults()
        {
            item.width = 16;
            item.height = 28;
            item.value = 100;
            item.rare = 3;
            item.accessory = true;
        }

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            player.statManaMax2 += 60;
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(null, "LesserManaGem", 1);
            recipe.AddIngredient(null, "ManaGem", 1);
            recipe.AddTile(null, "CrystalineInfuser");
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}