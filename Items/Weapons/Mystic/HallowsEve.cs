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
	public class HallowsEve : MysticItem
    {
		public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Hallow's Eve");
             Tooltip.SetDefault("'The spirits of the darkness are bent to your will'");
            Item.staff[item.type] = true;
        }

        public override void SetMysticDefaults()
		{
			item.damage = 55;
            item.width = 116;
			item.height = 122;
			item.useTime = 18;
			item.useAnimation = 18;
			item.useStyle = 5;
			item.noMelee = true; 
			item.knockBack = 2;
            item.value = Item.sellPrice(gold: 10);
            item.rare = ItemRarityID.Yellow;
			item.UseSound = SoundID.Item1;
			item.autoReuse = true;
			item.shootSpeed = 6f;
            item.scale = .75f;
        }

        public override string GetExtraTooltip()
        {
            LaugicalityPlayer laugicalityPlayer = LaugicalityPlayer.Get();

            switch (laugicalityPlayer.MysticMode)
            {
                case 1:
                    return "Shoots a burst of skulls that follow your mouse";
                case 2:
                    return "Shoots an orb with a fire trail that inflicts 'Spooked', which\nmakes enemies take more damage for each unique thing that hits them";
                case 3:
                    return "Creates Jack-o-lanterns that shoot at nearby enemies";
                default:
                    return "";
            }
        }

        public override bool MysticShoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
        {
            LaugicalityPlayer modPlayer = LaugicalityPlayer.Get(player);
            if (modPlayer.MysticMode == 1)
            {
				Projectile.NewProjectile(player.Center.X, player.Center.Y, 0f, 8f, ModContent.ProjectileType<HallowsEveDestruction1>(), damage, 3f, player.whoAmI);
				Projectile.NewProjectile(player.Center.X, player.Center.Y, 0f, -8f, ModContent.ProjectileType<HallowsEveDestruction1>(), damage, 3f, player.whoAmI);
				Projectile.NewProjectile(player.Center.X, player.Center.Y, 8f, 0f, ModContent.ProjectileType<HallowsEveDestruction1>(), damage, 3f, player.whoAmI);
				Projectile.NewProjectile(player.Center.X, player.Center.Y, -8f, 0f, ModContent.ProjectileType<HallowsEveDestruction1>(), damage, 3f, player.whoAmI);
				Projectile.NewProjectile(player.Center.X, player.Center.Y, 6f, 6f, ModContent.ProjectileType<HallowsEveDestruction2>(), damage, 3f, player.whoAmI);
				Projectile.NewProjectile(player.Center.X, player.Center.Y, -6f, -6f, ModContent.ProjectileType<HallowsEveDestruction2>(), damage, 3f, player.whoAmI);
				Projectile.NewProjectile(player.Center.X, player.Center.Y, 6f, -6f, ModContent.ProjectileType<HallowsEveDestruction2>(), damage, 3f, player.whoAmI);
				Projectile.NewProjectile(player.Center.X, player.Center.Y, -6f, 6f, ModContent.ProjectileType<HallowsEveDestruction2>(), damage, 3f, player.whoAmI);
                return false;
            }
            return true;
        }

        public override void Destruction(LaugicalityPlayer modPlayer)
        {
            item.damage = 55;
            item.useTime = 28;
            item.useAnimation = (int)(item.useTime);
            item.knockBack = 0;
            item.shootSpeed = 14f;
            item.shoot = ModContent.ProjectileType<Nothing>();
            item.UseSound = SoundID.Item1;
            LuxCost = 10;
        }

        public override void Illusion(LaugicalityPlayer modPlayer)
        {
            item.damage = 55;
            item.useTime = 14;
            item.useAnimation = item.useTime;
            item.knockBack = 5;
            item.shootSpeed = 10f;
            item.shoot = ModContent.ProjectileType<HallowsEveIllusion1>();
            item.noUseGraphic = false;
            item.UseSound = SoundID.Item1;
            VisCost = 8;
        }

        public override void Conjuration(LaugicalityPlayer modPlayer)
        {
            item.damage = 55;
            item.useTime = 30;
            item.useAnimation = item.useTime;
            item.knockBack = 2;
            item.shootSpeed = 8f;
            item.shoot = ModContent.ProjectileType<HallowsEveConjuration1>();
            item.noUseGraphic = false;
            item.UseSound = SoundID.Item1;
            MundusCost = 15;
        }

       


        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.SpookyWood, 40);
            recipe.AddIngredient(ItemID.Pumpkin, 12);
            recipe.AddIngredient(ItemID.Ectoplasm, 8);
            recipe.AddIngredient(mod, nameof(SoulOfHaught), 8);
            recipe.AddTile(TileID.MythrilAnvil);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}