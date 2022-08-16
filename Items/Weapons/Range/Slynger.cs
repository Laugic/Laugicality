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
    public class Slynger : LaugicalityItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Slynger");
            Tooltip.SetDefault("Converts normal snowballs into Clusterballs");
        }

        public override void SetDefaults()
        {
            item.damage = 40;
            item.crit = 20;
            item.ranged = true;
            item.width = 50;
            item.height = 26;
            item.useTime = 20;
            item.useAnimation = 4 * item.useTime;
            item.useStyle = 5;
            item.noMelee = true;
            item.knockBack = 12;
            item.value = Item.sellPrice(gold: 10);
            item.rare = ItemRarityID.Yellow;
            item.UseSound = SoundID.Item11;
            item.autoReuse = true;
            item.shootSpeed = 24f;
            item.useAmmo = AmmoID.Snowball;
            item.shoot = ModContent.ProjectileType<SnowRocket>();
        }
        public override bool ConsumeAmmo(Player player)
        {
            return player.itemAnimation >= item.useAnimation - 3 * item.useTime;
        }

        public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
        {
            Vector2 muzzleOffset = Vector2.Normalize(new Vector2(speedX, speedY)) * 20f;
            if (Collision.CanHit(position, 0, 0, position + muzzleOffset, 0, 0))
            {
                position += muzzleOffset;
            }
            if (player.itemAnimation >= item.useAnimation - 3 * item.useTime)
            {
                Main.PlaySound(2, player.Center, 11);
                if(type == ProjectileID.SnowBallFriendly)
                    type = ModContent.ProjectileType<ClusterballProjectile>();
                for (int i = 0; i < 3; i++)
                {
                    Vector2 perturbedSpeed = new Vector2(speedX, speedY).RotatedByRandom(MathHelper.ToRadians(15));
                    float scale = 1f - (Main.rand.NextFloat() * .3f);
                    perturbedSpeed = perturbedSpeed * scale;
                    Projectile.NewProjectile(position.X, position.Y, perturbedSpeed.X, perturbedSpeed.Y, type, damage, knockBack, player.whoAmI);
                }
            }
            return false;
        }


        public override Vector2? HoldoutOffset()
        {
            return new Vector2(-8, -8);
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.Stynger, 1);
            recipe.AddIngredient(ItemID.EyeoftheGolem, 1);
            recipe.AddIngredient(ModContent.ItemType<Slinger>(), 3);
            recipe.AddTile(TileID.MythrilAnvil);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}