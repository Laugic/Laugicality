using Laugicality.Items.Materials;
using Laugicality.Projectiles.Mystic.Conjuration;
using Laugicality.Projectiles.Mystic.Destruction;
using Laugicality.Projectiles.Mystic.Illusion;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Laugicality.Items.Weapons.Mystic
{
    public class GaiasWorld : MysticItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Gaia's World");
            Tooltip.SetDefault("The World is in your hands\nIllusion inflicts a random elemental debuff\nFires different projectiles based on Mysticism");
            Item.staff[item.type] = true;
        }

        public override string GetExtraTooltip()
        {
            LaugicalityPlayer laugicalityPlayer = LaugicalityPlayer.Get();

            switch (laugicalityPlayer.MysticMode)
            {
                case 1:
                    return "Shoots a burst of gem shards";
                case 2:
                    return "Shoots large gemstones that inflict 'Refracting', which makes enemies break off gem shards upon being hit,\ndealing damage based on their defense";
                case 3:
                    return "Spawns Sigils with different effects based on their Focus";
                default:
                    return "";
            }
        }

        public override bool MysticShoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
        {
            LaugicalityPlayer modPlayer = LaugicalityPlayer.Get(player);
            if (modPlayer.MysticMode == 1)
            {
                int numberProjectiles = Main.rand.Next(4, 7);
                for (int i = 0; i < numberProjectiles; i++)
                {
                    Vector2 perturbedSpeed = new Vector2(speedX, speedY).RotatedByRandom(MathHelper.ToRadians(10));

                    float scale = 1f - (Main.rand.NextFloat() * .3f);
                    perturbedSpeed = perturbedSpeed * scale;
                    int id = Projectile.NewProjectile(position.X, position.Y, perturbedSpeed.X, perturbedSpeed.Y, type, damage, knockBack, player.whoAmI);
                    Main.projectile[id].ai[1] = Main.rand.Next(6);
                }
                return false;
            }
            if(modPlayer.MysticMode == 2 || modPlayer.MysticMode == 3)
            {
                int id = Projectile.NewProjectile(position.X, position.Y, speedX, speedY, type, damage, knockBack, player.whoAmI);
                Main.projectile[id].ai[1] = Main.rand.Next(6);
                return false;
            }
            return true;
        }

        public override void SetMysticDefaults()
        {
            item.damage = 15;
            item.width = 40;
            item.height = 40;
            item.useTime = 18;
            item.useAnimation = 18;
            item.useStyle = 5;
            item.noMelee = true;
            item.knockBack = 2;
            item.value = Item.sellPrice(gold: 1);
            item.rare = ItemRarityID.Blue;
            item.UseSound = SoundID.Item20;
            item.autoReuse = true;
            item.shoot = ModContent.ProjectileType<GaiaDestruction>();
            item.shootSpeed = 6f;
        }

        public override void Destruction(LaugicalityPlayer modPlayer)
        {
            item.damage = 10;
            item.useAnimation = item.useTime = 30;
            item.knockBack = 6;
            item.shootSpeed = 10;
            item.shoot = ModContent.ProjectileType<GaiaDestruction>();
            LuxCost = 10;
        }

        public override void Illusion(LaugicalityPlayer modPlayer)
        {
            item.damage = 15;
            item.useTime = item.useAnimation = 30;
            item.knockBack = 4;
            item.shootSpeed = 12f;
            item.shoot = ModContent.ProjectileType<GaiaIllusion>();
            VisCost = 15;
        }

        public override void Conjuration(LaugicalityPlayer modPlayer)
        {
            item.damage = 20;
            item.useTime = item.useAnimation = 30;
            item.knockBack = 3;
            item.shootSpeed = 8f;
            item.shoot = ModContent.ProjectileType<GaiaConjuration>();
            MundusCost = 20;
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddRecipeGroup("IronBar", 12);
            recipe.AddIngredient(ItemID.Amethyst, 3);
            recipe.AddIngredient(ItemID.Topaz, 3);
            recipe.AddIngredient(ItemID.Sapphire, 3);
            recipe.AddIngredient(ItemID.Emerald, 3);
            recipe.AddIngredient(ItemID.Ruby, 3);
            recipe.AddIngredient(ItemID.Diamond, 3);
            recipe.AddIngredient(ModContent.ItemType<ArcaneShard>(), 3);
            recipe.AddTile(16);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}