using Laugicality.Items.Consumables.Potions;
using Laugicality.Items.Equipables;
using Laugicality.Structures;
using Laugicality.Tiles;
using System;
using Laugicality.Items.Materials;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;

namespace Laugicality
{
    partial class LaugicalityWorld
    {
        private void GenerateObsidium(int xO, int yO)
        {
            CreateObsidiumRock(xO, yO);

            //CreateWallVeins(xO, yO);

            GenerateObsidiumVeins(xO, yO);

            CreateObsidiumCaverns(xO, yO);
        }



        public void GenVein(double x, double y, double direction, double curve, double jerk, double growth, double wiggle, int length, int thiccness, int branches, double initialThicc, ushort tile)
        {
            double curThicc = initialThicc;
            bool genBranch = false;
            for (int i = 0; i < length * 2; i++)
            {
                GenBumpyCircle(x, y, curThicc / 2, tile);
                x += Math.Cos(direction);
                y += Math.Sin(direction);
                direction += curve;
                curve = curve / Math.Abs(curve) * Math.Min(Math.Abs(curve) * jerk, Math.PI / length);
                if (Main.rand.NextDouble() < wiggle)
                    curve = -curve;
                if (curThicc < thiccness)
                    curThicc += growth;
                if (Main.rand.NextDouble() < wiggle * 2)
                    curThicc -= growth * 2;
                if(curThicc > length * 2 - i && !genBranch && branches > 0)
                {
                    GenBranches(branches, x, y, direction - Math.PI / 3 + Main.rand.NextDouble() * Math.PI * .667, curve * (Main.rand.Next(2) * 2 - 1) / 2, jerk, growth, wiggle, length / 2, Math.Max(2, thiccness - 2), curThicc, tile);
                    genBranch = true;
                }
                curThicc = Math.Min(curThicc, length * 2 - i);
            }
        }

        private void GenBranches(int branches, double x, double y, double direction, double curve, double jerk, double growth, double wiggle, int length, int thiccness, double curThicc, ushort tile)
        {
            for (int i = 0; i < branches; i++)
                GenVein(x, y, direction - Math.PI / 3 + Main.rand.NextDouble() * Math.PI * .667, curve * (Main.rand.Next(2) * 2 - 1) / 2, jerk, growth, wiggle, length / 2, Math.Max(2, thiccness - 2), curThicc, tile);
        }

        private void GenBumpyCircle(double x, double y, double radius, ushort tile)
        {
            for (int i = -(int)radius; i <= radius; i++)
            {
                for (int j = -(int)radius; j <= radius; j++)
                {
                    if (TileCheckSafe((int)x + i, (int)y + j))
                    {
                        var dist = Distance(x + i, y + j, x, y);
                        if (dist <= radius)
                        {
                            Main.tile[(int)x + i, (int)y + j].liquid = 0;
                            WorldGen.PlaceTile((int)x + i, (int)y + j, tile, true, true);
                        }
                    }
                }
            }
        }

        public void GenVein(double x, double y, double direction, double curve, double jerk, double growth, double wiggle, int length, int thiccness, double initialThicc, ushort tile)
        {
            GenVein(x, y, direction, curve, jerk, growth, wiggle, length, thiccness, 0, initialThicc, tile);
        }

        public void GenVein(double x, double y, int length, int thiccness, int branches, double initialThicc, ushort tile)
        {
            GenVein(x, y,
                    Math.PI * 2 * Main.rand.NextDouble(),
                    (Main.rand.NextDouble() * Math.PI / length + .05) * (Main.rand.Next(2) * 2 - 1),
                    (.975 + Main.rand.NextDouble() * .05),
                    .5 + Main.rand.NextDouble() / 2,
                    Main.rand.NextDouble() / 5,
                    length,
                    thiccness,
                    branches,
                    initialThicc,
                    tile);
        }

