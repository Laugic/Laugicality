using Terraria;
using Terraria.ModLoader;

namespace Laugicality.Items.Equipables
{
    public class BandOfAncients : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Band of Ancients");
            Tooltip.SetDefault("+40 Mana");
        }

        public override void SetDefaults()
        {
            item.width = 48;
            item.height = 48;
            item.value = 100;
            item.rare = 1;
            item.accessory = true;
            //item.defense = 1000;
            //item.lifeRegen = 19;
        }

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            player.statManaMax2 += 40;
        }
        
        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(111, 1);
            recipe.AddIngredient(null, "AncientShard", 1);
            recipe.AddTile(16);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}