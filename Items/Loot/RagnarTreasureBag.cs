using Laugicality.Items.Equipables;
using Laugicality.NPCs.PreTrio;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Laugicality.Items.Loot
{
    public class RagnarTreasureBag : LaugicalityItem
    {
        public override void SetStaticDefaults()
        {
            Tooltip.SetDefault("");
        }
        public override void SetDefaults()
        {
            item.width = 30;
            item.height = 32;
            item.maxStack = 20;
            item.useAnimation = 45;
            item.useTime = 45;
            item.useStyle = 1;
            item.consumable = true;
            item.rare = ItemRarityID.Purple;
            item.expert = true;
        }

        public override bool CanRightClick()
        {
            return true;
        }


        public override void OpenBossBag(Player player)
        {
            player.QuickSpawnItem(ModContent.ItemType<DarkShard>(), Main.rand.Next(2, 4));
            player.QuickSpawnItem(ModContent.ItemType<MoltenCore>(), 1);
            player.QuickSpawnItem(ModContent.ItemType<ObsidiumChunk>(), Main.rand.Next(3, 5));
            
            int obsidiumItem = 0;
            int rand = Main.rand.Next(7);
            switch (rand)
            {
                case 0:
                    obsidiumItem = ItemID.LavaCharm;
                    break;
                case 1:
                    obsidiumItem = ModContent.ItemType<ObsidiumLily>();
                    break;
                case 2:
                    obsidiumItem = ModContent.ItemType<FireDust>();
                    break;
                case 3:
                    obsidiumItem = ModContent.ItemType<Eruption>();
                    break;
                case 4:
                    obsidiumItem = ModContent.ItemType<CrystalizedMagma>();
                    break;
                case 5:
                    obsidiumItem = ModContent.ItemType<Ragnashia>();
                    break;
                default:
                    obsidiumItem = ModContent.ItemType<MagmaHeart>();
                    break;
            }
            player.QuickSpawnItem(obsidiumItem, 1);

            player.QuickSpawnItem(188, Main.rand.Next(10, 15));
        }

        public override int BossBagNPC => ModContent.NPCType<Ragnar>();
    }
}