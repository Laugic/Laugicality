using Terraria;
using Terraria.ModLoader;

namespace Laugicality.Items.Equipables
{
    public class SupremeMysticEmblem : ModItem
    {
        public override void SetStaticDefaults()
        {
            Tooltip.SetDefault("+20% mystic damage");
        }

        public override void SetDefaults()
        {
            item.width = 24;
            item.height = 24;
            item.value = 100;
            item.rare = 4;
            item.accessory = true;
            //item.defense = 1000;
            //item.lifeRegen = 19;
        }

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            LaugicalityPlayer modPlayer = player.GetModPlayer<LaugicalityPlayer>(mod);
            modPlayer.mysticDamage += .2f;
        }
        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(null, "MysticEmblem", 1);
            recipe.AddIngredient(null, "SoulOfThought", 5);
            recipe.AddIngredient(null, "SoulOfFraught", 5);
            recipe.AddIngredient(null, "SoulOfWrought", 5);
            recipe.AddTile(null, "AncientEnchanter");
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}