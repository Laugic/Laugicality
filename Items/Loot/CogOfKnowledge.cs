using Terraria;
using Terraria.ModLoader;

namespace Laugicality.Items.Loot
{
    public class CogOfKnowledge : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Cog of Knowledge");
            Tooltip.SetDefault("Increases your max number of minions by 2");
        }

        public override void SetDefaults()
        {
            item.width = 32;
            item.height = 32;
            item.value = 100;
            item.rare = 2;
            item.accessory = true;
            item.expert = true;
        }

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            player.maxMinions += 2;
        }
        /*
        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(2328, 4);
            recipe.AddTile(null, "AlchemicalInfuser");
            recipe.SetResult(this);
            recipe.AddRecipe();
        }*/
    }
}