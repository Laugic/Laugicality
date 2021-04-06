using Laugicality.Dusts;
using Laugicality.Items.Loot;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Laugicality.Items.Equipables
{
    public class WarpburstBoots : BootItem
    {
        public override void SetStaticDefaults()
        {
            LaugicalityVars.DashBoots.Add(item.type);
            DisplayName.SetDefault("Warpburst Boots");
            Tooltip.SetDefault("Allows the wearer to dash\nIncreased jump height and movement speed\nCan dash multiple times in the air\nBecome immune for a time while dashing");
        }

        public override void SetDefaults()
        {
            item.width = 28;
            item.height = 28;
            item.value = Item.sellPrice(gold: 8);
            item.rare = ItemRarityID.Pink;
            item.accessory = true;
        }

        public override void SetBootVars()
        {
            DashCooldownMax = 45;
            VDashCooldownMax = 45;
            DashSpeed = 14;
            MaxVDashes = 3;
            JumpSpeed = 12;
            JumpDur = 20;
            ImmuneTime = 15;

            DustType = ModContent.DustType<White>();
            TrailLength = 45;
        }

        public override void OtherBonuses(Player player, bool hideVisual)
        {
            player.moveSpeed += .25f;
            player.jumpSpeedBoost += 3;
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<DemonsparkBoots>(), 1);
            recipe.AddIngredient(ModContent.ItemType<DioritusCore>());
            recipe.AddIngredient(ModContent.ItemType<AndesiaCore>());
            recipe.AddTile(TileID.TinkerersWorkbench);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}