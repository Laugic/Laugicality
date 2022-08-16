using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Laugicality.Items.Equipables
{
    public class FlareburstWaders : LaugicalityItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Flamespark Waders");
            Tooltip.SetDefault("Provides the ability to walk on water and lava\nGrants immunity to fire blocks and 10 seconds of immunity to lava\nLeave a trail of True Fire as you move");
        }

        public override void SetDefaults()
        {
            item.width = 28;
            item.height = 28;
            item.value = Item.sellPrice(gold: 10);
            item.rare = ItemRarityID.Lime;
            item.accessory = true;
        }

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            player.waterWalk = true;
            player.fireWalk = true;
            player.lavaMax += 10 * 60;
            if (!hideVisual)
                player.GetModPlayer<LaugicalityPlayer>().TrueFireTrail = true;
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.LavaWaders, 1);
            recipe.AddIngredient(ModContent.ItemType<CrystalizedMagma>(), 1);
            recipe.AddIngredient(ModContent.ItemType<FireDust>(), 1);
            recipe.AddTile(TileID.TinkerersWorkbench);
            recipe.SetResult(this);
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.LavaWaders, 1);
            recipe.AddIngredient(ModContent.ItemType<CrystalizedMagma>(), 1);
            recipe.AddIngredient(ItemID.MagmaStone, 1);
            recipe.AddTile(TileID.TinkerersWorkbench);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}