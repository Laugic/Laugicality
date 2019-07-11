using Laugicality.NPCs.RockTwins;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Laugicality.Items.Loot
{
    public class AnDioTreasureBag : LaugicalityItem
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
            player.QuickSpawnItem(mod.ItemType("DioritusCore"), Main.rand.Next(2, 4));
            player.QuickSpawnItem(mod.ItemType("AndesiaCore"), Main.rand.Next(2, 4));
            player.QuickSpawnItem(3081, Main.rand.Next(10, 31));
            player.QuickSpawnItem(3086, Main.rand.Next(10, 31));
            player.QuickSpawnItem(mod.ItemType("ZaWarudoWatch"), 1);
            player.QuickSpawnItem(188, Main.rand.Next(10, 15));

            int anDioItem = 0;
            int rand = Main.rand.Next(6);
            switch (rand)
            {
                case 0:
                    anDioItem = ItemID.DarkLance;
                    break;
                case 1:
                    anDioItem = ItemID.Flamelash;
                    break;
                case 2:
                    anDioItem = ItemID.FlowerofFire;
                    break;
                case 3:
                    anDioItem = ItemID.Sunfury;
                    break;
                case 4:
                    anDioItem = ItemID.HellwingBow;
                    break;
                default:
                    anDioItem = ItemID.ImpStaff;
                    break;
            }
            player.QuickSpawnItem(anDioItem, 1);
        }

        public override int BossBagNPC => mod.NPCType<AnDio3>();
    }
}