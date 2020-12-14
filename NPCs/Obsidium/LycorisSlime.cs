using Laugicality.Dusts;
using Laugicality.Items.Loot;
using Laugicality.Items.Placeable;
using Laugicality.Projectiles.NPCProj;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Laugicality.NPCs.Obsidium
{
    public class LycorisSlime : ModNPC
    {
        public override void SetStaticDefaults()
        {
            Main.npcFrameCount[npc.type] = 2;
        }

        public override void SetDefaults()
        {
            npc.aiStyle = 1;
            aiType = NPCID.BlueSlime;
            animationType = NPCID.BlueSlime;
            npc.width = 32;
            npc.height = 28;
            npc.damage = 30;
            npc.defense = 4;
            npc.lifeMax = 60;
            npc.HitSound = SoundID.NPCHit1;
            npc.DeathSound = SoundID.NPCDeath1;
            npc.value = Item.buyPrice(silver: 1);
            npc.lavaImmune = true;
            npc.noGravity = false;
            npc.buffImmune[BuffID.OnFire] = true;
        }

        public override void OnHitPlayer(Player target, int dmgDealt, bool crit)
        {
            target.AddBuff(BuffID.OnFire, 2 * 60 + Main.rand.Next(60), true);
        }

        public override void NPCLoot()
        {
            if(Main.rand.Next(3) != 0)
                Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ModContent.ItemType<Lycoris>(), Main.rand.Next(2, 5));
            Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.Gel, Main.rand.Next(1,4));
        }
    }
}
