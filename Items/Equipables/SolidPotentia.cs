using Terraria;
using Terraria.ID;
using Terraria.ModLoader;


namespace Laugicality.Items.Equipables
{
    public class SolidPotentia : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Solid Potentia");
            Tooltip.SetDefault("+12% Non-Overflow Mystic Damage");
        }

        public override void SetDefaults()
        {
            item.width = 32;
            item.height = 32;
            item.value = 1000;
            item.rare = 1;
            item.accessory = true;
        }

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            LaugicalityPlayer modPlayer = player.GetModPlayer<LaugicalityPlayer>(mod);
            modPlayer.antiflowDamage += .12f;
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(null, "ArcaneShard", 6);
            recipe.AddIngredient(null, "LavaGem", 6);
            recipe.AddIngredient(null, "Crystilla", 6);
            recipe.AddTile(null, "AlchemicalInfuser");
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}