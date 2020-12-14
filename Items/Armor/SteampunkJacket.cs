using Laugicality.Items.Loot;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Laugicality.Items.Armor
{
	[AutoloadEquip(EquipType.Body)]
	public class SteampunkJacket : LaugicalityItem
	{
		public override void SetStaticDefaults()
		{
			Tooltip.SetDefault("8% Increased damage and critical strike chance");
		}

		public override void SetDefaults()
		{
			item.width = 34;
			item.height = 22;
            item.value = Item.sellPrice(gold: 5);
            item.rare = ItemRarityID.Lime;
            item.defense = 16;
        }

        public override void UpdateEquip(Player player)
        {
            player.allDamage += 0.08f;
            player.thrownCrit += 8;
            player.rangedCrit += 8;
            player.magicCrit += 8;
            player.meleeCrit += 8;
        }


        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(mod, nameof(SteamBar), 24);
            recipe.AddTile(TileID.MythrilAnvil);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}