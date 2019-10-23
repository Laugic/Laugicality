using System.Collections.Generic;
using Laugicality.Items;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Laugicality.SoulStones
{
    public abstract class OldSoulStone : LaugicalityItem
    {

        //Throwing
        string _ks1 = "[c/2B9DE9:+10% Throwing Damage]"; string _ks2 = "[c/2B9DE9:Greatly increases jump height]"; string _ks3 = "[c/2B9DE9:Attacks Inflict 'Slimed']"; string _ks4 = "[c/2B9DE9:+20% Throwing velocity]";
        //Mystic
        string _eoC1 = "[c/B03A2E:Friendly Eyes spawn to protect you when you take damage.]"; string _eoC2 = "[c/B03A2E:Greatly increases movement speed]"; string _eoC3 = "[c/B03A2E:Hunter Potion Effect]"; string _eoC4 = "[c/B03A2E:+5% Destruction and Conjuration Damage, +20% Illusion Duration]";
        //Magic
        string _eoWboC1 = "[c/884EA0:Causes 'Blood Rage' when struck]"; string _eoWboC2 = "[c/884EA0:+4 Defense, +20 Max Life]"; string _eoWboC3 = "[c/884EA0:+20 Max Mana, Increased Life Regeneration]"; string _eoWboC4 = "[c/884EA0:Increased Mana Regeneration]";
        //Summon
        string _qb1 = "[c/F39C12:Attacks inflict Poison]"; string _qb2 = "[c/F39C12:Increased Life Regeneration]"; string _qb3 = "[c/F39C12:+1 Max Minion]"; string _qb4 = "[c/F39C12:+10% Minion damage]";
        //Range
        string _sk1 = "[c/839192:+5% Damage]"; string _sk2 = "[c/839192:5 Defense]"; string _sk3 = "[c/839192:Increased Run Speed]"; string _sk4 = "[c/839192:+10% Ranged Critical strike chance]";
        //Melee
        string _woF1 = "[c/AC395A:+5% Damage]"; string _woF2 = "[c/AC395A:Increased Life Regeneration]"; string _woF3 = "[c/AC395A:+40 Max Mana]"; string _woF4 = "[c/AC395A:Attacks inflict 'On Fire!']";
       
        string _tw1 = "[c/2BD34D:-10% Mana Cost, +20 Mana, +5% Magic damage, +5% Mystic Damage]"; string _tw2 = "[c/2BD34D:Increased Wing flight time if worn under Wings]"; 

        string _dst1 = "[c/DF0A0A:+12% Ranged Critical Strike Chance]"; string _dst2 = "[c/DF0A0A:Increased Movement Speed]"; 

        string _sp1 = "[c/AAAAAA:+5% Melee damage and speed, attacks inflict 'Cursed Inferno']"; string _sp2 = "[c/AAAAAA:+6 Defense]"; 

        string _pt1 = "[c/27AE60:+1 Max Minion, Increased Mana regeneration]"; string _pt2 = "[c/27AE60:Release Spores when struck.]"; 

        string _gl1 = "[c/AF740E:+10% Critical strike chance]"; string _gl2 = "[c/AF740E:Increased Life Regeneration]"; 

        string _df1 = "[c/04F6B2:+8% Ranged Damage and Melee Speed, Attacks inflict 'Venom']"; string _df2 = "[c/04F6B2:Greatly increased Wing Acceleration]"; string _df3 = "[c/04F6B2:+10% Mystic Damage and Duration]";

        string _lc2 = "[c/1D9CA7:+8% Magic, Minion, and Mystic Damage]"; string _lc1 = "[c/1D9CA7:+8% Melee, Ranged, and Throwing Damage]";

        string _ml1 = "[c/3BE5D7:+10% Damage, +12 Defense]";

        public override void SetStaticDefaults()
        {
            Tooltip.SetDefault("Absorbs the souls of powerful fallen creatures\nAn otherworldly entitiy seems to have sealed some of its power...");
        }

        public override void SetDefaults()
        {
            item.width = 30;
            item.height = 28;
            item.value = 10000;
            item.rare = ItemRarityID.Purple;
            item.expert = true;
            item.accessory = true;
            //item.lifeRegen = 19;
        }

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            LaugicalityPlayer mPlayer = LaugicalityPlayer.Get(player);
            int Class = mPlayer.Class;

            


            if (NPC.downedSlimeKing)
            {
                if (LaugicalityVars.slimeThrow.Contains(Class))
                    player.thrownDamage += 0.1f;

                if (LaugicalityVars.slimeJump.Contains(Class) && mPlayer.SoulStoneMovement)
                    player.jumpSpeedBoost += 5.0f;

                if (LaugicalityVars.slimeMinion.Contains(Class))
                    mPlayer.Slimey = true;

                if (LaugicalityVars.slimeVelocity.Contains(Class))
                    player.thrownVelocity += .2f;
            }
            if (NPC.downedBoss1)
            {
                if (LaugicalityVars.boss1Thorns.Contains(Class))
                    mPlayer.Eyes = true;

                if (LaugicalityVars.boss1Speed.Contains(Class))
                    player.moveSpeed += 1.0f;

                if (LaugicalityVars.boss1Detect.Contains(Class) && mPlayer.SoulStoneVisuals)
                    player.detectCreature = true;

                if (LaugicalityVars.boss1Damage.Contains(Class))
                {
                    mPlayer.DestructionDamage += 0.05f;
                    mPlayer.ConjurationDamage += 0.05f;
                    mPlayer.MysticDuration += 0.2f;
                }
            }
            if (NPC.downedBoss2)
            {
                if (LaugicalityVars.boss2Rage.Contains(Class))
                    mPlayer.BloodRage = true;

                if (LaugicalityVars.boss2Defence.Contains(Class))
                {
                    player.statDefense += 4;
                    player.statLifeMax2 += 20;
                }
                if (LaugicalityVars.boss2Regen.Contains(Class))
                {
                    player.lifeRegen += 1;
                    player.statManaMax2 += 20;
                }
                if (LaugicalityVars.boss2RBonus.Contains(Class))
                    player.manaRegenBonus += 15;

            }
            if (NPC.downedQueenBee)
            {
                if (LaugicalityVars.beeTrue.Contains(Class))
                    mPlayer.QueenBee = true;

                if (LaugicalityVars.beeRegen.Contains(Class))
                    player.lifeRegen += 2;

                if (LaugicalityVars.beeMinions.Contains(Class))
                    player.maxMinions += 1;

                if (LaugicalityVars.beeMDamage.Contains(Class))
                    player.minionDamage += .1f;

            }
            if (NPC.downedBoss3)
            {
                if (LaugicalityVars.boss3Damage.Contains(Class))
                {
                    player.allDamage += 0.05f;
                }
                if (LaugicalityVars.boss3Defense.Contains(Class))
                    player.statDefense += 5;

                if (LaugicalityVars.boss3Speed.Contains(Class))
                {
                    player.maxRunSpeed += .5f;
                    player.moveSpeed += .5f;
                }
                if (LaugicalityVars.boss3Crit.Contains(Class))
                    player.rangedCrit += 10;

            }
            if (Main.hardMode)
            {
                if (LaugicalityVars.hardDamage.Contains(Class))
                {
                    player.allDamage += 0.05f;
                }
                if (LaugicalityVars.hardRegen.Contains(Class))
                    player.lifeRegen += 2;

                if (LaugicalityVars.hardMana.Contains(Class))
                    player.statManaMax2 += 40;

                if (LaugicalityVars.hardObsid.Contains(Class))
                    mPlayer.Obsidium = true;

            }
            if (NPC.downedMechBoss1)
            {
                if (LaugicalityVars.mech1Crit.Contains(Class))
                    player.rangedCrit += 12;

                if (LaugicalityVars.mech1Speed.Contains(Class))
                    player.moveSpeed += .4f;

            }
            if (NPC.downedMechBoss2)
            {
                if (LaugicalityVars.mech2Magic.Contains(Class))
                {
                    player.magicDamage += 0.05f;
                    player.statManaMax2 += 20;
                    player.manaCost -= .1f;
                    mPlayer.MysticDamage += .05f;
                }
                if (LaugicalityVars.mech2Jump.Contains(Class) && mPlayer.SoulStoneMovement)
                    player.wingTimeMax += 120;

            }
            if (NPC.downedMechBoss3)
            {
                if (LaugicalityVars.mech3Damage.Contains(Class))
                {
                    mPlayer.SkeletonPrime = true;
                    player.meleeDamage += 0.05f;
                    player.meleeSpeed += 0.05f;
                }
                if (LaugicalityVars.mech3Defense.Contains(Class))
                    player.statDefense += 6;

            }
            if (NPC.downedPlantBoss)
            {
                if (LaugicalityVars.plantBonus.Contains(Class))
                {
                    player.maxMinions++;
                    player.manaRegenBonus += 20;
                }
                if (LaugicalityVars.plantThorns.Contains(Class))
                    mPlayer.Spores = true;

            }
            if (NPC.downedGolemBoss)
            {
                if (LaugicalityVars.golemCrit.Contains(Class))
                {
                    player.thrownCrit += 10;
                    player.rangedCrit += 10;
                    player.magicCrit += 10;
                    player.meleeCrit += 10;
                }
                if (LaugicalityVars.golemRegen.Contains(Class))
                    player.lifeRegen += 2;

            }
            if (NPC.downedFishron)
            {
                if (LaugicalityVars.fishDouche.Contains(Class))
                {
                    mPlayer.Doucheron = true;
                    player.rangedDamage += 0.08f;
                    player.meleeSpeed += 0.08f;
                }
                if (LaugicalityVars.fishSpeed.Contains(Class) && mPlayer.SoulStoneMovement)
                    player.jumpSpeedBoost += 4.0f;

                if (LaugicalityVars.fishMDamage.Contains(Class))
                {
                    mPlayer.DestructionDamage += 0.05f;
                    mPlayer.ConjurationDamage += 0.05f;
                    mPlayer.MysticDuration += 0.1f;
                }
            }
            if (NPC.downedAncientCultist)
            {
                if (LaugicalityVars.cultistDamage1.Contains(Class))
                {
                    player.rangedDamage += 0.08f;
                    player.meleeDamage += 0.08f;
                    player.thrownDamage += .08f;
                }
                if (LaugicalityVars.cultistDamage2.Contains(Class))
                {
                    player.magicDamage += 0.08f;
                    player.minionDamage += 0.08f;
                    mPlayer.MysticDamage += .08f;
                }
            }
            if (NPC.downedMoonlord)
            {
                player.allDamage += 0.10f;
                player.statDefense += 12;
            }
        }



        public override void ModifyTooltips(List<TooltipLine> tooltips)
        {
            Player ttPlayer = Main.player[Main.myPlayer];
            int Class = ttLaugicalityPlayer.Get(player).Class;
            //Tooltips
            /*if (KS > 0)
            {
                TooltipLine lineKSTT = new TooltipLine(mod, "", KSTT);
                tooltips.Add(lineKSTT);
            }*/
            //Class
            if      (Class == (int)LaugicalityVars.ClassType.Undefined      ) { TooltipLine lineClass = new TooltipLine(mod, "", "Your Soul is not Bound. \nCraft one of the class Stones to bind it!"); tooltips.Add(lineClass); }
            else if (Class == (int)LaugicalityVars.ClassType.Warrior        ) { TooltipLine lineClass = new TooltipLine(mod, "", "Warrior"); tooltips.Add(lineClass); }
            else if (Class == (int)LaugicalityVars.ClassType.Tank           ) { TooltipLine lineClass = new TooltipLine(mod, "", "Tank"); tooltips.Add(lineClass); }
            else if (Class == (int)LaugicalityVars.ClassType.Paladin        ) { TooltipLine lineClass = new TooltipLine(mod, "", "Paladin"); tooltips.Add(lineClass); }
            else if (Class == (int)LaugicalityVars.ClassType.Warlock        ) { TooltipLine lineClass = new TooltipLine(mod, "", "Warlock"); tooltips.Add(lineClass); }
            else if (Class == (int)LaugicalityVars.ClassType.Wizard         ) { TooltipLine lineClass = new TooltipLine(mod, "", "Wizard"); tooltips.Add(lineClass); }
            else if (Class == (int)LaugicalityVars.ClassType.Mage           ) { TooltipLine lineClass = new TooltipLine(mod, "", "Mage"); tooltips.Add(lineClass); }
            else if (Class == (int)LaugicalityVars.ClassType.Sharpshooter   ) { TooltipLine lineClass = new TooltipLine(mod, "", "Sharpshooter"); tooltips.Add(lineClass); }
            else if (Class == (int)LaugicalityVars.ClassType.Rogue          ) { TooltipLine lineClass = new TooltipLine(mod, "", "Rogue"); tooltips.Add(lineClass); }
            else if (Class == (int)LaugicalityVars.ClassType.Hunter         ) { TooltipLine lineClass = new TooltipLine(mod, "", "Hunter"); tooltips.Add(lineClass); }
            else if (Class == (int)LaugicalityVars.ClassType.Necromancer    ) { TooltipLine lineClass = new TooltipLine(mod, "", "Necromancer"); tooltips.Add(lineClass); }
            else if (Class == (int)LaugicalityVars.ClassType.Sorcerer       ) { TooltipLine lineClass = new TooltipLine(mod, "", "Sorcerer"); tooltips.Add(lineClass); }
            else if (Class == (int)LaugicalityVars.ClassType.Shaman         ) { TooltipLine lineClass = new TooltipLine(mod, "", "Shaman"); tooltips.Add(lineClass); }
            else if (Class == (int)LaugicalityVars.ClassType.Assasin        ) { TooltipLine lineClass = new TooltipLine(mod, "", "Assassin"); tooltips.Add(lineClass); }
            else if (Class == (int)LaugicalityVars.ClassType.Ninja          ) { TooltipLine lineClass = new TooltipLine(mod, "", "Ninja"); tooltips.Add(lineClass); }
            else if (Class == (int)LaugicalityVars.ClassType.Thief          ) { TooltipLine lineClass = new TooltipLine(mod, "", "Thief"); tooltips.Add(lineClass); }
            else if (Class == (int)LaugicalityVars.ClassType.Destructionist ) { TooltipLine lineClass = new TooltipLine(mod, "", "Destructionist"); tooltips.Add(lineClass); }
            else if (Class == (int)LaugicalityVars.ClassType.Illusionist    ) { TooltipLine lineClass = new TooltipLine(mod, "", "Illusionist"); tooltips.Add(lineClass); }
            else if (Class == (int)LaugicalityVars.ClassType.Conjurer       ) { TooltipLine lineClass = new TooltipLine(mod, "", "Conjurer"); tooltips.Add(lineClass); }
            //Tooltips
            if (NPC.downedSlimeKing)
            {
                if (LaugicalityVars.slimeThrow.Contains(Class))
                {
                    TooltipLine lineKs1 = new TooltipLine(mod, "", _ks1);
                    tooltips.Add(lineKs1);
                }

                if (LaugicalityVars.slimeJump.Contains(Class))
                {
                    TooltipLine lineKs2 = new TooltipLine(mod, "", _ks2);
                    tooltips.Add(lineKs2);
                }

                if (LaugicalityVars.slimeMinion.Contains(Class))
                {
                    TooltipLine lineKs3 = new TooltipLine(mod, "", _ks3);
                    tooltips.Add(lineKs3);
                }

                if (LaugicalityVars.slimeVelocity.Contains(Class))
                {
                    TooltipLine lineKs4 = new TooltipLine(mod, "", _ks4);
                    tooltips.Add(lineKs4);
                }
            }
            if (NPC.downedBoss1)
            {
                if (LaugicalityVars.boss1Thorns.Contains(Class))
                {
                    TooltipLine lineEoC1 = new TooltipLine(mod, "", _eoC1);
                    tooltips.Add(lineEoC1);
                }
                if (LaugicalityVars.boss1Speed.Contains(Class))
                {
                    TooltipLine lineEoC2 = new TooltipLine(mod, "", _eoC2);
                    tooltips.Add(lineEoC2);
                }
                if (LaugicalityVars.boss1Detect.Contains(Class))
                {
                    TooltipLine lineEoC3 = new TooltipLine(mod, "", _eoC3);
                    tooltips.Add(lineEoC3);
                }
                if (LaugicalityVars.boss1Damage.Contains(Class))
                {
                    TooltipLine lineEoC4 = new TooltipLine(mod, "", _eoC4);
                    tooltips.Add(lineEoC4);
                }
            }
            if (NPC.downedBoss2)
            {
                if (LaugicalityVars.boss2Rage.Contains(Class))
                {
                    TooltipLine lineEoWboC1 = new TooltipLine(mod, "", _eoWboC1);
                    tooltips.Add(lineEoWboC1);
                }
                if (LaugicalityVars.boss2Defence.Contains(Class))
                {
                    TooltipLine lineEoWboC2 = new TooltipLine(mod, "", _eoWboC2);
                    tooltips.Add(lineEoWboC2);
                }
                if (LaugicalityVars.boss2Regen.Contains(Class))
                {
                    TooltipLine lineEoWboC3 = new TooltipLine(mod, "", _eoWboC3);
                    tooltips.Add(lineEoWboC3);
                }
                if (LaugicalityVars.boss2RBonus.Contains(Class))
                {
                    TooltipLine lineEoWboC4 = new TooltipLine(mod, "", _eoWboC4);
                    tooltips.Add(lineEoWboC4);
                }
            }
            if (NPC.downedQueenBee)
            {
                if (LaugicalityVars.beeTrue.Contains(Class))
                {
                    TooltipLine lineQb1 = new TooltipLine(mod, "", _qb1);
                    tooltips.Add(lineQb1);
                }
                if (LaugicalityVars.beeRegen.Contains(Class))
                {
                    TooltipLine lineQb2 = new TooltipLine(mod, "", _qb2);
                    tooltips.Add(lineQb2);
                }
                if (LaugicalityVars.beeMinions.Contains(Class))
                {
                    TooltipLine lineQb3 = new TooltipLine(mod, "", _qb3);
                    tooltips.Add(lineQb3);
                }
                if (LaugicalityVars.beeMDamage.Contains(Class))
                {
                    TooltipLine lineQb4 = new TooltipLine(mod, "", _qb4);
                    tooltips.Add(lineQb4);
                }
            }
            if (NPC.downedBoss3)
            {
                if (LaugicalityVars.boss3Damage.Contains(Class))
                {
                    TooltipLine lineSk1 = new TooltipLine(mod, "", _sk1);
                    tooltips.Add(lineSk1);
                }
                if (LaugicalityVars.boss3Defense.Contains(Class))
                {
                    TooltipLine lineSk2 = new TooltipLine(mod, "", _sk2);
                    tooltips.Add(lineSk2);
                }
                if (LaugicalityVars.boss3Speed.Contains(Class))
                {
                    TooltipLine lineSk3 = new TooltipLine(mod, "", _sk3);
                    tooltips.Add(lineSk3);
                }
                if (LaugicalityVars.boss3Crit.Contains(Class))
                {
                    TooltipLine lineSk4 = new TooltipLine(mod, "", _sk4);
                    tooltips.Add(lineSk4);
                }

            }
            if (Main.hardMode)
            {
                if (LaugicalityVars.hardDamage.Contains(Class))
                {
                    TooltipLine lineWoF1 = new TooltipLine(mod, "", _woF1);
                    tooltips.Add(lineWoF1);
                }
                if (LaugicalityVars.hardRegen.Contains(Class))
                {
                    TooltipLine lineWoF2 = new TooltipLine(mod, "", _woF2);
                    tooltips.Add(lineWoF2);
                }
                if (LaugicalityVars.hardMana.Contains(Class))
                {
                    TooltipLine lineWoF3 = new TooltipLine(mod, "", _woF3);
                    tooltips.Add(lineWoF3);
                }
                if (LaugicalityVars.hardObsid.Contains(Class))
                {
                    TooltipLine lineWoF4 = new TooltipLine(mod, "", _woF4);
                    tooltips.Add(lineWoF4);
                }
            }
            if (NPC.downedMechBoss1)
            {
                if (LaugicalityVars.mech1Crit.Contains(Class))
                
                    {
                        TooltipLine lineDst1 = new TooltipLine(mod, "", _dst1);
                        tooltips.Add(lineDst1);
                    }
                if (LaugicalityVars.mech1Speed.Contains(Class))
                    {
                        TooltipLine lineDst2 = new TooltipLine(mod, "", _dst2);
                        tooltips.Add(lineDst2);
                    }
            }
            if (NPC.downedMechBoss2)
            {
                if (LaugicalityVars.mech2Magic.Contains(Class))
                    {
                        TooltipLine lineTw1 = new TooltipLine(mod, "", _tw1);
                        tooltips.Add(lineTw1);
                    }
                if (LaugicalityVars.mech2Jump.Contains(Class))
                    {
                        TooltipLine lineTw2 = new TooltipLine(mod, "", _tw2);
                        tooltips.Add(lineTw2);
                    }
            }
            if (NPC.downedMechBoss3)
            {
                if (LaugicalityVars.mech3Damage.Contains(Class))
                    {
                        TooltipLine lineSp1 = new TooltipLine(mod, "", _sp1);
                        tooltips.Add(lineSp1);
                    }
                if (LaugicalityVars.mech3Defense.Contains(Class))
                    {
                        TooltipLine lineSp2 = new TooltipLine(mod, "", _sp2);
                        tooltips.Add(lineSp2);
                    }
            }
            if (NPC.downedPlantBoss)
            {
                if (LaugicalityVars.plantBonus.Contains(Class))
                {
                    TooltipLine linePt1 = new TooltipLine(mod, "", _pt1);
                    tooltips.Add(linePt1);
                }
                if (LaugicalityVars.plantThorns.Contains(Class))
                {
                    TooltipLine linePt2 = new TooltipLine(mod, "", _pt2);
                    tooltips.Add(linePt2);
                }
            }
            if (NPC.downedGolemBoss)
            {
                if (LaugicalityVars.golemCrit.Contains(Class))
                {
                    TooltipLine lineGl1 = new TooltipLine(mod, "", _gl1);
                    tooltips.Add(lineGl1);
                }
                if (LaugicalityVars.golemRegen.Contains(Class))
                {
                    TooltipLine lineGl2 = new TooltipLine(mod, "", _gl2);
                    tooltips.Add(lineGl2);
                }
            }
            if (NPC.downedFishron)
            {
                if (LaugicalityVars.fishDouche.Contains(Class))
                {
                    TooltipLine lineDf1 = new TooltipLine(mod, "", _df1);
                    tooltips.Add(lineDf1);
                }
                if (LaugicalityVars.fishSpeed.Contains(Class))
                {
                    TooltipLine lineDf2 = new TooltipLine(mod, "", _df2);
                    tooltips.Add(lineDf2);
                }
                if (LaugicalityVars.fishMDamage.Contains(Class))
                {
                    TooltipLine lineDf3 = new TooltipLine(mod, "", _df3);
                    tooltips.Add(lineDf3);
                }
            }
            if (NPC.downedAncientCultist)
            {
                if (LaugicalityVars.cultistDamage1.Contains(Class))
                {
                    TooltipLine lineLc1 = new TooltipLine(mod, "", _lc1);
                    tooltips.Add(lineLc1);
                }
                if (LaugicalityVars.cultistDamage2.Contains(Class))
                {
                    TooltipLine lineLc2 = new TooltipLine(mod, "", _lc2);
                    tooltips.Add(lineLc2);
                }
            }
            if (NPC.downedMoonlord && Class > 0)
            {
                TooltipLine lineMl1 = new TooltipLine(mod, "", _ml1);
                tooltips.Add(lineMl1);
            }
        }
        
        /*public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.LifeCrystal);
            recipe.AddIngredient(null, "ArcaneShard", 10);
            recipe.AddTile(null, "AlchemicalInfuser");
            recipe.SetResult(this);
            recipe.AddRecipe();
        }*/
    }
    
}