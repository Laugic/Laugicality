using Laugicality.Items.Loot;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Laugicality.Items.Armor
{
	[AutoloadEquip(EquipType.Head)]
	public class BysmalMask : LaugicalityItem
	{
        public override void SetStaticDefaults()
		{
			Tooltip.SetDefault("+10% Damage \n+10% Additional Damage when in the Etherial");
		}

		public override void SetDefaults()
		{
			item.width = 34;
			item.height = 22;
			item.value = 10000;
			item.rare = ItemRarityID.LightPurple;
			item.defense = 16;
		}
        
        public override void UpdateEquip(Player player)
        {
            float dmgBoost = .1f;
            LaugicalityPlayer modPlayer = player.GetModPlayer<LaugicalityPlayer>(mod);
            if (modPlayer.Etherable > 0|| LaugicalityWorld.downedEtheria)
                dmgBoost += .1f;

            player.allDamage += dmgBoost;
        }


        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(null, "BysmalBar", 15);
            recipe.AddIngredient(mod, nameof(EtherialEssence), 4);
            recipe.AddTile(TileID.MythrilAnvil);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}