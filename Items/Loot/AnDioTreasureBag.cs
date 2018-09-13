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
    public class AnDioTreasureBag : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Treasure Bag");
            Tooltip.SetDefault("");
        }
        public override void SetDefaults()
        {
            item.width = 32;
            item.height = 46;
            item.maxStack = 20;
            item.useAnimation = 45;
            item.useTime = 45;
            item.useStyle = 1;
            item.consumable = true;
            item.rare = 11;
            item.expert = true;
            bossBagNPC = mod.NPCType("AnDio3");
        }

        public override bool CanRightClick()
        {
            return true;
        }


        public override void OpenBossBag(Player player)
        {
            player.QuickSpawnItem(mod.ItemType("DioritusCore"), Main.rand.Next(1, 3));
            player.QuickSpawnItem(mod.ItemType("AndesiaCore"), Main.rand.Next(1, 3));
            player.QuickSpawnItem(3081, Main.rand.Next(10, 31));
            player.QuickSpawnItem(3086, Main.rand.Next(10, 31));
            player.QuickSpawnItem(mod.ItemType("ZaWarudoWatch"), 1);
            player.QuickSpawnItem(188, Main.rand.Next(10, 15));
        }
        
    }
}