using Laugicality.NPCs.PreTrio;
using Terraria;
using Terraria.ID;

namespace Laugicality.Items.Loot
{
    public class DuneSharkronTreasureBag : LaugicalityItem
    {
        public override void SetStaticDefaults()
        {
            Tooltip.SetDefault("");
        }
        public override void SetDefaults()
        {
            item.width = 44;
            item.height = 34;
            item.maxStack = 20;
            item.rare = ItemRarityID.Orange;
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
            player.QuickSpawnItem(mod.ItemType("AncientShard"), Main.rand.Next(2,4));
            player.QuickSpawnItem(mod.ItemType("Crystilla"), Main.rand.Next(8, 15));
            player.QuickSpawnItem(mod.ItemType("Pyramind"), 1);
            int ran = Main.rand.Next(1, 8);
            if (ran == 1) player.QuickSpawnItem(ItemID.SandstorminaBottle, 1);
            if (ran == 2) player.QuickSpawnItem(ItemID.FlyingCarpet, 1);
            if (ran == 3) player.QuickSpawnItem(ItemID.BandofRegeneration, 1);
            if (ran == 4) player.QuickSpawnItem(ItemID.MagicMirror, 1);
            if (ran == 5) player.QuickSpawnItem(ItemID.CloudinaBottle, 1);
            if (ran == 6) player.QuickSpawnItem(ItemID.HermesBoots, 1);
            if (ran == 7) player.QuickSpawnItem(ItemID.EnchantedBoomerang, 1);

            player.QuickSpawnItem(188, Main.rand.Next(10, 15));
        }

        public override int BossBagNPC => mod.NPCType<DuneSharkron>();
    }
}