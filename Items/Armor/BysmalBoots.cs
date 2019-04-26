using Laugicality.Items.Loot;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Laugicality.Items.Armor
{
	[AutoloadEquip(EquipType.Legs)]
	public class BysmalBoots : LaugicalityItem
	{
		public override void SetStaticDefaults()
		{
			Tooltip.SetDefault("+15% Movement Speed\n+25% More Movement Speed and Max Run Speed when in the Etherial");
		}

		public override void SetDefaults()
		{
			item.width = 26;
			item.height = 26;
			item.value = 10000;
			item.rare = ItemRarityID.Orange;
			item.defense = 14;
		}

        public override void UpdateEquip(Player player)
        {
            player.moveSpeed += 0.15f;
            LaugicalityPlayer modPlayer = player.GetModPlayer<LaugicalityPlayer>(mod);
            if(modPlayer.Etherable > 0 || LaugicalityWorld.downedEtheria)
            {
                player.moveSpeed += 0.25f;
                player.maxRunSpeed += 1f;
            }
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(null, "BysmalBar", 12);
            recipe.AddIngredient(mod, nameof(EtherialEssence), 4);
            recipe.AddTile(TileID.MythrilAnvil);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}