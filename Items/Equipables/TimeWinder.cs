using Terraria;
using Terraria.ModLoader;

namespace Laugicality.Items.Equipables
{
    public class TimeWinder : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Time Winder");
            Tooltip.SetDefault("+15% Increased Damage while time is stopped");
        }

        public override void SetDefaults()
        {
            item.width = 32;
            item.height = 32;
            item.value = 100;
            item.rare = 6;
            item.accessory = true;
        }

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            LaugicalityPlayer modPlayer = player.GetModPlayer<LaugicalityPlayer>(mod);
            if(Laugicality.zaWarudo > 0)
            {
                player.magicDamage += 0.15f;
                player.meleeDamage += 0.15f;
                player.rangedDamage += 0.15f;
                player.thrownDamage += 0.15f;
                player.minionDamage += 0.15f;
            }
        }
        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(null, "AndesiaCore", 1);
            recipe.AddIngredient(null, "SteamTank", 1);
            recipe.AddIngredient(3086, 32);
            recipe.AddTile(134);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}