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
    public class ObsidiumChunk : ModItem
    {
        public override void SetStaticDefaults()
        {
            Tooltip.SetDefault("Pulsing with heat.");
        }
        public override void SetDefaults()
        {
            item.width = 28;
            item.height = 28;
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
            if (Main.rand.Next(1,9) != 1)
            {
                if (Main.rand.Next(1, 4) == 1) player.QuickSpawnItem(173, Main.rand.Next(2, 6));
                if (Main.rand.Next(1, 4) == 2) player.QuickSpawnItem(174, Main.rand.Next(3, 5));
                if (Main.rand.Next(1, 4) == 3) player.QuickSpawnItem(mod.ItemType("ObsidiumOre"), Main.rand.Next(2, 6));
            }
            else
            {
                if (Main.rand.Next(1, 4) == 1) player.QuickSpawnItem(175, Main.rand.Next(1, 4));
                else player.QuickSpawnItem(mod.ItemType("ObsidiumBar"), Main.rand.Next(1, 4));
            }

            int ran = Main.rand.Next(1, 7);
            if (ran == 1) player.QuickSpawnItem(182, Main.rand.Next(1, 3));
            if (ran == 2) player.QuickSpawnItem(178, Main.rand.Next(1, 3));
            if (ran == 3) player.QuickSpawnItem(179, Main.rand.Next(1, 3));
            if (ran == 4) player.QuickSpawnItem(177, Main.rand.Next(1, 3));
            if (ran == 5) player.QuickSpawnItem(180, Main.rand.Next(1, 3));
            if (ran == 6) player.QuickSpawnItem(181, Main.rand.Next(1, 3));

            if (Main.rand.Next(1, 4) == 1) player.QuickSpawnItem(2701, Main.rand.Next(6, 13));
        }
        
    }
}