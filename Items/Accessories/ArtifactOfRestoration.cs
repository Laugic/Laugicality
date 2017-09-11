using Terraria;
using Terraria.ModLoader;

namespace Laugicality.Items.Accessories
{
    public class ArtifactOfRestoration : ModItem
    {
        public override void SetStaticDefaults()
        {
            Tooltip.SetDefault("+600 Max Life \n+160 Mana \nNo Potion Sickness");
        }

        public override void SetDefaults()
        {
            item.width = 16;
            item.height = 28;
            item.value = 100;
            item.rare = 8;
            item.accessory = true;
            //item.defense = 1000;
            //item.lifeRegen = 19;
        }

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            player.statLifeMax2 += 600;
            player.statManaMax2 += 160;
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(null, "UltraHealingRelic", 1);
            recipe.AddIngredient(null, "UltraManaRelic", 1);
            recipe.AddTile(412);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}