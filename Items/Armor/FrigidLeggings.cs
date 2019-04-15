using Terraria;
using Terraria.ModLoader;

namespace Laugicality.Items.Armor
{
	[AutoloadEquip(EquipType.Legs)]
	public class FrigidLeggings : ModItem
	{
		public override void SetStaticDefaults()
		{
			Tooltip.SetDefault("Immunity to Frostburn, Chilled, and Frozen\n+10% Movement Speed");
		}

		public override void SetDefaults()
		{
			item.width = 34;
			item.height = 22;
			item.value = 10000;
			item.rare = 2;
			item.defense = 6;
		}

        public override void UpdateEquip(Player player)
        {
            player.moveSpeed += 0.10f;
            player.buffImmune[44] = true;
            player.buffImmune[46] = true;
            player.buffImmune[47] = true;
        }

		public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(null, "ChilledBar", 14);
            recipe.AddTile(16);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
	}
}