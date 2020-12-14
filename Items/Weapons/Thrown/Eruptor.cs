using Laugicality.Items.Loot;
using Laugicality.Items.Materials;
using Laugicality.Projectiles.Thrown;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Laugicality.Items.Weapons.Thrown
{
	public class Eruptor : LaugicalityItem
	{
		public override void SetStaticDefaults()
        {
            Tooltip.SetDefault("'For Fury'");
		}
        public int numShots = 1;
		public override void SetDefaults()
		{
            numShots = 3;
			item.damage = 32;
            item.thrown = true;
			item.width = 80;
			item.height = 44;
			item.useTime = 15;
			item.useAnimation = 15;
            item.useStyle = 1;
            item.noMelee = true;
			item.knockBack = 2;
			item.value = 10000;
			item.rare = ItemRarityID.LightRed;
			item.UseSound = SoundID.Item19;
			item.autoReuse = true;
			item.shootSpeed = 20f;
            item.shoot = ModContent.ProjectileType<EruptorProjectile>();
            item.noUseGraphic = true;
        }

        public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
        {
            numShots++;
            if (numShots > 6)
                numShots = 3;
            int numberProjectiles = numShots;
            for (int i = 0; i < numberProjectiles; i++)
            {
                Vector2 perturbedSpeed = new Vector2(speedX, speedY).RotatedByRandom(MathHelper.ToRadians(5+2*numShots));
                Projectile.NewProjectile(position.X, position.Y, perturbedSpeed.X, perturbedSpeed.Y, type, damage, knockBack, player.whoAmI);
            }
            return false; 
        }
        
        public override Vector2? HoldoutOffset()
        {
            return new Vector2(-26, 4);
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<Obshardian>(), 222);
            recipe.AddRecipeGroup("TitaniumBars", 8);
            recipe.AddIngredient(ModContent.ItemType<SoulOfHaught>(), 8);
            recipe.AddIngredient(null, "MagmaticCluster");
            recipe.AddTile(TileID.MythrilAnvil);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
	}
}