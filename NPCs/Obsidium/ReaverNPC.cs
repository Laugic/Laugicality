using Laugicality.Items.Loot;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Laugicality.NPCs.Obsidium
{
    public class ReaverNPC : ModNPC
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Reaver");
        }
        public override void SetDefaults()
        {
            npc.width = 42;
            npc.height = 48;
            npc.damage = 50;
            npc.defense = 30;
            npc.lifeMax = 250;
            npc.HitSound = SoundID.NPCHit3;
            npc.DeathSound = SoundID.NPCDeath3;
            Main.npcFrameCount[npc.type] = 4;
            npc.value = 2000f;
            npc.knockBackResist = 0f;
            npc.aiStyle = -1;
            npc.lavaImmune = true;
            npc.noGravity = true;
            npc.noTileCollide = true;
            npc.buffImmune[24] = true;
        }

        public override void OnHitPlayer(Player target, int dmgDealt, bool crit)
        {
            target.AddBuff(BuffID.OnFire, 300, true);
        }

        public override void AI()
        {
            if(npc.life < npc.lifeMax / 2 && npc.ai[0] != 1)
            {
                npc.ai[0] = 1;

                int n = NPC.NewNPC((int)npc.Center.X, (int)npc.Center.Y, ModContent.NPCType<ReaverHeadNPC>());
                Main.npc[n].ai[0] = npc.whoAmI;
            }
        }

        public override void FindFrame(int frameHeight)
        {
            npc.frameCounter += 1;
            if (npc.frameCounter > 30)
            {
                npc.frame.Y = npc.frame.Y + frameHeight;
                npc.frameCounter = 0;
            }
            if (npc.frame.Y > frameHeight * 3)
            {
                npc.frame.Y = 0;
            }
        }

        public override void NPCLoot()
        {
            //Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ModContent.ItemType<MagmaticCrystal>());
        }
    }
}
