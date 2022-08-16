using Laugicality.Items.Materials;
using Laugicality.Projectiles.Mystic.Conjuration;
using Laugicality.Projectiles.Mystic.Destruction;
using Laugicality.Projectiles.Mystic.Illusion;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using Laugicality.Projectiles.Special;

namespace Laugicality.Items.Weapons.Mystic
{
    public class AgnesInferno : MysticItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Agnes' Inferno");
        }

        public override void SetMysticDefaults()
        {
            item.damage = 32;
            item.width = 60;
            item.height = 60;
            item.useTime = 30;
            item.useAnimation = 30;
            item.useStyle = 5;
            item.noMelee = true;
            item.knockBack = 2;
            item.value = 10000;
            item.rare = ItemRarityID.Orange;
            item.UseSound = SoundID.Item20;
            item.autoReuse = true;
            item.shootSpeed = 8f;
            item.shoot = ModContent.ProjectileType<AgnesDestruction>();
            item.scale = 1.5f;
        }


        public override string GetExtraTooltip()
        {
            LaugicalityPlayer laugicalityPlayer = LaugicalityPlayer.Get();

            switch (laugicalityPlayer.MysticMode)
            {
                case 1:
                    return "Shoots fireballs";
                case 2:
                    return "Shoots orbiting fireballs that inflict 'Infernal', which \nmakes enemies take damage over time based on their defense";
                case 3:
                    return "Shoots Javelins that spawn a stream of fireballs";
                default:
                    return "";
            }
        }

        public override bool CanUseItem(Player player)
        {
            LaugicalityPlayer modPlayer = LaugicalityPlayer.Get(player);
            if (modPlayer.MysticMode == 1)
                return player.ownedProjectileCounts[item.shoot] < 1;
            if (modPlayer.MysticMode == 2)
                return player.ownedProjectileCounts[item.shoot] < 1;
            return true;
        }

        public override void Destruction(LaugicalityPlayer modPlayer)
        {
            item.damage = 32;
            item.useAnimation = item.useTime = 30;
            item.knockBack = 8;
            item.shootSpeed = 8f;
            item.useTurn = true;
            item.noUseGraphic = true;
            item.useStyle = 5;
            item.shoot = ModContent.ProjectileType<AgnesDestruction>();
            LuxCost = 8;
        }

        public override void Illusion(LaugicalityPlayer modPlayer)
        {
            item.damage = 28;
            item.useAnimation = item.useTime = 21;
            item.knockBack = 8;
            item.shootSpeed = 8f;
            item.useTurn = true;
            item.noUseGraphic = true;
            item.useStyle = 5;
            item.shoot = ModContent.ProjectileType<AgnesIllusion>();
            VisCost = 10;
        }

        public override void Conjuration(LaugicalityPlayer modPlayer)
        {
            item.damage = 24;
            item.useAnimation = item.useTime = 60;
            item.knockBack = 2;
            item.shootSpeed = 8f;
            item.useTurn = true;
            item.noUseGraphic = true;
            item.useStyle = 1;
            item.shoot = ModContent.ProjectileType<AgnesConjuration>();
            MundusCost = 25;
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.HellstoneBar, 12);
            recipe.AddIngredient(mod, nameof(ObsidiumBar), 12);
            recipe.AddTile(TileID.Hellforge);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}