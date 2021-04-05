using Laugicality.Dusts;
using Laugicality.Items.Loot;
using Laugicality.Items.Materials;
using Laugicality.Projectiles.Accessory;
using Microsoft.Xna.Framework;
using System;
using Terraria;
using Terraria.Graphics.Shaders;
using Terraria.ID;
using Terraria.ModLoader;

namespace Laugicality.Items.Equipables
{
    public class BysmaliteWarpers : BootItem
    {
        public override void SetStaticDefaults()
        {
            LaugicalityVars.DashBoots.Add(item.type);
            LaugicalityVars.RocketBoots.Add(item.type);
            Tooltip.SetDefault("Dimension-tearing speed and dashing\nDominion over everything\nLeave a Frigid trail\nIncreased Damage, Movement Speed, and Defense in the Etherial");
        }

        public override void SetDefaults()
        {
            item.width = 28;
            item.height = 28;
            item.value = Item.sellPrice(gold: 20);
            item.rare = ItemRarityID.Red;
            item.accessory = true;
        }

        public override void SetBootVars()
        {
            DashCooldownMax = 40;
            VDashCooldownMax = 40;
            DashSpeed = 20;
            MaxVDashes = -1;
            JumpSpeed = 14;
            JumpDur = 24;
            ImmuneTime = 20;
            WarpDist = 20;

            RocketBootTimeMax = 5 * 60 + 30;
            RocketSpeedMax = 13;
            RocketAccel = .25f;
            RocketAccelMax = .6f;
            RocketSoundID = SoundID.Item24;

            RunBoots = true;
            DustType = ModContent.DustType<EtherialDust>();
            ProjectileType = ModContent.ProjectileType<BysmalTrailProj>();
            TrailLength = 60;
        }

        public override void OtherBonuses(Player player, bool hideVisual)
        {
            player.jumpSpeedBoost += 5;
            player.moveSpeed += .6f;
            player.maxRunSpeed += 6.5f;
            player.iceSkate = true;
            player.doubleJumpBlizzard = true;
            player.noFallDmg = true;
            player.waterWalk = true;
            player.fireWalk = true;
            player.lavaImmune = true;
            player.buffImmune[24] = true;
            player.gills = true;
            player.ignoreWater = true;
            player.accFlipper = true;
            if (!hideVisual)
                player.GetModPlayer<LaugicalityPlayer>().BysmalTrail = true;
            if(LaugicalityWorld.downedEtheria || player.GetModPlayer<LaugicalityPlayer>().Etherable > 0)
            {
                player.GetModPlayer<LaugicalityPlayer>().DamageBoost(.1f);
                player.statDefense += 10;
                player.moveSpeed += 8f;
            }
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<SteamsparkJetboots>(), 1);
            recipe.AddIngredient(ModContent.ItemType<BysmalBar>(), 16);
            recipe.AddIngredient(ModContent.ItemType<EtherialEssence>(), 12);
            recipe.AddTile(TileID.MythrilAnvil);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}