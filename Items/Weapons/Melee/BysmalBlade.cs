using Laugicality.Buffs;
using Laugicality.Items.Loot;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Laugicality.Items.Weapons.Melee
{
	public class BysmalBlade : LaugicalityItem
	{
		public override void SetStaticDefaults()
		{
			Tooltip.SetDefault("'A chill like no other' \nInflicts 'Frostbite'.\nWhile in the Etherial after defeating Etheria, increased size and swing speed");
		}

		public override void SetDefaults()
		{
            item.scale = 2.5f;
			item.damage = 315;
			item.melee = true;
			item.width = 144;
			item.height = 144;
			item.useTime = 15;
			item.useAnimation = 15;
			item.useStyle = 1;
			item.knockBack = 6;
            item.value = 10000;
			item.rare = ItemRarityID.Lime;
			item.UseSound = SoundID.Item71;
            item.autoReuse = true;
        }

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(null, "BysmalBar", 12);
            recipe.AddIngredient(mod, nameof(EtherialEssence), 5);
            recipe.AddTile(null, "AlchemicalInfuser");
            recipe.SetResult(this);
			recipe.AddRecipe();
		}

        public override void HoldItem(Player player)
        {
            if((LaugicalityWorld.downedEtheria || LaugicalityPlayer.Get(player).Etherable > 0) && LaugicalityWorld.downedTrueEtheria)
            {
                item.scale = 3.5f;
                item.useTime = 12;
                item.useAnimation = 12;
            }
            else
            {
                item.scale = 2.5f;
                item.useTime = 15;
                item.useAnimation = 15;
            }
        }

        public override void OnHitNPC(Player player, NPC target, int damage, float knockback, bool crit)
		{
            target.AddBuff(ModContent.BuffType<Frostbite>(), 5 * 60);
        }
	}
}
