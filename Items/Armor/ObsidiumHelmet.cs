using Terraria;
using Terraria.ModLoader;

namespace Laugicality.Items.Armor
{
	[AutoloadEquip(EquipType.Head)]
	public class ObsidiumHelmet : ModItem
	{
        public override void SetStaticDefaults()
		{
			Tooltip.SetDefault("+15% Mystic Damage");
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
            modPlayer.mysticDamage += 0.15f;
        }

        

        public override void UpdateArmorSet(Player player)
        {
            LaugicalityPlayer modPlayer = player.GetModPlayer<LaugicalityPlayer>(mod);
            player.setBonus = "Magmatic Mystic Burst\nDecreased Mystic Burst cooldown\n+20% Mystic Burst damage\nAttacks inflict 'On Fire!'";
            modPlayer.obsidium = true;
            modPlayer.mysticObsidiumBurst = true;
            modPlayer.mysticSwitchCoolRate += 2;
            modPlayer.mysticBurstDamage += .2f;
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