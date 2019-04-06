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
            modPlayer.mysticDuration += 1f;
        }


        public override bool DrawHead()
        {
            return false;
        }
        
        public override void UpdateArmorSet(Player player)
        {
            LaugicalityPlayer modPlayer = player.GetModPlayer<LaugicalityPlayer>(mod);
            player.setBonus = "Mystic damage increased by 12%\nYour Max Mana is added to your Potentias\nRegen the Potentia that you aren't actively using";
            modPlayer.mysticDamage += .12f;
            modPlayer.luxMax += player.statManaMax2 / 3;
            modPlayer.visMax += player.statManaMax2 / 3;
            modPlayer.mundusMax += player.statManaMax2 / 3;

            if (modPlayer.mysticHold > 0)
            {
                if (modPlayer.lux < modPlayer.luxMax + modPlayer.luxMaxPermaBoost && modPlayer.mysticMode != 1)
                    modPlayer.lux += 1f / 20f;
                if (modPlayer.vis < modPlayer.visMax + modPlayer.visMaxPermaBoost && modPlayer.mysticMode != 2)
                    modPlayer.vis += 1f / 20f;
                if (modPlayer.mundus < modPlayer.mundusMax + modPlayer.mundusMaxPermaBoost && modPlayer.mysticMode != 3)
                    modPlayer.mundus += 1f / 20f;
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