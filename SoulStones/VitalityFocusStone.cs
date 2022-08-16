using Laugicality.Focuses;
using Laugicality.Items;
using Laugicality.Items.Equipables;
using Laugicality.Items.Materials;
using Laugicality.Tiles;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Laugicality.SoulStones
{
    public class VitalityFocusStone : LaugicalityItem
    {
        public override void SetStaticDefaults()
        {
            Tooltip.SetDefault("Infuses your Soul with Vitality");
        }

        public override void SetDefaults()
        {
            item.width = 28;
            item.height = 28;
            item.maxStack = 1;
            item.rare = ItemRarityID.Orange;
            item.useAnimation = 45;
            item.useTime = 45;
            item.useStyle = ItemUseStyleID.HoldingUp;
            item.UseSound = SoundID.Item9;
            item.consumable = false;
            item.value = Item.sellPrice(gold: 1);
        }

        public override bool UseItem(Player player)
        {
            player.GetModPlayer<LaugicalityPlayer>().Focus = FocusManager.Instance.Vitality;
            return base.UseItem(player);
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.LargeTopaz);
            recipe.AddIngredient(ModContent.ItemType<Arcanum>());
            recipe.AddTile(ModContent.TileType<AlchemicalInfuser>());
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}