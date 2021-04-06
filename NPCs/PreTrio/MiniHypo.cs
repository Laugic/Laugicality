using Laugicality.Dusts;
using Laugicality.Items.Loot;
using Laugicality.Items.Placeable;
using Laugicality.Projectiles.NPCProj;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Laugicality.NPCs.PreTrio
{
    public class MiniHypo : ModNPC
    {
        int counter = 0;
        public override void SetStaticDefaults()
        {
            Main.npcFrameCount[npc.type] = 2;
        }

        public override void SetDefaults()
        {
            npc.CloneDefaults(NPCID.MisterStabby);
            npc.width = 32;
            npc.height = 28;
            npc.damage = 40;
            npc.defense = 4;
            npc.lifeMax = 400;
            npc.HitSound = SoundID.NPCHit11;
            npc.DeathSound = SoundID.NPCDeath15;
            npc.value = 0;
            npc.noGravity = false;
            npc.buffImmune[BuffID.Frostburn] = true;
        }

        public override void OnHitPlayer(Player target, int dmgDealt, bool crit)
        {
            target.AddBuff(BuffID.Frostburn, 2 * 60 + Main.rand.Next(60), true);
        }

        public override void NPCLoot()
        {
            Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.SnowBlock, Main.rand.Next(1, 4));
        }

        public override void FindFrame(int frameHeight)
        {
            counter++;
            if (counter > 15)
                counter = 0;
            npc.frame.Y = frameHeight * (counter > 7?1:0);
        }
    }
}
