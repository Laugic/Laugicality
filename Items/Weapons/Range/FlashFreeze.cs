using Laugicality.Items.Loot;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Laugicality.Items.Materials;
using Laugicality.Projectiles.Ranged;

namespace Laugicality.Items.Weapons.Range
{
    public class FlashFreeze : LaugicalityItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Flash Freeze");
            Tooltip.SetDefault("Chance to enlarge snowballs");
        }

        public override void SetDefaults()
        {
            item.damage = 28;
            item.ranged = true;
            item.width = 50;
            item.height = 26;
            item.useAnimation = item.useTime = 10;
            item.useStyle = 5;
            item.noMelee = true;
            item.knockBack = 2;
            item.value = Item.sellPrice(gold: 5);
            item.rare = ItemRarityID.LightRed;
            item.UseSound = SoundID.Item11;
            item.autoReuse = true;
            item.shootSpeed = 12f;
            item.useAmmo = AmmoID.Snowball;
            item.shoot = ProjectileID.SnowBallFriendly;
        }

        public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
        {
            Vector2 muzzleOffset = Vector2.Normalize(new Vector2(speedX, speedY)) * 40f;
            muzzleOffset.Y -= 6;
            Vector2 perturbedSpeed = new Vector2(speedX, speedY).RotatedByRandom(MathHelper.ToRadians(4));
            if (Main.rand.Next(4) == 0)
            {
                perturbedSpeed.Y -= 4;
                position.Y -= 4;
                Projectile.NewProjectile(position + muzzleOffset, perturbedSpeed, ModContent.ProjectileType<BigSnowballProjectile>(), damage, knockBack, player.whoAmI, type);
            }
            else
                Projectile.NewProjectile(position + muzzleOffset, perturbedSpeed, type, damage, knockBack, player.whoAmI);
            return false;
        }

        public override Vector2? HoldoutOffset()
        {
            return new Vector2(-24, -8);
        }
    }
}