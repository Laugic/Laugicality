using System;
using System.Collections.Generic;
using System.IO;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Laugicality.Items.Accessories;

namespace Laugicality.Items.Loot
{
    public class SteamTrainTreasureBag : ModItem
    {
        public override void SetStaticDefaults()
        {
            Tooltip.SetDefault("");
        }
        public override void SetDefaults()
        {
            item.width = 36;
            item.height = 36;
            item.maxStack = 20;
            item.rare = 3;
            item.useAnimation = 45;
            item.useTime = 45;
            item.useStyle = 4;
            item.UseSound = SoundID.Item9;
            item.consumable = true;
        }

        public override bool CanRightClick()
        {
            return true;
        }


        public override void RightClick(Player player)
        {
            player.QuickSpawnItem(mod.ItemType("SteamBar"), Main.rand.Next(20, 35));
            player.QuickSpawnItem(mod.ItemType("SoulOfWrought"), Main.rand.Next(25, 40));
            player.QuickSpawnItem(mod.ItemType("SteamTank"), 1);
            player.QuickSpawnItem(499, Main.rand.Next(10, 15));
        }
        
    }
}