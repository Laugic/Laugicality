using Laugicality.Items.Consumables;
using Laugicality.Items.Loot;
using Laugicality.Items.Materials;
using Laugicality.Items.Placeable;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Laugicality.Items.Armor
{
	[AutoloadEquip(EquipType.Head)]
	public class ObsidiumHelmet : LaugicalityItem
	{
        public override void SetStaticDefaults()
		{
			Tooltip.SetDefault("+15% Mystic Damage");
		}

		public override void SetDefaults()
		{
			item.width = 34;
			item.height = 22;
            item.value = Item.sellPrice(gold: 1);
            item.rare = ItemRarityID.Orange;
			item.defense = 6;
		}

		public override bool IsArmorSet(Item head, Item body, Item legs)
		{
			return body.type == ModContent.ItemType<ObsidiumLongcoat>() && legs.type == ModContent.ItemType<ObsidiumPants>();
        }


        public override void UpdateEquip(Player player)
        {
            LaugicalityPlayer modPlayer = LaugicalityPlayer.Get(player);
            modPlayer.MysticDamage += 0.15f;
        }

        

        public override void UpdateArmorSet(Player player)
        {
            LaugicalityPlayer modPlayer = LaugicalityPlayer.Get(player);
            player.setBonus = "Increased Mystic damage for a time after swapping Mysticisms\nAttacks inflict 'On Fire!'";
            modPlayer.Obsidium = true;
            modPlayer.MysticObsidiumSwitch = true;
        }

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<ObsidiumBar>(), 10);
            recipe.AddIngredient(ModContent.ItemType<LavaGemItem>(), 4);
            recipe.AddIngredient(ModContent.ItemType<DarkShard>(), 1);
            recipe.AddTile(16);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}