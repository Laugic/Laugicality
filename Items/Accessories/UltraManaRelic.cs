using Terraria;
using Terraria.ModLoader;

namespace Laugicality.Items.Accessories
{
    public class UltraManaRelic : ModItem
    {
        public override void SetStaticDefaults()
        {
            Tooltip.SetDefault("+120 Mana");
        }

        public override void SetDefaults()
        {
            item.width = 16;
            item.height = 28;
            item.value = 100;
            item.rare = 8;
            item.accessory = true;
        }

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            player.statManaMax2 += 120;
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(null, "ManaCrystal", 1);
            recipe.AddIngredient(null, "MegaManaStone", 1);
            recipe.AddTile(null, "AncientEnchanter");
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}