using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;
using Laugicality;
using System.Linq;
using static Laugicality.LaugicalityVars;

namespace Laugicality.Items.SoulStone
{
    public class SoulStone : ModItem
    {
        
        public static int Class = (int)ClassType.Undefined; 

        //Throwing
        string KS1 = "[c/2B9DE9:+10% Throwing Damage]"; string KS2 = "[c/2B9DE9:Greatly increases jump height]"; string KS3 = "[c/2B9DE9:+1 Max Minion]"; string KS4 = "[c/2B9DE9:+20% Throwing velocity]";
        //Mystic
        string EoC1 = "[c/B03A2E:Enemies take damage on contact]"; string EoC2 = "[c/B03A2E:Greatly increases movement speed]"; string EoC3 = "[c/B03A2E:Hunter Potion Effect]"; string EoC4 = "[c/B03A2E:+5% Destruction and Conjuration Damage, +10% Illusion Duration]";
        //Magic
        string EoWBoC1 = "[c/884EA0:Causes 'Blood Rage' when struck]"; string EoWBoC2 = "[c/884EA0:+4 Defense, +20 Max Life]"; string EoWBoC3 = "[c/884EA0:+20 Max Mana, Increased Life Regeneration]"; string EoWBoC4 = "[c/B08E2E:Increased Mana Regeneration]";
        //Summon
        string QB1 = "[c/F39C12:Attacks inflict Poison]"; string QB2 = "[c/F39C12:Increased Life Regeneration]"; string QB3 = "[c/F39C12:+1 Max Minion]"; string QB4 = "[c/2B9DE9:+10% Minion damage]";
        //Range
        string SK1 = "[c/839192:+5% Damage]"; string SK2 = "[c/839192:5 Defense]"; string SK3 = "[c/839192:Increased Run Speed]"; string SK4 = "[c/839192:+10% Ranged Critical strike chance]";
        //Melee
        string WoF1 = "[c/AC395A:+5% Damage]"; string WoF2 = "[c/AC395A:Increased Life Regeneration]"; string WoF3 = "[c/AC395A:+40 Max Mana]"; string WoF4 = "[c/AC395A:Melee Attacks inflict 'On Fire!']";
       
        string TW1 = "[c/2BD34D:-10% Mana Cost, +20 Mana, +5% Magic damage, +5% Mystic Damage]"; string TW2 = "[c/2BD34D:Increased Wing flight time if worn under Wings]"; 

        string DST1 = "[c/DF0A0A:+12% Ranged Critical Strike Chance]"; string DST2 = "[c/DF0A0A:Increased Movement Speed]"; 

        string SP1 = "[c/AAAAAA:+5% Melee damage and speed, melee attacks inflict 'Cursed Inferno']"; string SP2 = "[c/AAAAAA:+6 Defense]"; 

        string PT1 = "[c/2B9DE9:+1 Max Minion, Increased Mana regeneration]"; string PT2 = "[c/2B9DE9:Enemies take full damage.]"; 

        string GL1 = "[c/AF740E:+10% Critical strike chance]"; string GL2 = "[c/AF740E:Increased Life Regeneration]"; 

        string DF1 = "[c/04F6B2:+8% Ranged Damage and Melee Speed, Melee attacks inflict 'Venom']"; string DF2 = "[c/04F6B2:Greatly increased Wing Acceleration]"; string DF3 = "[c/04F6B2:+10% Mystic Damage and Duration]";

        string LC1 = "[c/1D9CA7:+8% Magic, Minion, and Mystic Damage]"; string LC2 = "[c/1D9CA7:+8% Melee, Ranged, and Throwing Damage]";

        string ML1 = "[c/3BE5D7:+10% Damage, +12 Defense]";

        public override void SetStaticDefaults()
        {
            Tooltip.SetDefault("Absorbs the souls of powerful fallen creatures");
        }

