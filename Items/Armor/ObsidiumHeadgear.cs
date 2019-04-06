using Terraria;
using Terraria.ModLoader;

namespace Laugicality.Items.Armor
{
	[AutoloadEquip(EquipType.Head)]
	public class ObsidiumHeadgear : ModItem
	{
        public override void SetStaticDefaults()
		{
			Tooltip.SetDefault("+15% Ranged Damage");
		}

		public override void SetDefaults()
		{
			item.width = 34;
			item.height = 22;
			item.value = 10000;
			item.rare = 3;
			item.defense = 6;
		}

		public override bool IsArmorSet(Item head, Item body, Item legs)
		{
			return body.type == mod.ItemType("ObsidiumLongcoat") && legs.type == mod.ItemType("ObsidiumPants");
        }


        public override void UpdateEquip(Player player)
        {
            LaugicalityPlayer modPlayer = player.GetModPlayer<LaugicalityPlayer>(mod);
            player.rangedDamage += 0.15f;
        }

        

        public override void UpdateArmorSet(Player player)
        {
            LaugicalityPlayer modPlayer = player.GetModPlayer<LaugicalityPlayer>(mod);
            player.setBonus = "+10% Ranged Crit Chance \nAttacks inflict 'On Fire!' ";
            modPlayer.Obsidium = true;
            player.rangedCrit += 10;
        }

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(null, "ObsidiumBar", 10);
            recipe.AddIngredient(null, "LavaGem", 4);
            recipe.AddTile(16);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}