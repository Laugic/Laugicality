using Terraria;
using Terraria.ModLoader;

namespace Laugicality.Items.Armor
{
	[AutoloadEquip(EquipType.Body)]
	public class AnDioChestguard : ModItem
	{
		public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("AnDio Chestguard");
            Tooltip.SetDefault("'Generalist'\nYou are immune to Time Stop");
		}

		public override void SetDefaults()
		{
			item.width = 34;
			item.height = 22;
			item.value = 10000;
			item.rare = 3;
			item.defense = 16;
        }

        public override void UpdateEquip(Player player)
        {
            LaugicalityPlayer modPlayer = player.GetModPlayer<LaugicalityPlayer>(mod);
            modPlayer.zImmune = true;
        }


        public override bool IsArmorSet(Item head, Item body, Item legs)
        {
            return head.type == mod.ItemType("DioritusHelmet") && legs.type == mod.ItemType("AndesiaLeggings");
        }

        public override void UpdateArmorSet(Player player)
        {
            LaugicalityPlayer modPlayer = player.GetModPlayer<LaugicalityPlayer>(mod);
            player.setBonus = "50% more Potentia discharges to other Potentias when used\nDioritus Mystic Burst\nDecreases Mystic Burst cooldown" +
                "\nGreatly increased Potentia Regen when time is stopped\n'Out of Time' cooldown is shorter\nAutomatically stops time after taking a hit below 25% life";
            modPlayer.globalAbsorbRate *= 1.5f;
            if (Laugicality.zawarudo > 0)
            {
                if (modPlayer.lux < modPlayer.luxMax + modPlayer.luxMaxPermaBoost && modPlayer.mysticMode != 1)
                    modPlayer.lux += 1f / 4f;
                if (modPlayer.vis < modPlayer.visMax + modPlayer.visMaxPermaBoost && modPlayer.mysticMode != 2)
                    modPlayer.vis += 1f / 4f;
                if (modPlayer.mundus < modPlayer.mundusMax + modPlayer.mundusMaxPermaBoost && modPlayer.mysticMode != 3)
                    modPlayer.mundus += 1f / 4f;
            }
            modPlayer.mysticSwitchCoolRate += 2;
            modPlayer.zCoolDown -= 10 * 60;
            modPlayer.andioChestguard = true;
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(null, "DioritusCore", 1);
            recipe.AddIngredient(3081, 32);
            recipe.AddRecipeGroup("TitaniumBars", 24);
            recipe.AddTile(134);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}