using Laugicality.Dusts;
using Laugicality.Items.Materials;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Laugicality.Items.Weapons.Melee
{
	public class Scydian : LaugicalityItem
	{
		public override void SetStaticDefaults()
		{
			Tooltip.SetDefault("'The power of magma'\nBecomes stronger as you consume Obsidium Hearts");
		}

		public override void SetDefaults()
		{
            item.scale = 1.25f;
			item.damage = 60;
			item.melee = true;
			item.width = 64;
			item.height = 56;
			item.useTime = 40;
			item.useAnimation = 40;
			item.useStyle = 1;
			item.knockBack = 5;
            item.value = Item.sellPrice(gold: 1);
            item.rare = ItemRarityID.Orange;
            item.UseSound = SoundID.Item71;
			item.autoReuse = true;
        }

        public override void HoldItem(Player player)
        {
            LaugicalityPlayer modPlayer = LaugicalityPlayer.Get(player);
            item.useAnimation = item.useTime = 40 - modPlayer.ObsidiumHeart * 2;
            item.scale = 1.25f + .1f * modPlayer.ObsidiumHeart;
            base.HoldItem(player);
        }

        public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(mod, nameof(ObsidiumBar), 16);
			recipe.AddTile(16);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}

		public override void MeleeEffects(Player player, Rectangle hitbox)
		{
			if (Main.rand.Next(3) == 0)
			{
				int dust = Dust.NewDust(new Vector2(hitbox.X, hitbox.Y), hitbox.Width, hitbox.Height, ModContent.DustType<Magma>());
			}
		}

		public override void OnHitNPC(Player player, NPC target, int damage, float knockback, bool crit)
        {
            LaugicalityPlayer modPlayer = LaugicalityPlayer.Get(player);
            if (modPlayer.ObsidiumHeart > 0)
			    target.AddBuff(BuffID.OnFire, 2 * 60 + Main.rand.Next(60));
		}
	}
}
