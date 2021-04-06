using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Laugicality.Items.Equipables
{
    public class Bloat : LaugicalityItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Bloat");
            Tooltip.SetDefault("+100% Max Life. You cannot go above 50% of your Max Life.");
        }

        public override void SetDefaults()
        {
            item.width = 24;
            item.height = 24;
            item.value = Item.sellPrice(gold: 1);
            item.rare = ItemRarityID.Blue;
            item.accessory = true;
        }

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            player.statLifeMax2 *= 2;
            LaugicalityPlayer.Get(player).Bloat = true;
            if (player.statLife > (int)(player.statLifeMax2 * .5))
            {
                player.statLife = (int)(player.statLifeMax2 * .5);
                player.lifeRegen = 0;
            }
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.TissueSample, 12);
            recipe.AddIngredient(ItemID.ShadowScale, 8);
            recipe.AddTile(TileID.DemonAltar);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}