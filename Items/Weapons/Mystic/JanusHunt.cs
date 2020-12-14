using Laugicality.Items.Loot;
using Laugicality.Projectiles.Mystic.Conjuration;
using Laugicality.Projectiles.Mystic.Destruction;
using Laugicality.Projectiles.Mystic.Illusion;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using Laugicality.Items.Materials;

namespace Laugicality.Items.Weapons.Mystic
{
    public class JanusHunt : MysticItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Janus's Hunt");
            Tooltip.SetDefault("'Stalking through the sands'");
        }

        public override void SetMysticDefaults()
        {
            item.damage = 20;
            item.width = 44;
            item.height = 74;
            item.useTime = 18;
            item.useAnimation = 18;
            item.useStyle = 5;
            item.noMelee = true;
            item.knockBack = 2;
            item.value = Item.sellPrice(gold: 1);
            item.rare = ItemRarityID.Blue;
            item.UseSound = SoundID.Item5;
            item.autoReuse = true;
            item.shootSpeed = 6f;
        }

        public override string GetExtraTooltip()
        {
            LaugicalityPlayer laugicalityPlayer = LaugicalityPlayer.Get();

            switch (laugicalityPlayer.MysticMode)
            {
                case 1:
                    return "Rapidly shoots crystilla shards";
                case 2:
                    return "Shoots a phase arrow that teleports you to it when it hits something\nCreate a burst of sandballs where you teleport to and from\nInflicts 'Sandy', which makes enemies take more damage based on the speed of what damages them";
                case 3:
                    return "Shoots an arrow that spawns a Sandnado upon hitting a tile";
                default:
                    return "";
            }
        }


        public override bool MysticShoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
        {
            LaugicalityPlayer modPlayer = LaugicalityPlayer.Get(player);
            if (modPlayer.MysticMode == 1)
            {
                Vector2 perturbedSpeed = new Vector2(speedX, speedY).RotatedByRandom(MathHelper.ToRadians(10));
                float scale = 1.25f - (Main.rand.NextFloat() * .5f);
                perturbedSpeed = perturbedSpeed * scale;
                speedX = perturbedSpeed.X;
                speedY = perturbedSpeed.Y;
            }
            return true;
        }

        public override void Destruction(LaugicalityPlayer modPlayer)
        {
            item.damage = 15;
            item.useAnimation = item.useTime  = 10;
            item.knockBack = 2;
            item.shootSpeed = 18f;
            item.shoot = ModContent.ProjectileType<JanusDestruction>();
            LuxCost = 3;
        }

        public override void Illusion(LaugicalityPlayer modPlayer)
        {
            item.damage = 40;
            item.useAnimation = item.useTime = 120;
            item.knockBack = 1;
            item.shootSpeed = 12f;
            item.shoot = ModContent.ProjectileType<JanusIllusion>();
            VisCost = 50;
        }

        public override void Conjuration(LaugicalityPlayer modPlayer)
        {
            item.damage = 35;
            item.useAnimation = item.useTime = 120;
            item.knockBack = 2;
            item.shootSpeed = 16f;
            item.shoot = ModContent.ProjectileType<JanusConjuration>();
            MundusCost = 33;
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.FossilOre, 8);
            recipe.AddIngredient(ModContent.ItemType<Crystilla>(), 8);
            recipe.AddIngredient(ModContent.ItemType<AncientShard>(), 1);
            recipe.AddTile(TileID.Anvils);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}