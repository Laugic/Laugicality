using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;

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
            item.value = 10000;
            item.rare = 3;
            item.UseSound = SoundID.Item20;
            item.autoReuse = true;
            item.shootSpeed = 6f;
            item.scale = 1.5f;
        }

        public override bool MysticShoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
        {
            LaugicalityPlayer modPlayer = player.GetModPlayer<LaugicalityPlayer>(mod);
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
            item.shoot = mod.ProjectileType("Nothing");
            LuxCost = 0;
        }

        public override void Illusion(LaugicalityPlayer modPlayer)
        {
            item.damage = 32;
            item.useTime = 20;
            item.useAnimation = 20;
            item.knockBack = 4;
            item.shootSpeed = 12f;
            item.shoot = mod.ProjectileType("HadesIllusion");
            VisCost = 8;
        }

        public override void Conjuration(LaugicalityPlayer modPlayer)
        {
            item.damage = 22;
            item.useTime = 65;
            item.useAnimation = 65;
            item.knockBack = 2;
            item.shootSpeed = 8f;
            item.shoot = mod.ProjectileType("HadesConjuration");
            MundusCost = 20;
        }

        public override void OnHitNPC(Player player, NPC target, int damage, float knockback, bool crit)
        {
            LaugicalityPlayer modPlayer = player.GetModPlayer<LaugicalityPlayer>(mod);
            LuxCost = 16;
            if (modPlayer.MysticMode == 1 && modPlayer.lux >= LuxCost * modPlayer.luxUseRate * modPlayer.globalPotentiaUseRate)
            {
                Projectile.NewProjectile(target.Center.X + 32, target.Center.Y + 32, 0f, 0f, mod.ProjectileType("HadesExplosion"), damage, knockback, Main.myPlayer);
                
                modPlayer.lux -= LuxCost * modPlayer.luxUseRate * modPlayer.globalPotentiaUseRate;
                if (modPlayer.lux < 0)
                    modPlayer.lux = 0;
                if (modPlayer.lux > (modPlayer.luxMax + modPlayer.luxMaxPermaBoost) * modPlayer.luxOverflow * modPlayer.globalOverflow)
                    modPlayer.lux = (modPlayer.luxMax + modPlayer.luxMaxPermaBoost) * modPlayer.luxOverflow * modPlayer.globalOverflow;
                modPlayer.vis += LuxCost * modPlayer.globalAbsorbRate * modPlayer.visAbsorbRate * modPlayer.luxDischargeRate * modPlayer.luxUseRate * modPlayer.globalPotentiaUseRate;
                if (modPlayer.vis > (modPlayer.visMax + modPlayer.visMaxPermaBoost) * modPlayer.visOverflow * modPlayer.globalOverflow)
                    modPlayer.vis = (modPlayer.visMax + modPlayer.visMaxPermaBoost) * modPlayer.visOverflow * modPlayer.globalOverflow;
                modPlayer.mundus += LuxCost * modPlayer.globalAbsorbRate * modPlayer.mundusAbsorbRate * modPlayer.luxDischargeRate * modPlayer.luxUseRate * modPlayer.globalPotentiaUseRate;
                if (modPlayer.mundus > (modPlayer.mundusMax + modPlayer.mundusMaxPermaBoost) * modPlayer.mundusOverflow * modPlayer.globalOverflow)
                    modPlayer.mundus = (modPlayer.mundusMax + modPlayer.mundusMaxPermaBoost) * modPlayer.mundusOverflow * modPlayer.globalOverflow;
                
            }
            LuxCost = 0;

        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(null, "ObsidiumBar", 16);
            recipe.AddIngredient(null, "LavaGem", 8);
            recipe.AddIngredient(null, "DarkShard");
            recipe.AddTile(16);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}