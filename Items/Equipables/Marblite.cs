using Terraria;
using Terraria.ModLoader;


namespace Laugicality.Items.Equipables
{
    public class Marblite : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Marblite");
            Tooltip.SetDefault("+10% Mystic Damage\nGet 'For Honor' and 'For Glory' when switching Mysticism.");
        }

        public override void SetDefaults()
        {
            item.width = 48;
            item.height = 48;
            item.value = 10000;
            item.rare = 1;
            item.accessory = true;
        }

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            LaugicalityPlayer modPlayer = player.GetModPlayer<LaugicalityPlayer>(mod);
            modPlayer.mysticMarblite = true;
            modPlayer.mysticDamage += .1f;
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(null, "DioritusCore", 1);
            recipe.AddIngredient(3081, 25);
            recipe.AddIngredient(3086, 25);
            recipe.AddTile(16);
            recipe.SetResult(this, 1);
            recipe.AddRecipe();
        }
    }
}