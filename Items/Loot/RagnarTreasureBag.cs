using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Laugicality.Items.Loot
{
    public class RagnarTreasureBag : ModItem
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
            item.rare = 11;
            item.expert = true;
            bossBagNPC = mod.NPCType("Ragnar");
        }

        public override bool CanRightClick()
        {
            return true;
        }


        public override void OpenBossBag(Player player)
        {
            player.QuickSpawnItem(mod.ItemType("DarkShard"), Main.rand.Next(2, 4));
            player.QuickSpawnItem(mod.ItemType("MoltenCore"), 1);
            int ran = Main.rand.Next(1, 7);
            if (ran == 1) player.QuickSpawnItem(49, 1);
            if (ran == 2) player.QuickSpawnItem(ItemID.MagicMirror, 1);
            if (ran == 3) player.QuickSpawnItem(53, 1);
            if (ran == 4) player.QuickSpawnItem(ItemID.HermesBoots, 1);
            if (ran == 5) player.QuickSpawnItem(ItemID.EnchantedBoomerang, 1);
            if (ran == 6) player.QuickSpawnItem(ItemID.LavaCharm, 1);

            player.QuickSpawnItem(188, Main.rand.Next(10, 15));

            int rand= Main.rand.Next(1, 7);
            if (rand== 1) player.QuickSpawnItem(182, Main.rand.Next(1, 3));
            if (rand== 2) player.QuickSpawnItem(178, Main.rand.Next(1, 3));
            if (rand== 3) player.QuickSpawnItem(179, Main.rand.Next(1, 3));
            if (rand== 4) player.QuickSpawnItem(177, Main.rand.Next(1, 3));
            if (rand== 5) player.QuickSpawnItem(180, Main.rand.Next(1, 3));
            if (rand== 6) player.QuickSpawnItem(181, Main.rand.Next(1, 3));
        }
        
    }
}