using Terraria;
using Terraria.ModLoader;

namespace Laugicality.Items.Armor
{
	[AutoloadEquip(EquipType.Head)]
	public class MagmaticMask : ModItem
	{
        public override void SetStaticDefaults()
		{
			Tooltip.SetDefault("+15% Mystic and Throwing Damage");
		}

		public override void SetDefaults()
		{
			item.width = 34;
			item.height = 22;
			item.value = 10000;
			item.rare = 3;
			item.defense = 12;
		}
        

        public override bool IsArmorSet(Item head, Item body, Item legs)
        {
            return body.type == mod.ItemType("MagmaticLongcoat") && legs.type == mod.ItemType("MagmaticBoots");
        }

        public override void UpdateArmorSet(Player player)
        {
            LaugicalityPlayer modPlayer = player.GetModPlayer<LaugicalityPlayer>(mod);
            player.setBonus = "Eruption Mystic Burst\nAttacks inflict 'On Fire!'\nIncreased stats after being submerged in Lava";
            modPlayer.obsidium = true;
            modPlayer.magmatic = true;


            if (player.lavaWet)
                player.AddBuff(mod.BuffType("Magmatic"), 60 * 15);
        }


        public override void UpdateEquip(Player player)
        {
            LaugicalityPlayer modPlayer = player.GetModPlayer<LaugicalityPlayer>(mod);
            modPlayer.mysticDamage += 0.15f;
            player.thrownDamage += .15f;
        }
        

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(null, "ObsidiumHelmet", 1);
            recipe.AddRecipeGroup("TitaniumBars", 12);
            recipe.AddIngredient(null, "MagmaticCrystal", 2);
            recipe.AddIngredient(null, "MagmaticCluster", 1);
            recipe.AddTile(134);
            recipe.SetResult(this);
            recipe.AddRecipe();


            ModRecipe recipe2 = new ModRecipe(mod);
            recipe2.AddIngredient(null, "ObsidiumBand", 1);
            recipe2.AddRecipeGroup("TitaniumBars", 12);
            recipe2.AddIngredient(null, "MagmaticCrystal", 2);
            recipe2.AddIngredient(null, "MagmaticCluster", 1);
            recipe2.AddTile(134);
            recipe2.SetResult(this);
            recipe2.AddRecipe();
        }
    }
}