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
            Tooltip.SetDefault("Increases maximum mana by 20\n+100% Mystic Duration");
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
            modPlayer.MysticDuration += 1f;
        }


        public override bool DrawHead()
        {
            return false;
        }
        
        public override void UpdateArmorSet(Player player)
        {
            LaugicalityPlayer modPlayer = player.GetModPlayer<LaugicalityPlayer>(mod);
            player.setBonus = "Mystic damage increased by 12%\nYour Max Mana is added to your Potentias\nRegen the Potentia that you aren't actively using";
            modPlayer.MysticDamage += .12f;
            modPlayer.LuxMax += player.statManaMax2 / 3;
            modPlayer.VisMax += player.statManaMax2 / 3;
            modPlayer.MundusMax += player.statManaMax2 / 3;

            if (modPlayer.MysticHold > 0)
            {
                if (modPlayer.Lux < modPlayer.LuxMax + modPlayer.LuxMaxPermaBoost && modPlayer.MysticMode != 1)
                    modPlayer.Lux += 1f / 20f;
                if (modPlayer.Vis < modPlayer.VisMax + modPlayer.VisMaxPermaBoost && modPlayer.MysticMode != 2)
                    modPlayer.Vis += 1f / 20f;
                if (modPlayer.Mundus < modPlayer.MundusMax + modPlayer.MundusMaxPermaBoost && modPlayer.MysticMode != 3)
                    modPlayer.Mundus += 1f / 20f;
            }
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