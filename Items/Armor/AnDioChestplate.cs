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
            player.setBonus = "After staying on a Mysticism for 5 seconds, increase its power by 1\nTime stop lasts longer\nAutomatically stops time after taking a hit below 20% life";
            LaugicalityWorld.zWarudo += 140;
            modPlayer.andioChestplate = true;
            modPlayer.destructionPower += 1;
            modPlayer.illusionPower += 1;
            modPlayer.conjurationPower += 1;
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