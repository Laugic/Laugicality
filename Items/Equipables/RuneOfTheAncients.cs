using Terraria;
using Terraria.ModLoader;


namespace Laugicality.Items.Equipables
{
    public class RuneOfTheAncients : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Rune of the Ancients");
            Tooltip.SetDefault("Release a sandstorm when changing Mysticism.");
        }

        public override void SetDefaults()
        {
            item.width = 22;
            item.height = 36;
            item.value = 10000;
            item.rare = 1;
            item.accessory = true;
        }

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            LaugicalityPlayer modPlayer = player.GetModPlayer<LaugicalityPlayer>(mod);
            modPlayer.mysticSandBurst = true;
        }
        
        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(169, 24);
            recipe.AddIngredient(607, 16);
            recipe.AddIngredient(null, "AncientShard", 1);
            recipe.AddTile(16);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}