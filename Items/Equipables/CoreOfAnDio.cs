using Terraria;
using Terraria.ModLoader;


namespace Laugicality.Items.Equipables
{
    public class CoreOfAnDio : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Sands of Time");
            Tooltip.SetDefault("You are immune to Time Stop");
        }

        public override void SetDefaults()
        {
            item.width = 48;
            item.height = 48;
            item.value = 100;
            item.rare = 5;
            item.accessory = true;
        }

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            LaugicalityPlayer modPlayer = player.GetModPlayer<LaugicalityPlayer>(mod);
            modPlayer.zImmune = true;
        }
        
        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(null, "DioritusCore", 1);
            recipe.AddIngredient(null, "AndesiaCore", 1);
            recipe.AddTile(16);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}