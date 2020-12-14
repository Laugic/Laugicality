using Laugicality.Items.Loot;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Laugicality.Items.Armor
{
	[AutoloadEquip(EquipType.Head)]
	public class SteampunkHeadgear : LaugicalityItem
	{
public override void SetStaticDefaults()
        {
            Tooltip.SetDefault("+20% Throwing Damage");
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


        public override void UpdateEquip(Player player)
        {
            player.thrownDamage += .2f;
        }

        public override void UpdateArmorSet(Player player)
        {
            player.setBonus = "+33% Throwing Velocity, \nAttacks inflict 'Steamy!' ";
            LaugicalityPlayer modPlayer = LaugicalityPlayer.Get(player);
            modPlayer.Steamified = true;
            player.thrownVelocity += .33f;
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