using Terraria;
using Terraria.ModLoader;

namespace Laugicality.Items.Armor
{
	[AutoloadEquip(EquipType.Head)]
	public class SteampunkMask : ModItem
	{
public override void SetStaticDefaults()
		{
			Tooltip.SetDefault("+4 Minion capacity");
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

        public override bool DrawHead()
        {
            return true;
        }

        public virtual void DrawHair(ref bool drawHair, ref bool drawAltHair)
        {
            drawHair = true;
            drawAltHair = true;
        }
        public override void UpdateEquip(Player player)
        {
            player.maxMinions += 4;
        }

        public override void UpdateArmorSet(Player player)
        {
            LaugicalityPlayer modPlayer = player.GetModPlayer<LaugicalityPlayer>(mod);
            modPlayer.meFied = true;
            player.setBonus = "+18% Minion damage \nAttacks inflict 'Steamy!' ";
            player.minionDamage += 0.18f;
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