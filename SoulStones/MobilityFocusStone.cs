using Laugicality.Focuses;
using Laugicality.Items;
using Laugicality.Items.Materials;
using Laugicality.Tiles;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Laugicality.SoulStones
{
    public class MobilityFocusStone : LaugicalityItem
    {
        public override void SetStaticDefaults()
        {
            Tooltip.SetDefault("Infuses your Soul with Mobility");
        }

        public override void SetDefaults()
        {
            item.width = 28;
            item.height = 28;
            item.maxStack = 20;
            item.rare = ItemRarityID.Orange;
            item.useAnimation = 45;
            item.useTime = 45;
            item.useStyle = ItemUseStyleID.HoldingUp;
            item.UseSound = SoundID.Item9;
            item.consumable = true;
        }

        public override bool CanRightClick()
        {
            return true;
        }

        public override void RightClick(Player player)
        {
            player.GetModPlayer<LaugicalityPlayer>().Focus = FocusManager.Instance.Mobility;
            player.GetModPlayer<LaugicalityPlayer>().FocusName = player.GetModPlayer<LaugicalityPlayer>().FOCUS_NAME_MOBILITY;
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.Emerald);
            recipe.AddIngredient(mod.ItemType<ArcaneShard>(), 3);
            recipe.AddTile(mod.TileType<AlchemicalInfuser>());
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}