        public override void SetDefaults()
        {
            item.width = 30;
            item.height = 28;
            item.value = 10000;
            item.rare = 11;
            item.expert = true;
            item.accessory = true;
            //item.lifeRegen = 19;
        }

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            LaugicalityPlayer modPlayer = player.GetModPlayer<LaugicalityPlayer>(mod);
            Class = modPlayer.Class;
            if (NPC.downedSlimeKing)
            {
                if (SlimeThrow.Contains(Class))
                    player.thrownDamage += 0.1f;

                if (SlimeJump.Contains(Class))
                    player.jumpSpeedBoost += 5.0f;

                if (SlimeMinion.Contains(Class))
                    player.maxMinions += 1;

                if (SlimeVelocity.Contains(Class))
                    player.thrownVelocity += .2f;
            }
            if (NPC.downedBoss1)
            {
                if (Boss1Thorns.Contains(Class))
                    player.thorns += 0.333333343f;

                if (Boss1Speed.Contains(Class))
                    player.moveSpeed += 1.0f;

                if (modPlayer.Class == 3 || modPlayer.Class == 6 || modPlayer.Class == 9 || modPlayer.Class == 11 || modPlayer.Class == 13 || modPlayer.Class == 18)
                {
                    player.detectCreature = true;
                }
                if (modPlayer.Class ==  16 || modPlayer.Class == 17 || modPlayer.Class == 18)
                {
                    modPlayer.destructionDamage += 0.05f;
                    modPlayer.conjurationDamage += 0.05f;
                    modPlayer.mysticDuration += 0.1f;
                }
            }
            if (NPC.downedBoss2)
            {
                if (modPlayer.Class == 1 || modPlayer.Class == 4 || modPlayer.Class == 7 || modPlayer.Class == 10 || modPlayer.Class == 13 || modPlayer.Class == 14 || modPlayer.Class == 16)
                {
                    modPlayer.bRage = true;
                }
                if (modPlayer.Class == 2 || modPlayer.Class == 3 || modPlayer.Class == 8 || modPlayer.Class == 12 || modPlayer.Class == 17)
                {
                    player.statDefense += 4;
                    player.statLifeMax2 += 20;
                }
                if (modPlayer.Class == 5 || modPlayer.Class == 6 || modPlayer.Class == 9 || modPlayer.Class == 11 || modPlayer.Class == 15 || modPlayer.Class == 18)
                {
                    player.lifeRegen += 1;
                    player.statManaMax2 += 20;
                }
                if (modPlayer.Class == 4 || modPlayer.Class == 5 || modPlayer.Class == 6 )
                {
                    player.manaRegenBonus += 15;
                }
            }
            if (NPC.downedQueenBee)
            {
                if (modPlayer.Class == 1 || modPlayer.Class == 7 || modPlayer.Class == 8 || modPlayer.Class == 16)
                {
                    modPlayer.qB = true;
                }
                if (modPlayer.Class ==  2 || modPlayer.Class == 3 || modPlayer.Class == 4 || modPlayer.Class == 13 || modPlayer.Class == 14 || modPlayer.Class == 15 || modPlayer.Class == 18)
                {
                    player.lifeRegen += 2;
                }
                if (modPlayer.Class ==  5 || modPlayer.Class == 6 || modPlayer.Class == 9 || modPlayer.Class == 10 || modPlayer.Class == 11 || modPlayer.Class == 12 || modPlayer.Class == 17)
                {
                    player.maxMinions += 1;
                }
                if (modPlayer.Class ==  10 || modPlayer.Class == 11 || modPlayer.Class == 12)
                {
                    player.minionDamage += .1f;
                }
            }
            if (NPC.downedBoss3)
            {
                if (modPlayer.Class ==  1 || modPlayer.Class == 4 || modPlayer.Class == 7 || modPlayer.Class == 10 || modPlayer.Class == 13 || modPlayer.Class == 16)
                {
                    player.thrownDamage += 0.05f;
                    player.rangedDamage += 0.05f;
                    player.magicDamage += 0.05f;
                    player.minionDamage += 0.05f;
                    player.meleeDamage += 0.05f;
                    modPlayer.mysticDamage += 0.05f;
                }
                if (modPlayer.Class ==  2 || modPlayer.Class == 17)
                {
                    player.statDefense += 5;
                }
                if (modPlayer.Class ==  3 || modPlayer.Class == 5 || modPlayer.Class == 6 || modPlayer.Class == 8 || modPlayer.Class == 9 || modPlayer.Class == 11 || modPlayer.Class == 12 || modPlayer.Class == 14 || modPlayer.Class == 15 || modPlayer.Class == 18)
                {
                    player.maxRunSpeed += .5f;
                    player.moveSpeed += .5f;
                }
                if (modPlayer.Class == 7 || modPlayer.Class == 8 || modPlayer.Class == 9)
                {
                    player.rangedCrit += 10;
                }
            }
            if (Main.hardMode)
            {
                if (modPlayer.Class == 1 || modPlayer.Class == 4 || modPlayer.Class == 7 || modPlayer.Class == 10 || modPlayer.Class == 13 || modPlayer.Class == 16)
                {
                    player.thrownDamage += 0.05f;
                    player.rangedDamage += 0.05f;
                    player.magicDamage += 0.05f;
                    player.minionDamage += 0.05f;
                    player.meleeDamage += 0.05f;
                    modPlayer.mysticDamage += 0.05f;
                }
                if (modPlayer.Class == 2 || modPlayer.Class == 17 || modPlayer.Class == 3 || modPlayer.Class == 8 || modPlayer.Class == 9  || modPlayer.Class == 12 || modPlayer.Class == 14 || modPlayer.Class == 15)
                {
                    player.lifeRegen += 2;
                }
                if (modPlayer.Class == 5 || modPlayer.Class == 6 || modPlayer.Class == 11 || modPlayer.Class == 18)
                {
                    player.statManaMax2 += 40;
                }
                if (modPlayer.Class == 1 || modPlayer.Class == 2 || modPlayer.Class == 3)
                {
                    modPlayer.obsidium = true;
                }
            }
            if (NPC.downedMechBoss1)
            {
                if (modPlayer.Class == 7 || modPlayer.Class == 8 || modPlayer.Class ==  9 )
                {
                    player.rangedCrit += 12;
                }
                if (modPlayer.Class == 1 || modPlayer.Class == 2 || modPlayer.Class ==  3 || modPlayer.Class ==  4 || modPlayer.Class ==  5 || modPlayer.Class ==  6 || modPlayer.Class ==  10 || modPlayer.Class ==  11 || modPlayer.Class ==  12 || modPlayer.Class ==  13 || modPlayer.Class ==  14 || modPlayer.Class ==  15 || modPlayer.Class ==  16 || modPlayer.Class ==  17 || modPlayer.Class ==  18 )
                {
                    player.moveSpeed += .4f;
                }
            }
            if (NPC.downedMechBoss2)
            {
                if (modPlayer.Class == 4 || modPlayer.Class == 5 || modPlayer.Class == 6 || modPlayer.Class == 16 || modPlayer.Class == 17 || modPlayer.Class == 18 || modPlayer.Class == 10 || modPlayer.Class == 11 || modPlayer.Class == 12)
                {
                    player.magicDamage += 0.05f;
                    player.statManaMax2 += 20;
                    player.manaCost -= .1f;
                    modPlayer.mysticDamage += .05f;
                }
                if (modPlayer.Class == 1 || modPlayer.Class == 2 || modPlayer.Class == 3 || modPlayer.Class == 7 || modPlayer.Class == 8 || modPlayer.Class == 9 || modPlayer.Class == 13 || modPlayer.Class == 14 || modPlayer.Class == 15)
                {
                    player.jumpSpeedBoost += 1.5f;
                }
            }
            if (NPC.downedMechBoss3)
            {
                if (modPlayer.Class == 1 || modPlayer.Class == 2 || modPlayer.Class == 3)
                {
                    modPlayer.skp = true;
                    player.meleeDamage += 0.05f;
                    player.meleeSpeed += 0.05f;
                }
                if (modPlayer.Class == 7 || modPlayer.Class == 8 || modPlayer.Class == 9 || modPlayer.Class == 4 || modPlayer.Class == 5 || modPlayer.Class == 6 || modPlayer.Class == 10 || modPlayer.Class == 11 || modPlayer.Class == 12 || modPlayer.Class == 13 || modPlayer.Class == 14 || modPlayer.Class == 15 || modPlayer.Class == 16 || modPlayer.Class == 17 || modPlayer.Class == 18)
                {
                    player.statDefense += 6;
                }
            }
            if (NPC.downedPlantBoss)
            {
                if (modPlayer.Class == 4 || modPlayer.Class == 5 || modPlayer.Class == 6 || modPlayer.Class == 10 || modPlayer.Class == 11 || modPlayer.Class == 12 || modPlayer.Class == 16 || modPlayer.Class == 17 || modPlayer.Class == 18)
                {
                    player.maxMinions++;
                    player.manaRegenBonus += 20;
                }
                if (modPlayer.Class == 1 || modPlayer.Class == 2 || modPlayer.Class == 3 || modPlayer.Class == 7 || modPlayer.Class == 8 || modPlayer.Class == 9 ||  modPlayer.Class == 13 || modPlayer.Class == 14 || modPlayer.Class == 15 )
                {
                    player.thorns += 1f;
                }
            }
            if (NPC.downedGolemBoss)
            {
                if (modPlayer.Class ==  1 || modPlayer.Class == 4 || modPlayer.Class == 7 || modPlayer.Class == 13 )
                {
                    player.thrownCrit += 10;
                    player.rangedCrit += 10;
                    player.magicCrit += 10;
                    player.meleeCrit += 10;
                }
                if (modPlayer.Class ==  2 || modPlayer.Class == 3 || modPlayer.Class == 5 || modPlayer.Class == 6 || modPlayer.Class == 8 || modPlayer.Class == 9 || modPlayer.Class == 10 || modPlayer.Class == 11 || modPlayer.Class == 12 || modPlayer.Class == 14 || modPlayer.Class == 15 || modPlayer.Class == 16 || modPlayer.Class == 17 || modPlayer.Class == 18)
                {
                    player.lifeRegen += 2;
                }
            }
            if (NPC.downedFishron)
            {
                if (modPlayer.Class ==  1 || modPlayer.Class == 2 || modPlayer.Class == 3 || modPlayer.Class == 7 || modPlayer.Class == 8 || modPlayer.Class == 9)
                {
                    modPlayer.douche = true;
                    player.rangedDamage += 0.08f;
                    player.meleeSpeed += 0.08f;
                }
                if (modPlayer.Class ==  4 || modPlayer.Class == 5 || modPlayer.Class == 6 || modPlayer.Class == 10 || modPlayer.Class == 11 || modPlayer.Class == 12 || modPlayer.Class == 13 || modPlayer.Class == 14 || modPlayer.Class == 15)
                {
                    player.jumpSpeedBoost += 4.0f;
                }
                if (modPlayer.Class == 16 || modPlayer.Class == 17 || modPlayer.Class == 18)
                {
                    modPlayer.destructionDamage += 0.05f;
                    modPlayer.conjurationDamage += 0.05f;
                    modPlayer.mysticDuration += 0.1f;
                }
            }
            if (NPC.downedAncientCultist)
            {
                if (modPlayer.Class == 1 || modPlayer.Class == 4 || modPlayer.Class == 7 || modPlayer.Class == 13)
                {
                    player.rangedDamage += 0.08f;
                    player.meleeDamage += 0.08f;
                    modPlayer.mysticDamage += .08f;
                }
                if (modPlayer.Class == 2 || modPlayer.Class == 3 || modPlayer.Class == 5 || modPlayer.Class == 6 || modPlayer.Class == 8 || modPlayer.Class == 9 || modPlayer.Class == 10 || modPlayer.Class == 11 || modPlayer.Class == 12 || modPlayer.Class == 14 || modPlayer.Class == 15 || modPlayer.Class == 16 || modPlayer.Class == 17 || modPlayer.Class == 18)
                {
                    player.magicDamage += 0.08f;
                    player.minionDamage += 0.08f;
                    player.thrownDamage += .08f;
                }
            }
            if (NPC.downedMoonlord)
            {
                player.thrownDamage += 0.10f;
                player.rangedDamage += 0.10f;
                player.magicDamage += 0.10f;
                player.minionDamage += 0.10f;
                player.meleeDamage += 0.10f;
                modPlayer.mysticDamage += .1f;
                player.statDefense += 12;
            }
        }



