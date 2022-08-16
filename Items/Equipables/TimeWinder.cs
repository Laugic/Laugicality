using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using WebmilioCommons.Time;

namespace Laugicality.Items.Equipables
{
    public class TimeWinder : LaugicalityItem
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
            item.rare = ItemRarityID.LightPurple;
            item.accessory = true;
        }

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            LaugicalityPlayer modPlayer = LaugicalityPlayer.Get(player);
            if(Laugicality.zaWarudo > 0 || TimeManagement.TimeAltered)
            {
                player.allDamage += 0.15f;
            }
        }
        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(null, "AndesiaCore", 1);
            recipe.AddIngredient(null, "SteamTank", 1);
            recipe.AddIngredient(3086, 32);
            recipe.AddTile(TileID.MythrilAnvil);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}