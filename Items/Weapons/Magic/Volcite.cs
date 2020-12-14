using Laugicality.Items.Materials;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Laugicality.Items.Weapons.Magic
{
	public class Volcite : LaugicalityItem
	{
		public override void SetStaticDefaults()
		{
			Tooltip.SetDefault("'Volcanic Eruption'\nBecomes more powerful as you consume Obsidium Hearts");
			Item.staff[item.type] = true;
		}

		public override void SetDefaults()
		{
			item.damage = 34;
			item.magic = true;
			item.mana = 10;
			item.width = 28;
			item.height = 30;
			item.useAnimation = item.useTime = 20;
            item.useStyle = 5;
			item.noMelee = true;
			item.knockBack = 5;
			item.value = 10000;
			item.rare = ItemRarityID.Orange;
			item.UseSound = SoundID.Item20;
			item.autoReuse = true;
			item.shoot = ModContent.ProjectileType<Projectiles.Magic.VolciteProjectile>();
			item.shootSpeed = 18f;
        }

        public override void HoldItem(Player player)
        {
            LaugicalityPlayer modPlayer = LaugicalityPlayer.Get(player);
            item.useAnimation = item.useTime = 20 - modPlayer.ObsidiumHeart;
            base.HoldItem(player);
        }

        public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
        {
            LaugicalityPlayer modPlayer = LaugicalityPlayer.Get(player);
            int id = Projectile.NewProjectile(position.X, position.Y, speedX, speedY, type, damage, knockBack, Main.myPlayer);
            Main.projectile[id].ai[1] = modPlayer.ObsidiumHeart;
            return false;
        }

        public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(mod, nameof(ObsidiumBar), 16);
			recipe.AddTile(16);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}