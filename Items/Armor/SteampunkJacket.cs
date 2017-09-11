using Terraria;
using Terraria.ModLoader;

namespace Laugicality.Items.Armor
{
	[AutoloadEquip(EquipType.Body)]
	public class SteampunkJacket : ModItem
	{
		public override void SetStaticDefaults()
		{
			Tooltip.SetDefault("8% Increased damage and critical strike chance");
		}

		public override void SetDefaults()
		{
			item.width = 34;
			item.height = 22;
			item.value = 10000;
			item.rare = 5;
			item.defense = 16;
        }

        public override void UpdateEquip(Player player)
        {
            player.thrownDamage += 0.08f;
            player.rangedDamage += 0.08f;
            player.magicDamage += 0.08f;
            player.minionDamage += 0.08f;
            player.meleeDamage += 0.08f;
            player.thrownCrit += 8;
            player.rangedCrit += 8;
            player.magicCrit += 8;
            player.meleeCrit += 8;
        }


        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(null, "SteamBar", 24);
            recipe.AddTile(134);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}