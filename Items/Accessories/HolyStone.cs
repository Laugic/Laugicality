using Terraria;
using Terraria.ModLoader;

namespace Laugicality.Items.Accessories
{
    public class HolyStone : ModItem
    {
        public override void SetStaticDefaults()
        {
            Tooltip.SetDefault("Decreased enemy spawn rate \nTake less damage from cold sources \nIncreases heart pickup range \nIncreases life regeneration \n+1 Max Minion \nIncreases max life by 20% \nEquip in last slot for maximum effectiveness");
        }

        public override void SetDefaults()
        {
            item.width = 32;
            item.height = 32;
            item.value = 1000;
            item.rare = 4;
            item.accessory = true;
            //item.defense = 1000;
            item.lifeRegen = 2;
        }

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            player.maxMinions++;
            player.calmed = true;
            player.resistCold = true;
            player.lifeMagnet = true;
            player.statLifeMax2 += (player.statLifeMax + player.statLifeMax2) / 5 / 20 * 20 - (player.statLifeMax / 5 / 20 * 20);
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(null, "LebenCrystal", 1);
            recipe.AddIngredient(null, "VerteCrystal", 1);
            recipe.AddTile(null, "MineralEnchanter");
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}