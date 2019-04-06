using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;

namespace Laugicality.Items.Weapons.Mystic
{
	public class VulcansWrath : MysticItem
    {
		public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Vulcan's Wrath");
            Tooltip.AddLine("'Unleash his fury'");
            Tooltip.AddLine("Illusion inflicts 'Steamy'");
            Tooltip.AddLine("Fires different projectiles based on Mysticism");
        }

		public override void SetMysticDefaults()
		{
			item.damage = 48;
            item.width = 48;
			item.height = 48;
			item.useTime = 18;
			item.useAnimation = 18;
			item.useStyle = 1;
			item.noMelee = false; 
			item.knockBack = 2;
			item.value = 10000;
			item.rare = 3;
			item.UseSound = SoundID.Item1;
			item.autoReuse = true;
			item.shootSpeed = 6f;
		}

        public override bool MysticShoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
        {
            LaugicalityPlayer modPlayer = player.GetModPlayer<LaugicalityPlayer>(mod);
            if (modPlayer.MysticMode == 1)
            {
                int numberProjectiles = Main.rand.Next(2, 5);
                for (int i = 0; i < numberProjectiles; i++)
                {
                    Vector2 perturbedSpeed = new Vector2(speedX, speedY).RotatedByRandom(MathHelper.ToRadians(10)); 

                    float scale = 1f - (Main.rand.NextFloat() * .3f);
                    perturbedSpeed = perturbedSpeed * scale;
                    Projectile.NewProjectile(position.X, position.Y, perturbedSpeed.X, perturbedSpeed.Y, 242, damage, knockBack, player.whoAmI);
                }

            }
            return true;
        }

        public override void Destruction(LaugicalityPlayer modPlayer)
        {
            item.damage = 54;
            item.useTime = 32;
            item.useAnimation = (int)(item.useTime / 2);
            item.knockBack = 6;
            item.shootSpeed = 14f;
            item.shoot = 242;
            item.UseSound = SoundID.Item1;
            item.scale = 1.5f;
            LuxCost = 8;
        }

        public override void Illusion(LaugicalityPlayer modPlayer)
        {
            item.damage = 48;
            item.useTime = 10;
            item.useAnimation = item.useTime;
            item.knockBack = 5;
            item.shootSpeed = 18f;
            item.shoot = mod.ProjectileType("VulcanIllusion");
            item.noUseGraphic = false;
            item.UseSound = SoundID.Item1;
            item.scale = 1f;
            VisCost = 4;
        }

        public override void Conjuration(LaugicalityPlayer modPlayer)
        {
            item.damage = 48;
            item.useTime = 30;
            item.useAnimation = item.useTime;
            item.knockBack = 2;
            item.shootSpeed = 20f;
            item.shoot = mod.ProjectileType("VulcanConjuration");
            item.noUseGraphic = false;
            item.UseSound = SoundID.Item1;
            item.scale = 1f;
            MundusCost = 12;
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(null, "SteamBar", 16);
            recipe.AddIngredient(null, "SoulOfWrought", 8);
            recipe.AddIngredient(null, "SoulOfFraught", 8);
            recipe.AddIngredient(null, "Gear", 12);
            recipe.AddTile(134);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}