using Terraria;
using Terraria.ModLoader;

namespace Laugicality.Items.Equipables
{
    public class MoltenTank : ModItem
    {
        public override void SetStaticDefaults()
        {
            Tooltip.SetDefault("+10% Throwing Damage and Velocity");
        }

        public override void SetDefaults()
        {
            item.width = 24;
            item.height = 24;
            item.value = 100;
            item.rare = 1;
            item.accessory = true;
            //item.defense = 1000;
            item.lifeRegen = 1;
        }

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            player.thrownDamage += .1f;
            player.thrownVelocity += .1f;
        }
        
        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(3, 25);
            recipe.AddIngredient(207, 2);
            recipe.AddIngredient(null, "DarkShard", 1);
            recipe.AddTile(16);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}