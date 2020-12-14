using Laugicality.Items.Materials;
using Laugicality.Projectiles.Ranged;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Laugicality.Items.Weapons.Range
{
	public class ObsidiumGreatbow : LaugicalityItem
	{
		public override void SetStaticDefaults()
		{
			Tooltip.SetDefault("'Molten Frenzy'\n20% chance to not consume ammo\nBecomes stronger as you consume Obsidium Hearts");
		}

		public override void SetDefaults()
        {
            item.scale *= 1.2f;
            item.damage = 28;
			item.ranged = true;
			item.width = 20;
			item.height = 64;
			item.useAnimation = item.useTime = 30;
			item.useStyle = 5;
			item.noMelee = true; 
			item.knockBack = 3;
			item.value = 10000;
			item.rare = ItemRarityID.Orange;
			item.UseSound = SoundID.Item10;
			item.autoReuse = true;
			item.shoot = 10; 
			item.shootSpeed = 16f;
			item.useAmmo = AmmoID.Arrow;
        }

        public override void HoldItem(Player player)
        {
            LaugicalityPlayer modPlayer = LaugicalityPlayer.Get(player);
            item.useAnimation = item.useTime = 35 - modPlayer.ObsidiumHeart * 2;
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
        
		public override bool ConsumeAmmo(Player player)
		{
			return Main.rand.NextFloat() >= .20f;
		}
        
		public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
        {
            LaugicalityPlayer modPlayer = LaugicalityPlayer.Get(player);
            if (type == ProjectileID.WoodenArrowFriendly && modPlayer.ObsidiumHeart > 0) 
			{
				type = ModContent.ProjectileType<ObsidiumArrow>(); 
			}
            if (modPlayer.ObsidiumHeart >= 5)
            {
                Vector2 perturbedSpeed = new Vector2(speedX, speedY).RotatedByRandom(MathHelper.ToRadians(5));
                float scale = 1f - (Main.rand.NextFloat() * .3f);
                perturbedSpeed = perturbedSpeed * scale;
                Projectile.NewProjectile(position.X, position.Y, perturbedSpeed.X, perturbedSpeed.Y, type, damage, knockBack, player.whoAmI);
            }
            
            return true; 
		}
	}
}
