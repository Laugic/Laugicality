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
    public class SteamsparkJetboots : BootItem
    {
        public override void SetStaticDefaults()
        {
            LaugicalityVars.DashBoots.Add(item.type);
            LaugicalityVars.RocketBoots.Add(item.type);
            Tooltip.SetDefault("Steam speed!\nDominion over liquids and the sky\nLeave a trail of Steam");
        }

        public override void SetDefaults()
        {
            item.width = 28;
            item.height = 28;
            item.value = Item.sellPrice(gold: 18);
            item.rare = ItemRarityID.Red;
            item.accessory = true;
        }

        public override void SetBootVars()
        {
            DashCooldownMax = 40;
            VDashCooldownMax = 40;
            DashSpeed = 18;
            MaxVDashes = 6;
            JumpSpeed = 14;
            JumpDur = 24;
            ImmuneTime = 18;

            RocketBootTimeMax = 4 * 60 + 30;
            RocketSpeedMax = 12;
            RocketAccel = .075f;
            RocketAccelMax = .6f;
            RocketSoundID = SoundID.Item13;

            RunBoots = true;
            DustType = ModContent.DustType<SteamTrailDust>();
            ProjectileType = ModContent.ProjectileType<SteamTrailProj>();
            TrailLength = 60;
        }

        public override void OtherBonuses(Player player, bool hideVisual)
        {
            player.jumpSpeedBoost += 4;
            player.moveSpeed += .5f;
            player.maxRunSpeed += 5.5f;
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
                player.GetModPlayer<LaugicalityPlayer>().SteamTrail = true;
        }
        /*
        public override void Run(Player player)
        {
            if (Main.tileSolid[Main.tile[(int)(player.Center.X / 16), (int)(player.Center.Y / 16) + 2].type] && Main.tile[(int)(player.Center.X / 16), (int)(player.Center.Y / 16) + 2].type != 0 && Math.Abs(player.velocity.X) > 4)
            {
                int newDust = Dust.NewDust(new Vector2(player.Center.X + player.velocity.X, player.position.Y + 4 + (float)player.height - 10f + player.velocity.Y), 8, 8, ModContent.DustType<Steam>(), 0f, 0f, 0, default(Color), 1.5f);
                Main.dust[newDust].scale = 4;
            }
        }*/

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<HyperwarpLightboots>(), 1);
            recipe.AddIngredient(ItemID.Jetpack, 1);
            recipe.AddIngredient(ModContent.ItemType<SteamTank>(), 1);
            recipe.AddIngredient(ModContent.ItemType<SteamBar>(), 16);
            recipe.AddIngredient(ModContent.ItemType<Gear>(), 25);
            recipe.AddTile(TileID.MythrilAnvil);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}