using Laugicality.Buffs;
using Laugicality.Items.Loot;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Laugicality.Projectiles.Summon;

namespace Laugicality.Items.Weapons.Summon
{
	public class Antenna : LaugicalityItem
	{
		public override void SetStaticDefaults()
		{
			Tooltip.SetDefault("Summons a TV to fight for you.");
		}

		public override void SetDefaults()
		{
			item.damage = 55;
			item.summon = true;
			item.mana = 16;
			item.width = 48;
			item.height = 48;
			item.useTime = 36;
			item.useAnimation = 36;
			item.useStyle = 1;
			item.noMelee = true;
			item.knockBack = 3;
			item.value = Item.buyPrice(0, 25, 0, 0);
			item.rare = ItemRarityID.Lime;
			item.UseSound = SoundID.Item44;
			item.shoot = mod.ProjectileType<TV>();
			item.shootSpeed = 12f;
			item.buffType = mod.BuffType(nameof(TVBuff));
			item.buffTime = 3600;
		}
		
		public override bool AltFunctionUse(Player player)
		{
			return true;
		}
		
		public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
		{
			return player.altFunctionUse != 2;
		}
		
		public override bool UseItem(Player player)
		{
			if(player.altFunctionUse == 2)
			{
				player.MinionNPCTargetAim();
			}
			return base.UseItem(player);
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddTile(TileID.MythrilAnvil);
            recipe.AddIngredient(mod, nameof(SteamBar), 12);
            recipe.AddIngredient(null, "SoulOfThought", 20);
            recipe.AddIngredient(1344, 40);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}
