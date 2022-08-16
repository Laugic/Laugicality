using Terraria.ID;
using Terraria.ModLoader;
using Laugicality.Projectiles.Mystic.Destruction;
using Laugicality.Projectiles.Mystic.Illusion;
using Laugicality.Projectiles.Mystic.Conjuration;
using Terraria;
using Laugicality.Projectiles.Special;
using Microsoft.Xna.Framework;
using System;
using Laugicality.Buffs;
using Laugicality.NPCs;
using Laugicality.Items.Materials;
using Laugicality.Projectiles.Mystic.Misc;

namespace Laugicality.Items.Weapons.Mystic
{
    public class ThorsHammer : MysticItem
    {
        bool IllusionCharged { get; set; }
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Thor's Hammer");
        }

        public override void SetMysticDefaults()
        {
            item.damage = 10;
            item.width = 48;
            item.height = 48;
            item.useTime = 18;
            item.useAnimation = 18;
            item.useStyle = 1;
            item.noMelee = false;
            item.knockBack = 2;
            item.value = Item.sellPrice(gold: 10);
            item.rare = ItemRarityID.Red;
            item.UseSound = SoundID.Item71;
            item.autoReuse = true;
            item.shootSpeed = 6f;
            IllusionCharged = false;
        }

        public override string GetExtraTooltip()
        {
            LaugicalityPlayer laugicalityPlayer = LaugicalityPlayer.Get();

            switch (laugicalityPlayer.MysticMode)
            {
                case 1:
                    return "Throw the hammer";
                case 2:
                    return "Swing the hammer when you land on the ground after a fall to create a Lightning Explosion\nInflicts 'Thunder Charged', which makes enemies release lightning bolts after being hit";
                case 3:
                    return "Creates Shadow Portals that shoot lightning";
                default:
                    return "";
            }
        }

        public override void OnHitNPC(Player player, NPC target, int damage, float knockBack, bool crit)
        {
            base.OnHitNPC(player, target, damage, knockBack, crit);
            LaugicalityPlayer modPlayer = LaugicalityPlayer.Get(player);
            if (modPlayer.MysticMode == 2 && modPlayer.Vis > VisCost)
            {
                target.AddBuff(ModContent.BuffType<ThunderCharged>(), (int)(8 * 60 * modPlayer.MysticDuration) + Main.rand.Next(1 * 60));
            }
        }

        public override void Destruction(LaugicalityPlayer modPlayer)
        {
            item.damage = 100;
            item.noMelee = true;
            item.noUseGraphic = true;
            item.useAnimation = item.useTime = 20;
            item.knockBack = 3;
            item.useStyle = ItemUseStyleID.SwingThrow;
            item.shoot = ModContent.ProjectileType<ThorHammerDestruction>();
            item.UseSound = SoundID.Item71;
            item.shootSpeed = 36f;
            LuxCost = 10;
            item.autoReuse = true;
        }

        public override void Illusion(LaugicalityPlayer modPlayer)
        {
            item.damage = 300;
            item.noMelee = false;
            item.noUseGraphic = false;
            item.autoReuse = false;
            VisCost = 40;
            item.useAnimation = item.useTime = 30;
            item.useStyle = ItemUseStyleID.SwingThrow;
            item.knockBack = 5;
            item.shootSpeed = 16f;
            item.shoot = ModContent.ProjectileType<Nothing>();
            item.UseSound = SoundID.Item71;
        }

        public override void Conjuration(LaugicalityPlayer modPlayer)
        {
            item.damage = 140;
            item.noMelee = true;
            item.noUseGraphic = true;
            item.autoReuse = true;
            item.useTime = 60;
            item.useAnimation = item.useTime;
            item.useStyle = ItemUseStyleID.SwingThrow;
            item.knockBack = 2;
            item.shootSpeed = 4f;
            item.shoot = ModContent.ProjectileType<ThorShadowConjuration>();
            item.UseSound = SoundID.Item93;
            MundusCost = 40;
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<GalacticFragment>(), 18);
            recipe.AddTile(TileID.LunarCraftingStation);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}
