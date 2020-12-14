using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Laugicality.Items.Armor
{
	[AutoloadEquip(EquipType.Legs)]
	public class ShroomPants : LaugicalityItem
	{
		public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Shroom Stalk");
            Tooltip.SetDefault("+10% Movement Speed");
		}

		public override void SetDefaults()
		{
			item.width = 34;
			item.height = 22;
			item.value = 10000;
			item.rare = ItemRarityID.Blue;
			item.defense = 2;
		}

        public override void UpdateEquip(Player player)
        {
            LaugicalityPlayer modPlayer = LaugicalityPlayer.Get(player);
            player.moveSpeed += 0.1f;
        }
        

		public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(183, 10);
            recipe.AddIngredient(176, 8);
            recipe.AddTile(16);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
	}
}