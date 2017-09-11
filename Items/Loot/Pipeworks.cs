using Terraria;
using Terraria.ModLoader;

namespace Laugicality.Items.Loot
{
    public class Pipeworks : ModItem
    {
        public override void SetStaticDefaults()
        {
            Tooltip.SetDefault("+15% Throwing damage \n+25% Throwing Velocity");
        }

        public override void SetDefaults()
        {
            item.width = 32;
            item.height = 32;
            item.value = 100;
            item.rare = 2;
            item.accessory = true;
            item.expert = true;
            //item.defense = 1000;
            //item.lifeRegen = 19;
        }

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            player.thrownDamage += .15f;
            player.thrownVelocity += .25f;
        }
        /*
        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(2328, 4);
            recipe.AddTile(null, "AlchemicalInfuser");
            recipe.SetResult(this);
            recipe.AddRecipe();
        }*/
    }
}