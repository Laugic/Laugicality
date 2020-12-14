using Laugicality.Items.Loot;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Laugicality.Items.Armor
{
	[AutoloadEquip(EquipType.Head)]
	public class SteampunkMask : LaugicalityItem
	{
        public override void SetStaticDefaults()
		{
			Tooltip.SetDefault("+4 Minion capacity");
		}

		public override void SetDefaults()
		{
			item.width = 34;
			item.height = 22;
            item.value = Item.sellPrice(gold: 5);
            item.rare = ItemRarityID.Lime;
            item.defense = 14;
		}
        
		public override bool IsArmorSet(Item head, Item body, Item legs)
		{
			return body.type == ModContent.ItemType<SteampunkJacket>() && legs.type == ModContent.ItemType<SteampunkBoots>();
        }

	    public override bool DrawHead() => true;

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
            LaugicalityPlayer modPlayer = LaugicalityPlayer.Get(player);
            modPlayer.Steamified = true;
            player.setBonus = "+18% Minion damage \nAttacks inflict 'Steamy!' ";
            player.minionDamage += 0.18f;
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);

            recipe.AddIngredient(mod, nameof(SteamBar), 12);
            recipe.AddTile(TileID.MythrilAnvil);

            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}