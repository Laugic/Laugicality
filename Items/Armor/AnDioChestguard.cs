using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Laugicality.Items.Armor
{
	[AutoloadEquip(EquipType.Body)]
	public class AnDioChestguard : LaugicalityItem
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
			item.rare = ItemRarityID.Orange;
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
            modPlayer.GlobalAbsorbRate *= 1.5f;
            if (Laugicality.zaWarudo > 0)
            {
                if (modPlayer.Lux < modPlayer.LuxMax + modPlayer.LuxMaxPermaBoost && modPlayer.MysticMode != 1)
                    modPlayer.Lux += 1f / 4f;
                if (modPlayer.Vis < modPlayer.VisMax + modPlayer.VisMaxPermaBoost && modPlayer.MysticMode != 2)
                    modPlayer.Vis += 1f / 4f;
                if (modPlayer.Mundus < modPlayer.MundusMax + modPlayer.MundusMaxPermaBoost && modPlayer.MysticMode != 3)
                    modPlayer.Mundus += 1f / 4f;
            }
            modPlayer.MysticSwitchCoolRate += 2;
            modPlayer.zCoolDown -= 10 * 60;
            modPlayer.AndioChestguard = true;
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(null, "DioritusCore", 1);
            recipe.AddIngredient(3081, 32);
            recipe.AddRecipeGroup("TitaniumBars", 24);
            recipe.AddTile(TileID.MythrilAnvil);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}