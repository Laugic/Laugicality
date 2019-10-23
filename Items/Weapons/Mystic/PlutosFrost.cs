using Laugicality.Items.Loot;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;

namespace Laugicality.Items.Weapons.Mystic
{
    public class PlutosFrost : MysticItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Pluto's Frost");
            Tooltip.SetDefault("'Harness the void of Space' \nIllusion inflicts 'Frigid', which stops enemies in their tracks\nWhile in the Etherial after defeating Etheria, +50% Overflow and Potentia Discharge and +25% Damage\nFires different projectiles based on Mysticism");
            Item.staff[item.type] = true;
        }

        public override void SetMysticDefaults()
        {
            item.damage = 60;
            item.width = 48;
            item.height = 48;
            item.useTime = 18;
            item.useAnimation = 18;
            item.useStyle = 5;
            item.noMelee = true;
            item.knockBack = 2;
            item.value = 10000;
            item.rare = ItemRarityID.Orange;
            item.UseSound = SoundID.Item1;
            item.autoReuse = true;
            item.shootSpeed = 6f;
            LuxCost = 10;
            VisCost = 10;
            MundusCost = 10;
        }

        public override bool MysticShoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
        {
            LaugicalityPlayer modPlayer = LaugicalityPlayer.Get(player);
            if ((LaugicalityWorld.downedEtheria || LaugicalityPlayer.Get(player).Etherable > 0) && LaugicalityWorld.downedTrueEtheria)
            {
                modPlayer.MysticDamage += .25f;
                modPlayer.GlobalAbsorbRate *= 1.5f;
                modPlayer.GlobalOverflow += .5f;
            }
            if (modPlayer.MysticMode == 2)
            {
                int numberProjectiles = Main.rand.Next(1, 3);
                for (int i = 0; i < numberProjectiles; i++)
                {
                    Vector2 perturbedSpeed = new Vector2(speedX, speedY).RotatedByRandom(MathHelper.ToRadians(10));
                    float scale = 1f - (Main.rand.NextFloat() * .3f);
                    perturbedSpeed = perturbedSpeed * scale;
                    if (Main.player[Main.myPlayer] == player)
                        Projectile.NewProjectile(position.X, position.Y, perturbedSpeed.X, perturbedSpeed.Y, ModContent.ProjectileType("PlutoIllusion"), damage, knockBack, player.whoAmI);
                }

            }
            return true;
        }

        public override void Destruction(LaugicalityPlayer modPlayer)
        {
            item.damage = 100;
            item.useTime = 16;
            item.useAnimation = item.useTime;
            item.knockBack = 6;
            item.shootSpeed = 14f;
            item.shoot = ModContent.ProjectileType("PlutoDestruction");
            LuxCost = 5;
        }

        public override void Illusion(LaugicalityPlayer modPlayer)
        {
            item.damage = 60;
            item.useTime = 10;
            item.useAnimation = item.useTime;
            item.knockBack = 5;
            item.shootSpeed = 18f;
            item.shoot = ModContent.ProjectileType("PlutoIllusion");
            item.noUseGraphic = false;
            VisCost = 6;
        }

        public override void Conjuration(LaugicalityPlayer modPlayer)
        {
            item.damage = 54;
            item.useTime = 24;
            item.useAnimation = item.useTime;
            item.knockBack = 2;
            item.shootSpeed = 24f;
            item.shoot = ModContent.ProjectileType("PlutoConjuration");
            item.noUseGraphic = false;
            MundusCost = 16;
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(null, "Yuletide", 1);
            recipe.AddIngredient(null, "BysmalBar", 12);
            recipe.AddIngredient(mod, nameof(EtherialEssence), 15);
            recipe.AddIngredient(mod, nameof(SoulOfSought), 8);
            recipe.AddTile(TileID.MythrilAnvil);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}