using Terraria;
using Terraria.ModLoader;


namespace Laugicality.Items.Equipables
{
    public class DestructionCore : ModItem
    {
        public override void SetStaticDefaults()
        {
            Tooltip.SetDefault("+10% Destruction Damage\n+25% Destruction Overflow\nAbsorb 25% more Lux when using Vis and Mundus");
        }

        public override void SetDefaults()
        {
            item.width = 32;
            item.height = 32;
            item.value = 100;
            item.rare = 2;
            item.accessory = true;
        }

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            LaugicalityPlayer modPlayer = player.GetModPlayer<LaugicalityPlayer>(mod);
            modPlayer.DestructionDamage += .1f;
            modPlayer.LuxOverflow += .25f;
            modPlayer.LuxAbsorbRate += .25f;
        }
        
        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(null, "DarkShard", 1);
            recipe.AddIngredient(null, "DarkShard", 1);
            recipe.AddIngredient(null, "AuraDust", 2);
            recipe.AddIngredient(null, "AlbusDust", 2);
            recipe.AddTile(null, "AlchemicalInfuser");
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}