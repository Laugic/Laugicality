using Laugicality.Items.Loot;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Laugicality.Items.Armor
{
	[AutoloadEquip(EquipType.Head)]
	public class SteampunkHelmet : LaugicalityItem
	{
public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Steampunk Hat");
            Tooltip.SetDefault("+20% Mystic Damage");
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
            LaugicalityPlayer modPlayer = LaugicalityPlayer.Get(player);
            modPlayer.MysticDamage += .17f;
        }

        public override void UpdateArmorSet(Player player)
        {
            player.setBonus = "+200% Mystic Duration\nSwitching Mysticisms unleashes a burst of Steam\nDecreased Mystic Burst cooldown\nAttacks inflict 'Steamy!', which makes enemies take more damage";
            LaugicalityPlayer modPlayer = LaugicalityPlayer.Get(player);
            modPlayer.Steamified = true;
            modPlayer.MysticSteamBurst = true;
            modPlayer.MysticDuration += 2f;
            modPlayer.MysticSwitchCoolRate += 3;
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