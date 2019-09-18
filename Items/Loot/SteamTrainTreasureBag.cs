using Laugicality.NPCs.SteamTrain;
using Terraria;
using Terraria.ID;

namespace Laugicality.Items.Loot
{
    public class SteamTrainTreasureBag : LaugicalityItem
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
            player.QuickSpawnItem(mod.ItemType<SteamBar>(), Main.rand.Next(20, 35));
            player.QuickSpawnItem(mod.ItemType<SoulOfWrought>(), Main.rand.Next(25, 40));
            player.QuickSpawnItem(mod.ItemType<SteamTank>());

            player.QuickSpawnItem(ItemID.GreaterHealingPotion, Main.rand.Next(10, 15));
        }

        public override int BossBagNPC => mod.NPCType<SteamTrain>();
    }
}