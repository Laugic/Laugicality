using Laugicality.Dusts;
using Laugicality.Items.Consumables;
using Laugicality.Items.Consumables.Potions;
using Laugicality.Items.Equipables;
using Laugicality.Items.Materials;
using Laugicality.Items.Misc;
using Laugicality.Items.Placeable;
using Laugicality.Projectiles.NPCProj;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Laugicality.NPCs
{
    [AutoloadHead]
    public class TheLastMoldyrian : ModNPC
    {
        int _chatIndex = 0;
        int _mysticChatIndex = 0;
        public override bool Autoload(ref string name)
        {
            name = "TheLastMoldyrian";
            return mod.Properties.Autoload;
        }

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("The Last Moldyrian");
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
            _mysticChatIndex = 0;
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
                Dust.NewDust(npc.position, npc.width, npc.height, ModContent.DustType<White>());
            }
        }

        public override bool CanTownNPCSpawn(int numTownNpCs, int money)
        {
            return (numTownNpCs > 3);
        }
        public override string TownNPCName()
        {
            return "";
        }
        
        public override string GetChat()
        {
            int steampunker = NPC.FindFirstNPC(NPCID.Steampunker);


            //Mystic Dialogue
            if (LaugicalityPlayer.Get().MysticDamage > 1 && Main.rand.Next(2) == 0)
            {
                _mysticChatIndex++;
                switch (_chatIndex % 3)
                {
                    default:
                        return "Are you pursuing the way of the Mystic, " + Main.LocalPlayer.name + "? I have not seen another soul destined down that path for years.";
                }
            }

            _chatIndex++;
            //General Dialogue
            switch (_chatIndex % 8)
            {
                case 1:
                    return "Have faith, young one. Good times will come again. Someday.";
                case 2:
                    return "Do you have a moment to talk about whatever it is that you believe in?";
                case 3:
                    return "Blessings upon you!";
                case 4:
                    return "If you happen to spot a Vetruvian, best keep to yourself. Those ones can't help but play dirty. Probably had something to do with... Nevermind.";
                case 5:
                    return "Have you been praying lately? \n\n...to whom? Why, to anyone of course.";
                case 6:
                    return "There will always be things in the universe we can't explain, but that doesn't mean they don't have an explanation.";
                default:
                    return "Good day and gods bless, " + Main.LocalPlayer.name + ".";
            }
            return "Good day and gods bless, " + Main.LocalPlayer.name + ".";
        }

        public override void SetChatButtons(ref string button, ref string button2) => button = Lang.inter[28].Value;

        public override void OnChatButtonClicked(bool firstButton, ref bool shop)
        {
            if (firstButton)
                shop = true;
        }

        public override void SetupShop(Chest shop, ref int nextSlot)
        {
            shop.item[nextSlot].SetDefaults(ModContent.ItemType<AncientScroll>());
            shop.item[nextSlot].value = Item.buyPrice(silver: 1);
            nextSlot++;

            shop.item[nextSlot].SetDefaults(ModContent.ItemType<MysticaPotion>());
            shop.item[nextSlot].value = Item.buyPrice(silver: 5);
            nextSlot++;

            shop.item[nextSlot].SetDefaults(ItemID.MushroomGrassSeeds);
            shop.item[nextSlot].value = Item.buyPrice(silver: 3);
            nextSlot++;

            shop.item[nextSlot].SetDefaults(ModContent.ItemType<FaeryInABottle>());
            shop.item[nextSlot].value = Item.buyPrice(gold: 3);
            nextSlot++;

            if(LaugicalityWorld.downedDuneSharkron)
                shop.item[nextSlot].SetDefaults(ModContent.ItemType<SolidPotentia>());
            shop.item[nextSlot].value = Item.buyPrice(gold: 5);
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