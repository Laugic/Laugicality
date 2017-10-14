using Terraria;
using Terraria.ModLoader;

namespace Laugicality.Items.Armor
{
	[AutoloadEquip(EquipType.Head)]
	public class ObsidiumHat : ModItem
	{
        public override void SetStaticDefaults()
		{
			Tooltip.SetDefault("+12% Ranged, Summon, Magic, Throwing, and Mystic Damage");
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
            player.thrownDamage += 0.12f;
            player.rangedDamage += 0.12f;
            player.magicDamage += 0.12f;
            player.minionDamage += 0.12f;
            modPlayer.mysticDamage += 0.12f;
            //modPlayer.mysticDuration += 1f;
        }

        public override void UpdateArmorSet(Player player)
        {
            LaugicalityPlayer modPlayer = player.GetModPlayer<LaugicalityPlayer>(mod);
            player.setBonus = "Increased Life Regen \n+4 Defense \nAttacks inflict 'On Fire!' ";
            modPlayer.obsidium = true;

            player.lifeRegen +=3;
            player.statDefense += 4;
        }

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(null, "ObsidiumBar", 10);
            recipe.AddIngredient(173, 10);
            recipe.AddIngredient(225, 10);
            recipe.AddTile(16);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}