        private void CreateObsidiumRock(int xO, int yO)
        {
            for (int i = (int)(-225 * sizeMult); i <= (int)(225 * sizeMult); i++)
            {
                for (int j = (int)(-275 * sizeMult); j <= (int)(275 * sizeMult); j++)
                {
                    CreateObsidiumTileCheck(xO, yO, i, j);
                }
            }
        }

        private void CreateWallVeins(int xO, int yO)
        {
            GenerateFeature(xO, yO, 80, (ushort)ModContent.TileType<Lycoris>(), 5, 8, 140 * sizeMult);


            for (int i = (int)(-250 * sizeMult); i <= (int)(250 * sizeMult); i++)
            {
                for (int j = (int)(-325 * sizeMult); j <= (int)(325 * sizeMult); j++)
                {
                    if (TileCheckSafe(xO + i, yO + j))
                    {
                        if (Main.tile[xO + i, yO + j].type == (ushort)ModContent.TileType<Lycoris>())
                        {
                            PlaceTile(xO + i, yO + j, ModContent.TileType<Tiles.ObsidiumRock>(), WallID.Lavafall);
                        }
                    }
                }
            }
        }

        private void CreateObsidiumTileCheck(int xO, int yO, int i, int j)
        {
            if (TileCheckSafe(xO + i, yO + j))
            {
                if (Main.tile[xO + i, yO + j].wall != WallID.LihzahrdBrick && Main.tile[xO + i, yO + j].type != TileID.LihzahrdBrick)
                {
                    if (j < -(int)(150 * sizeMult))
                    {
                        GenerateCavernTop(xO, yO, i, j);
                    }
                    else if (j < 0)
                    {
                        GenerateCavernTopMid(xO, yO, i, j);
                    }
                    else if (j < (int)(100 * sizeMult))
                    {
                        GenerateCavernMid(xO, yO, i, j);
                    }
                    else if (j < 200 * sizeMult && yO + j < Main.maxTilesY - 200)
                    {
                        GenerateCavernBottom(xO, yO, i, j);
                    }
                }
            }
        }

        private void GenerateCavernTop(int xO, int yO, int i, int j)
        {
            int sign = 1;
            if (i != 0)
                sign = (int)(Math.Abs(i) / i);
            if (Distance(xO + sign * 100 * sizeMult, yO - 150 * sizeMult, xO + i, yO + j) < 100 * sizeMult)
            {
                PlaceTile(xO + i, yO + j, ModContent.TileType<Tiles.ObsidiumRock>(), mod.WallType("ObsidiumRockWall"));
            }
            else if (Distance(xO + sign * 100 * sizeMult, yO - (int)(150 * sizeMult), xO + i, yO + j) < 100 * sizeMult + 6)
            {
                if (Main.rand.Next(6) < 100 * sizeMult + 6 - Distance(xO + sign * 100 * sizeMult, yO - 150 * sizeMult, xO + i, yO + j))
                {
                    PlaceTile(xO + i, yO + j, ModContent.TileType<Tiles.ObsidiumRock>());
                }
            }
        }

        private void GenerateCavernTopMid(int xO, int yO, int i, int j)
        {
            if (Distance(xO + i, yO + j, xO, yO) < (int)(150 * sizeMult - (int)(j * 2 / 3)))
            {
                PlaceTile(xO + i, yO + j, ModContent.TileType<Tiles.ObsidiumRock>(), mod.WallType("ObsidiumRockWall"));
            }
            else if (Distance(xO + i, yO + j, xO, yO) < (int)(150 * sizeMult - (int)(j * 2 / 3)) + 6)
            {
                if (Main.rand.Next(6) < -Distance(xO + i, yO + j, xO, yO) + 6 + (int)(150 * sizeMult - (int)(j * 2 / 3)))
                {
                    PlaceTile(xO + i, yO + j, ModContent.TileType<Tiles.ObsidiumRock>());
                }
            }
        }

