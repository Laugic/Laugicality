using Terraria;
using Terraria.ModLoader;

namespace Laugicality.Items.Armor
{
	[AutoloadEquip(EquipType.Head)]
	public class BysmalMask : ModItem
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
			item.rare = 6;
			item.defense = 16;
		}
        
        public override void UpdateEquip(Player player)
        {
            float dmgBoost = .1f;
            LaugicalityPlayer modPlayer = player.GetModPlayer<LaugicalityPlayer>(mod);
            if (modPlayer.etherable || LaugicalityWorld.downedEtheria)
                dmgBoost += .1f;

            player.thrownDamage += dmgBoost;
            player.rangedDamage += dmgBoost;
            player.magicDamage += dmgBoost;
            player.minionDamage += dmgBoost;
            player.meleeDamage += dmgBoost;
        }


        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(null, "BysmalBar", 15);
            recipe.AddIngredient(null, "EtherialEssence", 4);
            recipe.AddTile(134);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}