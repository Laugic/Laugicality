using Terraria;
using Terraria.ModLoader;


namespace Laugicality.Items.Equipables
{
    public class CoreOfMysticism : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Core of Mysticism");
            Tooltip.SetDefault("+15% Mystic Damage\n25% more Mystica is transfered when used");
        }

        public override void SetDefaults()
        {
            item.width = 48;
            item.height = 48;
            item.value = 100;
            item.rare = 5;
            item.accessory = true;
        }

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            LaugicalityPlayer modPlayer = player.GetModPlayer<LaugicalityPlayer>(mod);
            modPlayer.globalAbsorbRate += .25f;
            modPlayer.mysticDamage += .15f;
        }
        
        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(null, "DestructionCore", 1);
            recipe.AddIngredient(null, "IllusionCore", 1);
            recipe.AddIngredient(null, "ConjurationCore", 1);
            recipe.AddIngredient(null, "SoulOfWrought", 8);
            recipe.AddTile(null, "MineralEnchanter");
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}