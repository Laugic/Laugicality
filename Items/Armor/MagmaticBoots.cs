using Laugicality.Items.Loot;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Laugicality.Items.Armor
{
	[AutoloadEquip(EquipType.Legs)]
	public class MagmaticBoots : LaugicalityItem
	{
		public override void SetStaticDefaults()
		{
			Tooltip.SetDefault("+100% Mystic Duration\n+50%Throwing Velocity\n+15% Movement Speed\nProvides waterwalking and free movement in liquids");
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
            player.moveSpeed += 0.15f;
            LaugicalityPlayer modPlayer = LaugicalityPlayer.Get(player);
            modPlayer.MysticDuration += 1f;
            player.thrownVelocity += .5f;
            player.waterWalk = true;
            player.ignoreWater = true;
        }
        

		public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(null, "ObsidiumPants", 1);
            recipe.AddRecipeGroup("TitaniumBars", 10);
            recipe.AddIngredient(ModContent.ItemType<SoulOfHaught>(), 4);
            recipe.AddIngredient(null, "MagmaticCluster", 1);
            recipe.AddTile(TileID.MythrilAnvil);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
	}
}