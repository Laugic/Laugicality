using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Laugicality.Items.Armor
{
	[AutoloadEquip(EquipType.Head)]
	public class MagmaticMask : LaugicalityItem
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
			item.rare = ItemRarityID.Orange;
			item.defense = 12;
		}
        

        public override bool IsArmorSet(Item head, Item body, Item legs)
        {
            return body.type == ModContent.ItemType("MagmaticLongcoat") && legs.type == ModContent.ItemType("MagmaticBoots");
        }

        public override void UpdateArmorSet(Player player)
        {
            LaugicalityPlayer modPlayer = LaugicalityPlayer.Get(player);
            player.setBonus = "Eruption & Magmatic Mystic Bursts\n+25% Mystic Burst Damage & Decreased Mystic Burst cooldown\n+15%Throwing Crit Chance\nAttacks inflict 'On Fire!'\nIncreased stats after being submerged in Lava";
            modPlayer.Obsidium = true;
            modPlayer.Magmatic = true;
            modPlayer.MysticObsidiumBurst = true;
            player.thrownCrit += 15;
            modPlayer.MysticSwitchCoolRate += 2;

            if (player.lavaWet)
                player.AddBuff(ModContent.BuffType("Magmatic"), 60 * 15);
        }


        public override void UpdateEquip(Player player)
        {
            LaugicalityPlayer modPlayer = LaugicalityPlayer.Get(player);
            modPlayer.MysticDamage += 0.15f;
            player.thrownDamage += .15f;
        }
        

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(null, "ObsidiumHelmet", 1);
            recipe.AddRecipeGroup("TitaniumBars", 12);
            recipe.AddIngredient(null, "MagmaticCrystal", 2);
            recipe.AddIngredient(null, "MagmaticCluster", 1);
            recipe.AddTile(TileID.MythrilAnvil);
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