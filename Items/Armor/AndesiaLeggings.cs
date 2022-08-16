using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Laugicality.Items.Armor
{
	[AutoloadEquip(EquipType.Legs)]
	public class AndesiaLeggings : LaugicalityItem
	{
		public override void SetStaticDefaults()
		{
			Tooltip.SetDefault("+100% Mystic Duration\nIncreased Max Minions\n+15% movement speed");
		}

		public override void SetDefaults()
		{
			item.width = 34;
			item.height = 22;
            item.value = Item.sellPrice(gold: 4);
            item.rare = ItemRarityID.Pink;
            item.defense = 12;
		}

        public override void UpdateEquip(Player player)
        {
            LaugicalityPlayer modPlayer = LaugicalityPlayer.Get(player);
            modPlayer.MysticDuration += 1f;
            player.moveSpeed += 0.15f;
            player.maxMinions += 3;
        }
        

		public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(null, "AndesiaCore", 1);
            recipe.AddIngredient(3086, 32);
            recipe.AddRecipeGroup("TitaniumBars", 20);
            recipe.AddTile(TileID.MythrilAnvil);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
	}
}