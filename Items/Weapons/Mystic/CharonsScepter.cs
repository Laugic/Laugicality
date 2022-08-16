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
    public class CharonsScepter : MysticItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Charon's Scepter");
            Tooltip.SetDefault("Pay the toll");
            Item.staff[item.type] = true;
        }

        public override void SetMysticDefaults()
        {
            item.damage = 32;
            item.width = 58;
            item.height = 58;
            item.useTime = 30;
            item.useAnimation = 30;
            item.useStyle = 5;
            item.noMelee = true;
            item.useStyle = 5;
            item.knockBack = 2;
            item.value = 10000;
            item.rare = ItemRarityID.Orange;
            item.UseSound = SoundID.Item20;
            item.autoReuse = true;
            item.shootSpeed = 12f;
            item.shoot = ModContent.ProjectileType<AgnesDestruction>();
        }


        public override string GetExtraTooltip()
        {
            LaugicalityPlayer laugicalityPlayer = LaugicalityPlayer.Get();

            switch (laugicalityPlayer.MysticMode)
            {
                case 1:
                    return "Shoots a shotgun of bones";
                case 2:
                    return "Shoots a bouncing spiked ball that inflict 'Undeath', which \nmakes enemies spawn powerful shadows on death";
                case 3:
                    return "Create an orbiting spikeball";
                default:
                    return "";
            }
        }

        public override bool MysticShoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
        {
            Vector2 muzzleOffset = Vector2.Normalize(new Vector2(speedX, speedY)) * 48f;
            if (Collision.CanHit(position, 0, 0, position + muzzleOffset, 0, 0))
                position += muzzleOffset;
            LaugicalityPlayer modPlayer = LaugicalityPlayer.Get(player);
            if (modPlayer.MysticMode == 1)
            {
                int numberProjectiles = Main.rand.Next(4, 7);
                for (int i = 0; i < numberProjectiles; i++)
                {
                    Vector2 perturbedSpeed = new Vector2(speedX, speedY).RotatedByRandom(MathHelper.ToRadians(10));

                    float scale = 1f - (Main.rand.NextFloat() * .3f);
                    perturbedSpeed = perturbedSpeed * scale;
                    Projectile.NewProjectile(position.X, position.Y, perturbedSpeed.X, perturbedSpeed.Y, type, damage, knockBack, player.whoAmI);
                }
                return false;
            }
            return true;
        }

        public override void Destruction(LaugicalityPlayer modPlayer)
        {
            item.damage = 24;
            item.useAnimation = item.useTime = 30;
            item.knockBack = 8;
            item.shootSpeed = 8f;
            item.shoot = ModContent.ProjectileType<CharonDestruction>();
            LuxCost = 10;
        }

        public override void Illusion(LaugicalityPlayer modPlayer)
        {
            item.damage = 28;
            item.useAnimation = item.useTime = 21;
            item.knockBack = 8;
            item.shootSpeed = 8f;
            item.useStyle = 5;
            item.shoot = ModContent.ProjectileType<CharonIllusion>();
            VisCost = 33;
        }

        public override void Conjuration(LaugicalityPlayer modPlayer)
        {
            item.damage = 28;
            item.useAnimation = item.useTime = 60;
            item.knockBack = 2;
            item.shootSpeed = 8f;
            item.useStyle = 1;
            item.shoot = ModContent.ProjectileType<CharonConjuration>();
            MundusCost = 40;
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.Bone, 30);
            recipe.AddIngredient(ItemID.GoldenKey, 1);
            recipe.AddIngredient(ItemID.GoldCoin, 1);
            recipe.AddTile(TileID.BewitchingTable);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}