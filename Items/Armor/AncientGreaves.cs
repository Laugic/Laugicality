using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Laugicality.Items.Armor
{
    [AutoloadEquip(EquipType.Legs)]
    public class AncientGreaves : LaugicalityItem
    {
        public override void SetStaticDefaults()
        {
            Tooltip.SetDefault("Increased jump height\n+15% Movement Speed and Max Run Speed");
        }

        public override void SetDefaults()
        {
            item.width = 34;
            item.height = 22;
            item.value = 10000;
            item.rare = ItemRarityID.Orange;
            item.defense = 4;
        }

        public override void UpdateEquip(Player player)
        {
            player.moveSpeed += 0.15f;
            player.maxRunSpeed += .15f;
            player.jumpSpeedBoost += 4;
        }
        
        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(null, "Crystilla", 4);
            recipe.AddIngredient(ItemID.DesertFossil, 8);
            recipe.AddTile(16);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}