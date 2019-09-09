using Laugicality.Dusts;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Laugicality.NPCs
{
	[AutoloadHead]
	public class Conductor : ModNPC
	{
        int _chatIndex = 0;
		public override bool Autoload(ref string name)
		{
			name = "Conductor";
			return mod.Properties.Autoload;
		}

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Conductor");
            Main.npcFrameCount[npc.type] = 25;
            NPCID.Sets.ExtraFramesCount[npc.type] = 5;
            NPCID.Sets.AttackFrameCount[npc.type] = 4;
            NPCID.Sets.DangerDetectRange[npc.type] = 1000;
            NPCID.Sets.AttackType[npc.type] = 0;
            NPCID.Sets.AttackTime[npc.type] = 30;
            NPCID.Sets.AttackAverageChance[npc.type] = 30;
        }

        public override void SetDefaults()
		{
            _chatIndex = 0;
            npc.townNPC = true;
			npc.friendly = true;
			npc.width = 18;
			npc.height = 40;
			npc.aiStyle = 7;
			npc.damage = 50;
			npc.defense = 15;
			npc.lifeMax = 250;
			npc.HitSound = SoundID.NPCHit1;
			npc.DeathSound = SoundID.NPCDeath1;
			npc.knockBackResist = 0.5f;
			animationType = NPCID.Guide;
		}

		public override void HitEffect(int hitDirection, double damage)
		{
			int num = npc.life > 0 ? 1 : 5;
			for (int k = 0; k < num; k++)
			{
				Dust.NewDust(npc.position, npc.width, npc.height, mod.DustType<Steam>());
			}
		}

		public override bool CanTownNPCSpawn(int numTownNpCs, int money)
		{
            if (LaugicalityWorld.downedAnnihilator && LaugicalityWorld.downedSlybertron && LaugicalityWorld.downedSteamTrain)
            {
                return true;
            }
			return false;
		}

		public override string TownNPCName()
		{
			switch (WorldGen.genRand.Next(6))
			{
				case 0:
					return "Lord Charles III";
				case 1:
					return "Sir Christopher";
				case 2:
					return "Earl Crane";
                case 3:
                    return "Lord Crimblesworth";
                case 4:
                    return "Baron Chester von Kingsly";
                default:
                    return "Laugic";
            }
		}

		public override void FindFrame(int frameHeight)
		{
			/*npc.frame.Width = 40;
			if (((int)Main.time / 10) % 2 == 0)
			{
				npc.frame.X = 40;
			}
			else
			{
				npc.frame.X = 0;
			}*/
		}

		public override string GetChat()
		{
			int steampunker = NPC.FindFirstNPC(NPCID.Steampunker);
            _chatIndex++;
            if (TownNPCName() == "Laugic" && _chatIndex % 9 == 0)
                return "Heyo " + Main.LocalPlayer.name + ". How're you enjoying Enigma so far? I mean uh- ahem... Trains?";
            if (Main.LocalPlayer.GetModPlayer<LaugicalityPlayer>(mod).MysticDamage > 1 && _chatIndex % 10 == 0)
                return "Oh, you aren't one of those 'Mystics' are you? The Moldyrians have such an ancient way of thinking. Steam power is where it's at!";
			if (steampunker >= 0 && Main.rand.Next(3) == 0)
			{
                switch (_chatIndex % 3)
                {
                    case 0:
				        return "Oh, of course. My wares are much more valueable than that " + Main.npc[steampunker].GivenName + "'s.";
                    case 1:
                        return "I bet " + Main.npc[steampunker].GivenName + " hasn't even invented a sentient machine yet!";
                    default:
                        return "A jetpack? Please. Tell " + Main.npc[steampunker].GivenName + " those went out of style a few centuries ago. Jetboots are the best you can get! Besides trains, of course.";
                }
			}
			switch (_chatIndex % 8)
			{
				case 0:
					return "Spiffing!";
                case 1:
                    return "Trains are all the rage in Vetruvia these days.";
                case 2:
                    return "A train ride a day keeps the Steam Train away!";
                case 3:
                    return "All aboard!";
                case 4:
                    return "I wonder what happened to all of the Moldyrians. You wouldn't happen to have seen one recently, would you?";
                case 5:
                    return "'What is the meaning of life?' I, for one, think the answer probably involves lots of steam.";
                case 6:
                    return "Hm? How did I get these items that call giant mechanical abominations at a whim? Through the power of Steam, of course!";
                default:
					return "Would you like to talk about Trains?";
			}
		}

		public override void SetChatButtons(ref string button, ref string button2)
		{
			button = Lang.inter[28].Value;
		}

		public override void OnChatButtonClicked(bool firstButton, ref bool shop)
		{
			if (firstButton)
			{
				shop = true;
			}
		}

		public override void SetupShop(Chest shop, ref int nextSlot)
		{
            shop.item[nextSlot].SetDefaults(mod.ItemType("Gear"));
            nextSlot++;
			shop.item[nextSlot].SetDefaults(mod.ItemType("ToyTrain"));
			nextSlot++;
            shop.item[nextSlot].SetDefaults(544);
            shop.item[nextSlot].value = 50000;
            nextSlot++;
            shop.item[nextSlot].SetDefaults(556);
            shop.item[nextSlot].value = 50000;
            nextSlot++;
            shop.item[nextSlot].SetDefaults(557);
            shop.item[nextSlot].value = 50000;
            nextSlot++;
            shop.item[nextSlot].SetDefaults(mod.ItemType("MechanicalMonitor"));
            shop.item[nextSlot].value = 60000;
            nextSlot++;
            shop.item[nextSlot].SetDefaults(mod.ItemType("SteamCrown"));
            shop.item[nextSlot].value = 60000;
            nextSlot++;
            shop.item[nextSlot].SetDefaults(mod.ItemType("SuspiciousTrainWhistle"));
            shop.item[nextSlot].value = 60000;
            nextSlot++;
        }

		public override void TownNPCAttackStrength(ref int damage, ref float knockback)
		{
			damage = 50;
			knockback = 4f;
		}

		public override void TownNPCAttackCooldown(ref int cooldown, ref int randExtraCooldown)
		{
			cooldown = 12;
			randExtraCooldown = 30;
		}

		public override void TownNPCAttackProj(ref int projType, ref int attackDelay)
		{
			projType = mod.ProjectileType("ConductorProjectile");
			attackDelay = 1;
		}

		public override void TownNPCAttackProjSpeed(ref float multiplier, ref float gravityCorrection, ref float randomOffset)
		{
			multiplier = 12f;
			randomOffset = 1f;
		}
	}
}