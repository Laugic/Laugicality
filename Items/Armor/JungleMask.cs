using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Laugicality.Items.Armor
{
	[AutoloadEquip(EquipType.Head)]
	public class JungleMask : LaugicalityItem
	{
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Jungle Hood");
            Tooltip.SetDefault("Mystic damage increased by 12%\n+100% Mystic Duration");
		}

		public override void SetDefaults()
		{
			item.width = 34;
			item.height = 22;
			item.value = Item.sellPrice(silver: 90);
			item.rare = ItemRarityID.Orange;
			item.defense = 4;
		}

		public override bool IsArmorSet(Item head, Item body, Item legs)
		{
			return body.type == 229 && legs.type == 230;
        }


        public override void UpdateEquip(Player player)
        {
            LaugicalityPlayer modPlayer = LaugicalityPlayer.Get(player);
            modPlayer.MysticDamage += .12f;
            modPlayer.MysticDuration += 1f;
        }


        public override bool DrawHead()
        {
            return false;
        }
        
        public override void UpdateArmorSet(Player player)
        {
            LaugicalityPlayer modPlayer = LaugicalityPlayer.Get(player);
            player.setBonus = "Your Max Mana is added to your Potentias\nIncreased Mana and Potentia regen";
            modPlayer.LuxMax += player.statManaMax2 / 3;
            modPlayer.VisMax += player.statManaMax2 / 3;
            modPlayer.MundusMax += player.statManaMax2 / 3;

            modPlayer.LuxUnuseRegen += .04f;
            modPlayer.VisUnuseRegen += .04f;
            modPlayer.MundusUnuseRegen += .04f;

            player.manaRegen += 15;
        }

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(331, 8);
            recipe.AddIngredient(1124, 4);
            recipe.AddTile(16);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}