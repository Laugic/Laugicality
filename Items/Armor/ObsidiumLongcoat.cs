using Terraria;
using Terraria.ModLoader;

namespace Laugicality.Items.Armor
{
	[AutoloadEquip(EquipType.Body)]
	public class ObsidiumLongcoat : ModItem
	{
		public override void SetStaticDefaults()
		{
			Tooltip.SetDefault("Immunity to lava, 'On Fire!', and 'Burning' \nIncreases life regeneration");
		}

		public override void SetDefaults()
		{
			item.width = 34;
			item.height = 22;
			item.value = 10000;
			item.rare = 3;
			item.defense = 8;
            item.lifeRegen = 2;
        }

        public override void UpdateEquip(Player player)
        {
            player.AddBuff(1, 2);
        }
        

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(null, "ObsidiumBar", 20);
            recipe.AddIngredient(173, 10);
            recipe.AddIngredient(225, 10);
            recipe.AddTile(16);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}