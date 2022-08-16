using Terraria;
using Terraria.ID;
using Terraria.ModLoader;


namespace Laugicality.Items.Equipables
{
    public class GaiasGem : LaugicalityItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Gaia's Gem");
            Tooltip.SetDefault("+50% Mystic Duration");
        }

        public override void SetDefaults()
        {
            item.width = 32;
            item.height = 32;
            item.value = Item.sellPrice(gold:3);
            item.rare = ItemRarityID.Green;
            item.accessory = true;
        }

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            LaugicalityPlayer modPlayer = LaugicalityPlayer.Get(player);
            modPlayer.MysticDuration += .5f;
        }
        
        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.LargeAmethyst);
            recipe.AddIngredient(ItemID.LargeTopaz);
            recipe.AddIngredient(ItemID.LargeSapphire);
            recipe.AddIngredient(ItemID.LargeEmerald);
            recipe.AddIngredient(ItemID.LargeRuby);
            recipe.AddIngredient(ItemID.LargeDiamond);
            recipe.AddIngredient(ModContent.ItemType<Arcanum>());
            recipe.AddTile(null, "AlchemicalInfuser");
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}