using Terraria;
using Terraria.ID;
using Microsoft.Xna.Framework;
using Terraria.ModLoader;

namespace Laugicality.Items.Weapons.Mystic
{
    public class SaturnsRings : MysticItem
    {
        int charge = 0;
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Saturn's Rings");
            Tooltip.SetDefault("'The majesty of Space'\nIllusion inflicts 'Orbital'. Orbital enemies take more damage and knockback.\nFires different projectiles based on Mysticism");
        }
        
        public override void SetMysticDefaults()
        {
            charge = 0;
            item.damage = 50;
            item.width = 68;
            item.height = 40;
            item.useTime = 18;
            item.useAnimation = 18;
            item.useStyle = 5;
            item.noMelee = true;
            item.knockBack = 2;
            item.value = 10000;
            item.rare = ItemRarityID.Yellow;
            item.UseSound = SoundID.Item1;
            item.autoReuse = true;
            item.shootSpeed = 6f;
        }

        public override bool MysticShoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
        {
            Vector2 muzzleOffset = Vector2.Normalize(new Vector2(speedX, speedY)) * 50f;

            LaugicalityPlayer modPlayer = LaugicalityPlayer.Get(player);
            if (modPlayer.MysticMode == 1)
            {
                charge++;
                Main.PlaySound(SoundID.Item60, position);
                if(charge > 2)
                {
                    int numberProjectiles = 24;
                    for (int i = 0; i < numberProjectiles; i++)
                    {
                        Vector2 perturbedSpeed = new Vector2(speedX, speedY).RotatedByRandom(MathHelper.ToRadians(7));
                        float scale = 1f - (Main.rand.NextFloat() * .4f);
                        perturbedSpeed = perturbedSpeed * scale;
                        Projectile.NewProjectile(position.X, position.Y, perturbedSpeed.X, perturbedSpeed.Y, type, damage, knockBack, player.whoAmI);
                    }

                    charge = 0;
                    Main.PlaySound(SoundID.Item84, position);
                }
                return false;
            }
            return true;
        }

        public override void Destruction(LaugicalityPlayer modPlayer)
        {
            item.useStyle = 5;
            item.damage = 85;
            item.useTime = 45;
            item.useAnimation = item.useTime;
            item.knockBack = 4;
            item.shootSpeed = 18f;
            item.shoot = ModContent.ProjectileType("SaturnDestruction");
        }

        public override void Illusion(LaugicalityPlayer modPlayer)
        {
            item.useStyle = 5;
            item.damage = 50;
            item.useTime = 24;
            item.useAnimation = item.useTime;
            item.knockBack = 1;
            item.shootSpeed = 18f;
            item.shoot = ModContent.ProjectileType("SaturnIllusion1");
        }

        public override void Conjuration(LaugicalityPlayer modPlayer)
        {
            item.useStyle = 5;
            item.damage = 60;
            item.useTime = 24;
            item.useAnimation = item.useTime;
            item.knockBack = 2;
            item.shootSpeed = 8f;
            item.shoot = ModContent.ProjectileType("SaturnConjuration1");
        }
    }
}