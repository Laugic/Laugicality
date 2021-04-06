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
    public class Snowtillery : LaugicalityItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Snowtillery");
            Tooltip.SetDefault("Shoots snow rockets that push the player as well");
        }

        public override void SetDefaults()
        {
            item.damage = 20;
            item.ranged = true;
            item.width = 50;
            item.height = 26;
            item.useTime = 14;
            item.useAnimation = 6 * item.useTime;
            item.useStyle = 5;
            item.noMelee = true;
            item.knockBack = 12;
            item.value = Item.sellPrice(gold: 2);
            item.rare = ItemRarityID.Green;
            item.UseSound = SoundID.Item11;
            item.autoReuse = true;
            item.shootSpeed = .15f;
            item.useAmmo = AmmoID.Snowball;
            item.shoot = ModContent.ProjectileType<SnowRocket>();
        }
        public override bool ConsumeAmmo(Player player)
        {
            return player.itemAnimation >= item.useAnimation - 4 * item.useTime;
        }

        public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
        {
            Vector2 muzzleOffset = Vector2.Normalize(new Vector2(speedX, speedY)) * 20f;
            if (Collision.CanHit(position, 0, 0, position + muzzleOffset, 0, 0))
            {
                position += muzzleOffset;
            }
            if (player.itemAnimation >= item.useAnimation - 4 * item.useTime)
            {
                Main.PlaySound(2, player.Center, 11);
                type = ModContent.ProjectileType<SnowRocket>();
                Projectile.NewProjectile(position.X, position.Y, speedX, speedY, type, damage, knockBack, player.whoAmI);
            }
            return false;
        }


        public override Vector2? HoldoutOffset()
        {
            return new Vector2(-8, 8);
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.SnowballCannon, 1);
            recipe.AddIngredient(ItemID.IllegalGunParts, 1);
            recipe.AddTile(TileID.TinkerersWorkbench);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}