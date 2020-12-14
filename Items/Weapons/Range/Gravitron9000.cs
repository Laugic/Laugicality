using Laugicality.Items.Loot;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Laugicality.Items.Materials;
using Laugicality.Projectiles.Ranged;
using Laugicality.Items.Accessories;

namespace Laugicality.Items.Weapons.Range
{
    public class Gravitron9000 : LaugicalityItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Gravitron 9000");
            Tooltip.SetDefault("33% chance to not consume ammo\nConverts normal snowballs and iceballs into Anti-Iceballs");
        }

        public override void SetDefaults()
        {
            item.damage = 42;
            item.ranged = true;
            item.width = 50;
            item.height = 26;
            item.useAnimation = item.useTime = 10;
            item.useStyle = 5;
            item.noMelee = true;
            item.knockBack = 2;
            item.value = Item.sellPrice(gold: 7);
            item.rare = ItemRarityID.Lime;
            item.UseSound = SoundID.Item11;
            item.autoReuse = true;
            item.shootSpeed = 12f;
            item.useAmmo = AmmoID.Snowball;
            item.shoot = ProjectileID.SnowBallFriendly;
        }

        public override bool ConsumeAmmo(Player player)
        {
            if (Main.rand.Next(3) == 0)
                return false;
            return base.ConsumeAmmo(player);
        }
        public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
        {
            Vector2 muzzleOffset = Vector2.Normalize(new Vector2(speedX, speedY)) * 45f;
            if (Collision.CanHit(position, 0, 0, position + muzzleOffset, 0, 0))
            {
                position += muzzleOffset;
                position.Y -= 5;
            }

            Vector2 perturbedSpeed = new Vector2(speedX, speedY).RotatedByRandom(MathHelper.ToRadians(10));
            float scale = 1f - (Main.rand.NextFloat() * .2f);
            perturbedSpeed = perturbedSpeed * scale;
            if (type == ProjectileID.SnowBallFriendly || type == ModContent.ProjectileType<IceBallProjectile>())
                type = ModContent.ProjectileType<AntiIceballProjectile>();
            Projectile.NewProjectile(position.X, position.Y, perturbedSpeed.X, perturbedSpeed.Y, type, damage, knockBack, player.whoAmI);

            return false;
        }


        public override Vector2? HoldoutOffset()
        {
            return new Vector2(-8, -8);
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.HallowedBar, 16);
            recipe.AddIngredient(ModContent.ItemType<SoulOfSought>(), 12);
            recipe.AddIngredient(ModContent.ItemType<GravitationGem>(), 1);
            recipe.AddTile(TileID.MythrilAnvil);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}