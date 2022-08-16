using Laugicality.Items.Loot;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Laugicality.Items.Materials;
using Laugicality.Projectiles.Ranged;

namespace Laugicality.Items.Weapons.Range
{
    public class Hailmaker : LaugicalityItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Hailmaker");
            Tooltip.SetDefault("Shoots big snowballs that rain more snowballs");
        }

        public override void SetDefaults()
        {
            item.damage = 16;
            item.ranged = true;
            item.width = 50;
            item.height = 26;
            item.useAnimation = item.useTime = 30;
            item.useStyle = 5;
            item.noMelee = true;
            item.knockBack = 2;
            item.value = Item.sellPrice(gold: 1);
            item.rare = ItemRarityID.Green;
            item.UseSound = SoundID.Item13;
            item.autoReuse = true;
            item.shootSpeed = 13f;
            item.useAmmo = AmmoID.Snowball;
            item.shoot = ProjectileID.SnowBallFriendly;
        }

        public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
        {
            Projectile.NewProjectile(position, new Vector2(speedX, speedY), ModContent.ProjectileType<BigHail>(), damage, knockBack, player.whoAmI, type);
            return false;
        }

        public override Vector2? HoldoutOffset()
        {
            return new Vector2(-3, 0);
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.AquaScepter);
            recipe.AddIngredient(ModContent.ItemType<FrostShard>());
            recipe.AddIngredient(ModContent.ItemType<ChilledBar>(), 8);
            recipe.AddTile(TileID.Anvils);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}