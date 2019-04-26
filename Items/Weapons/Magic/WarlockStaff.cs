using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;

namespace Laugicality.Items.Weapons.Magic
{
	public class WarlockStaff : LaugicalityItem
    {
        private int reload = 0;
        private int reloadMax = 12;
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Staff of The Enlightened Warlock");
            Tooltip.SetDefault("Ion Blast");
			Item.staff[item.type] = true;
		}

		public override void SetDefaults()
		{
			item.damage = 550;
			item.magic = true;
			item.mana = 6;
			item.width = 28;
			item.height = 30;
			item.useTime = 2;
			item.useAnimation = 24;
			item.useStyle = 5;
			item.noMelee = true;
			item.knockBack = 5;
			item.value = 10000;
			item.rare = ItemRarityID.Cyan;
			item.UseSound = SoundID.Item20;
			item.autoReuse = true;
			item.shoot = mod.ProjectileType("WarlockStaff3");
			item.shootSpeed = 36f;
		}

        public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
        {
            reload--;
            Vector2 target = Main.MouseWorld;
            Vector2 vel = player.DirectionTo(target) * item.shootSpeed;
            if (reload <= 0)
            {
                reload = reloadMax;
                Projectile.NewProjectile(player.Center.X, player.Center.Y, vel.X, vel.Y, mod.ProjectileType("WarlockStaff1"), (int)(item.damage) * 4, 3, Main.myPlayer);
            }
            return true;
        }/*
        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(3467, 16);
            recipe.AddIngredient(3457, 8);
            recipe.AddTile(412);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }*/
    }
}