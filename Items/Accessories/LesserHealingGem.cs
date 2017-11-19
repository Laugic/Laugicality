using Terraria;
using Terraria.ModLoader;

namespace Laugicality.Items.Accessories
{
    public class LesserHealingGem : ModItem
    {
        public override void SetStaticDefaults()
        {
            Tooltip.SetDefault("+50 Max Life \nGives 1 minute of Potion Sickness");
        }

        public override void SetDefaults()
        {
            item.width = 16;
            item.height = 28;
            item.value = 100;
            item.rare = 2;
            item.accessory = true;
            //item.defense = 1000;
            //item.lifeRegen = 19;
        }

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            player.statLifeMax2 += 50;
            player.AddBuff(21, 3600);
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(28, 4);
            recipe.AddTile(null, "AlchemicalInfuser");
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}