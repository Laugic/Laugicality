using Terraria;
using Terraria.ID;
using Terraria.ModLoader;


namespace Laugicality.Items.Equipables
{
    public class ConjurationCore : ModItem
    {
        public override void SetStaticDefaults()
        {
            Tooltip.SetDefault("+10% Conjuration Damage\n+25% Conjuration Overflow\nAbsorb 25% more Mundus when using Vis and Lux");
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
            modPlayer.conjurationDamage += .1f;
            modPlayer.mundusOverflow += .25f;
            modPlayer.mundusAbsorbRate += .25f;
        }
        
        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(null, "DarkShard", 1);
            recipe.AddIngredient(null, "AncientShard", 1);
            recipe.AddIngredient(null, "VerdiDust", 2);
            recipe.AddIngredient(null, "AlbusDust", 2);
            recipe.AddTile(null, "AlchemicalInfuser");
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}