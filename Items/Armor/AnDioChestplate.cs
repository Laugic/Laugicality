using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Laugicality.Items.Armor
{
	[AutoloadEquip(EquipType.Body)]
	public class AnDioChestplate : LaugicalityItem
	{
		public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("AnDio Chestplate");
            Tooltip.SetDefault("'Specialist'\nYou are immune to Time Stop");
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
            player.setBonus = "+50 to all Potentias\n25% Reduced Potentia useage\nThe lower your Potentia, the higher your Mystic damage\nPotentia does not decrease when time is stopped\nTime stop lasts longer\nAutomatically stops time after taking a hit below 25% life";
            modPlayer.zaWarudoDuration += 2 * 60;
            modPlayer.AndioChestplate = true;
            modPlayer.LuxMax += 50;
            modPlayer.VisMax += 50;
            modPlayer.MundusMax += 50;
            if (modPlayer.MysticMode == 1 && modPlayer.Lux < (modPlayer.LuxMax + modPlayer.LuxMaxPermaBoost))
                modPlayer.MysticDamage += (1 - (modPlayer.Lux / (modPlayer.LuxMax + modPlayer.LuxMaxPermaBoost))) / 5;
            if (modPlayer.MysticMode == 2 && modPlayer.Vis < (modPlayer.VisMax + modPlayer.VisMaxPermaBoost))
                modPlayer.MysticDamage += (1 - (modPlayer.Vis / (modPlayer.VisMax + modPlayer.VisMaxPermaBoost))) / 5;
            if (modPlayer.MysticMode == 3 && modPlayer.Mundus < (modPlayer.MundusMax + modPlayer.MundusMaxPermaBoost))
                modPlayer.MysticDamage += (1 - (modPlayer.Mundus / (modPlayer.MundusMax + modPlayer.MundusMaxPermaBoost))) / 5;
            modPlayer.GlobalPotentiaUseRate *= .75f;
            if (Laugicality.zaWarudo > 0)
                modPlayer.GlobalPotentiaUseRate = 0;
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(null, "AndesiaCore", 1);
            recipe.AddIngredient(3086, 32);
            recipe.AddRecipeGroup("TitaniumBars", 24);
            recipe.AddTile(TileID.MythrilAnvil);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}