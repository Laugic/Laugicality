using Laugicality.Items.Materials;
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
    public class AgnesInferno : MysticItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Agnes' Inferno");
            Tooltip.SetDefault("Blaze of Glory\nIllusion inflicts 'On Fire'\nFires different projectiles based on Mysticism");
        }

        public override void SetMysticDefaults()
        {
            item.damage = 32;
            item.width = 60;
            item.height = 60;
            item.useTime = 30;
            item.useAnimation = 30;
            item.useStyle = 5;
            item.noMelee = true;
            item.knockBack = 2;
            item.value = 10000;
            item.rare = ItemRarityID.Orange;
            item.UseSound = SoundID.Item20;
            item.autoReuse = true;
            item.shootSpeed = 8f;
            item.shoot = ModContent.ProjectileType<AgnesDestruction>();
            item.scale = 1.5f;
        }
        /*
        public override bool CanUseItem(Player player)
        {
            LaugicalityPlayer modPlayer = LaugicalityPlayer.Get(player);
            if (modPlayer.MysticMode != 1)
                return player.ownedProjectileCounts[item.shoot] < 1;
            return true;
        }*/
        /*
        public override bool MysticShoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
        {
            LaugicalityPlayer modPlayer = LaugicalityPlayer.Get(player);
            if (modPlayer.MysticMode != 1)
                return true;
            return false;
        }
        */

        public override bool CanUseItem(Player player)
        {
            LaugicalityPlayer modPlayer = LaugicalityPlayer.Get(player);
            if (modPlayer.MysticMode == 1)
                return player.ownedProjectileCounts[item.shoot] < 1;
            return true;
        }
        public override bool MysticShoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
        {
            LaugicalityPlayer modPlayer = LaugicalityPlayer.Get(player);
            if (modPlayer.MysticMode == 1 && modPlayer.Lux >= LuxCost)
            {
                Projectile.NewProjectile(position.X, position.Y, speedX, speedY, ModContent.ProjectileType<AgnesDestruction2>(), damage, knockBack, player.whoAmI);
                return true;
            }
            return true;
        }

        public override void Destruction(LaugicalityPlayer modPlayer)
        {
            item.damage = 44;
            item.useAnimation = item.useTime = 30;
            item.knockBack = 8;
            item.shootSpeed = 8f;
            item.useTurn = true;
            item.noUseGraphic = true;
            item.useStyle = 5;
            item.shoot = ModContent.ProjectileType<AgnesDestruction>();
            LuxCost = 4;
        }

        public override void Illusion(LaugicalityPlayer modPlayer)
        {
            item.damage = 32;
            item.useTime = 20;
            item.useAnimation = 20;
            item.knockBack = 4;
            item.shootSpeed = 12f;
            item.useTurn = false;
            item.noUseGraphic = false;
            item.useStyle = 1;
            item.shoot = ModContent.ProjectileType<HadesIllusion>();
            VisCost = 8;
        }

        public override void Conjuration(LaugicalityPlayer modPlayer)
        {
            item.damage = 22;
            item.useTime = 65;
            item.useAnimation = 65;
            item.knockBack = 2;
            item.shootSpeed = 8f;
            item.useTurn = false;
            item.noUseGraphic = false;
            item.useStyle = 1;
            item.shoot = ModContent.ProjectileType<HadesConjuration>();
            MundusCost = 20;
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.HellstoneBar, 12);
            recipe.AddIngredient(mod, nameof(ObsidiumBar), 12);
            recipe.AddTile(TileID.Hellforge);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}