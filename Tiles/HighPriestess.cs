using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;
using Terraria.ObjectData;

namespace Laugicality.Tiles
{
    public class HighPriestess : ModTile
    {
        public override void SetDefaults()
        {
            Main.tileSolidTop[Type] = false;
            Main.tileFrameImportant[Type] = true;
            Main.tileNoAttach[Type] = true;
            Main.tileTable[Type] = true;
            Main.tileLavaDeath[Type] = true;
            TileObjectData.newTile.CopyFrom(TileObjectData.Style3x3Wall);
            TileObjectData.addTile(Type);
            ModTranslation name = CreateMapEntryName();
            name.SetDefault("High Priestess");
            AddMapEntry(new Color(0, 150, 150), name);
            disableSmartCursor = true;
            dustType = mod.DustType("Etherial");
        }

        public override void NumDust(int i, int j, bool fail, ref int num)
        {
            num = fail ? 1 : 3;
        }

        public override void KillMultiTile(int i, int j, int frameX, int frameY)
        {
            Vector2 pos;
            pos.X = i * 16 - 24;
            pos.Y = j * 16 - 24;
            for (int k = 0; k < 12; k++)
            {
                Dust.NewDust(pos, 64, 64, mod.DustType("Etherial"), 0f, 0f);
            }
        }

        public override void HitWire(int i, int j)
        {
            bool boss = false;
            Vector2 pos;
            pos.X = i * 16 - 24;
            pos.Y = j * 16 - 24;

            for (int k = 0; k < 200; k++)
            {
                if (Main.npc[k].boss && Main.npc[k].active)
                {
                    boss = true;
                    break;
                }
            }
            if(!boss)
            {
                LaugicalityWorld.downedEtheria = !LaugicalityWorld.downedEtheria;
                for(int k = 0; k < 12; k++)
                {
                    Dust.NewDust(pos, 64, 64, mod.DustType("Etherial"), 0f, 0f);
                }
                Main.PlaySound(SoundLoader.customSoundType, -1, -1, mod.GetSoundSlot(SoundType.Custom, "Sounds/EtherialChange"));
            }
        }
    }
}
