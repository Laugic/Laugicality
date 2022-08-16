using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using WebmilioCommons.Time;

namespace Laugicality.Items.Armor
{
	[AutoloadEquip(EquipType.Body)]
	public class AnDioChestplate : LaugicalityItem
	{
		public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("AnDio Chestplate");
            Tooltip.SetDefault("Increased duration of Time Stop\nYou are immune to Time Stop");
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
            modPlayer.zaWarudoDuration += 2 * 60;
        }


        public override bool IsArmorSet(Item head, Item body, Item legs)
        {
            return head.type == ModContent.ItemType<DioritusHelmet>() && legs.type == ModContent.ItemType<AndesiaLeggings>();
        }

        public override void UpdateArmorSet(Player player)
        {
            player.setBonus = "Deal increased damage while Time is Stopped";

            if (TimeManagement.TimeAltered)
                player.allDamage += .25f;
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