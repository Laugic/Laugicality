using Terraria;
using Terraria.ModLoader;

namespace Laugicality.Items.Armor
{
	[AutoloadEquip(EquipType.Body)]
	public class AnDioChestplate : ModItem
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
            player.setBonus = "+50 to all Potentias\n25% Reduced Potentia useage\nThe lower your Potentia, the higher your Mystic damage\nPotentia does not decrease when time is stopped\nTime stop lasts longer\nAutomatically stops time after taking a hit below 25% life";
            modPlayer.zaWarudoDuration += 2 * 60;
            modPlayer.andioChestplate = true;
            modPlayer.luxMax += 50;
            modPlayer.visMax += 50;
            modPlayer.mundusMax += 50;
            if (modPlayer.mysticMode == 1 && modPlayer.lux < (modPlayer.luxMax + modPlayer.luxMaxPermaBoost))
                modPlayer.mysticDamage += (1 - (modPlayer.lux / (modPlayer.luxMax + modPlayer.luxMaxPermaBoost))) / 5;
            if (modPlayer.mysticMode == 2 && modPlayer.vis < (modPlayer.visMax + modPlayer.visMaxPermaBoost))
                modPlayer.mysticDamage += (1 - (modPlayer.vis / (modPlayer.visMax + modPlayer.visMaxPermaBoost))) / 5;
            if (modPlayer.mysticMode == 3 && modPlayer.mundus < (modPlayer.mundusMax + modPlayer.mundusMaxPermaBoost))
                modPlayer.mysticDamage += (1 - (modPlayer.mundus / (modPlayer.mundusMax + modPlayer.mundusMaxPermaBoost))) / 5;
            modPlayer.globalPotentiaUseRate *= .75f;
            if (Laugicality.zawarudo > 0)
                modPlayer.globalPotentiaUseRate = 0;
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(null, "AndesiaCore", 1);
            recipe.AddIngredient(3086, 32);
            recipe.AddRecipeGroup("TitaniumBars", 24);
            recipe.AddTile(134);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}