using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Laugicality.Items.Equipables
{
    public class Arcanum : LaugicalityItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Arcanum");
            Tooltip.SetDefault("+40 mana\n+15% Overflow");
        }

        public override void SetDefaults()
        {
            item.width = 24;
            item.height = 24;
            item.value = Item.sellPrice(silver: 50);
            item.rare = ItemRarityID.Blue;
            item.accessory = true;
        }

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            player.statManaMax2 += 40;
            LaugicalityPlayer modPlayer = LaugicalityPlayer.Get(player);
            modPlayer.GlobalOverflow += .15f;
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(null, "ArcaneShard", 15);
            recipe.AddTile(null, "AlchemicalInfuser");
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}