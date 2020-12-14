using Laugicality.Dusts;
using Laugicality.Items.Consumables;
using Laugicality.Items.Equipables;
using Laugicality.Items.Materials;
using Laugicality.Items.Placeable;
using Laugicality.Projectiles.NPCProj;
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
				Dust.NewDust(npc.position, npc.width, npc.height, ModContent.DustType<Steam>());
			}
		}

		public override bool CanTownNPCSpawn(int numTownNpCs, int money)
		{
            return (LaugicalityWorld.downedAnnihilator && LaugicalityWorld.downedSlybertron && LaugicalityWorld.downedSteamTrain);
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

            //Boss Chat
            if(Main.rand.Next(3) == 0)
            {
                switch(_chatIndex % 10)
                {
                    case 0:
                        if(LaugicalityWorld.downedDuneSharkron)
                            return "You took down that desert beast, Dune Sharkron? That thing's evaded me through the sands for years. How ever did you manage to catch its attention?";
                        break;
                    case 1:
                        if (LaugicalityWorld.downedHypothema)
                            return "You mean to tell me you fought an angry snowflake? And it fought back?!? What is this world coming to...";
                        break;
                    case 2:
                        if (LaugicalityWorld.downedRagnar)
                            return "You've really managed to defeat Ragnar? That Titan was the one that destroyed my factory years ago... Now I can finally set up a mining operation in the depths of the Obsidium!";
                        break;
                    case 3:
                        if (LaugicalityWorld.downedAnDio)
                            return "Whatever the Moldyrians did to marble and granite to turn it into that dastardly AnDio creature, it can't have been good. You say you've managed to defeat it? That's quite the task! Did you figure out what made it tick?";
                        break;
                    case 4:
                        if (Main.hardMode)
                            return "You're saying you defeated a 'Wall of Flesh' that materialized in Hell upon dropping a doll in magma? Now that is voodoo nonsense, I say. I'll believe that when I see trains fly.";
                        break;
                    case 5:
                        return "Ah! Yes, my uh... rogue creations. Well, they were definitely well behaved before, but since this strange scream was heard across the world, they all went haywire. Would you have any idea what the source of that might have been?";
                    case 6:
                        if (NPC.downedPlantBoss)
                            return "A giant moving plant you say? Your stories are getting more and more ridiculous. Next you'll tell me of 'strange ghostly spirits' and 'eldritch beings', I'm sure.";
                        break;
                    case 7:
                        if (NPC.downedGolemBoss)
                            return "Ancient mechanical machinations! You don't say. That must be the source where the Moldyrians got their technology... Finally, I'm staring to get some answers.";
                        break;
                    case 8:
                        if (LaugicalityWorld.downedTrueEtheria)
                            return "What? A frightening ghostly spirit and a parallel dimension? Well half of that story is of quite interest to me. Tell me more about this alternate 'dimension' you speak of.";
                        break;
                    default:
                        if (NPC.downedMoonlord)
                            return "Ah yes of course. I too have defeated great eldritch beings. We took a field trip to destroy one during high school. Indeed. That definitely happened.";
                        break;
                }
            }

            //Other NPC Dialogue
			if (steampunker >= 0 && Main.rand.Next(3) == 0)
			{
                switch (_chatIndex % 3)
                {
                    case 0:
				        return "Oh, of course. My wares are much more valueable than that " + Main.npc[steampunker].GivenName + "'s.";
                    case 1:
                        return "I bet " + Main.npc[steampunker].GivenName + " hasn't even invented a sentient machine yet!";
                    default:
                        return "A jetpack? Please. Tell " + Main.npc[steampunker].GivenName + " those went out of style a few centuries ago. Jetboots are the best transport you can get! Besides trains, of course.";
                }
			}

			switch (_chatIndex % 10)
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
                    return "Hm? How did I get these items that call giant mechanical abominations at a whim? Through the power of steam, of course!";
                case 7:
                    if (TownNPCName() == "Laugic")
                        return "Heyo " + Main.LocalPlayer.name + ". How're you enjoying Enigma so far? I mean uh- ahem... Trains?";
                    break;
                case 8:
                    if (LaugicalityPlayer.Get().MysticDamage > 1)
                        return "Oh, you aren't one of those 'Mystics' are you? The Moldyrians had such an ancient way of thinking. Steam power is where it's at!";
                    break;
                default:
					return "Would you like to talk about trains?";
            }
            return "Would you like to talk about trains?";
        }

		public override void SetChatButtons(ref string button, ref string button2) => button = Lang.inter[28].Value;

        public override void OnChatButtonClicked(bool firstButton, ref bool shop)
		{
			if (firstButton)
                shop = true;
        }

		public override void SetupShop(Chest shop, ref int nextSlot)
		{
            shop.item[nextSlot].SetDefaults(ModContent.ItemType<Gear>());
            nextSlot++;

            shop.item[nextSlot].SetDefaults(ModContent.ItemType<ToyTrain>());
            nextSlot++;

            shop.item[nextSlot].SetDefaults(ModContent.ItemType<BrassFAN>());
            nextSlot++;

            shop.item[nextSlot].SetDefaults(ModContent.ItemType<BrassRING>());
            nextSlot++;

            shop.item[nextSlot].SetDefaults(ModContent.ItemType<SteamVENT>());
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

            shop.item[nextSlot].SetDefaults(ModContent.ItemType<MechanicalMonitor>());
            shop.item[nextSlot].value = 60000;
            nextSlot++;

            shop.item[nextSlot].SetDefaults(ModContent.ItemType<SteamCrown>());
            shop.item[nextSlot].value = 60000;
            nextSlot++;

            shop.item[nextSlot].SetDefaults(ModContent.ItemType<SuspiciousTrainWhistle>());
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
			projType = ModContent.ProjectileType<ConductorProjectile>();
			attackDelay = 1;
		}

		public override void TownNPCAttackProjSpeed(ref float multiplier, ref float gravityCorrection, ref float randomOffset)
		{
			multiplier = 12f;
			randomOffset = 1f;
		}
	}
}