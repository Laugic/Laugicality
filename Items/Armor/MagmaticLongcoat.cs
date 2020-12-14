using Laugicality.Items.Loot;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Laugicality.Items.Armor
{
	[AutoloadEquip(EquipType.Body)]
	public class MagmaticLongcoat : LaugicalityItem
	{
		public override void SetStaticDefaults()
		{
			Tooltip.SetDefault("Immunity to lava, 'On Fire!', and 'Burning'\n+10% Throwing critical strike chance");
		}

		public override void SetDefaults()
		{
			item.width = 34;
			item.height = 22;
            item.value = Item.sellPrice(gold: 4);
            item.rare = ItemRarityID.Pink;
            item.defense = 16;
        }

        public override void UpdateEquip(Player player)
        {
            player.lavaImmune = true;
            player.fireWalk = true;
            player.buffImmune[24] = true;
            player.thrownCrit += 10;
        }
        

		public override void AddRecipes()
		{
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(null, "ObsidiumLongcoat", 1);
            recipe.AddRecipeGroup("TitaniumBars", 18);
            recipe.AddIngredient(ModContent.ItemType<SoulOfHaught>(), 6);
            recipe.AddIngredient(null, "MagmaticCluster", 1);
            recipe.AddTile(TileID.MythrilAnvil);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
	}
}