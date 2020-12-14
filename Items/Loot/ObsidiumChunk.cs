using Laugicality.Items.Materials;
using Laugicality.Items.Placeable;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Laugicality.Items.Loot
{
    public class ObsidiumChunk : LaugicalityItem
    {
        public override void SetStaticDefaults()
        {
            Tooltip.SetDefault("Pulsing with heat\nRight Click to open");
        }

        public override void SetDefaults()
        {
            item.width = 28;
            item.height = 28;
            item.maxStack = 20;
            item.rare = ItemRarityID.Orange;
            item.useAnimation = 45;
            item.useTime = 45;
            item.useStyle = ItemUseStyleID.HoldingUp;
            item.UseSound = SoundID.Item9;
            item.consumable = true;
        }

        public override bool CanRightClick()
        {
            return true;
        }


        public override void RightClick(Player player)
        {
            if (Main.hardMode)
            {
                if (Main.rand.Next(8) != 0)
                {
                    int rand = Main.rand.Next(10);
                    switch (rand)
                    {
                        case 1:
                            player.QuickSpawnItem(ItemID.CobaltOre, Main.rand.Next(4, 12));
                            break;
                        case 2:
                            player.QuickSpawnItem(ItemID.CobaltBar, Main.rand.Next(2, 7));
                            break;
                        case 3:
                            player.QuickSpawnItem(ItemID.MythrilOre, Main.rand.Next(4, 12));
                            break;
                        case 4:
                            player.QuickSpawnItem(ItemID.MythrilBar, Main.rand.Next(2, 7));
                            break;
                        case 5:
                            player.QuickSpawnItem(ItemID.PalladiumOre, Main.rand.Next(4, 12));
                            break;
                        case 6:
                            player.QuickSpawnItem(ItemID.PalladiumBar, Main.rand.Next(2, 7));
                            break;
                        case 7:
                            player.QuickSpawnItem(ItemID.OrichalcumOre, Main.rand.Next(4, 12));
                            break;
                        case 8:
                            player.QuickSpawnItem(ItemID.OrichalcumBar, Main.rand.Next(2, 7));
                            break;
                        default:
                            player.QuickSpawnItem(ModContent.ItemType<ObsidiumBar>(), Main.rand.Next(8, 15));
                            break;
                    }
                    if (Main.rand.Next(1, 4) == 0) player.QuickSpawnItem(173, Main.rand.Next(4, 12));
                }
                else
                {
                    if (Main.rand.Next(1, 4) == 1) player.QuickSpawnItem(175, Main.rand.Next(6, 13));
                    else player.QuickSpawnItem(ModContent.ItemType<ObsidiumBar>(), Main.rand.Next(6, 13));
                }

                int ran = Main.rand.Next(1, 8);
                if (ran == 1) player.QuickSpawnItem(182, Main.rand.Next(2, 4));
                if (ran == 2) player.QuickSpawnItem(178, Main.rand.Next(2, 4));
                if (ran == 3) player.QuickSpawnItem(179, Main.rand.Next(2, 4));
                if (ran == 4) player.QuickSpawnItem(177, Main.rand.Next(2, 4));
                if (ran == 5) player.QuickSpawnItem(180, Main.rand.Next(2, 4));
                if (ran == 6) player.QuickSpawnItem(181, Main.rand.Next(2, 4));
                if (ran == 7) player.QuickSpawnItem(ModContent.ItemType<LavaGemItem>(), Main.rand.Next(2, 4));
                
            }
            else
            {
                if (Main.rand.Next(1, 9) != 1)
                {
                    if (Main.rand.Next(1, 4) == 1) player.QuickSpawnItem(173, Main.rand.Next(2, 6));
                    if (Main.rand.Next(1, 4) == 2) player.QuickSpawnItem(174, Main.rand.Next(3, 5));
                    if (Main.rand.Next(1, 4) == 3) player.QuickSpawnItem(ModContent.ItemType<ObsidiumOre>(), Main.rand.Next(2, 6));
                }
                else
                {
                    if (Main.rand.Next(1, 4) == 1) player.QuickSpawnItem(175, Main.rand.Next(1, 4));
                    else player.QuickSpawnItem(ModContent.ItemType<ObsidiumBar>(), Main.rand.Next(1, 4));
                }

                int ran = Main.rand.Next(1, 8);
                if (ran == 1) player.QuickSpawnItem(182, Main.rand.Next(1, 3));
                if (ran == 2) player.QuickSpawnItem(178, Main.rand.Next(1, 3));
                if (ran == 3) player.QuickSpawnItem(179, Main.rand.Next(1, 3));
                if (ran == 4) player.QuickSpawnItem(177, Main.rand.Next(1, 3));
                if (ran == 5) player.QuickSpawnItem(180, Main.rand.Next(1, 3));
                if (ran == 6) player.QuickSpawnItem(181, Main.rand.Next(1, 3));
                if (ran == 7) player.QuickSpawnItem(ModContent.ItemType<LavaGemItem>(), Main.rand.Next(1, 3));

                if (Main.rand.Next(1, 4) == 1) player.QuickSpawnItem(2701, Main.rand.Next(6, 13));
            }
        }
        
    }
}