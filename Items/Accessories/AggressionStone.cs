using Terraria;
using Terraria.ModLoader;

namespace Laugicality.Items.Accessories
{
    public class AggressionStone : ModItem
    {
        public override void SetStaticDefaults()
        {
            Tooltip.SetDefault("+10% Ranged damage \n20% Chance to not use ammo \nIncreases knockback, magic damage, and mana regen \nIncreased Enemy Spawns");
        }

        public override void SetDefaults()
        {
            item.width = 32;
            item.height = 32;
            item.value = 1000;
            item.rare = 4;
            item.accessory = true;
            //item.defense = 1000;
            //item.lifeRegen = 19;
        }

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            player.manaRegenBonus += 25;
            player.magicDamage += 0.20f;
            player.AddBuff(108, 2);
            player.ammoCost80 = true;
            player.rangedDamage += 0.10f;
            player.enemySpawns = true;
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(null, "ReichCrystal", 1);
            recipe.AddIngredient(null, "KekCrystal", 1);
            recipe.AddTile(null, "MineralEnchanter");
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}