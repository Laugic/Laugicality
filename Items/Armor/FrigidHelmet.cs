using Terraria;
using Terraria.ModLoader;

namespace Laugicality.Items.Armor
{
	[AutoloadEquip(EquipType.Head)]
	public class FrigidHelmet : ModItem
	{
        public override void SetStaticDefaults()
		{
			Tooltip.SetDefault("+10% Melee and Ranged Damage");
		}

		public override void SetDefaults()
		{
			item.width = 34;
			item.height = 22;
			item.value = 10000;
			item.rare = 2;
			item.defense = 5;
		}

		public override bool IsArmorSet(Item head, Item body, Item legs)
		{
			return body.type == mod.ItemType("FrigidChestplate") && legs.type == mod.ItemType("FrigidLeggings");
        }


        public override void UpdateEquip(Player player)
        {
            player.meleeDamage += 0.1f;
            player.rangedDamage += 0.1f;
        }

        public override void UpdateArmorSet(Player player)
        {
            LaugicalityPlayer modPlayer = player.GetModPlayer<LaugicalityPlayer>(mod);
            player.setBonus = "Attacks inflict Frostburn.";
            modPlayer.Frost = true;
            
        }

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(null, "ChilledBar", 12);
            recipe.AddIngredient(null, "FrostShard", 1);
            recipe.AddTile(16);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}