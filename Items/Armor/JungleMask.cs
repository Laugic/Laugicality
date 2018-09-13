using Terraria;
using Terraria.ModLoader;

namespace Laugicality.Items.Armor
{
	[AutoloadEquip(EquipType.Head)]
	public class JungleMask : ModItem
	{
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Jungle Hood");
            Tooltip.SetDefault("Increases maximum mana by 20\n+125% Mystic Duration");
		}

		public override void SetDefaults()
		{
			item.width = 34;
			item.height = 22;
			item.value = 10000;
			item.rare = 3;
			item.defense = 4;
		}

		public override bool IsArmorSet(Item head, Item body, Item legs)
		{
			return body.type == 229 && legs.type == 230;
        }


        public override void UpdateEquip(Player player)
        {
            LaugicalityPlayer modPlayer = player.GetModPlayer<LaugicalityPlayer>(mod);
            player.statManaMax2 += 20;
            modPlayer.mysticDuration += 1.25f;
        }


        public override bool DrawHead()
        {
            return false;
        }

        /*public override void DrawHair(ref bool drawHair, ref bool drawAltHair)
        {
            drawAltHair = true;
        }*/

        public override void UpdateArmorSet(Player player)
        {
            LaugicalityPlayer modPlayer = player.GetModPlayer<LaugicalityPlayer>(mod);
            player.setBonus = "Mystic damage increased by 12%";
            modPlayer.mysticDamage += .12f;
            
        }

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(331, 6);
            recipe.AddIngredient(1124, 4);
            recipe.AddTile(16);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}