using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using WebmilioCommons.Time;

namespace Laugicality.Items.Armor
{
	[AutoloadEquip(EquipType.Body)]
	public class AnDioChestguard : LaugicalityItem
	{
		public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("AnDio Chestguard");
            Tooltip.SetDefault("Decreased cooldown between Time Stops\nYou are immune to Time Stop");
		}

		public override void SetDefaults()
		{
			item.width = 34;
			item.height = 22;
            item.value = Item.sellPrice(gold: 4);
            item.rare = ItemRarityID.Pink;
			item.defense = 16;
        }

        public override void UpdateEquip(Player player)
        {
            LaugicalityPlayer modPlayer = LaugicalityPlayer.Get(player);
            modPlayer.zImmune = true;
            modPlayer.zCoolDown -= 10 * 60;
        }


        public override bool IsArmorSet(Item head, Item body, Item legs)
        {
            return head.type == ModContent.ItemType<DioritusHelmet>() && legs.type == ModContent.ItemType<AndesiaLeggings>();
        }

        public override void UpdateArmorSet(Player player)
        {
            LaugicalityPlayer modPlayer = LaugicalityPlayer.Get(player);
            player.setBonus = "Automatically stop time after taking a hit below 25% life\nYou are immune while Time is Stopped";
            if (TimeManagement.TimeAltered)
            {
                player.immune = true;
                player.immuneTime = Math.Max(player.immuneTime, 4);
            }
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