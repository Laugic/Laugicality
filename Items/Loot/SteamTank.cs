using Terraria;
using Terraria.ModLoader;

namespace Laugicality.Items.Loot
{
    public class SteamTank : ModItem
    {
        public override void SetStaticDefaults()
        {
            //DisplayName.SetDefault("Cog of Knowledge");
            Tooltip.SetDefault("Steam powered!\nIncreases Mystic damage by 12% \nIncreases movement speed by 25% and jump height by 2\nReduces the cooldown between Mystic Bursts.");
        }

        public override void SetDefaults()
        {
            item.width = 38;
            item.height = 48;
            item.value = 100;
            item.rare = 2;
            item.accessory = true;
            item.expert = true;
        }

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            var modPlayer = player.GetModPlayer<LaugicalityPlayer>(mod);
            player.jumpSpeedBoost += 2f;
            player.moveSpeed += 0.5f;
            modPlayer.mysticDamage += 0.12f;
            modPlayer.mysticSwitchCoolRate += 1;
        }
        /*
        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(2328, 4);
            recipe.AddTile(null, "AlchemicalInfuser");
            recipe.SetResult(this);
            recipe.AddRecipe();
        }*/
    }
}