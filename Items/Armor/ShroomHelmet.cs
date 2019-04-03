using Terraria;
using Terraria.ModLoader;

namespace Laugicality.Items.Armor
{
	[AutoloadEquip(EquipType.Head)]
	public class ShroomHelmet : ModItem
	{
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Shroom Cap");
            Tooltip.SetDefault("+4% Mystic Damage");
		}

		public override void SetDefaults()
		{
			item.width = 34;
			item.height = 22;
			item.value = 10000;
			item.rare = 1;
			item.defense = 2;
		}

		public override bool IsArmorSet(Item head, Item body, Item legs)
		{
			return body.type == mod.ItemType("ShroomChest") && legs.type == mod.ItemType("ShroomPants");
        }


        public override void UpdateEquip(Player player)
        {
            LaugicalityPlayer modPlayer = player.GetModPlayer<LaugicalityPlayer>(mod);
            modPlayer.mysticDamage += .04f;
        }

        public override bool DrawHead()
        {
            return true;
        }

        public override void DrawHair(ref bool drawHair, ref bool drawAltHair)
        {
            drawAltHair = true;
        }
        public override void UpdateArmorSet(Player player)
        {
            LaugicalityPlayer modPlayer = player.GetModPlayer<LaugicalityPlayer>(mod);
            player.setBonus = "Attacks cast using Overflow can pass through walls\nWhen at Max Potentia, Overflow slowly accrues over time";
            modPlayer.shroomOverflow = 2;

            if (modPlayer.mysticHold > 0)
            {
                if (modPlayer.lux >= modPlayer.luxMax + modPlayer.luxMaxPermaBoost && modPlayer.lux < (modPlayer.luxMax + modPlayer.luxMaxPermaBoost) * modPlayer.luxOverflow * modPlayer.globalOverflow)
                    modPlayer.lux += 1f / 20f;
                if (modPlayer.vis >= modPlayer.visMax + modPlayer.visMaxPermaBoost && modPlayer.vis < (modPlayer.visMax + modPlayer.visMaxPermaBoost) * modPlayer.visOverflow * modPlayer.globalOverflow)
                    modPlayer.vis += 1f / 20f;
                if (modPlayer.mundus >= modPlayer.mundusMax + modPlayer.mundusMaxPermaBoost && modPlayer.mundus < (modPlayer.mundusMax + modPlayer.mundusMaxPermaBoost) * modPlayer.mundusOverflow * modPlayer.globalOverflow)
                    modPlayer.mundus += 1f / 20f;
            }
        }

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(183, 10);
            recipe.AddIngredient(176, 6);
            recipe.AddTile(16);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}