        private void GenerateCavernMid(int xO, int yO, int i, int j)
        {
            if (Distance(xO + i, yO + j, xO, yO) < (int)(150 * sizeMult - .47 * j))
            {
                PlaceTile(xO + i, yO + j, ModContent.TileType<Tiles.ObsidiumRock>(), mod.WallType("ObsidiumRockWall"));
            }
            else if (Distance(xO + i, yO + j, xO, yO) < (int)(150 * sizeMult - .47 * j) + 6)
            {
                if (Main.rand.Next(6) < -Distance(xO + i, yO + j, xO, yO) + 6 + (int)(150 * sizeMult - .47 * j))
                {
                    PlaceTile(xO + i, yO + j, ModContent.TileType<Tiles.ObsidiumRock>());
                }
            }
        }

        private void GenerateCavernBottom(int xO, int yO, int i, int j)
        {
            int radius = 100 * sizeMult;//(Main.tile.GetLength(1) - 200) - (yO + (int)(100 * sizeMult));
            if (!TileCheckSafe(xO + i, yO + j))
                return;
            if (i < 0 && i > -radius)
            {
                if (Distance(xO + i, yO + j, xO - (int)(25 * sizeMult) - radius, yO + (int)(100 * sizeMult)) > radius)
                {
                    PlaceTile(xO + i, yO + j, ModContent.TileType<Tiles.ObsidiumRock>(), mod.WallType("ObsidiumRockWall"));
                }
                else if (Distance(xO + i, yO + j, xO - (int)(25 * sizeMult) - radius, yO + (int)(100 * sizeMult)) < radius + 6)
                {
                    if (Main.rand.Next(6) < Distance(xO + i, yO + j, xO - (int)(25 * sizeMult) - radius, yO + (int)(100 * sizeMult)) - 6 - radius)
                    {
                        PlaceTile(xO + i, yO + j, ModContent.TileType<Tiles.ObsidiumRock>());
                    }
                }
            }
            else if (i >= 0 && i < radius + 1)
            {
                if (Distance(xO + i, yO + j, xO + (int)(25 * sizeMult) + radius, yO + (int)(100 * sizeMult)) > radius)
                {
                    PlaceTile(xO + i, yO + j, ModContent.TileType<Tiles.ObsidiumRock>(), mod.WallType("ObsidiumRockWall"));
                }
                else if (Distance(xO + i, yO + j, xO + (int)(25 * sizeMult) + radius, yO + (int)(100 * sizeMult)) < radius + 6)
                {
                    if (Main.rand.Next(6) < Distance(xO + i, yO + j, xO + (int)(25 * sizeMult) + radius, yO + (int)(100 * sizeMult)) - 6 - radius)
                    {
                        PlaceTile(xO + i, yO + j, ModContent.TileType<Tiles.ObsidiumRock>());
                    }
                }
            }
        }

        private void CreateObsidiumCaverns(int xO, int yO)
        {
            GenerateCave(xO, yO, 100 * sizeMult, (ushort)TileID.BubblegumBlock, 9 * sizeMult, 15 * sizeMult, 3 * sizeMult);
            GenerateCave(xO, yO, 50 * sizeMult, (ushort)TileID.BubblegumBlock, 16, 25, 140 * sizeMult);
            GenerateCave(xO, yO, 50 * sizeMult, (ushort)TileID.BubblegumBlock, 25, 30, 25 * sizeMult);
            
            for (int i = (int)(-250 * sizeMult); i <= (int)(250 * sizeMult); i++)
            {
                for (int j = (int)(-325 * sizeMult); j <= (int)(325 * sizeMult); j++)
                {
                    if (TileCheckSafe(xO + i, yO + j))
                    {
                        if (Main.tile[xO + i, yO + j].type == (ushort)249)
                        {
                            WorldGen.KillTile(xO + i, yO + j);
                        }
                    }
                }
            }
        }


