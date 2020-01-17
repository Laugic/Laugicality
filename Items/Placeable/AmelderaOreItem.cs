using Laugicality.Items.Materials;
using Laugicality.Tiles;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Laugicality.Items.Placeable
{
    public class AmelderaOreItem : LaugicalityItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Ameldera Ore");
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
            item.useAnimation = 8;
            item.useTime = 8;
            item.useStyle = 1;
            item.consumable = true;
            item.value = 0;
            item.rare = ItemRarityID.LightPurple;
            item.createTile = ModContent.TileType<ObsidiumOreBlock>();
        }



        public override void ExtractinatorUse(ref int resultType, ref int resultStack)
        {
            int category = Main.rand.Next(3);
            resultStack = 1;
            switch (category)
            {
                case 0:
                    GetPearls(ref resultType, ref resultStack);
                    break;
                default:
                    GetJunk(ref resultType, ref resultStack);
                    break;
            }
        }

        private void GetJunk(ref int resultType, ref int resultStack)
        {
            int type = Main.rand.Next(6);
            switch (type)
            {
                case 0:
                    resultType = ModContent.ItemType<Soot>();
                    resultStack += Main.rand.Next(0, 3);
                    break;
                case 1:
                    resultType = ModContent.ItemType<ElderockItem>();
                    resultStack += Main.rand.Next(0, 2);
                    break;
                case 2:
                    resultType = ModContent.ItemType<ElderlilyItem>();
                    resultStack += Main.rand.Next(0, 2);
                    break;
                case 3:
                    resultType = ModContent.ItemType<ElderootItem>();
                    break;
                default:
                    resultType = ModContent.ItemType<ObsidiumRock>();
                    resultStack += Main.rand.Next(0, 3);
                    break;
            }
        }

        private void GetPearls(ref int resultType, ref int resultStack)
        {
            resultType = ModContent.ItemType<ElderPearl>();
            if (Main.rand.NextBool(6))
                resultStack++;
        }
    }
}