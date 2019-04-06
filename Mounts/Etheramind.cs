using Terraria;
using Terraria.ModLoader;

namespace Laugicality.Mounts
{
    public class Etheramind : ModMountData
    {
        int delay = 0;
        public override void SetDefaults()
        {
            delay = 0;
            mountData.spawnDust = mod.DustType("Etherial");
            mountData.buff = mod.BuffType("Etheramind");
            mountData.heightBoost = 20;
            mountData.fallDamage = 0f;
            mountData.runSpeed = 25f;
            mountData.dashSpeed = 8f;
            mountData.flightTimeMax = 99999;
            mountData.fatigueMax = 0;
            mountData.jumpHeight = 5;
            mountData.acceleration = 0.8f;
            mountData.jumpSpeed = 5f;
            mountData.blockExtraJumps = false;
            mountData.totalFrames = 1;
            mountData.constantJump = true;
            int[] array = new int[mountData.totalFrames];
            for (int l = 0; l < array.Length; l++)
            {
                array[l] = 20;
            }
            mountData.playerYOffsets = array;
            mountData.xOffset = 13;
            mountData.bodyFrame = 3;
            mountData.yOffset = -12;
            mountData.playerHeadOffset = 22;
            mountData.standingFrameCount = 0;
            mountData.standingFrameDelay = 12;
            mountData.standingFrameStart = 0;
            mountData.runningFrameCount = 0;
            mountData.runningFrameDelay = 12;
            mountData.runningFrameStart = 0;
            mountData.flyingFrameCount = 0;
            mountData.flyingFrameDelay = 0;
            mountData.flyingFrameStart = 0;
            mountData.inAirFrameCount = 1;
            mountData.inAirFrameDelay = 12;
            mountData.inAirFrameStart = 0;
            mountData.idleFrameCount = 0;
            mountData.idleFrameDelay = 12;
            mountData.idleFrameStart = 0;
            mountData.idleFrameLoop = true;
            mountData.swimFrameCount = mountData.inAirFrameCount;
            mountData.swimFrameDelay = mountData.inAirFrameDelay;
            mountData.swimFrameStart = mountData.inAirFrameStart;
            if (Main.netMode != 2)
            {
                mountData.textureWidth = mountData.backTexture.Width + 20;
                mountData.textureHeight = mountData.backTexture.Height;
            }
        }

        public override void UpdateEffects(Player player)
        {
            delay++;
            if(delay >= 60)
            {
                delay = 0;
                if(Main.netMode != 1)
                {
                    Projectile.NewProjectile(player.Center.X, player.Center.Y + 12, 0, 6, mod.ProjectileType("Etherblast"), 400, 3f, Main.myPlayer);
                }
            }
        }
    }
}