using Laugicality.Items.Placeable;
using Terraria;
using Terraria.ModLoader;
using Microsoft.Xna.Framework.Graphics;

namespace Laugicality.Tiles
{
    public class AntitherialTile : ModTile
    {
        public override void SetDefaults()
        {
            Main.tileSolid[Type] = true;
            //Main.tileMerge[56][ModContent.TileType<ObsidiumOreBlock>()] = true;
            //Main.tileMerge[ModContent.TileType<ObsidiumOreBlock>()][56] = true;
            //Main.tileSpelunker[Type] = true;
            Main.tileLighted[Type] = true;
            //ModTranslation name = CreateMapEntryName();
            //name.SetDefault("Obsidium Ore");
            //AddMapEntry(new Color(150, 50, 50), name);
            mineResist = .5f;
            minPick = 0;
            dustType = 90;
            drop = ModContent.ItemType<AntitherialBlock>();
        }
        
        public override void NumDust(int i, int j, bool fail, ref int num)
        {
            num = fail ? 1 : 3;
        }
        
        public override void ModifyLight(int i, int j, ref float r, ref float g, ref float b)
        {
            r = 0f;
            g = 0.2f;
            b = 0.3f;
        }
        
        public override bool CanExplode(int i, int j)
        {
            return false;
        }
        
        public override bool PreDraw(int i, int j, SpriteBatch spriteBatch)
		{
            if(LaugicalityWorld.downedEtheria == false)
            {
                Main.tileSolid[Type] = true;
            }
            else 
            {
                Main.tileSolid[Type] = false;
            }
            if(LaugicalityWorld.downedEtheria == false)
            {
			    return true;
            }
            else 
            {
                return false;
            }
		}

        public override bool CanKillTile(int i, int j, ref bool blockDamaged)
		{

            if(LaugicalityWorld.downedEtheria == false)
            {
			    return true;
            }
            else 
            {
                return false;
            }
		}
    }
}