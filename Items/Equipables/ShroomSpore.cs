using Terraria;
using Terraria.ModLoader;


namespace Laugicality.Items.Equipables
{
    public class ShroomSpore : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Spore Cloud");
            Tooltip.SetDefault("Unleash Spores when changing Mysticism.");
        }

        public override void SetDefaults()
        {
            item.width = 48;
            item.height = 48;
            item.value = 100;
            item.rare = 1;
            item.accessory = true;
        }

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            LaugicalityPlayer modPlayer = player.GetModPlayer<LaugicalityPlayer>(mod);
            modPlayer.mysticShroomBurst = true;
        }
        
        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(183, 16);
            recipe.AddTile(16);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}