using Laugicality.Items.Loot;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Laugicality.Items.Materials;

namespace Laugicality.Items.Weapons.Range
{
    public class BlackIce : LaugicalityItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Black Ice");
            Tooltip.SetDefault("Fires faster in extreme heat\nFires more accurately in extreme cold\n50% chance not to consume ammo\n'They won't see it coming'");
        }

        public override void SetDefaults()
        {
            item.damage = 20;
            item.ranged = true;
            item.width = 50;
            item.height = 26;
            item.useTime = 12;
            item.useAnimation = 12;
            item.useStyle = 5;
            item.noMelee = true;
            item.knockBack = 2;
            item.value = Item.sellPrice(gold: 2);
            item.rare = ItemRarityID.Orange;
            item.UseSound = SoundID.Item11;
            item.autoReuse = true;
            item.shootSpeed = 15f;
            item.useAmmo = AmmoID.Snowball;
            item.shoot = ProjectileID.SnowBallFriendly;
        }

        public override void HoldItem(Player player)
        {
            LaugicalityPlayer modPlayer = LaugicalityPlayer.Get(player);
            item.useTime = item.useAnimation = 8;
            if(player.ZoneDesert || player.ZoneUnderworldHeight || modPlayer.zoneObsidium)
                item.useTime = item.useAnimation = 6;
        }

        public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
        {
            LaugicalityPlayer modPlayer = LaugicalityPlayer.Get(player);
            Vector2 muzzleOffset = Vector2.Normalize(new Vector2(speedX, speedY)) * 40f;
            if (Collision.CanHit(position, 0, 0, position + muzzleOffset, 0, 0))
            {
                position += muzzleOffset;
                position.X += -4 + Main.rand.Next(8);
                position.Y += -4 + Main.rand.Next(8);
            }
            for (int i = 0; i < 2; i++)
            {
                Vector2 perturbedSpeed = new Vector2(speedX, speedY);
                int spread = 24;
                if (player.ZoneDesert || player.ZoneUnderworldHeight || modPlayer.zoneObsidium)
                    perturbedSpeed *= 1.25f;
                if (player.ZoneSnow || player.ZoneSkyHeight || LaugicalityWorld.downedEtheria)
                {
                    spread = 10;
                }
                perturbedSpeed = perturbedSpeed.RotatedByRandom(MathHelper.ToRadians(spread));
                float scale = 1f - (Main.rand.NextFloat() * .3f);
                perturbedSpeed = perturbedSpeed * scale;
                Projectile.NewProjectile(position.X, position.Y, perturbedSpeed.X, perturbedSpeed.Y, type, damage, knockBack, player.whoAmI);
            }
            return false;
        }

        public override bool ConsumeAmmo(Player player)
        {
            if (Main.rand.Next(2) == 0)
                return false;
            return base.ConsumeAmmo(player);
        }

        public override Vector2? HoldoutOffset()
        {
            return new Vector2(-5, 5);
        }
    }
}