        private void GenerateObsidiumVeins(int xO, int yO)
        {
            /*
            GenerateVeins(xO, yO, 100, (ushort)ModContent.TileType<SootTile>(), 16, 32, 2, 4, 2, 3);
            GenerateVeins(xO, yO, 100, (ushort)ModContent.TileType<Radiata>(), 16, 32, 2, 4, 2, 3);
            GenerateVeins(xO, yO, 120, (ushort)ModContent.TileType<Lycoris>(), 16, 32, 2, 4, 2, 3);
            GenerateVeins(xO, yO, 160, (ushort)ModContent.TileType<ObsidiumOreBlock>(), 12, 20, 2, 3, 0, 2);*/
            GenerateFeature(xO, yO, 25, (ushort)ModContent.TileType<Tiles.Radiata>(), 2, 6, 180 * sizeMult);
            GenerateFeature(xO, yO, 50, (ushort)ModContent.TileType<Lycoris>(), 3, 6, 140 * sizeMult);
            GenerateFeature(xO, yO, 75, (ushort)ModContent.TileType<Tiles.Radiata>(), 3, 5, 180 * sizeMult);
            GenerateFeature(xO, yO, 75, (ushort)ModContent.TileType<Lycoris>(), 3, 5, 140 * sizeMult);
            GenerateFeature(xO, yO, 100, (ushort)ModContent.TileType<SootTile>(), 12, 18, 25 * sizeMult);
            GenerateFeature(xO, yO, 80, (ushort)ModContent.TileType<ObsidiumOreBlock>(), 3, 6, 50 * sizeMult);
            GenerateFeature(xO, yO, 40, (ushort)ModContent.TileType<ObsidiumOreBlock>(), 6, 9, 30 * sizeMult);
        }

        private void GenerateCave(int xO, int yO, int numSteps, ushort tileType, int minSize, int maxSize, int length)
        {
            for (int k = 0; k < numSteps * sizeMult; k++)
            {
                int x = xO + Main.rand.Next(-200 * sizeMult, 200 * sizeMult);
                int y = yO + Main.rand.Next(-250 * sizeMult, 250 * sizeMult);
                if (Main.tile[x, y].type == (ushort)ModContent.TileType<Tiles.ObsidiumRock>() || (Main.tile[x, y].active() == false && (Main.tile[x, y].wall == mod.WallType("ObsidiumRockWall") || Main.tile[x, y].wall == WallID.Lavafall)) || Main.tile[x, y].type == (ushort)ModContent.TileType<Lycoris>() || Main.tile[x, y].type == (ushort)ModContent.TileType<Tiles.Radiata>())
                    WorldGen.TileRunner(x, y, Main.rand.Next(minSize, maxSize), length, tileType, false, 0f, 0f, false, true);
            }
        }

        private void GenerateFeature(int xO, int yO, int numSteps, ushort tileType, int minSize, int maxSize, int length)
        {
            for (int k = 0; k < numSteps * sizeMult; k++)
            {
                int x = xO + Main.rand.Next(-225 * sizeMult, 225 * sizeMult);
                int y = yO + Main.rand.Next(-275 * sizeMult, 275 * sizeMult);
                if (Main.tile[x, y].type == (ushort)ModContent.TileType<Tiles.ObsidiumRock>() || (Main.tile[x, y].active() == false && (Main.tile[x, y].wall == mod.WallType("ObsidiumRockWall") || Main.tile[x, y].wall == WallID.Lavafall)) || Main.tile[x, y].type == (ushort)ModContent.TileType<Lycoris>() || Main.tile[x, y].type == (ushort)ModContent.TileType<Tiles.Radiata>())
                    WorldGen.TileRunner(x, y, Main.rand.Next(minSize, maxSize), length, tileType, false, 0f, 0f, false, true);
            }
        }

