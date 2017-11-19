using Terraria;
using Terraria.ModLoader;

namespace Laugicality.Items.Loot
{
    public class StoneOfEtheria : ModItem
    {
        public override void SetStaticDefaults()
        {
            Tooltip.SetDefault("Greatly increased life regeneration while in the Etherial");
        }

        public override void SetDefaults()
        {
            item.width = 24;
            item.height = 24;
            item.value = 100;
            item.rare = 2;
            item.accessory = true;
            item.expert = true;
            //item.defense = 1000;
        }

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            var modPlayer = Main.LocalPlayer.GetModPlayer<LaugicalityPlayer>(mod);
            if (modPlayer.etherial || modPlayer.etherable)
            {
                item.lifeRegen = 12;
            }
            else
                item.lifeRegen = 0;
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