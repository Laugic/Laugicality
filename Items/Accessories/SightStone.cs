using Terraria;
using Terraria.ModLoader;

namespace Laugicality.Items.Accessories
{
    public class SightStone : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Vision Stone");
            Tooltip.SetDefault("Mastery of light");
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
            var modPlayer = player.GetModPlayer<LaugicalityPlayer>(mod);
            if (modPlayer.spelunker)
                player.findTreasure = true;
            Lighting.AddLight((int)(player.position.X + (float)(player.width / 2)) / 16, (int)(player.position.Y + (float)(player.height / 2)) / 16, 0.8f, 0.95f, 1f);
            if (modPlayer.owl)
                player.nightVision = true;
            if (modPlayer.hunter)
                player.detectCreature = true;
            if (modPlayer.danger)
                player.dangerSense = true;

        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(null, "LichtCrystal", 1);
            recipe.AddIngredient(null, "SichtCrystal", 1);
            recipe.AddTile(null, "MineralEnchanter");
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}