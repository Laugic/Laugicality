using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Laugicality.NPCs.Etherial.BossFights
{
    public class SparkSlime : ModNPC
    {
        int counter = 0;
        public override void SetDefaults()
        {
            LaugicalityVars.etherial.Add(npc.type);
            npc.width = 18;
            npc.height = 18;
            npc.damage = 80;
            npc.defense = 80;
            npc.lifeMax = 4000;
            npc.HitSound = SoundID.NPCHit4;
            npc.DeathSound = SoundID.NPCDeath14;
            npc.value = 60f;
            npc.knockBackResist = 0f;
            npc.aiStyle = 1;
            npc.lavaImmune = true;
            Main.npcFrameCount[npc.type] = 2;
        }

        public override void AI()
        {
            counter++;
            if (counter > 2 * 60)
            {
                counter = 0;
                if (Main.netMode != 1)
                {
                    Projectile.NewProjectile(npc.Center.X, npc.Center.Y, -4, 0, mod.ProjectileType("Electroshock"), (int)(npc.damage / 2), 3, Main.myPlayer);
                    Projectile.NewProjectile(npc.Center.X, npc.Center.Y, 4, 0, mod.ProjectileType("Electroshock"), (int)(npc.damage / 2), 3, Main.myPlayer);
                    Projectile.NewProjectile(npc.Center.X, npc.Center.Y, 0, -4, mod.ProjectileType("Electroshock"), (int)(npc.damage / 2), 3, Main.myPlayer);
                    Projectile.NewProjectile(npc.Center.X, npc.Center.Y, 0, 4, mod.ProjectileType("Electroshock"), (int)(npc.damage / 2), 3, Main.myPlayer);
                }
            }
            MovementCheck();
        }

        private void MovementCheck()
        {
            if (Main.player[npc.target].Center.Y < npc.Center.Y - 200)
            {
                npc.velocity.Y -= .4f;
            }
            if (Main.player[npc.target].Center.Y > npc.Center.Y + 20)
            {
                npc.noTileCollide = true;
            }
            else
                npc.noTileCollide = false;
        }

        public override bool? DrawHealthBar(byte hbPosition, ref float scale, ref Vector2 position)
        {
            return false;
        }
    }
}
