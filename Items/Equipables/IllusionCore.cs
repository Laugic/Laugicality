using Terraria;
using Terraria.ID;
using Terraria.ModLoader;


namespace Laugicality.Items.Equipables
{
    public class IllusionCore : LaugicalityItem
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
            item.rare = ItemRarityID.Green;
            item.accessory = true;
        }

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            LaugicalityPlayer modPlayer = player.GetModPlayer<LaugicalityPlayer>(mod);
            modPlayer.IllusionDamage += .1f;
            modPlayer.VisOverflow += .25f;
            modPlayer.VisAbsorbRate += .25f;
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