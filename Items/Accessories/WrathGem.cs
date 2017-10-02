using Terraria;
using Terraria.ModLoader;

namespace Laugicality.Items.Accessories
{
    public class WrathGem : ModItem
    {
        public override void SetStaticDefaults()
        {
            Tooltip.SetDefault("+10% damage");
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
            player.magicDamage += 0.10f;
            player.meleeDamage += 0.10f;
            player.rangedDamage += 0.10f;
            player.thrownDamage += 0.10f;
            player.minionDamage += 0.10f;
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(2349, 4);
            recipe.AddTile(null, "AlchemicalInfuser");
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}