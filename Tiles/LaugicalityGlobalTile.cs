using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.ObjectData;
using Terraria.Localization;
using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework.Graphics;

namespace Laugicality.Tiles
{
    public class LaugicalityGlobalTile : GlobalTile
    {

        /*
        public override void RandomUpdate(int i, int j, int type)
        {
            int count = 0;
            int obsCount = 0;
            if(type == 56)
            {
                if (Main.tile[i, j - 1].type == 0 && Main.tile[i, j].active())
                {
                    for (int k = 0; k < 100; k++)
                    {
                        for (int l = 0; l < 100; l++)
                        {
                            if (Main.tile[k, l].type == (ushort)mod.TileType("LavaGem"))
                                count++;
                        }
                    }
                    for (int k = 0; k < 100; k++)
                    {
                        for (int l = 0; l < 100; l++)
                        {
                            if (Main.tile[k, l].type == (ushort)mod.TileType("ObsidiumRock") || Main.tile[k, l].type == 56)
                                obsCount++;
                        }
                    }

                    if (count < 12 && obsCount > 50)
                        Terraria.WorldGen.PlaceTile(i, j - 1, mod.TileType("LavaGem"), true);
                }
            }
        }
        public override bool PreDraw(int i, int j, int type, SpriteBatch spriteBatch)
		{
            if (etherial)
            {
                if(LaugicalityWorld.downedEtheria == true)
                {
                    Main.tileSolid[type] = true;
                }
                else 
                {
                    Main.tileSolid[type] = false;
                }
                if(LaugicalityWorld.downedEtheria == true)
                {
			        return true;
                }
                else 
                {
                    return false;
                }
            }
            if (antitherial)
            {
                if(LaugicalityWorld.downedEtheria == true)
                {
                    Main.tileSolid[type] = false;
                }
                else 
                {
                    Main.tileSolid[type] = true;
                }
                if(LaugicalityWorld.downedEtheria == true)
                {
			        return false;
                }
                else 
                {
                    return true;
                }
            }
            return true;
		}

        public override bool CanKillTile(int i, int j, int type, ref bool blockDamaged)
		{
            if (etherial)
            {
                if(LaugicalityWorld.downedEtheria == true)
                {
			        return true;
                }
                else 
                {
                    return false;
                }
            }
            if (antitherial)
            {
                if(LaugicalityWorld.downedEtheria == true)
                {
			        return false;
                }
                else 
                {
                    return true;
                }
            }
            return true;
		}*/
    }
}