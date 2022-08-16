using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Laugicality.Items.Armor
{
	[AutoloadEquip(EquipType.Head)]
	public class ShroomHelmet : LaugicalityItem
	{
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Shroom Cap");
            Tooltip.SetDefault("+8% Mystic Damage");
		}

		public override void SetDefaults()
		{
			item.width = 34;
			item.height = 22;
			item.value = 10000;
			item.rare = ItemRarityID.Blue;
			item.defense = 2;
		}

		public override bool IsArmorSet(Item head, Item body, Item legs)
		{
			return body.type == ModContent.ItemType<ShroomChest>() && legs.type == ModContent.ItemType<ShroomPants>();
        }


        public override void UpdateEquip(Player player)
        {
            LaugicalityPlayer modPlayer = LaugicalityPlayer.Get(player);
            modPlayer.MysticDamage += .08f;
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
            LaugicalityPlayer modPlayer = LaugicalityPlayer.Get(player);
            player.setBonus = "Overflow attacks shoot Spores from your head\nOverflow slowly accrues over time";
            modPlayer.ShroomOverflow = 2;

            if (modPlayer.MysticHold > 0)
            {
                if (modPlayer.Lux >= modPlayer.LuxMax + modPlayer.LuxMaxPermaBoost && modPlayer.Lux < (modPlayer.LuxMax + modPlayer.LuxMaxPermaBoost) * modPlayer.LuxOverflow * modPlayer.GlobalOverflow)
                    modPlayer.Lux += 1f / 20f;
                if (modPlayer.Vis >= modPlayer.VisMax + modPlayer.VisMaxPermaBoost && modPlayer.Vis < (modPlayer.VisMax + modPlayer.VisMaxPermaBoost) * modPlayer.VisOverflow * modPlayer.GlobalOverflow)
                    modPlayer.Vis += 1f / 20f;
                if (modPlayer.Mundus >= modPlayer.MundusMax + modPlayer.MundusMaxPermaBoost && modPlayer.Mundus < (modPlayer.MundusMax + modPlayer.MundusMaxPermaBoost) * modPlayer.MundusOverflow * modPlayer.GlobalOverflow)
                    modPlayer.Mundus += 1f / 20f;
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