        private void GenerateVeins(int xO, int yO, int numSteps, ushort tileType, int minLength, int maxLength, int minThicc, int maxThicc, int minBranches, int maxBranches)
        {
            for (int k = 0; k < numSteps * sizeMult; k++)
            {
                int x = xO + Main.rand.Next(-225 * sizeMult, 225 * sizeMult);
                int y = yO + Main.rand.Next(-275 * sizeMult, 275 * sizeMult);
                if (Main.tile[x, y].type == (ushort)ModContent.TileType<Tiles.ObsidiumRock>() || (Main.tile[x, y].active() == false && (Main.tile[x, y].wall == mod.WallType("ObsidiumRockWall") || Main.tile[x, y].wall == WallID.Lavafall)) || Main.tile[x, y].type == (ushort)ModContent.TileType<Lycoris>() || Main.tile[x, y].type == (ushort)ModContent.TileType<Tiles.Radiata>())
                    GenVein(x, y, Main.rand.Next(minLength, maxLength + 1), Main.rand.Next(minThicc, maxThicc + 1), Main.rand.Next(minBranches, maxBranches + 1), 0, tileType);
            }
        }

        private void GenerateObsidiumStructures(int xO, int yO)
        {
            DecorationStructures(xO, yO);

            LootStructures(xO, yO);

            HeartWorld.HeartGen(xO - 60, yO - 90);
        }

        private void DecorationStructures(int xO, int yO)
        {
            int s = Main.rand.Next(8);
            int structX = xO - 225 * sizeMult + Main.rand.Next(225 * sizeMult * 2);
            int structY = yO - 275 * sizeMult + Main.rand.Next(275 * sizeMult / 2);

            for (int q = 0; q < 12 * sizeMult; q++)
            {
                s = GenerateDecorationStructure(s, structX, structY);
                Point16 newStructurePosition = new Point16(structX, structY);
                newStructurePosition = AlterStructureLocation(xO, yO, structX, structY);
                structX = newStructurePosition.X;
                structY = newStructurePosition.Y;
            }
        }

        private int GenerateDecorationStructure(int s, int structX, int structY)
        {
            if (TileCheckSafe(structX, structY))
            {
                if (Main.tile[structX, structY].wall == mod.WallType("ObsidiumRockWall") || Main.tile[structX, structY].wall == WallID.Lavafall)
                {
                    bool mirrored = false;
                    if (Main.rand.Next(2) == 0)
                        mirrored = true;

                    PickDecorationStructure(s, structX, structY, mirrored);

                    s++;
                    if (s >= 8)
                        s = 0;
                }
            }
            return s;
        }

        private Point16 AlterStructureLocation(int xO, int yO, int structX, int structY)
        {
            structX = Main.rand.Next(-250 * sizeMult, 250 * sizeMult) + xO;
            structY = Main.rand.Next(-275 * sizeMult, 275 * sizeMult) + yO;
            Point16 structurePosition = new Point16(structX, structY);
            return structurePosition;
        }

        private void PickDecorationStructure(int s, int structX, int structY, bool mirrored)
        {
            switch (s)
            {
                case 0:
                    TreeRuin.StructureGen(structX, structY, mirrored);
                    break;
                case 1:
                    PetrifiedTitans.StructureGen(structX, structY, mirrored);
                    break;
                case 2:
                    ObsidiumChalice.StructureGen(structX, structY, mirrored);
                    break;
                case 3:
                    LycorisCave.StructureGen(structX, structY, mirrored);
                    break;
                case 4:
                    LavaCave1.StructureGen(structX, structY, mirrored);
                    break;
                case 5:
                    LavaCave2.StructureGen(structX, structY, mirrored);
                    break;
                case 6:
                    LavaCave3.StructureGen(structX, structY, mirrored);
                    break;
                case 7:
                    LivingLycoris.StructureGen(structX, structY, mirrored);
                    break;
                default:
                    LavaCave1.StructureGen(structX, structY, mirrored);
                    break;
            }
        }

