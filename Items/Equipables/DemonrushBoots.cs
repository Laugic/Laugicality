using Laugicality.Dusts;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Laugicality.Items.Equipables
{
    public class DemonrushBoots : BootItem
    {
        public override void SetStaticDefaults()
        {
            LaugicalityVars.DashBoots.Add(item.type);
            DisplayName.SetDefault("Devilrush Boots");
            Tooltip.SetDefault("Allows the wearer to dash in any direction\nIncreased jump height");
        }

        public override void SetDefaults()
        {
            item.width = 28;
            item.height = 28;
            item.value = Item.sellPrice(gold: 3);
            item.rare = ItemRarityID.Orange;
            item.accessory = true;
        }

        public override void SetBootVars()
        {
            DashCooldownMax = 45;
            VDashCooldownMax = 45;
            DashSpeed = 12;
            MaxVDashes = 1;
            JumpSpeed = 12;
            JumpDur = 20;

            DustType = ModContent.DustType<Black>();
            TrailLength = 45;
        }

        public override void OtherBonuses(Player player, bool hideVisual)
        {
            player.jumpSpeedBoost += 3;
        }


        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<DarkfootBoots>(), 1);
            recipe.AddIngredient(ModContent.ItemType<Eruption>(), 1);
            recipe.AddTile(TileID.TinkerersWorkbench);
            recipe.SetResult(this);
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<BloodfootBoots>(), 1);
            recipe.AddIngredient(ModContent.ItemType<Eruption>(), 1);
            recipe.AddTile(TileID.TinkerersWorkbench);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}