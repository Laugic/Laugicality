using Laugicality.Items.Loot;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using Laugicality.Projectiles.Special;

namespace Laugicality.Items.Weapons.Mystic
{
	public class MarsFury : MysticItem
    {
        int _counter = 0;
		public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Mars' Fury");
            Tooltip.SetDefault("A Furious War\nIllusion inflicts 'Furious', which deals damage over time and makes enemies explode into Magma Shards upon death\nFires different projectiles based on Mysticism");
        }

		public override void SetMysticDefaults()
		{
            _counter = 0;
            item.damage = 40;
            item.width = 66;
			item.height = 74;
			item.useTime = 18;
			item.useAnimation = 18;
			item.useStyle = 1;
			item.noMelee = false;
			item.knockBack = 2;
			item.value = 10000;
			item.rare = ItemRarityID.Orange;
			item.UseSound = SoundID.Item20;
			item.autoReuse = true;
			item.shootSpeed = 6f;
            item.scale = 1.5f;
		}
        
        public override bool MysticShoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
        {
            LaugicalityPlayer modPlayer = LaugicalityPlayer.Get(player);
            if(_counter > 0)
                _counter--;
            if (modPlayer.MysticMode == 2 && _counter <= 0)
            {
                Projectile.NewProjectile(player.Center.X, player.Center.Y, 0f, 8f, ModContent.ProjectileType("MarsIllusion"), damage, 3f, player.whoAmI);
                Projectile.NewProjectile(player.Center.X, player.Center.Y, 0f, -8f, ModContent.ProjectileType("MarsIllusion"), damage, 3f, player.whoAmI);
                Projectile.NewProjectile(player.Center.X, player.Center.Y, 8f, 0f, ModContent.ProjectileType("MarsIllusion"), damage, 3f, player.whoAmI);
                Projectile.NewProjectile(player.Center.X, player.Center.Y, -8f, 0f, ModContent.ProjectileType("MarsIllusion"), damage, 3f, player.whoAmI);
                Projectile.NewProjectile(player.Center.X, player.Center.Y, 6f, 6f, ModContent.ProjectileType("MarsIllusion"), damage, 3f, player.whoAmI);
                Projectile.NewProjectile(player.Center.X, player.Center.Y, -6f, -6f, ModContent.ProjectileType("MarsIllusion"), damage, 3f, player.whoAmI);
                Projectile.NewProjectile(player.Center.X, player.Center.Y, 6f, -6f, ModContent.ProjectileType("MarsIllusion"), damage, 3f, player.whoAmI);
                Projectile.NewProjectile(player.Center.X, player.Center.Y, -6f, 6f, ModContent.ProjectileType("MarsIllusion"), damage, 3f, player.whoAmI);
                _counter = 6;
            }
            return true;
        }      

        public override void Destruction(LaugicalityPlayer modPlayer)
        {
            item.scale = 1.5f;
            item.damage = 44;
            item.useTime = 30;
            item.useAnimation = item.useTime;
            item.knockBack = 8;
            item.shootSpeed = 4f;
            item.shoot = ModContent.ProjectileType<Nothing>();
        }

        public override void Illusion(LaugicalityPlayer modPlayer)
        {
            item.scale = 1f;
            item.damage = 32;
            item.useTime = 10;
            item.useAnimation = 10;
            item.knockBack = 4;
            item.shootSpeed = 12f;
            item.shoot = ModContent.ProjectileType<Nothing>();
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
            item.shoot = ModContent.ProjectileType("MarsConjuration");
            MundusCost = 20;
        }

        public override void OnHitNPC(Player player, NPC target, int damage, float knockback, bool crit)
        {
            LaugicalityPlayer modPlayer = LaugicalityPlayer.Get(player);
            LuxCost = 8;
            if (modPlayer.MysticMode == 1 && modPlayer.Lux >= LuxCost * modPlayer.LuxUseRate * modPlayer.GlobalPotentiaUseRate)
            {
                Projectile.NewProjectile(target.Center.X, target.Center.Y, 0f, 0f, ModContent.ProjectileType("MarsDestruction"), damage, knockback, Main.myPlayer);

                modPlayer.Lux -= LuxCost * modPlayer.LuxUseRate * modPlayer.GlobalPotentiaUseRate;
                if (modPlayer.Lux < 0)
                    modPlayer.Lux = 0;
                if (modPlayer.Lux > (modPlayer.LuxMax + modPlayer.LuxMaxPermaBoost) * modPlayer.LuxOverflow * modPlayer.GlobalOverflow)
                    modPlayer.Lux = (modPlayer.LuxMax + modPlayer.LuxMaxPermaBoost) * modPlayer.LuxOverflow * modPlayer.GlobalOverflow;
                modPlayer.Vis += LuxCost * modPlayer.GlobalAbsorbRate * modPlayer.VisAbsorbRate * modPlayer.LuxDischargeRate * modPlayer.LuxUseRate * modPlayer.GlobalPotentiaUseRate;
                if (modPlayer.Vis > (modPlayer.VisMax + modPlayer.VisMaxPermaBoost) * modPlayer.VisOverflow * modPlayer.GlobalOverflow)
                    modPlayer.Vis = (modPlayer.VisMax + modPlayer.VisMaxPermaBoost) * modPlayer.VisOverflow * modPlayer.GlobalOverflow;
                modPlayer.Mundus += LuxCost * modPlayer.GlobalAbsorbRate * modPlayer.MundusAbsorbRate * modPlayer.LuxDischargeRate * modPlayer.LuxUseRate * modPlayer.GlobalPotentiaUseRate;
                if (modPlayer.Mundus > (modPlayer.MundusMax + modPlayer.MundusMaxPermaBoost) * modPlayer.MundusOverflow * modPlayer.GlobalOverflow)
                    modPlayer.Mundus = (modPlayer.MundusMax + modPlayer.MundusMaxPermaBoost) * modPlayer.MundusOverflow * modPlayer.GlobalOverflow;

            }
            LuxCost = 0;
        }

        public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(null, "HadesJudgement", 1);
            recipe.AddIngredient(null, "MagmaticCluster");
            recipe.AddIngredient(null, "MagmaticCrystal", 4);
            recipe.AddIngredient(mod, nameof(SoulOfHaught), 8);
            recipe.AddRecipeGroup("TitaniumBars", 6);
            recipe.AddIngredient(null, "RubrumDust", 4);
            recipe.AddIngredient(null, "AlbusDust", 2);
            recipe.AddTile(TileID.MythrilAnvil);
			recipe.SetResult(this);
			recipe.AddRecipe();
            
        }
    }
}