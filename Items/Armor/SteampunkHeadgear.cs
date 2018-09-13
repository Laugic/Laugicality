using Terraria;
using Terraria.ModLoader;

namespace Laugicality.Items.Armor
{
	[AutoloadEquip(EquipType.Head)]
	public class SteampunkHeadgear : ModItem
	{
public override void SetStaticDefaults()
        {
            Tooltip.SetDefault("+20% Throwing Damage");
		}

		public override void SetDefaults()
		{
			item.width = 34;
			item.height = 22;
			item.value = 10000;
			item.rare = 5;
			item.defense = 14;
		}

		public override bool IsArmorSet(Item head, Item body, Item legs)
		{
			return body.type == mod.ItemType("SteampunkJacket") && legs.type == mod.ItemType("SteampunkBoots");
        }


        public override void UpdateEquip(Player player)
        {
            player.thrownDamage += .2f;
        }

        public override void UpdateArmorSet(Player player)
        {
            player.setBonus = "+33% Throwing Velocity, \nAttacks inflict 'Steamy!' ";
            LaugicalityPlayer modPlayer = player.GetModPlayer<LaugicalityPlayer>(mod);
            modPlayer.meFied = true;
            player.thrownVelocity += .33f;
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(null, "SteamBar", 12);
            recipe.AddTile(134);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}