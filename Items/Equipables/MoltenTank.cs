using Terraria;
using Terraria.ModLoader;

namespace Laugicality.Items.Equipables
{
    public class MoltenTank : ModItem
    {
        public override void SetStaticDefaults()
        {
            Tooltip.SetDefault("+33% Mystic Duration\n+10% Overflow Damage");
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
            modPlayer.MysticDuration += .25f;
            modPlayer.OverflowDamage += .1f;
        }
        
        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(null, "DarkShard", 1);
            recipe.AddIngredient(null, "ObsidiumBar", 10);
            recipe.AddTile(16);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}