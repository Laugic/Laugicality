using Laugicality.Items.Loot;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Laugicality.Items.Weapons.Range
{
    public class Blizzard : LaugicalityItem
    {
        public override void SetStaticDefaults()
        {
            Tooltip.SetDefault("'Let snow fly'\nWhile in the Etherial after defeating Etheria, shoot an extra snowball\n50% chance not to consume ammo");
        }

        public override void SetDefaults()
        {
            item.damage = 100;
            item.ranged = true;
            item.width = 72;
            item.height = 36;
            item.useTime = 5;
            item.useAnimation = 5;
            item.useStyle = 5;
            item.noMelee = true;
            item.knockBack = 4;
            item.value = 10000;
            item.rare = ItemRarityID.LightRed;
            item.UseSound = SoundID.Item34;
            item.autoReuse = true;
            item.shootSpeed = 18f;
            item.useAmmo = AmmoID.Snowball;
            item.shoot = ProjectileID.SnowBallFriendly;
        }

        public override bool ConsumeAmmo(Player player)
        {
            if (Main.rand.Next(2) == 0)
                return false;
            return base.ConsumeAmmo(player);
        }

        public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
        {
            Vector2 muzzleOffset = Vector2.Normalize(new Vector2(speedX, speedY)) * 40f;
            if (Collision.CanHit(position, 0, 0, position + muzzleOffset, 0, 0))
            {
                position += muzzleOffset;
            }
            int numberProjectiles = 1;
            if (Main.rand.Next(8) == 0)
                numberProjectiles++;
            if (((LaugicalityWorld.downedEtheria || player.GetModPlayer<LaugicalityPlayer>(mod).Etherable > 0) && LaugicalityWorld.downedTrueEtheria))
                numberProjectiles++;
            for (int i = 0; i < numberProjectiles; i++)
            {
                Vector2 perturbedSpeed = new Vector2(speedX, speedY).RotatedByRandom(MathHelper.ToRadians(8));

                float scale = 1f - (Main.rand.NextFloat() * .3f);
                perturbedSpeed = perturbedSpeed * scale;
                Projectile.NewProjectile(position.X, position.Y, perturbedSpeed.X, perturbedSpeed.Y, type, damage, knockBack, player.whoAmI);
            }

            return false;
        }

        public override Vector2? HoldoutOffset()
        {
            return new Vector2(-15, 0);
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(null, "FrostThrower", 1);
            recipe.AddIngredient(null, "BysmalBar", 12);
            recipe.AddIngredient(mod, nameof(EtherialEssence), 5);
            recipe.AddTile(null, "AlchemicalInfuser");
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}