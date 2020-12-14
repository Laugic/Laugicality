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

namespace Laugicality.Items.Weapons.Mystic
{
    public class DeathsHarvest : MysticItem
    {
        bool IllusionCharged { get; set; }
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Death's Harvest");
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
            item.value = Item.sellPrice(gold: 2);
            item.rare = ItemRarityID.Blue;
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
                    return "The scythe grows as you swing it";
                case 2:
                    return "Charge the scythe, then dash forward\nInflicts 'Death Mark', which makes enemies drop Souls on death\nSouls restore Potentia and grant the 'Reaper' buff";
                case 3:
                    return "Throws Scythes that hover around and follow you\nSpawn Skull Bursts upon picking up a Soul";
                default:
                    return "";
            }
        }
        public override bool MysticShoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
        {
            LaugicalityPlayer modPlayer = LaugicalityPlayer.Get(player);
            if (modPlayer.MysticMode == 1 && modPlayer.Lux >= LuxCost)
            {
                item.scale = Math.Min(Math.Max(1.5f, item.scale + .05f), 2.5f);
                return false;
            }
            else
                item.scale = 1;
            if(modPlayer.MysticMode == 2)
            {
                if (!IllusionCharged)
                    IllusionCharged = true;
                else
                {
                    IllusionCharged = false;
                    player.immune = true;
                    player.immuneTime = 30;
                    player.velocity.X += speedX;
                    player.velocity.Y += speedY;
                }
            }
            else
                IllusionCharged = false;
            return true;
        }

        public override void OnHitNPC(Player player, NPC target, int damage, float knockBack, bool crit)
        {
            base.OnHitNPC(player, target, damage, knockBack, crit);
            LaugicalityPlayer modPlayer = LaugicalityPlayer.Get(player);
            if (modPlayer.MysticMode == 2 && modPlayer.Vis > VisCost)
            {
                target.AddBuff(ModContent.BuffType<DeathMark>(), (int)(8 * 60 * modPlayer.MysticDuration) + Main.rand.Next(1 * 60));
                target.GetGlobalNPC<LaugicalGlobalNPCs>().DeathMarked = true;
            }
        }

        public override void Destruction(LaugicalityPlayer modPlayer)
        {
            item.damage = 20;
            item.noMelee = false;
            item.noUseGraphic = false;
            item.useAnimation = item.useTime = 25;
            item.knockBack = 3;
            item.useStyle = ItemUseStyleID.SwingThrow;
            item.shoot = ModContent.ProjectileType<Nothing>();
            item.UseSound = SoundID.Item71;
            LuxCost = 5;
        }

        public override void Illusion(LaugicalityPlayer modPlayer)
        {
            item.damage = 40;
            item.noMelee = false;
            item.noUseGraphic = false;
            VisCost = 10;
            if (modPlayer.Vis < VisCost)
            {
                item.damage = 15;
                IllusionCharged = false;
            }
            item.useTime = 60;
            item.useAnimation = IllusionCharged ? 60 : 20;
            item.useStyle = IllusionCharged ? ItemUseStyleID.HoldingOut : ItemUseStyleID.SwingThrow;
            item.knockBack = 5;
            item.shootSpeed = 16f;
            item.shoot = ModContent.ProjectileType<Nothing>();
            item.UseSound = IllusionCharged ? SoundID.Item60: SoundID.Item71;
        }

        public override void Conjuration(LaugicalityPlayer modPlayer)
        {
            item.damage = 20;
            item.noMelee = true;
            item.noUseGraphic = true;
            item.useTime = 60;
            item.useAnimation = item.useTime;
            item.useStyle = ItemUseStyleID.SwingThrow;
            item.knockBack = 2;
            item.shootSpeed = 4f;
            item.shoot = ModContent.ProjectileType<DeathConjuration>();
            item.UseSound = SoundID.Item71;
            MundusCost = 20;
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddRecipeGroup(Laugicality.EVIL_BARS_GROUP, 16);
            recipe.AddTile(TileID.DemonAltar);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}
