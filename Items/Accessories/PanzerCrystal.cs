using Terraria;
using Terraria.ModLoader;

namespace Laugicality.Items.Accessories
{
    public class PanzerCrystal : ModItem
    {
        public override void SetStaticDefaults()
        {
            Tooltip.SetDefault("+10% Damage reduction \n Attackers take damage");
        }

        public override void SetDefaults()
        {
            item.width = 16;
            item.height = 28;
            item.value = 100;
            item.rare = 3;
            item.accessory = true;
            item.defense = 8;
            //item.lifeRegen = 19;
        }

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            player.endurance += 0.10f;
            if (player.thorns < 1f)
            {
                player.thorns = 0.5f;
            }

        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(null, "IronskinGem", 1);
            recipe.AddIngredient(null, "EnduranceGem", 1);
            recipe.AddIngredient(null, "ThornsGem", 1);
            recipe.AddTile(null, "CrystalineInfuser");
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}