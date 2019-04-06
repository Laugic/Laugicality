using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Laugicality.Items.Equipables
{
    public class TheBloodOfOld : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("The Blood of Old");
            Tooltip.SetDefault("+8% Mystic Damage.\nAn Additional +8% Mystic Damage when below 50% Life");
        }

        public override void SetDefaults()
        {
            item.width = 24;
            item.height = 24;
            item.value = 100;
            item.rare = 1;
            item.accessory = true;
        }

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            LaugicalityPlayer modPlayer = player.GetModPlayer<LaugicalityPlayer>(mod);
            modPlayer.MysticDamage += .08f;
            if(player.statLife <= player.statLifeMax2 / 2)
                modPlayer.MysticDamage += .08f;
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.CrimtaneBar, 8);
            recipe.AddTile(null, "AlchemicalInfuser");
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}