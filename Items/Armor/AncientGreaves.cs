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
            Tooltip.SetDefault("Innate Sandstorm in a Bottle\n+15% Movement Speed");
        }

        public override void SetDefaults()
        {
            item.width = 34;
            item.height = 22;
            item.value = Item.sellPrice(silver: 50);
            item.rare = ItemRarityID.Blue;
            item.defense = 4;
        }

        public override void UpdateEquip(Player player)
        {
            player.doubleJumpSandstorm = true;
            player.moveSpeed += 0.15f;
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