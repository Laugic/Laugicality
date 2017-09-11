using Terraria;
using Terraria.ModLoader;

namespace Laugicality.Items.Accessories
{
    public class MegaHealingStone : ModItem
    {
        public override void SetStaticDefaults()
        {
            Tooltip.SetDefault("+350 Max Life");
        }

        public override void SetDefaults()
        {
            item.width = 16;
            item.height = 28;
            item.value = 100;
            item.rare = 5;
            item.accessory = true;
            //item.defense = 1000;
            //item.lifeRegen = 19;
        }

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            player.statLifeMax2 += 350;
            player.AddBuff(21, 3600);
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(null, "GreaterHealingGem", 1);
            recipe.AddIngredient(null, "SuperHealingGem", 1);
            recipe.AddTile(null, "MineralEnchanter");
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}