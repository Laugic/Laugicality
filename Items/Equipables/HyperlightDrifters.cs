using Laugicality.Dusts;
using Laugicality.Items.Materials;
using Laugicality.Projectiles.Accessory;
using Microsoft.Xna.Framework;
using System;
using Terraria;
using Terraria.Graphics.Shaders;
using Terraria.ID;
using Terraria.ModLoader;
using WebmilioCommons.Recipes;

namespace Laugicality.Items.Equipables
{
    public class HyperlightDrifters : BootItem
    {
        public override void SetStaticDefaults()
        {
            LaugicalityVars.DashBoots.Add(item.type);
            LaugicalityVars.RocketBoots.Add(item.type);
            Tooltip.SetDefault("Light speed and light dash\nDominion over everything\nLeave a Cosmic trail\n+10% Damage");
        }

        public override void SetDefaults()
        {
            item.width = 28;
            item.height = 28;
            item.value = Item.sellPrice(gold: 24);
            item.rare = ItemRarityID.Purple;
            item.accessory = true;
            item.defense = 10;
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
            WarpDist = 25;

            RocketBootTimeMax = 6 * 60;
            RocketSpeedMax = 14;
            RocketAccel = .25f;
            RocketAccelMax = .7f;
            RocketSoundID = SoundID.Item13;

            RunBoots = true;
            DustType = ModContent.DustType<Rainbow>();
            ProjectileType = ModContent.ProjectileType<CosmicTrailProj>();
            TrailLength = 60;
        }

        public override void OtherBonuses(Player player, bool hideVisual)
        {
            player.jumpSpeedBoost += 7;
            player.moveSpeed += .75f;
            player.maxRunSpeed += 7.5f;
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
            if(!hideVisual)
                player.GetModPlayer<LaugicalityPlayer>().CosmicTrail = true;
            player.GetModPlayer<LaugicalityPlayer>().DamageBoost(.1f);
        }

        public override void AddRecipes()
        {
            this.BuildRecipe()
                .Requires<BysmaliteWarpers>()
                .Requires(ItemID.LunarBar, 16)
                .Requires<GalacticFragment>(12)
                .At(TileID.LunarCraftingStation);
        }
    }
}