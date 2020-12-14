using Laugicality.Items.Materials;
using Laugicality.Projectiles.Mystic.Conjuration;
using Laugicality.Projectiles.Mystic.Destruction;
using Laugicality.Projectiles.Mystic.Illusion;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using Laugicality.Projectiles.Special;
using Laugicality.Items.Placeable;
using Laugicality.Items.Loot;
using Laugicality.Items.Consumables;

namespace Laugicality.Items.Weapons.Mystic
{
    public class HadesJudgement : MysticItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Hades' Judgement");
            Tooltip.SetDefault("Cleanse your sins\nIllusion inflicts 'Shadowflame'\nFires different projectiles based on Mysticism");
        }

        public override void SetMysticDefaults()
        {
            item.damage = 34;
            item.width = 66;
            item.height = 74;
            item.useTime = 18;
            item.useAnimation = 18;
            item.useStyle = 1;
            item.noMelee = false;
            item.knockBack = 2;
            item.value = Item.sellPrice(gold: 2);
            item.rare = ItemRarityID.Orange;
            item.UseSound = SoundID.Item20;
            item.autoReuse = true;
            item.shootSpeed = 6f;
            item.scale = 1.5f;
        }

        public override bool MysticShoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
        {
            LaugicalityPlayer modPlayer = LaugicalityPlayer.Get(player);
            if (modPlayer.MysticMode != 1)
                return true;
            else return false;
        }

        public override void Destruction(LaugicalityPlayer modPlayer)
        {
            item.damage = 44;
            item.useTime = 40;
            item.useAnimation = item.useTime;
            item.knockBack = 8;
            item.shootSpeed = 4f;
            item.shoot = ModContent.ProjectileType<Nothing>();
            LuxCost = 0;
        }

        public override void Illusion(LaugicalityPlayer modPlayer)
        {
            item.damage = 32;
            item.useTime = 20;
            item.useAnimation = 20;
            item.knockBack = 4;
            item.shootSpeed = 12f;
            item.shoot = ModContent.ProjectileType<HadesIllusion>();
            VisCost = 8;
        }

        public override void Conjuration(LaugicalityPlayer modPlayer)
        {
            item.damage = 22;
            item.useTime = 65;
            item.useAnimation = 65;
            item.knockBack = 2;
            item.shootSpeed = 8f;
            item.shoot = ModContent.ProjectileType<HadesConjuration>();
            MundusCost = 20;
        }

        public override void OnHitNPC(Player player, NPC target, int damage, float knockback, bool crit)
        {
            LaugicalityPlayer modPlayer = LaugicalityPlayer.Get(player);
            LuxCost = 16;
            if (modPlayer.MysticMode == 1 && modPlayer.Lux >= LuxCost * modPlayer.LuxUseRate * modPlayer.GlobalPotentiaUseRate)
            {
                Projectile.NewProjectile(target.Center.X + 32, target.Center.Y + 32, 0f, 0f, ModContent.ProjectileType<HadesExplosion>(), damage, knockback, Main.myPlayer);
                
                modPlayer.Lux -= LuxCost * modPlayer.LuxUseRate * modPlayer.GlobalPotentiaUseRate;
                if (modPlayer.Lux < 0)
                    modPlayer.Lux = 0;
                if (modPlayer.Lux > (modPlayer.LuxMax + modPlayer.LuxMaxPermaBoost) * modPlayer.LuxOverflow * modPlayer.GlobalOverflow)
                    modPlayer.Lux = (modPlayer.LuxMax + modPlayer.LuxMaxPermaBoost) * modPlayer.LuxOverflow * modPlayer.GlobalOverflow;
                modPlayer.Vis += LuxCost * modPlayer.GlobalAbsorbRate * modPlayer.VisAbsorbRate * modPlayer.LuxDischargeRate * modPlayer.LuxUseRate * modPlayer.GlobalPotentiaUseRate;
                if (modPlayer.Vis > (modPlayer.VisMax + modPlayer.VisMaxPermaBoost) * modPlayer.VisOverflow * modPlayer.GlobalOverflow)
                    modPlayer.Vis = (modPlayer.VisMax + modPlayer.VisMaxPermaBoost) * modPlayer.VisOverflow * modPlayer.GlobalOverflow;
                modPlayer.Mundus += LuxCost * modPlayer.GlobalAbsorbRate * modPlayer.MundusAbsorbRate * modPlayer.LuxDischargeRate * modPlayer.LuxUseRate * modPlayer.GlobalPotentiaUseRate;
                if (modPlayer.Mundus > (modPlayer.MundusMax + modPlayer.MundusMaxPermaBoost) * modPlayer.MundusOverflow * modPlayer.GlobalOverflow)
                    modPlayer.Mundus = (modPlayer.MundusMax + modPlayer.MundusMaxPermaBoost) * modPlayer.MundusOverflow * modPlayer.GlobalOverflow;
                
            }
            LuxCost = 0;

        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(mod, nameof(ObsidiumBar), 16);
            recipe.AddIngredient(mod, nameof(LavaGemItem), 8);
            recipe.AddIngredient(ModContent.ItemType<ObsidiumHeart>(), 1);
            recipe.AddTile(TileID.Hellforge);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}