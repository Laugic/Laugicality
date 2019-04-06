using Terraria;
using Terraria.ModLoader;

namespace Laugicality.Items.Accessories
{
    public class AlterationStone : ModItem
    {
        public override void SetStaticDefaults()
        {
            Tooltip.SetDefault("Mastery of land and air");
        }

        public override void SetDefaults()
        {
            item.width = 32;
            item.height = 32;
            item.value = 1000;
            item.rare = 4;
            item.accessory = true;
        }

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            player.tileSpeed += 0.25f;
            player.wallSpeed += 0.25f;
            player.blockRange++;
            player.pickSpeed -= 0.25f;
            var modPlayer = player.GetModPlayer<LaugicalityPlayer>(mod);
            if (modPlayer.soulStoneM)
            {
                if (modPlayer.feather)
                    player.slowFall = true;
            }
            player.moveSpeed += 0.25f;
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(null, "DeinstCrystal", 1);
            recipe.AddIngredient(null, "BewungCrystal", 1);
            recipe.AddTile(null, "MineralEnchanter");
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}