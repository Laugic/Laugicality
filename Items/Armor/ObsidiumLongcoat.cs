using Laugicality.Items.Consumables;
using Laugicality.Items.Loot;
using Laugicality.Items.Materials;
using Laugicality.Items.Placeable;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Laugicality.Items.Armor
{
	[AutoloadEquip(EquipType.Body)]
	public class ObsidiumLongcoat : LaugicalityItem
	{
		public override void SetStaticDefaults()
		{
			Tooltip.SetDefault("Immunity to lava, 'On Fire!', and 'Burning'");
		}

		public override void SetDefaults()
		{
			item.width = 34;
			item.height = 22;
            item.value = Item.sellPrice(gold: 1);
            item.rare = ItemRarityID.Orange;
			item.defense = 8;
        }

        public override void UpdateEquip(Player player)
        {
            player.lavaImmune = true;
            player.fireWalk = true;
            player.buffImmune[24] = true;
        }
        

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<ObsidiumBar>(), 20);
            recipe.AddIngredient(ModContent.ItemType<LavaGemItem>(), 8);
            recipe.AddIngredient(ModContent.ItemType<ObsidiumHeart>(), 1);
            recipe.AddTile(16);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}