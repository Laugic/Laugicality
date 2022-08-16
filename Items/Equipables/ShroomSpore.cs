using Terraria;
using Terraria.ID;
using Terraria.ModLoader;


namespace Laugicality.Items.Equipables
{
    public class ShroomSpore : LaugicalityItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Spore Cloud");
            Tooltip.SetDefault("Overflow attacks shoot spores on hit");
        }

        public override void SetDefaults()
        {
            item.width = 48;
            item.height = 48;
            item.value = Item.sellPrice(silver: 10);
            item.rare = ItemRarityID.Blue;
            item.accessory = true;
        }

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            LaugicalityPlayer modPlayer = LaugicalityPlayer.Get(player);
            modPlayer.MysticShroomBurst = true;
        }
        
        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(183, 16);
            recipe.AddTile(16);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}