        public override void ModifyTooltips(List<TooltipLine> tooltips)
        {
            //Tooltips
            /*if (KS > 0)
            {
                TooltipLine lineKSTT = new TooltipLine(mod, "", KSTT);
                tooltips.Add(lineKSTT);
            }*/
            //Class
            if (Class == 0) { TooltipLine lineClass = new TooltipLine(mod, "", "Your Soul is not Bound. \nCraft one of the class Stones to bind it!"); tooltips.Add(lineClass); }
            else if (Class == 1) { TooltipLine lineClass = new TooltipLine(mod, "", "Warrior"); tooltips.Add(lineClass); }
            else if (Class == 2) { TooltipLine lineClass = new TooltipLine(mod, "", "Tank"); tooltips.Add(lineClass); }
            else if (Class == 3) { TooltipLine lineClass = new TooltipLine(mod, "", "Paladin"); tooltips.Add(lineClass); }
            else if (Class == 4) { TooltipLine lineClass = new TooltipLine(mod, "", "Warlock"); tooltips.Add(lineClass); }
            else if (Class == 5) { TooltipLine lineClass = new TooltipLine(mod, "", "Wizard"); tooltips.Add(lineClass); }
            else if (Class == 6) { TooltipLine lineClass = new TooltipLine(mod, "", "Mage"); tooltips.Add(lineClass); }
            else if (Class == 7) { TooltipLine lineClass = new TooltipLine(mod, "", "Sharpshooter"); tooltips.Add(lineClass); }
            else if (Class == 8) { TooltipLine lineClass = new TooltipLine(mod, "", "Rogue"); tooltips.Add(lineClass); }
            else if (Class == 9) { TooltipLine lineClass = new TooltipLine(mod, "", "Hunter"); tooltips.Add(lineClass); }
            else if (Class == 10) { TooltipLine lineClass = new TooltipLine(mod, "", "Necromancer"); tooltips.Add(lineClass); }
            else if (Class == 11) { TooltipLine lineClass = new TooltipLine(mod, "", "Sorcerer"); tooltips.Add(lineClass); }
            else if (Class == 12) { TooltipLine lineClass = new TooltipLine(mod, "", "Shaman"); tooltips.Add(lineClass); }
            else if (Class == 13) { TooltipLine lineClass = new TooltipLine(mod, "", "Assassin"); tooltips.Add(lineClass); }
            else if (Class == 14) { TooltipLine lineClass = new TooltipLine(mod, "", "Ninja"); tooltips.Add(lineClass); }
            else if (Class == 15) { TooltipLine lineClass = new TooltipLine(mod, "", "Thief"); tooltips.Add(lineClass); }
            else if (Class == 16) { TooltipLine lineClass = new TooltipLine(mod, "", "Destructionist"); tooltips.Add(lineClass); }
            else if (Class == 17) { TooltipLine lineClass = new TooltipLine(mod, "", "Illusionist"); tooltips.Add(lineClass); }
            else if (Class == 18) { TooltipLine lineClass = new TooltipLine(mod, "", "Conjurer"); tooltips.Add(lineClass); }
            //Tooltips
            if (NPC.downedSlimeKing)
            {
                if (Class == 13 || Class == 14 || Class == 15)
                {
                    TooltipLine lineKS1 = new TooltipLine(mod, "", KS1);
                    tooltips.Add(lineKS1);
                }

                if (Class == 2 || Class == 3 || Class == 8 || Class == 14 || Class == 17)
                {
                    TooltipLine lineKS2 = new TooltipLine(mod, "", KS2);
                    tooltips.Add(lineKS2);
                }

                if (Class == 1 || Class == 3 || Class == 4 || Class == 5 || Class == 6 || Class == 7 || Class == 9 || Class == 10 || Class == 11 || Class == 12 || Class == 16 || Class == 18)
                {
                    TooltipLine lineKS3 = new TooltipLine(mod, "", KS3);
                    tooltips.Add(lineKS3);
                }

                if (Class == 13 || Class == 15)
                {
                    TooltipLine lineKS4 = new TooltipLine(mod, "", KS4);
                    tooltips.Add(lineKS4);
                }
            }
            if (NPC.downedBoss1)
            {
                if (Class == 1 || Class == 4 || Class == 7 || Class == 10 || Class == 15 || Class == 16)
                {
                    TooltipLine lineEoC1 = new TooltipLine(mod, "", EoC1);
                    tooltips.Add(lineEoC1);
                }
                if (Class == 2 || Class == 5 || Class == 8 || Class == 12 || Class == 14 || Class == 17)
                {
                    TooltipLine lineEoC2 = new TooltipLine(mod, "", EoC2);
                    tooltips.Add(lineEoC2);
                }
                if (Class == 3 || Class == 6 || Class == 9 || Class == 11 || Class == 13 || Class == 18)
                {
                    TooltipLine lineEoC3 = new TooltipLine(mod, "", EoC3);
                    tooltips.Add(lineEoC3);
                }
                if (Class == 16 || Class == 17 || Class == 18)
                {
                    TooltipLine lineEoC4 = new TooltipLine(mod, "", EoC4);
                    tooltips.Add(lineEoC4);
                }
            }
            if (NPC.downedBoss2)
            {
                if (Class == 1 || Class == 4 || Class == 7 || Class == 10 || Class == 13 || Class == 14 || Class == 16)
                {
                    TooltipLine lineEoWBoC1 = new TooltipLine(mod, "", EoWBoC1);
                    tooltips.Add(lineEoWBoC1);
                }
                if (Class == 2 || Class == 3 || Class == 8 || Class == 12 || Class == 17)
                {
                    TooltipLine lineEoWBoC2 = new TooltipLine(mod, "", EoWBoC2);
                    tooltips.Add(lineEoWBoC2);
                }
                if (Class == 5 || Class == 6 || Class == 9 || Class == 11 || Class == 15 || Class == 18)
                {
                    TooltipLine lineEoWBoC3 = new TooltipLine(mod, "", EoWBoC3);
                    tooltips.Add(lineEoWBoC3);
                }
                if (Class == 4 || Class == 5 || Class == 6)
                {
                    TooltipLine lineEoWBoC4 = new TooltipLine(mod, "", EoWBoC4);
                    tooltips.Add(lineEoWBoC4);
                }
            }
            if (NPC.downedQueenBee)
            {
                if (Class == 1 || Class == 7 || Class == 8 || Class == 16)
                {
                    TooltipLine lineQB1 = new TooltipLine(mod, "", QB1);
                    tooltips.Add(lineQB1);
                }
                if (Class == 2 || Class == 3 || Class == 4 || Class == 13 || Class == 14 || Class == 15 || Class == 18)
                {
                    TooltipLine lineQB2 = new TooltipLine(mod, "", QB2);
                    tooltips.Add(lineQB2);
                }
                if (Class == 5 || Class == 6 || Class == 9 || Class == 10 || Class == 11 || Class == 12 || Class == 17)
                {
                    TooltipLine lineQB3 = new TooltipLine(mod, "", QB3);
                    tooltips.Add(lineQB3);
                }
                if (Class == 10 || Class == 11 || Class == 12)
                {
                    TooltipLine lineQB4 = new TooltipLine(mod, "", QB4);
                    tooltips.Add(lineQB4);
                }
            }
            if (NPC.downedBoss3)
            {
                if (Class == 1 || Class == 4 || Class == 7 || Class == 10 || Class == 13 || Class == 16)
                {
                    TooltipLine lineSK1 = new TooltipLine(mod, "", SK1);
                    tooltips.Add(lineSK1);
                }
                if (Class == 2 || Class == 17)
                {
                    TooltipLine lineSK2 = new TooltipLine(mod, "", SK2);
                    tooltips.Add(lineSK2);
                }
                if (Class == 3 || Class == 5 || Class == 6 || Class == 8 || Class == 9 || Class == 11 || Class == 12 || Class == 14 || Class == 15 || Class == 18)
                {
                    TooltipLine lineSK3 = new TooltipLine(mod, "", SK3);
                    tooltips.Add(lineSK3);
                }
                if (Class == 7 || Class == 8 || Class == 9)
                {
                    TooltipLine lineSK4 = new TooltipLine(mod, "", SK4);
                    tooltips.Add(lineSK4);
                }

            }
            if (Main.hardMode)
            {
                if (Class == 1 || Class == 4 || Class == 7 || Class == 10 || Class == 13 || Class == 16)
                {
                    TooltipLine lineWoF1 = new TooltipLine(mod, "", WoF1);
                    tooltips.Add(lineWoF1);
                }
                if (Class == 2 || Class == 17 || Class == 3 || Class == 8 || Class == 9 || Class == 12 || Class == 14 || Class == 15)
                {
                    TooltipLine lineWoF2 = new TooltipLine(mod, "", WoF2);
                    tooltips.Add(lineWoF2);
                }
                if (Class == 5 || Class == 6 || Class == 11 || Class == 18)
                {
                    TooltipLine lineWoF3 = new TooltipLine(mod, "", WoF3);
                    tooltips.Add(lineWoF3);
                }
                if (Class == 1 || Class == 2 || Class == 3)
                {
                    TooltipLine lineWoF4 = new TooltipLine(mod, "", WoF4);
                    tooltips.Add(lineWoF4);
                }
            }
            if (NPC.downedMechBoss2)
            {
                if (Class == 7 || Class == 8 || Class == 9)
                
                    {
                        TooltipLine lineTW1 = new TooltipLine(mod, "", TW1);
                        tooltips.Add(lineTW1);
                    }
                if (Class == 1 || Class == 2 || Class == 3 || Class == 4 || Class == 5 || Class == 6 || Class == 10 || Class == 11 || Class == 12 || Class == 13 || Class == 14 || Class == 15 || Class == 16 || Class == 17 || Class == 18)
                    {
                        TooltipLine lineTW2 = new TooltipLine(mod, "", TW2);
                        tooltips.Add(lineTW2);
                    }
            }
            if (NPC.downedMechBoss1)
            {
                if (Class == 4 || Class == 5 || Class == 6 || Class == 16 || Class == 17 || Class == 18 || Class == 10 || Class == 11 || Class == 12)
                    {
                        TooltipLine lineDST1 = new TooltipLine(mod, "", DST1);
                        tooltips.Add(lineDST1);
                    }
                if (Class == 1 || Class == 2 || Class == 3 || Class == 7 || Class == 8 || Class == 9 || Class == 13 || Class == 14 || Class == 15)
                    {
                        TooltipLine lineDST2 = new TooltipLine(mod, "", DST2);
                        tooltips.Add(lineDST2);
                    }
            }
            if (NPC.downedMechBoss3)
            {
                if (Class == 1 || Class == 2 || Class == 3)
                    {
                        TooltipLine lineSP1 = new TooltipLine(mod, "", SP1);
                        tooltips.Add(lineSP1);
                    }
                if (Class == 7 || Class == 8 || Class == 9 || Class == 4 || Class == 5 || Class == 6 || Class == 10 || Class == 11 || Class == 12 || Class == 13 || Class == 14 || Class == 15 || Class == 16 || Class == 17 || Class == 18)
                    {
                        TooltipLine lineSP2 = new TooltipLine(mod, "", SP2);
                        tooltips.Add(lineSP2);
                    }
            }
            if (NPC.downedPlantBoss)
            {
                if (Class == 4 || Class == 5 || Class == 6 || Class == 10 || Class == 11 || Class == 12 || Class == 16 || Class == 17 || Class == 18)
                {
                    TooltipLine linePT1 = new TooltipLine(mod, "", PT1);
                    tooltips.Add(linePT1);
                }
                if (Class == 1 || Class == 2 || Class == 3 || Class == 7 || Class == 8 || Class == 9 || Class == 13 || Class == 14 || Class == 15)
                {
                    TooltipLine linePT2 = new TooltipLine(mod, "", PT2);
                    tooltips.Add(linePT2);
                }
            }
            if (NPC.downedGolemBoss)
            {
                if (Class == 1 || Class == 4 || Class == 7 || Class == 13)
                {
                    TooltipLine lineGL1 = new TooltipLine(mod, "", GL1);
                    tooltips.Add(lineGL1);
                }
                if (Class == 2 || Class == 3 || Class == 5 || Class == 6 || Class == 8 || Class == 9 || Class == 10 || Class == 11 || Class == 12 || Class == 14 || Class == 15 || Class == 16 || Class == 17 || Class == 18)
                {
                    TooltipLine lineGL2 = new TooltipLine(mod, "", GL2);
                    tooltips.Add(lineGL2);
                }
            }
            if (NPC.downedFishron)
            {
                if (Class == 1 || Class == 2 || Class == 3 || Class == 7 || Class == 8 || Class == 9)
                {
                    TooltipLine lineDF1 = new TooltipLine(mod, "", DF1);
                    tooltips.Add(lineDF1);
                }
                if (Class == 4 || Class == 5 || Class == 6 || Class == 10 || Class == 11 || Class == 12 || Class == 13 || Class == 14 || Class == 15)
                {
                    TooltipLine lineDF2 = new TooltipLine(mod, "", DF2);
                    tooltips.Add(lineDF2);
                }
                if (Class == 16 || Class == 17 || Class == 18)
                {
                    TooltipLine lineDF3 = new TooltipLine(mod, "", DF3);
                    tooltips.Add(lineDF3);
                }
            }
            if (NPC.downedAncientCultist)
            {
                if (Class == 1 || Class == 4 || Class == 7 || Class == 13)
                {
                    TooltipLine lineLC1 = new TooltipLine(mod, "", LC1);
                    tooltips.Add(lineLC1);
                }
                if (Class == 2 || Class == 3 || Class == 5 || Class == 6 || Class == 8 || Class == 9 || Class == 10 || Class == 11 || Class == 12 || Class == 14 || Class == 15 || Class == 16 || Class == 17 || Class == 18)
                {
                    TooltipLine lineLC2 = new TooltipLine(mod, "", LC2);
                    tooltips.Add(lineLC2);
                }
            }
            if (NPC.downedMoonlord && Class > 0)
            {
                TooltipLine lineML1 = new TooltipLine(mod, "", ML1);
                tooltips.Add(lineML1);
            }
        }
        
        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(29);
            recipe.AddIngredient(109);
            recipe.AddTile(null, "AlchemicalInfuser");
            recipe.SetResult(this);
            recipe.AddRecipe();
        }


    }
    
}