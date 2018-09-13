using Terraria;
using Terraria.ID;
using Terraria.ModLoader;


namespace Laugicality.Items.Equipables
{
    public class RuneOfEruption : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Rune of Eruption");
            Tooltip.SetDefault("Release a storm of lava when changing Mysticism.");
        }

        public override void SetDefaults()
        {
            item.width = 22;
            item.height = 36;
            item.value = 10000;
            item.rare = 3;
            item.accessory = true;
        }

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            LaugicalityPlayer modPlayer = player.GetModPlayer<LaugicalityPlayer>(mod);
            modPlayer.mysticEruptionBurst = true;
        }
        
        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(null, "RuneOfTheAncients", 1);
            recipe.AddIngredient(null, "Eruption", 1);
            recipe.AddIngredient(null, "SoulOfHaught", 8);
            recipe.AddTile(134);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}