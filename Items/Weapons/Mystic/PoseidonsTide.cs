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
    public class PoseidonsTide : MysticItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Poseidon's Tide");
        }

        public override void SetMysticDefaults()
        {
            item.damage = 70;
            item.width = 76;
            item.height = 76;
            item.useTime = 30;
            item.useAnimation = 30;
            item.useStyle = 5;
            item.noMelee = true;
            item.knockBack = 2;
            item.value = Item.sellPrice(gold: 6);
            item.rare = ItemRarityID.Yellow;
            item.UseSound = SoundID.Item92;
            item.autoReuse = true;
            item.shootSpeed = 8f;
            item.scale = 1;
        }


        public override string GetExtraTooltip()
        {
            LaugicalityPlayer laugicalityPlayer = LaugicalityPlayer.Get();

            switch (laugicalityPlayer.MysticMode)
            {
                case 1:
                    return "A spear that shoots bubbles";
                case 2:
                    return "Shoots a trident that is chained to you. Inflicts 'Bubbly', \nwhich makes enemies emit bubbles";
                case 3:
                    return "Creates mini cthulunados that shoot bubbles and fly at enemies";
                default:
                    return "";
            }
        }

        public override bool CanUseItem(Player player)
        {
            LaugicalityPlayer modPlayer = LaugicalityPlayer.Get(player);
            if (modPlayer.MysticMode == 1)
                return player.ownedProjectileCounts[item.shoot] < 1;
            return true;
        }

        public override void Destruction(LaugicalityPlayer modPlayer)
        {
            item.damage = 65;
            item.UseSound = SoundID.Item76;
            item.useAnimation = item.useTime = 30;
            item.knockBack = 8;
            item.shootSpeed = 8f;
            item.useTurn = true;
            item.noUseGraphic = true;
            item.useStyle = 5;
            item.shoot = ModContent.ProjectileType<PoseidonDestruction>();
            LuxCost = 15;
        }

        public override void Illusion(LaugicalityPlayer modPlayer)
        {
            item.damage = 80;
            item.UseSound = SoundID.Item92;
            item.useAnimation = item.useTime = 21;
            item.knockBack = 8;
            item.shootSpeed = 18f;
            item.useTurn = true;
            item.noUseGraphic = true;
            item.useStyle = 1;
            item.shoot = ModContent.ProjectileType<PoseidonIllusion>();
            VisCost = 15;
        }

        public override void Conjuration(LaugicalityPlayer modPlayer)
        {
            item.damage = 65;
            item.UseSound = SoundID.Item21;
            item.useAnimation = item.useTime = 53;
            item.knockBack = 2;
            item.shootSpeed = 8f;
            item.useTurn = true;
            item.noUseGraphic = false;
            item.useStyle = 1;
            item.shoot = ModContent.ProjectileType<PoseidonConjuration1>();
            MundusCost = 30;
        }
    }
}