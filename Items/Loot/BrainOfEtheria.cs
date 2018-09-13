using Terraria;
using Terraria.ModLoader;

namespace Laugicality.Items.Loot
{
    public class BrainOfEtheria : ModItem
    {
        public override void SetStaticDefaults()
        {
            Tooltip.SetDefault("+1 to all Mystic powers while in the Etherial");
        }

        public override void SetDefaults()
        {
            item.width = 24;
            item.height = 24;
            item.value = 100;
            item.rare = 2;
            item.accessory = true;
            item.expert = true;
        }

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            var modPlayer = player.GetModPlayer<LaugicalityPlayer>(mod);
            if (modPlayer.etherial || modPlayer.etherable)
            {
                modPlayer.conjurationPower += 1;
                modPlayer.illusionPower += 1;
                modPlayer.destructionPower += 1;
            }
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