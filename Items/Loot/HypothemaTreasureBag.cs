using Laugicality.NPCs.PreTrio;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Laugicality.Items.Loot
{
    public class HypothemaTreasureBag : LaugicalityItem
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
            item.rare = ItemRarityID.Green;
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
            player.QuickSpawnItem(ModContent.ItemType("FrostShard"), Main.rand.Next(2,4));
            player.QuickSpawnItem(ModContent.ItemType("FrostEssence"), 1);
            player.QuickSpawnItem(ModContent.ItemType("ChilledBar"), Main.rand.Next(22, 36));
            int ran = Main.rand.Next(1, 7);
            if (ran == 1) player.QuickSpawnItem(ItemID.IceBoomerang, 1);
            if (ran == 2) player.QuickSpawnItem(ItemID.IceBlade, 1);
            if (ran == 3) player.QuickSpawnItem(ItemID.IceSkates, 1);
            if (ran == 4) player.QuickSpawnItem(ItemID.SnowballCannon, 1);
            if (ran == 5) player.QuickSpawnItem(987, 1);
            if (ran == 6) player.QuickSpawnItem(ItemID.FlurryBoots, 1);
            
    
            player.QuickSpawnItem(188, Main.rand.Next(10, 15));
            player.QuickSpawnItem(ItemID.SnowBlock, Main.rand.Next(40, 75));
            player.QuickSpawnItem(ItemID.IceBlock, Main.rand.Next(40, 75));

        }

        public override int BossBagNPC => mod.NPCType<Hypothema>();
    }
}