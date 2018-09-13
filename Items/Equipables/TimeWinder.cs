using Terraria;
using Terraria.ModLoader;

namespace Laugicality.Items.Equipables
{
    public class TimeWinder : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Time Winder");
            Tooltip.SetDefault("Greatly increased mobility while time is stopped");
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
            if((NPC.CountNPCS(mod.NPCType("ZaWarudo")) >= 1))
            {
                player.moveSpeed += 3f;
                player.maxRunSpeed += 3f;
                player.jumpSpeedBoost += 3f;
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