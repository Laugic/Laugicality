using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Laugicality.Items.Armor
{
	[AutoloadEquip(EquipType.Body)]
	public class FrigidChestplate : LaugicalityItem
	{
		public override void SetStaticDefaults()
		{
			Tooltip.SetDefault("+10% Melee Speed and Range Crit Chance");
		}

		public override void SetDefaults()
		{
			item.width = 34;
			item.height = 22;
            item.value = Item.sellPrice(silver: 60);
            item.rare = ItemRarityID.Green;
			item.defense = 6;
        }

        public override void UpdateEquip(Player player)
        {
            player.meleeSpeed += .1f;
            player.rangedCrit += 10;
        }
        
        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(null, "ChilledBar", 16);
            recipe.AddIngredient(null, "FrostShard", 1);
            recipe.AddTile(16);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
	}
}