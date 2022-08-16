using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using System;
using Laugicality.Projectiles.Mystic.Conjuration;
using Laugicality.Projectiles.Mystic.Destruction;
using Laugicality.Projectiles.Mystic.Illusion;
using Microsoft.Xna.Framework;
using Laugicality.Projectiles.Special;

namespace Laugicality.Items.Weapons.Mystic
{
	public class FriggsPhalanx : MysticItem
    {
		public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Frigg's Phalanx");
            Tooltip.SetDefault("'The swarm cometh'");
			Item.staff[item.type] = true;
		}

        public override void SetMysticDefaults()
		{
			item.damage = 25;
            item.width = 48;
			item.height = 48;
			item.useTime = 18;
			item.useAnimation = 18;
			item.useStyle = 5;
			item.noMelee = true;
			item.knockBack = 2;
			item.value = 10000;
			item.rare = ItemRarityID.Blue;
			item.UseSound = SoundID.Item20;
			item.autoReuse = true;
			item.shoot = ModContent.ProjectileType<Nothing>();
			item.shootSpeed = 6f;
        }

        public override string GetExtraTooltip()
        {
            LaugicalityPlayer laugicalityPlayer = LaugicalityPlayer.Get();

            switch (laugicalityPlayer.MysticMode)
            {
                case 1:
                    return "Shoots a spread of bees and spores";
                case 2:
                    return "Shoots spore clouds that inflict 'Pollinated', \nwhich makes bees deal more damage and be consumed on hit";
                case 3:
                    return "Spawns a hive that shoots bees";
                default:
                    return "";
            }
        }

        public override bool MysticShoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
        {
            LaugicalityPlayer modPlayer = LaugicalityPlayer.Get(player);
            if (modPlayer.MysticMode == 1)
            {
                int numberProjectiles = 2 + Main.rand.Next(1, 4);
                for (int i = 0; i < numberProjectiles; i++)
                {
                    Vector2 perturbedSpeed = new Vector2(speedX, speedY).RotatedByRandom(MathHelper.ToRadians(10));
                    float scale = 1f - (Main.rand.NextFloat() * .3f);
                    perturbedSpeed = perturbedSpeed * scale;
                    if(Main.rand.Next(3) == 0)
                    {
                        if(player.strongBees && Main.rand.Next(3) == 0)
                            Projectile.NewProjectile(position.X, position.Y, perturbedSpeed.X, perturbedSpeed.Y, ProjectileID.GiantBee, (int)(damage * 1.5), knockBack, player.whoAmI);
                        else
                            Projectile.NewProjectile(position.X, position.Y, perturbedSpeed.X, perturbedSpeed.Y, ProjectileID.Bee, damage, knockBack, player.whoAmI);
                    }
                    else
                        Projectile.NewProjectile(position.X, position.Y, perturbedSpeed.X, perturbedSpeed.Y, ModContent.ProjectileType<FriggDestruction>(), damage, knockBack, player.whoAmI);
                }
            }
            if(modPlayer.MysticMode == 2)
            {
                float theta = (float)Main.rand.NextDouble() * 3.14f * 2;
                float mag = 360;
                Projectile.NewProjectile((int)(Main.MouseWorld.X) + (int)(mag * Math.Cos(theta)), (int)(Main.MouseWorld.Y) + (int)(mag * Math.Sin(theta)), -4 * (float)Math.Cos(theta), -4 * (float)Math.Sin(theta), ModContent.ProjectileType<FriggIllusion>(), damage, 3, Main.myPlayer);
            }
            return true;
        }

        public override void Destruction(LaugicalityPlayer modPlayer)
        {
            item.damage = 20;
            item.useTime = 20;
            item.useAnimation = item.useTime;
            item.knockBack = 1f;
            item.shootSpeed = 10;
            item.shoot = ModContent.ProjectileType<Nothing>();
            LuxCost = 8;
        }

        public override void Illusion(LaugicalityPlayer modPlayer)
        {
            item.damage = 25;
            item.useTime = 15;
            item.useAnimation = 15;
            item.knockBack = 1;
            item.shootSpeed = 8f;
            item.shoot = ModContent.ProjectileType<Nothing>();
            VisCost = 5;
        }

        public override void Conjuration(LaugicalityPlayer modPlayer)
        {
            item.damage = 20;
            item.useTime = 50;
            item.useAnimation = 50;
            item.knockBack = 5;
            item.shootSpeed = 2f;
            item.shoot = ModContent.ProjectileType<FriggConjuration>();
            MundusCost = 16;
        }

        public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(331, 10);
            recipe.AddIngredient(2431, 8);
            recipe.AddTile(16);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
    }
}