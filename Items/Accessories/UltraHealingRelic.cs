using Terraria;
using Terraria.ModLoader;

namespace Laugicality.Items.Accessories
{
    public class UltraHealingRelic : ModItem
    {
        public override void SetStaticDefaults()
        {
            Tooltip.SetDefault("+500 Max Life");
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
            player.statLifeMax2 += 500;
            player.AddBuff(21, 3600);
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(null, "HealingCrystal", 1);
            recipe.AddIngredient(null, "MegaHealingStone", 1);
            recipe.AddTile(null, "AncientEnchanter");
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}