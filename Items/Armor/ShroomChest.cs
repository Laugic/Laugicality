using Laugicality.Items.Materials;
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
            Tooltip.SetDefault("+20% Overflow");
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
            LaugicalityPlayer modPlayer = LaugicalityPlayer.Get(player);
            modPlayer.GlobalOverflow += .2f;
        }
        
        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.GlowingMushroom, 16);
            recipe.AddIngredient(ItemID.MudBlock, 12);
            recipe.AddIngredient(ModContent.ItemType<ArcaneShard>(), 8);
            recipe.AddTile(16);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
	}
}