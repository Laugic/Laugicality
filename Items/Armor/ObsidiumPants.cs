using Laugicality.Items.Loot;
using Laugicality.Items.Materials;
using Laugicality.Items.Placeable;
using Laugicality.Tiles;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Laugicality.Items.Armor
{
	[AutoloadEquip(EquipType.Legs)]
	public class ObsidiumPants : LaugicalityItem
	{
		public override void SetStaticDefaults()
		{
			Tooltip.SetDefault("Provides waterwalking and free movement in liquids \n+10% Movement Speed");
		}

		public override void SetDefaults()
		{
			item.width = 34;
			item.height = 22;
            item.value = Item.sellPrice(gold: 1);
            item.rare = ItemRarityID.Orange;
			item.defense = 7;
		}

        public override void UpdateEquip(Player player)
        {
            player.moveSpeed += 0.10f;
            player.waterWalk = true;
            player.ignoreWater = true;
        }
        

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<ObsidiumBar>(), 15);
            recipe.AddIngredient(ModContent.ItemType<Placeable.ObsidiumRock>(), 20);
            recipe.AddIngredient(ModContent.ItemType<ObsidiumChunk>(), 2);
            recipe.AddTile(16);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}