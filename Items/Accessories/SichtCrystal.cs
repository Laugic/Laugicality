using Terraria;
using Terraria.ModLoader;

namespace Laugicality.Items.Accessories
{
    public class SichtCrystal : ModItem
    {
        public override void SetStaticDefaults()
        {
            Tooltip.SetDefault("'I see all.'");
        }

        public override void SetDefaults()
        {
            item.width = 16;
            item.height = 28;
            item.value = 100;
            item.rare = 3;
            item.accessory = true;
            //item.defense = 8;
            //item.lifeRegen = 19;
        }

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            player.findTreasure = true;
            player.detectCreature = true;
            player.dangerSense = true;

        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(null, "HunterGem", 1);
            recipe.AddIngredient(null, "DangersenseGem", 1);
            recipe.AddIngredient(null, "SpelunkerGem", 1);
            recipe.AddTile(null, "CrystalineInfuser");
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}