using Laugicality.Items.Equipables;
using Laugicality.Tiles;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Laugicality.Items.Placeable
{
    public class Soot : LaugicalityItem
    {
        public override void SetStaticDefaults()
        {
            Tooltip.SetDefault("Can be used in the Extractinator");
            ItemID.Sets.ExtractinatorMode[item.type] = item.type;
        }

        public override void SetDefaults()
        {
            item.width = 16;
            item.height = 16;
            item.maxStack = 999;
            item.useTurn = true;
            item.autoReuse = true;
            item.useAnimation = 15;
            item.useTime = 2;
            item.useStyle = 1;
            item.consumable = true;
            item.value = 0;
            item.createTile = mod.TileType<SootTile>();
        }

        public override void ExtractinatorUse(ref int resultType, ref int resultStack)
        {
            int category = Main.rand.Next(4);
            resultStack = 1;
            switch (category)
            {
                case 0:
                    GetMoney(ref resultType, ref resultStack);
                    break;
                case 1:
                    GetOre(ref resultType, ref resultStack);
                    break;
                case 2:
                    GetGem(ref resultType, ref resultStack);
                    break;
                default:
                    GetMisc(ref resultType, ref resultStack);
                    break;
            }
        }

        private void GetMoney(ref int resultType, ref int resultStack)
        {
            if(Main.rand.Next(2) == 0)
            {
                resultType = ItemID.CopperCoin;
                resultStack = Main.rand.Next(50, 99);
            }
            else if (Main.rand.Next(50) <= 48)
            {
                resultType = ItemID.SilverCoin;
                resultStack = Main.rand.Next(5, 10);
            }
            else if(Main.rand.Next(2) == 0)
            {
                resultType = ItemID.GoldCoin;
                resultStack = 1;
            }
            else
            {
                resultType = ItemID.CopperCoin;
                resultStack = Main.rand.Next(50, 99);
            }
            if (Main.rand.NextBool(8))
                resultStack++;
        }
        private void GetOre(ref int resultType, ref int resultStack)
        {
            int type = Main.rand.Next(7);
            switch(type)
            {
                case 0:
                    resultType = ItemID.SilverOre;
                    break;
                case 1:
                    resultType = ItemID.TungstenOre;
                    break;
                case 2:
                    resultType = ItemID.GoldOre;
                    break;
                case 3:
                    resultType = ItemID.PlatinumOre;
                    break;
                default:
                    resultType = mod.ItemType<ObsidiumOre>();
                    break;
            }
            if (Main.rand.NextBool(8))
                resultStack++;
        }
        private void GetGem(ref int resultType, ref int resultStack)
        {
            int type = Main.rand.Next(9);
            switch (type)
            {
                case 0:
                    resultType = ItemID.Amethyst;
                    break;
                case 1:
                    resultType = ItemID.Topaz;
                    break;
                case 2:
                    resultType = ItemID.Sapphire;
                    break;
                case 3:
                    resultType = ItemID.Emerald;
                    break;
                case 4:
                    resultType = ItemID.Ruby;
                    break;
                case 5:
                    resultType = ItemID.Diamond;
                    break;
                default:
                    resultType = mod.ItemType<LavaGem>();
                    break;
            }
            if (Main.rand.NextBool(8))
                resultStack++;
        }
        private void GetMisc(ref int resultType, ref int resultStack)
        {
            int category = Main.rand.Next(100);
            if(category < 48)
                GetOre(ref resultType, ref resultStack);
            else if(category < 95)
                GetGem(ref resultType, ref resultStack);
            else
            {
                int rand = Main.rand.Next(7);
                switch (rand)
                {
                    case 0:
                        resultType = ItemID.LavaCharm;
                        break;
                    case 1:
                        resultType = mod.ItemType<ObsidiumLily>();
                        break;
                    case 2:
                        resultType = mod.ItemType<FireDust>();
                        break;
                    case 3:
                        resultType = mod.ItemType<Eruption>();
                        break;
                    case 4:
                        resultType = mod.ItemType<CrystalizedMagma>();
                        break;
                    case 5:
                        resultType = mod.ItemType<Ragnashia>();
                        break;
                    default:
                        resultType = mod.ItemType<MagmaHeart>();
                        break;
                }
            }
        }
    }
}