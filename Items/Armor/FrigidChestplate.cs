using Terraria;
using Terraria.ModLoader;

namespace Laugicality.Items.Armor
{
	[AutoloadEquip(EquipType.Body)]
	public class FrigidChestplate : ModItem
	{
		public override void SetStaticDefaults()
		{
			Tooltip.SetDefault("+7% Melee Speed and Range Crit Chance");
		}

		public override void SetDefaults()
		{
			item.width = 34;
			item.height = 22;
			item.value = 10000;
			item.rare = 2;
			item.defense = 6;
            item.lifeRegen = 2;
        }

        public override void UpdateEquip(Player player)
        {
            player.meleeSpeed += .07f;
            player.rangedCrit += 7;
        }

        public override void DrawHands(ref bool drawHands, ref bool drawArms)
        {
            drawHands = true;
            drawArms = true;
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