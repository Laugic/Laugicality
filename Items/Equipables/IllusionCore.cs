using Terraria;
using Terraria.ModLoader;


namespace Laugicality.Items.Equipables
{
    public class IllusionCore : ModItem
    {
        public override void SetStaticDefaults()
        {
            Tooltip.SetDefault("+10% Illusion Damage\n+25% Illusion Overflow\nAbsorb 25% more Vis when using Mundus and Lux");
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
            modPlayer.illusionDamage += .1f;
            modPlayer.visOverflow += .25f;
            modPlayer.visAbsorbRate += .25f;
        }
        
        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(null, "DarkShard", 1);
            recipe.AddIngredient(null, "FrostShard", 1);
            recipe.AddIngredient(null, "RegisDust", 2);
            recipe.AddIngredient(null, "AlbusDust", 2);
            recipe.AddTile(null, "AlchemicalInfuser");
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}