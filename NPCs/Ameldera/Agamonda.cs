using Terraria;
using Terraria.ID;
using System.IO;
using Laugicality.Items.Loot;
using Terraria.ModLoader;
using Laugicality.NPCs.Obsidium;
using Laugicality.Items.Materials;
using System;
using Microsoft.Xna.Framework;

namespace Laugicality.NPCs.Ameldera
{
	class AgamondaHead : Agamonda
    {
        int delay = 0;
		public override string Texture { get { return "Laugicality/NPCs/Ameldera/AgamondaHead"; } }

		public override void SetDefaults()
        {
            npc.CloneDefaults(NPCID.DiggerHead);
            npc.width = 48;
            npc.height = 48;
            npc.damage = 60;
            npc.defense = 20;
            npc.lifeMax = 2000;
            npc.HitSound = SoundID.NPCHit3;
            npc.DeathSound = SoundID.NPCDeath3;
            npc.aiStyle = -1;
            npc.lavaImmune = true;
            npc.buffImmune[24] = true;
        }

		public override void Init()
		{
			base.Init();
			head = true;
		}


        public override void AI()
        {
            Player player = Main.player[npc.target];
            delay++;
            if (delay > 60)
            {
                delay = 0;
                Vector2 newVel = npc.velocity;
                newVel.Normalize();
                newVel *= 12;
                if (Main.netMode != 1)
                    Projectile.NewProjectile(npc.Center, newVel, ModContent.ProjectileType<ElderShardRock>(), npc.damage / 4, 5);
            }

            base.AI();
        }


        /*
        public override float SpawnChance(NPCSpawnInfo spawnInfo)
        {
            if (LaugicalityWorld.obsidiumTiles > 150 && LaugicalityWorld.downedRagnar && Main.hardMode)
                return SpawnCondition.Cavern.Chance * 0.25f;
            else return 0f;
        }*/

        int _attackCounter = 0;

		public override void SendExtraAI(BinaryWriter writer)
		{
			writer.Write(_attackCounter);
		}

		public override void ReceiveExtraAI(BinaryReader reader)
		{
			_attackCounter = reader.ReadInt32();
		}

		public override void CustomBehavior()
		{

		}
	}

	class AgamondaBody : Agamonda
    {
        int delay = 0;
        public override string Texture { get { return "Laugicality/NPCs/Ameldera/AgamondaBody"; } }

		public override void SetDefaults()
        {
            npc.CloneDefaults(NPCID.DiggerBody);
            npc.width = 48;
            npc.height = 48;
            npc.damage = 30;
            npc.defense = 50;
            npc.lifeMax = 500;
            npc.HitSound = SoundID.NPCHit3;
            npc.DeathSound = SoundID.NPCDeath3;
            npc.aiStyle = -1;
            npc.lavaImmune = true;
            npc.buffImmune[24] = true;
        }
        public override void AI()
        {
            Player player = Main.player[npc.target];
            delay++;
            if (delay > 2 * 60)
            {
                delay = 0;
                if (npc.position.Y < player.position.Y - 120)
                {
                    float theta = Main.rand.NextFloat() * (float)Math.PI;
                    float mag = Main.rand.NextFloat() * 3 + 3;
                    if (Main.netMode != 1)
                        Projectile.NewProjectile(npc.Center, new Vector2((float)Math.Cos(theta) * mag, (float)Math.Sin(theta) * -mag), ModContent.ProjectileType<ElderCrystalShard>(), npc.damage / 4, 3f);

                }

            }

            base.AI();
        }
    }

	class AgamondaTail : Agamonda
    {
		public override string Texture { get { return "Laugicality/NPCs/Ameldera/AgamondaTail"; } }

		public override void SetDefaults()
        {
            npc.CloneDefaults(NPCID.DiggerTail);
            npc.width = 48;
            npc.height = 48;
            npc.damage = 40;
            npc.defense = 40;
            npc.lifeMax = 4000;
            npc.HitSound = SoundID.NPCHit3;
            npc.DeathSound = SoundID.NPCDeath3;
            npc.aiStyle = -1;
            npc.lavaImmune = true;
            npc.buffImmune[24] = true;
        }

		public override void Init()
		{
			base.Init();
			tail = true;
		}
	}
    
	public abstract class Agamonda : Worm
    {
        public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Agamonda");
		}

		public override void Init()
		{
			minLength = 4;
			maxLength = 7;
			tailType = ModContent.NPCType<AgamondaTail>();
			bodyType = ModContent.NPCType<AgamondaBody>();
			headType = ModContent.NPCType<AgamondaHead>();
			speed = 20f;
			turnSpeed = 0.25f;
            npc.buffImmune[24] = true;
        }

        public override void NPCLoot()
        {
            Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ModContent.ItemType<ElderPearl>());
        }
    }
    
}