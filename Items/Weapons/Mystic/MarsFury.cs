using Laugicality.Items.Loot;
using Laugicality.Projectiles.Mystic.Conjuration;
using Laugicality.Projectiles.Mystic.Destruction;
using Laugicality.Projectiles.Mystic.Illusion;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using Laugicality.Projectiles.Special;

namespace Laugicality.Items.Weapons.Mystic
{
	public class MarsFury : MysticItem
    {
		public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Mars' Fury");
            Tooltip.SetDefault("A Furious War\nIllusion inflicts 'Furious', which deals damage over time and\nmakes enemies shoot fireballs when hit\nFires different projectiles based on Mysticism");
        }

		public override void SetMysticDefaults()
		{
            item.damage = 40;
            item.width = 66;
			item.height = 74;
			item.useTime = 18;
			item.useAnimation = 18;
			item.useStyle = 1;
			item.noMelee = false;
			item.knockBack = 2;
			item.value = Item.sellPrice(gold: 3);
			item.rare = ItemRarityID.Orange;
			item.UseSound = SoundID.Item20;
			item.autoReuse = true;
			item.shootSpeed = 6f;
            item.scale = 1f;
		}
        
        public override bool MysticShoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
        {
            LaugicalityPlayer modPlayer = LaugicalityPlayer.Get(player);
            if (modPlayer.MysticMode == 1)
            {
                int numberProjectiles = Main.rand.Next(2, 6);
                for (int i = 0; i < numberProjectiles; i++)
                {
                    Vector2 perturbedSpeed = new Vector2(speedX, speedY).RotatedByRandom(MathHelper.ToRadians(20));

                    float scale = 1f - (Main.rand.NextFloat() * .3f);
                    perturbedSpeed = perturbedSpeed * scale;
                    Projectile.NewProjectile(position.X, position.Y, perturbedSpeed.X, perturbedSpeed.Y, type, damage, knockBack, player.whoAmI);
                }
            }
            return true;
        }      

        public override void Destruction(LaugicalityPlayer modPlayer)
        {
            item.scale = 1.25f;
            item.damage = 44;
            item.useAnimation = item.useTime = 20;
            item.knockBack = 8;
            item.shootSpeed = 16f;
            item.shoot = ModContent.ProjectileType<MarsDestruction>();
            LuxCost = 6;
        }

        public override void Illusion(LaugicalityPlayer modPlayer)
        {
            item.scale = 1f;
            item.damage = 32;
            item.useTime = 10;
            item.useAnimation = 10;
            item.knockBack = 4;
            item.shootSpeed = 18f;
            item.shoot = ModContent.ProjectileType<MarsIllusion>();
            VisCost = 4;
        }

        public override void Conjuration(LaugicalityPlayer modPlayer)
        {
            item.scale = 1f;
            item.damage = 32;
            item.useTime = 38;
            item.useAnimation = 38;
            item.knockBack = 2;
            item.shootSpeed = 12f;
            item.shoot = ModContent.ProjectileType<MarsConjuration>();
            MundusCost = 20;
        }
        public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(null, "HadesJudgement", 1);
            recipe.AddRecipeGroup("TitaniumBars", 8);
            recipe.AddIngredient(ModContent.ItemType<SoulOfHaught>(), 8);
            recipe.AddIngredient(null, "MagmaticCluster");
            recipe.AddTile(TileID.MythrilAnvil);
			recipe.SetResult(this);
			recipe.AddRecipe();
            
        }
    }
}