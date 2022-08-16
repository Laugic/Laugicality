using Laugicality.Items.Materials;
using Laugicality.Items.Placeable;
using Laugicality.Tiles;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;


namespace Laugicality.Items.Equipables
{
    public class DestructionCore : LaugicalityItem
    {
        public override void SetStaticDefaults()
        {
            Tooltip.SetDefault("+10% Destruction Damage\n+50 Lux");
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
            modPlayer.DestructionDamage += .1f;
            modPlayer.LuxMax += 50;
        }
        
        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.LargeTopaz, 1);
            recipe.AddIngredient(ItemID.LargeRuby, 1);
            recipe.AddIngredient(ModContent.ItemType<Arcanum>());
            recipe.AddTile(ModContent.TileType<AlchemicalInfuser>());
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}