        private void LootStructures(int xO, int yO)
        {
            int structX = xO - 225 * sizeMult + Main.rand.Next(225 * sizeMult * 2);
            int structY = yO - 275 * sizeMult + Main.rand.Next(275 * sizeMult / 2);

            for (int q = 0; q < 10 * sizeMult; q++)
            {
                GenerateLootStructure(structX, structY);
                Point16 newStructurePosition = new Point16(structX, structY);
                newStructurePosition = AlterStructureLocation(xO, yO, structX, structY);
                structX = newStructurePosition.X;
                structY = newStructurePosition.Y;
            }
        }

        private void GenerateLootStructure(int structX, int structY)
        {
            if (TileCheckSafe(structX, structY))
            {
                if (Main.tile[structX, structY].wall == mod.WallType("ObsidiumRockWall") || Main.tile[structX, structY].wall == WallID.Lavafall)
                {
                    ObsidiumHouses.GenerateHouse(structX, structY);
                }
            }
        }

        public static void PlaceObsidiumChest(int x, int y, ushort floorType)
        {
            ClearSpaceForChest(x, y, floorType);
            int chestIndex = WorldGen.PlaceChest(x, y, (ushort)ModContent.TileType<ObsidiumChest>(), false, 0);

            int specialItem = GetObsidiumLoot();
            obsidiumPosition++;
            int[] oreLoot = GetObsidiumOreLoot();
            int[] potionLoot = GetObsidiumPotionLoot();
            int[] money = GetObsidiumMoneyLoot();
            int[] miscLoot = GetObsidiumMiscLoot();

            int[] itemsToPlaceInChests = new int[] { specialItem, oreLoot[0], potionLoot[0], money[0], miscLoot[0] };
            int[] itemCounts = new int[] { 1, oreLoot[1], potionLoot[1], money[1], miscLoot[1] };

            FillChest(chestIndex, itemsToPlaceInChests, itemCounts);
        }

        private static int GetObsidiumLoot()
        {
            int[] obsidiumLoot = new int[] { ModContent.ItemType<Eruption>(), ModContent.ItemType<FireDust>(), ModContent.ItemType<CrystalizedMagma>(), ModContent.ItemType<ObsidiumLily>(), ModContent.ItemType<MagmaHeart>(), ModContent.ItemType<Ragnashia>(), };

            if (obsidiumPosition < obsidiumLoot.GetLength(0))
                return obsidiumLoot[obsidiumPosition];
            else
            {
                obsidiumPosition = 0;
                return obsidiumLoot[obsidiumPosition];
            }
        }

        private static int[] GetObsidiumOreLoot()
        {
            int[] oreLoot = new int[] { ItemID.GoldBar, ItemID.PlatinumBar, ItemID.TungstenBar, ItemID.SilverBar };
            int orePos = Main.rand.Next(oreLoot.GetLength(0));
            int oreCount = Main.rand.Next(6, 16);
            int[] ore = { 0, 0 };
            ore[0] = oreLoot[orePos];
            ore[1] = oreCount;
            return ore;
        }

        private static int[] GetObsidiumPotionLoot()
        {
            int[] potLoot = new int[] { ModContent.ItemType<JumpBoostPotion>(), ItemID.InfernoPotion, ItemID.ObsidianSkinPotion, ItemID.LifeforcePotion, ItemID.WrathPotion };
            int potPos = Main.rand.Next(potLoot.GetLength(0));
            int potCount = Main.rand.Next(2, 5);
            int[] pot = { 0, 0 };
            pot[0] = potLoot[potPos];
            pot[1] = potCount;
            return pot;
        }

        private static int[] GetObsidiumMoneyLoot()
        {
            int monType = 0;
            int monCount = 0;
            if (Main.rand.Next(2) == 0)
            {
                monType = ItemID.GoldCoin;
                monCount = Main.rand.Next(1, 4);
            }
            else
            {
                monType = ItemID.SilverCoin;
                monCount = Main.rand.Next(60, 99);
            }
            int[] mon = { 0, 0 };
            mon[0] = monType;
            mon[1] = monCount;
            return mon;
        }

