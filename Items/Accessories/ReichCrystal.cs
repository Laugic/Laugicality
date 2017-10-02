using Terraria;
using Terraria.ModLoader;

namespace Laugicality.Items.Accessories
{
    public class ReichCrystal : ModItem
    {
        public override void SetStaticDefaults()
        {
            Tooltip.SetDefault("+10% Ranged damage \n20% Chance to not use ammo \nIncreased Enemy Spawns");
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
            player.ammoCost80 = true;
            player.rangedDamage += 0.10f;
            player.enemySpawns = true;
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(null, "ArcheryGem", 1);
            recipe.AddIngredient(null, "AmmoReservationGem", 1);
            recipe.AddIngredient(null, "BattleGem", 1);
            recipe.AddTile(null, "CrystalineInfuser");
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}