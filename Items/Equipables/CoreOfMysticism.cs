using Laugicality.Items.Loot;
using Laugicality.Tiles;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;


namespace Laugicality.Items.Equipables
{
    public class CoreOfMysticism : LaugicalityItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Core of Mysticism");
            Tooltip.SetDefault("+15% Mystic Damage\n+50 Potentia");
        }

        public override void SetDefaults()
        {
            item.width = 48;
            item.height = 48;
            item.value = 100;
            item.rare = ItemRarityID.Pink;
            item.accessory = true;
        }

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            LaugicalityPlayer modPlayer = LaugicalityPlayer.Get(player);
            modPlayer.MysticDamage += .15f;
            modPlayer.MundusMax += 50;
            modPlayer.LuxMax += 50;
            modPlayer.VisMax += 50;
        }
        
        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(null, "DestructionCore", 1);
            recipe.AddIngredient(null, "IllusionCore", 1);
            recipe.AddIngredient(null, "ConjurationCore", 1);
            recipe.AddIngredient(mod, nameof(SoulOfWrought), 8);
            recipe.AddTile(null, nameof(MineralEnchanterTile));
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}