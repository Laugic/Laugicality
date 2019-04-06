using Terraria;
using Terraria.ModLoader;

namespace Laugicality.Items.Loot
{
    public class DuneSharkronTreasureBag : ModItem
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
            item.rare = 3;
            item.useAnimation = 45;
            item.useTime = 45;
            item.useStyle = 1;
            item.consumable = true;
            item.rare = 11;
            item.expert = true;
            bossBagNPC = mod.NPCType("DuneSharkron");
        }

        public override bool CanRightClick()
        {
            return true;
        }


        public override void OpenBossBag(Player player)
        {
            player.QuickSpawnItem(mod.ItemType("AncientShard"), Main.rand.Next(2,4));
            player.QuickSpawnItem(mod.ItemType("Crystilla"), Main.rand.Next(6, 11));
            player.QuickSpawnItem(mod.ItemType("Pyramind"), 1);
            int ran = Main.rand.Next(1, 5);
            if (ran == 1) player.QuickSpawnItem(934, 1);
            if (ran == 2) player.QuickSpawnItem(857, 1);
            if (ran == 3) player.QuickSpawnItem(848, 1);
            if (ran == 4) player.QuickSpawnItem(866, 1);

            player.QuickSpawnItem(188, Main.rand.Next(10, 15));
        }
        
    }
}