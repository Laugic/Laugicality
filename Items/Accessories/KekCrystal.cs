using Terraria;
using Terraria.ModLoader;

namespace Laugicality.Items.Accessories
{
    public class KekCrystal : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Mage Crystal");
            Tooltip.SetDefault("Increases knockback, magic damage, and mana regen");
        }

        public override void SetDefaults()
        {
            item.width = 16;
            item.height = 28;
            item.value = 100;
            item.rare = 3;
            item.accessory = true;
        }

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            player.manaRegenBonus += 25;
            player.magicDamage += 0.20f;
            player.kbBuff = true;

        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(null, "MagicPowerGem", 1);
            recipe.AddIngredient(null, "ManaRegenerationGem", 1);
            recipe.AddIngredient(null, "TitanGem", 1);
            recipe.AddTile(null, "CrystalineInfuser");
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}