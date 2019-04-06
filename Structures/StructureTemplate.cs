using Terraria;

namespace Laugicality.Structures
{
    public class StructureTemplate
    {
        private static readonly int[,] _structureArray = new int[,]
        {

        };

        public static void StructureGen(int xPosO, int yPosO, bool mirrored)
        {
            //Obsidium Heart
            /**
             * 0 = Do Nothing
             * 9 = Kill tile
             * */
            

            for (int i = 0; i < _structureArray.GetLength(1); i++)
            {
                for (int j = 0; j < _structureArray.GetLength(0); j++)
                {
                    if(mirrored)
                    {
                        if (TileCheckSafe((int)(xPosO + _structureArray.GetLength(1) - i), (int)(yPosO + j)))
                        {
                            if (_structureArray[j, i] == 9)
                            {
                                WorldGen.KillTile(xPosO + _structureArray.GetLength(1) - i, yPosO + j);
                            }
                        }
                    }
                    else
                    {
                        if (TileCheckSafe((int)(xPosO + i), (int)(yPosO + j)))
                        {
                            if (_structureArray[j, i] == 9)
                            {
                                WorldGen.KillTile(xPosO + i, yPosO + j);
                            }
                        }
                    }
                }
            }
        }
        
        //Making sure tiles arent out of bounds
        private static bool TileCheckSafe(int i, int j)
        {
            if (i > 0 && i < Main.maxTilesX && j > 0 && j < Main.maxTilesY)
                return true;
            return false;
        }
    }
}