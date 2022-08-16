using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Laugicality.Items.Armor
{
	[AutoloadEquip(EquipType.Head)]
	public class DioritusHelmet : LaugicalityItem
	{
        public override void SetStaticDefaults()
		{
			Tooltip.SetDefault("+15% Damage\n+10% critical strike chance");
		}

		public override void SetDefaults()
		{
			item.width = 34;
			item.height = 22;
            item.value = Item.sellPrice(gold: 4);
            item.rare = ItemRarityID.Pink;
            item.defense = 12;
		}
        


        public override void UpdateEquip(Player player)
        {
            player.allDamage += .15f;
            player.meleeCrit += 10;
            player.rangedCrit += 10;
            player.magicCrit += 10;
            player.thrownCrit += 10;
        }
        

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(null, "DioritusCore", 1);
            recipe.AddIngredient(3081, 32);
            recipe.AddRecipeGroup("TitaniumBars", 12);
            recipe.AddTile(TileID.MythrilAnvil);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}