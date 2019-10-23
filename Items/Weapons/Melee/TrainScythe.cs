using Laugicality.Buffs;
using Laugicality.Dusts;
using Laugicality.Items.Loot;
using Laugicality.Items.Materials;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Laugicality.Items.Weapons.Melee
{
	public class TrainScythe : LaugicalityItem
	{
		public override void SetStaticDefaults()
		{
			Tooltip.SetDefault("CHOO CHOO! \nInflicts 'Steamy'");
		}

		public override void SetDefaults()
		{
            item.scale = 3f;
			item.damage = 832;
			item.melee = true;
			item.width = 144;
			item.height = 144;
			item.useTime = 55;
			item.useAnimation = 55;
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
			recipe.AddIngredient(mod, nameof(SteamBar), 16);
            recipe.AddIngredient(mod, nameof(SoulOfWrought), 8);
            recipe.AddIngredient(mod, nameof(Gear), 8);
            recipe.AddTile(TileID.MythrilAnvil);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}

		public override void MeleeEffects(Player player, Rectangle hitbox)
		{
			if (Main.rand.Next(2) == 0)
			{
				int dust = Dust.NewDust(new Vector2(hitbox.X, hitbox.Y), hitbox.Width, hitbox.Height, ModContent.DustType<Steam>());
			}
		}

		public override void OnHitNPC(Player player, NPC target, int damage, float knockback, bool crit)
		{
			target.AddBuff(ModContent.BuffType<Steamy>(), 2 * 60);
		}
	}
}
