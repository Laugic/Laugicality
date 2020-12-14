using Laugicality.Projectiles.Mystic.Conjuration;
using Laugicality.Projectiles.Mystic.Destruction;
using Laugicality.Projectiles.Mystic.Illusion;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;

namespace Laugicality.Items.Weapons.Mystic
{
	public class HermesFlight : MysticItem
    {
		public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Hermes' Flight");
            Tooltip.SetDefault("Weild the power of Hermes");
			Item.staff[item.type] = true;
		}

		public override void SetMysticDefaults()
		{
			item.damage = 20;
            item.width = 28;
			item.height = 28;
			item.useTime = 18;
			item.useAnimation = 18;
			item.useStyle = 5;
			item.noMelee = true;
			item.knockBack = 2;
            item.value = Item.sellPrice(silver: 40);
            item.rare = ItemRarityID.Blue;
            item.UseSound = SoundID.Item20;
			item.autoReuse = true;
			item.shoot = ModContent.ProjectileType<HermesDestruction>();
			item.shootSpeed = 6f;
        }

        public override string GetExtraTooltip()
        {
            LaugicalityPlayer laugicalityPlayer = LaugicalityPlayer.Get();

            switch (laugicalityPlayer.MysticMode)
            {
                case 1:
                    return "Shoots a burst of feathers";
                case 2:
                    return "Shoots gusts of wind that inflict 'Aerial weakness',\nwhich makes enemies take more damage when you are above them";
                case 3:
                    return "Shoots feathers that orbit you";
                default:
                    return "";
            }
        }

        public override bool MysticShoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
        {
            LaugicalityPlayer modPlayer = LaugicalityPlayer.Get(player);
            if (modPlayer.MysticMode == 1)
            {
                int numberProjectiles = Main.rand.Next(2, 4);
                for (int i = 0; i < numberProjectiles; i++)
                {
                    Vector2 perturbedSpeed = new Vector2(speedX, speedY).RotatedByRandom(MathHelper.ToRadians(10));
                    float scale = 1f - (Main.rand.NextFloat() * .3f);
                    perturbedSpeed = perturbedSpeed * scale;
                    Projectile.NewProjectile(position.X, position.Y, perturbedSpeed.X, perturbedSpeed.Y, ModContent.ProjectileType<HermesDestruction>(), damage, knockBack, player.whoAmI);
                }
            }
            return true;
        }

        public override void Destruction(LaugicalityPlayer modPlayer)
        {
            item.damage = 15;
            item.useTime = 30;
            item.useAnimation = item.useTime;
            item.knockBack = 4;
            item.shootSpeed = 12;
            item.shoot = ModContent.ProjectileType<HermesDestruction>();
            LuxCost = 10;
        }

        public override void Illusion(LaugicalityPlayer modPlayer)
        {
            item.damage = 22;
            item.useTime = 30;
            item.useAnimation = item.useTime;
            item.knockBack = 2;
            item.shootSpeed = 8f;
            item.shoot = ModContent.ProjectileType<HermesIllusion>();
            VisCost = 10;
        }

        public override void Conjuration(LaugicalityPlayer modPlayer)
        {
            item.damage = 15;
            item.useTime = 15;
            item.useAnimation = item.useTime;
            item.knockBack = 5;
            item.shootSpeed = 8f;
            item.shoot = ModContent.ProjectileType<HermesConjuration>();
            MundusCost = 5;
        }

        public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.Wood, 12);
            recipe.anyWood = true;
            recipe.AddIngredient(ItemID.Feather, 4);
            recipe.AddIngredient(ItemID.FallenStar, 2);
            recipe.AddTile(16);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
    }
}