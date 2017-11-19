using Terraria;
using Terraria.ID;
using Terraria.ModLoader;


namespace Laugicality.Items.Equipables
{
    public class CoreOfMysticism : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Core of Mysticism");
            Tooltip.SetDefault("+1 to all Mysticism Powers");
        }

        public override void SetDefaults()
        {
            item.width = 48;
            item.height = 48;
            item.value = 100;
            item.rare = 5;
            item.accessory = true;
            //item.defense = 1000;
            item.lifeRegen = 1;
        }

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            LaugicalityPlayer modPlayer = player.GetModPlayer<LaugicalityPlayer>(mod);
            modPlayer.destructionPower += 1;
            modPlayer.illusionPower += 1;
            modPlayer.conjurationPower += 1;
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