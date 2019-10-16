using Laugicality.Items.Loot;
using Laugicality.Items.Materials;
using Laugicality.Projectiles.Magic;
using Microsoft.Xna.Framework;
using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Laugicality.Items.Weapons.Magic
{
    public class AncientStaff : LaugicalityItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Ancient Staff");
            Tooltip.SetDefault("'Crystilla Rain'");
            Item.staff[item.type] = true;
        }

        public override void SetDefaults()
        {
            item.damage = 24;
            item.magic = true;
            item.mana = 2;
            item.width = 28;
            item.height = 30;
            item.useTime = 10;
            item.useAnimation = 10;
            item.useStyle = 5;
            item.noMelee = true;
            item.knockBack = 5;
            item.value = 10000;
            item.rare = ItemRarityID.Orange;
            item.shoot = mod.ProjectileType<CrystillaShardProjectile>();
            item.UseSound = SoundID.Item20;
            item.autoReuse = true;
            item.shootSpeed = 4f;
        }

        public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
        {
            float theta = (float)Main.rand.NextDouble() * 3.14f / 6 + 3.14f * 255f / 180f;
            float mag = 600;
            Projectile.NewProjectile((int)(Main.MouseWorld.X + Main.rand.Next(-40, 40)) + (int)(mag * Math.Cos(theta)), (int)(player.position.Y) + (int)(mag * Math.Sin(theta)), -15 * (float)Math.Cos(theta), -15 * (float)Math.Sin(theta), mod.ProjectileType<CrystillaShardProjectile>(), damage, 3, Main.myPlayer);
            theta = (float)Main.rand.NextDouble() * 3.14f / 6 + 3.14f * 255f / 180f;
            mag = 700;
            Projectile.NewProjectile((int)(Main.MouseWorld.X + Main.rand.Next(-40, 40)) + (int)(mag * Math.Cos(theta)), (int)(player.position.Y) + (int)(mag * Math.Sin(theta)), -15 * (float)Math.Cos(theta), -15 * (float)Math.Sin(theta), mod.ProjectileType<CrystillaShardProjectile>(), damage, 3, Main.myPlayer);
            return false;
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(mod, nameof(AncientShard), 1);
            recipe.AddIngredient(ItemID.FossilOre, 6);
            recipe.AddIngredient(mod, nameof(Crystilla), 6);
            recipe.AddTile(TileID.Anvils);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}