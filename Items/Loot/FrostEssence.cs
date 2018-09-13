using Terraria;
using Terraria.ModLoader;

namespace Laugicality.Items.Loot
{
    public class FrostEssence : ModItem
    {
        public override void SetStaticDefaults()
        {
            Tooltip.SetDefault("Unleashes Ice Shards when struck. +8% Melee and Ranged crit");
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
            modPlayer.frigid = true;
            player.meleeCrit += 8;
            player.rangedCrit += 8;
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