using Laugicality.Items.Loot;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Laugicality.Items.Materials;
using System;

namespace Laugicality.Items.Weapons.Range
{
    public class SpineChiller : LaugicalityItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Spine Chiller");
            Tooltip.SetDefault("Shoots in an area around your cursor\n80% chance not to consume ammo");
        }

        public override void SetDefaults()
        {
            item.damage = 50;
            item.ranged = true;
            item.width = 50;
            item.height = 26;
            item.useAnimation = 30;
            item.useTime = 4;
            item.useStyle = 5;
            item.noMelee = true;
            item.knockBack = 2;
            item.value = Item.sellPrice(gold: 10);
            item.rare = ItemRarityID.Yellow;
            item.UseSound = SoundID.Item5;
            item.autoReuse = true;
            item.shootSpeed = 16f;
            item.useAmmo = AmmoID.Snowball;
            item.shoot = ProjectileID.SnowBallFriendly;
        }

        public override bool ConsumeAmmo(Player player)
        {
            return Main.rand.NextFloat() >= .8f;
        }

        public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
        {
            float theta = (float)Main.rand.NextDouble() * 3.14f * 2;
            float mag = 50;
            Projectile.NewProjectile((int)(Main.MouseWorld.X) + (int)(mag * Math.Cos(theta)), player.position.Y - 600 - Math.Abs((int)(mag * Math.Sin(theta))), -3 + 6 * (float)Main.rand.NextDouble(), 8 + 2 * Math.Abs((float)Math.Sin(theta)), type, damage, 3, Main.myPlayer);
            return false;
        }

        public override Vector2? HoldoutOffset()
        {
            return new Vector2(-5, 0);
        }
    }
}