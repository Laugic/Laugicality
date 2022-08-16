using Laugicality.Items.Materials;
using Laugicality.Tiles;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;


namespace Laugicality.Items.Equipables
{
    public class IllusionCore : LaugicalityItem
    {
        public override void SetStaticDefaults()
        {
            Tooltip.SetDefault("+10% Illusion Damage\n+50 Vis");
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
            LaugicalityPlayer modPlayer = LaugicalityPlayer.Get(player);
            modPlayer.IllusionDamage += .1f;
            modPlayer.VisMax += 50;
        }
        
        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.LargeAmethyst, 1);
            recipe.AddIngredient(ItemID.LargeDiamond, 1);
            recipe.AddIngredient(ModContent.ItemType<Arcanum>());
            recipe.AddTile(ModContent.TileType<AlchemicalInfuser>());
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}