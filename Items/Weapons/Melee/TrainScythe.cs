using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Laugicality.Items.Weapons.Melee
{
	public class TrainScythe : ModItem
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
			item.rare = 7;
			item.UseSound = SoundID.Item71;
			item.autoReuse = true;
        }

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(null, "SteamBar", 16);
            recipe.AddIngredient(null, "SoulOfWrought", 8);
            recipe.AddIngredient(null, "Gear", 8);
            recipe.AddTile(134);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}

		public override void MeleeEffects(Player player, Rectangle hitbox)
		{
			if (Main.rand.Next(2) == 0)
			{
				int dust = Dust.NewDust(new Vector2(hitbox.X, hitbox.Y), hitbox.Width, hitbox.Height, mod.DustType("Steam"));
			}
		}

		public override void OnHitNPC(Player player, NPC target, int damage, float knockback, bool crit)
		{
			target.AddBuff(mod.BuffType("Steamy"), 2 * 60);
		}
	}
}
