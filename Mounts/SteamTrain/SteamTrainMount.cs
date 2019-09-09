using System;
using Laugicality.Dusts;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;

namespace Laugicality.Mounts.SteamTrain
{
	public class SteamTrainMount : ModMountData
	{
        public bool boosted = false;

		public override void SetDefaults()
		{
            boosted = false;
			mountData.spawnDust = mod.DustType<Steam>();
			mountData.buff = mod.BuffType<SteamTrainMountBuff>();
			mountData.heightBoost = 20;
			mountData.fallDamage = 0.5f;
			mountData.runSpeed = 25f;
			mountData.dashSpeed = 8f;
			mountData.flightTimeMax = 0;
			mountData.fatigueMax = 0;
			mountData.jumpHeight = 4;
			mountData.acceleration = 0.04f;
			mountData.jumpSpeed = 4f;
			mountData.blockExtraJumps = true;
			mountData.totalFrames = 6;
			mountData.constantJump = true;

			int[] array = new int[mountData.totalFrames];
			for (int l = 0; l < array.Length; l++)
			{
				array[l] = 20;
			}

			mountData.playerYOffsets = array;
			mountData.xOffset = 75;
			mountData.bodyFrame = 3;
			mountData.yOffset = -2;
			mountData.playerHeadOffset = 22;
			mountData.standingFrameCount = 6;
			mountData.standingFrameDelay = 999999;
			mountData.standingFrameStart = 0;
			mountData.runningFrameCount = 6;
			mountData.runningFrameDelay = 12;
			mountData.runningFrameStart = 0;
			mountData.flyingFrameCount = 0;
			mountData.flyingFrameDelay = 0;
			mountData.flyingFrameStart = 0;
			mountData.inAirFrameCount = 1;
			mountData.inAirFrameDelay = 12;
			mountData.inAirFrameStart = 0;
			mountData.idleFrameCount = 6;
			mountData.idleFrameDelay = 999999;
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
            if (Math.Abs(player.velocity.X) > 3f)
            {
                Rectangle rect = player.getRect();
                Dust.NewDust(new Vector2(rect.X, rect.Y), rect.Width, 0, mod.DustType<TrainSteam>());

                if (boosted == false)
                {
                    Main.PlaySound(SoundLoader.customSoundType, -1, -1, mod.GetSoundSlot(SoundType.Custom, "Sounds/train_whistle"));
                    boosted = true;
                }
            }

            else boosted = false;
		}
	}
}