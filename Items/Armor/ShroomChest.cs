using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Laugicality.Items.Armor
{
	[AutoloadEquip(EquipType.Body)]
	public class ShroomChest : LaugicalityItem
	{
		public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Shroom Amalgam");
            Tooltip.SetDefault("+2% Mystic Damage\n+20% Overflow");
		}

		public override void SetDefaults()
		{
			item.width = 34;
			item.height = 22;
			item.value = 10000;
			item.rare = ItemRarityID.Blue;
			item.defense = 3;
        }

        public override void UpdateEquip(Player player)
        {
            LaugicalityPlayer modPlayer = player.GetModPlayer<LaugicalityPlayer>(mod);
            modPlayer.MysticDamage += .02f;
            modPlayer.GlobalOverflow += .2f;
        }
        
        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(183, 16);
            recipe.AddIngredient(176, 12);
            recipe.AddIngredient(109, 1);
            recipe.AddTile(16);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
	}
}