        private static int[] GetObsidiumMiscLoot()
        {
            int[] mscLoot = new int[] {
                ModContent.ItemType<Items.Placeable.LavaGemItem>(), ModContent.ItemType<Items.Placeable.Lycoris>(),
                ModContent.ItemType<Items.Placeable.Radiata>() };

            int mscPos = Main.rand.Next(mscLoot.GetLength(0));
            int mscCount = Main.rand.Next(4, 9);
            int[] msc = { 0, 0 };
            msc[0] = mscLoot[mscPos];
            msc[1] = mscCount;
            return msc;
        }

        public override void PostWorldGen()
        {
            DryTheObsidium();
            GrowLavaGems();
        }
        
        private void DryTheObsidium()
        {
            for(int i = 0; i < Main.maxTilesX - 2; i++)
            {
                for (int j = 0; j < Main.maxTilesX - 2; j++)
                {
                    if(TileCheckSafe(i, j))
                    {
                        if(Main.tile[i,j].liquid > 0 && Main.tile[i,j].lava() == false && (Main.tile[i,j].wall == (ushort)mod.WallType("ObsidiumRockWall") || Main.tile[i, j].wall == WallID.Lavafall))
                        {
                            Main.tile[i, j].liquid = 0;
                        }
                    }
                }
            }
        }

        private void GrowLavaGems()
        {
            for (int i = 0; i < Main.maxTilesX - 2; i++)
            {
                for (int j = 0; j < Main.maxTilesX - 2; j++)
                {
                    if (TileCheckSafe(i, j) && TileCheckSafe(i, j + 1))
                    {
                        if ((Main.tile[i, j].wall == mod.WallType("ObsidiumRockWall") || Main.tile[i, j].wall == WallID.Lavafall) && Main.tile[i, j + 1].type == (ushort)ModContent.TileType<Tiles.ObsidiumRock>() && Main.tile[i, j].type == 0 && Main.tile[i, j].active() == false)
                        {
                            if(Main.rand.Next(8) == 0)
                            {
                                WorldGen.PlaceTile(i, j, ModContent.TileType<LavaGem>(), true);
                            }
                        }
                        else if((Main.tile[i, j].wall == mod.WallType("ObsidiumRockWall") || Main.tile[i, j].wall == WallID.Lavafall) && Main.tile[i, j].type == (ushort)ModContent.TileType<Tiles.ObsidiumRock>())
                        {
                            if (Main.rand.Next(3) == 0)
                            {
                                if (TileCheckSafe(i, j - 1) && TileCheckSafe(i, j + 1) && TileCheckSafe(i, j - 2) && TileCheckSafe(i, j + 2))
                                    SpawnRocks(i, j);
                            }
                        }
                    }
                }
            }
        }

        private bool SpawnRocks(int i, int j)
        {
            if (Main.tile[i, j - 1].type == 0 && Main.rand.Next(4) == 0)
            {
                WorldGen.PlaceTile(i, j - 1, ModContent.TileType<ObsidiumRocks>(), true);
                return true;
            }
            else if (Main.tile[i, j - 1].type == 0 && Main.tile[i, j - 2].type == 0 && Main.rand.Next(3) == 0)
            {
                WorldGen.PlaceTile(i, j - 1, ModContent.TileType<ObsidiumStalagmites>(), true);
                return true;
            }
            else if (Main.tile[i, j + 1].type == 0 && Main.tile[i, j + 2].type == 0 && Main.rand.Next(2) == 0)
            {
                WorldGen.PlaceTile(i, j + 1, ModContent.TileType<ObsidiumStalactites>(), true);
                return true;
            }
            return false;
        }
    }
}
