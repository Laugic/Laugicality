using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;
using Laugicality;
using System.Linq;

namespace Laugicality.Items.SoulStone
{
    public class SoulStone : ModItem
    {

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
            var mPlayer = Main.LocalPlayer.GetModPlayer<LaugicalityPlayer>(mod);
            var Class = mPlayer.Class;
            if (NPC.downedSlimeKing)
            {
                if (LaugicalityVars.SlimeThrow.Contains(Class))
                    player.thrownDamage += 0.1f;

                if (LaugicalityVars.SlimeJump.Contains(Class))
                    player.jumpSpeedBoost += 5.0f;

                if (LaugicalityVars.SlimeMinion.Contains(Class))
                    player.maxMinions += 1;

                if (LaugicalityVars.SlimeVelocity.Contains(Class))
                    player.thrownVelocity += .2f;
            }
            if (NPC.downedBoss1)
            {
                if (LaugicalityVars.Boss1Thorns.Contains(Class))
                    player.thorns += 0.333333343f;

                if (LaugicalityVars.Boss1Speed.Contains(Class))
                    player.moveSpeed += 1.0f;

                if (LaugicalityVars.Boss1Detect.Contains(Class))
                    player.detectCreature = true;

                if (LaugicalityVars.Boss1Damage.Contains(Class))
                {
                    mPlayer.destructionDamage += 0.05f;
                    mPlayer.conjurationDamage += 0.05f;
                    mPlayer.mysticDuration += 0.1f;
                }
            }
            if (NPC.downedBoss2)
            {
                if (LaugicalityVars.Boss2Rage.Contains(Class))
                    mPlayer.bRage = true;

                if (LaugicalityVars.Boss2Defence.Contains(Class))
                {
                    player.statDefense += 4;
                    player.statLifeMax2 += 20;
                }
                if (LaugicalityVars.Boss2Regen.Contains(Class))
                {
                    player.lifeRegen += 1;
                    player.statManaMax2 += 20;
                }
                if (LaugicalityVars.Boss2RBonus.Contains(Class))
                    player.manaRegenBonus += 15;

            }
            if (NPC.downedQueenBee)
            {
                if (LaugicalityVars.BeeTrue.Contains(Class))
                    mPlayer.qB = true;

                if (LaugicalityVars.BeeRegen.Contains(Class))
                    player.lifeRegen += 2;

                if (LaugicalityVars.BeeMinions.Contains(Class))
                    player.maxMinions += 1;

                if (LaugicalityVars.BeeMDamage.Contains(Class))
                    player.minionDamage += .1f;

            }
            if (NPC.downedBoss3)
            {
                if (LaugicalityVars.Boss3Damage.Contains(Class))
                {
                    player.thrownDamage += 0.05f;
                    player.rangedDamage += 0.05f;
                    player.magicDamage += 0.05f;
                    player.minionDamage += 0.05f;
                    player.meleeDamage += 0.05f;
                    mPlayer.mysticDamage += 0.05f;
                }
                if (LaugicalityVars.Boss3Defense.Contains(Class))
                    player.statDefense += 5;

                if (LaugicalityVars.Boss3Speed.Contains(Class))
                {
                    player.maxRunSpeed += .5f;
                    player.moveSpeed += .5f;
                }
                if (LaugicalityVars.Boss3Crit.Contains(Class))
                    player.rangedCrit += 10;

            }
            if (Main.hardMode)
            {
                if (LaugicalityVars.HardDamage.Contains(Class))
                {
                    player.thrownDamage += 0.05f;
                    player.rangedDamage += 0.05f;
                    player.magicDamage += 0.05f;
                    player.minionDamage += 0.05f;
                    player.meleeDamage += 0.05f;
                    mPlayer.mysticDamage += 0.05f;
                }
                if (LaugicalityVars.HardRegen.Contains(Class))
                    player.lifeRegen += 2;

                if (LaugicalityVars.HardMana.Contains(Class))
                    player.statManaMax2 += 40;

                if (LaugicalityVars.HardObsid.Contains(Class))
                    mPlayer.obsidium = true;

            }
            if (NPC.downedMechBoss1)
            {
                if (LaugicalityVars.Mech1Crit.Contains(Class))
                    player.rangedCrit += 12;

                if (LaugicalityVars.Mech1Speed.Contains(Class))
                    player.moveSpeed += .4f;

            }
            if (NPC.downedMechBoss2)
            {
                if (LaugicalityVars.Mech2Magic.Contains(Class))
                {
                    player.magicDamage += 0.05f;
                    player.statManaMax2 += 20;
                    player.manaCost -= .1f;
                    mPlayer.mysticDamage += .05f;
                }
                if (LaugicalityVars.Mech2Jump.Contains(Class))
                    player.jumpSpeedBoost += 1.5f;

            }
            if (NPC.downedMechBoss3)
            {
                if (LaugicalityVars.Mech3Damage.Contains(Class))
                {
                    mPlayer.skp = true;
                    player.meleeDamage += 0.05f;
                    player.meleeSpeed += 0.05f;
                }
                if (LaugicalityVars.Mech3Defense.Contains(Class))
                    player.statDefense += 6;

            }
            if (NPC.downedPlantBoss)
            {
                if (LaugicalityVars.PlantBonus.Contains(Class))
                {
                    player.maxMinions++;
                    player.manaRegenBonus += 20;
                }
                if (LaugicalityVars.PlantThorns.Contains(Class))
                    player.thorns += 1f;

            }
            if (NPC.downedGolemBoss)
            {
                if (LaugicalityVars.GolemCrit.Contains(Class))
                {
                    player.thrownCrit += 10;
                    player.rangedCrit += 10;
                    player.magicCrit += 10;
                    player.meleeCrit += 10;
                }
                if (LaugicalityVars.GolemRegen.Contains(Class))
                    player.lifeRegen += 2;

            }
            if (NPC.downedFishron)
            {
                if (LaugicalityVars.FishDouche.Contains(Class))
                {
                    mPlayer.douche = true;
                    player.rangedDamage += 0.08f;
                    player.meleeSpeed += 0.08f;
                }
                if (LaugicalityVars.FishSpeed.Contains(Class))
                    player.jumpSpeedBoost += 4.0f;

                if (LaugicalityVars.FishMDamage.Contains(Class))
                {
                    mPlayer.destructionDamage += 0.05f;
                    mPlayer.conjurationDamage += 0.05f;
                    mPlayer.mysticDuration += 0.1f;
                }
            }
            if (NPC.downedAncientCultist)
            {
                if (LaugicalityVars.CultistDamage1.Contains(Class))
                {
                    player.rangedDamage += 0.08f;
                    player.meleeDamage += 0.08f;
                    mPlayer.mysticDamage += .08f;
                }
                if (LaugicalityVars.CultistDamage2.Contains(Class))
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
                mPlayer.mysticDamage += .1f;
                player.statDefense += 12;
            }
        }



        public override void ModifyTooltips(List<TooltipLine> tooltips)
        {
            var Class = Main.LocalPlayer.GetModPlayer<LaugicalityPlayer>(mod).Class;
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
                if (LaugicalityVars.SlimeThrow.Contains(Class))
                {
                    TooltipLine lineKS1 = new TooltipLine(mod, "", KS1);
                    tooltips.Add(lineKS1);
                }

                if (LaugicalityVars.SlimeJump.Contains(Class))
                {
                    TooltipLine lineKS2 = new TooltipLine(mod, "", KS2);
                    tooltips.Add(lineKS2);
                }

                if (LaugicalityVars.SlimeMinion.Contains(Class))
                {
                    TooltipLine lineKS3 = new TooltipLine(mod, "", KS3);
                    tooltips.Add(lineKS3);
                }

                if (LaugicalityVars.SlimeVelocity.Contains(Class))
                {
                    TooltipLine lineKS4 = new TooltipLine(mod, "", KS4);
                    tooltips.Add(lineKS4);
                }
            }
            if (NPC.downedBoss1)
            {
                if (LaugicalityVars.Boss1Thorns.Contains(Class))
                {
                    TooltipLine lineEoC1 = new TooltipLine(mod, "", EoC1);
                    tooltips.Add(lineEoC1);
                }
                if (LaugicalityVars.Boss1Speed.Contains(Class))
                {
                    TooltipLine lineEoC2 = new TooltipLine(mod, "", EoC2);
                    tooltips.Add(lineEoC2);
                }
                if (LaugicalityVars.Boss1Detect.Contains(Class))
                {
                    TooltipLine lineEoC3 = new TooltipLine(mod, "", EoC3);
                    tooltips.Add(lineEoC3);
                }
                if (LaugicalityVars.Boss1Damage.Contains(Class))
                {
                    TooltipLine lineEoC4 = new TooltipLine(mod, "", EoC4);
                    tooltips.Add(lineEoC4);
                }
            }
            if (NPC.downedBoss2)
            {
                if (LaugicalityVars.Boss2Rage.Contains(Class))
                {
                    TooltipLine lineEoWBoC1 = new TooltipLine(mod, "", EoWBoC1);
                    tooltips.Add(lineEoWBoC1);
                }
                if (LaugicalityVars.Boss2Defence.Contains(Class))
                {
                    TooltipLine lineEoWBoC2 = new TooltipLine(mod, "", EoWBoC2);
                    tooltips.Add(lineEoWBoC2);
                }
                if (LaugicalityVars.Boss2Regen.Contains(Class))
                {
                    TooltipLine lineEoWBoC3 = new TooltipLine(mod, "", EoWBoC3);
                    tooltips.Add(lineEoWBoC3);
                }
                if (LaugicalityVars.Boss2RBonus.Contains(Class))
                {
                    TooltipLine lineEoWBoC4 = new TooltipLine(mod, "", EoWBoC4);
                    tooltips.Add(lineEoWBoC4);
                }
            }
            if (NPC.downedQueenBee)
            {
                if (LaugicalityVars.BeeTrue.Contains(Class))
                {
                    TooltipLine lineQB1 = new TooltipLine(mod, "", QB1);
                    tooltips.Add(lineQB1);
                }
                if (LaugicalityVars.BeeRegen.Contains(Class))
                {
                    TooltipLine lineQB2 = new TooltipLine(mod, "", QB2);
                    tooltips.Add(lineQB2);
                }
                if (LaugicalityVars.BeeMinions.Contains(Class))
                {
                    TooltipLine lineQB3 = new TooltipLine(mod, "", QB3);
                    tooltips.Add(lineQB3);
                }
                if (LaugicalityVars.BeeMDamage.Contains(Class))
                {
                    TooltipLine lineQB4 = new TooltipLine(mod, "", QB4);
                    tooltips.Add(lineQB4);
                }
            }
            if (NPC.downedBoss3)
            {
                if (LaugicalityVars.Boss3Damage.Contains(Class))
                {
                    TooltipLine lineSK1 = new TooltipLine(mod, "", SK1);
                    tooltips.Add(lineSK1);
                }
                if (LaugicalityVars.Boss3Defense.Contains(Class))
                {
                    TooltipLine lineSK2 = new TooltipLine(mod, "", SK2);
                    tooltips.Add(lineSK2);
                }
                if (LaugicalityVars.Boss3Speed.Contains(Class))
                {
                    TooltipLine lineSK3 = new TooltipLine(mod, "", SK3);
                    tooltips.Add(lineSK3);
                }
                if (LaugicalityVars.Boss3Crit.Contains(Class))
                {
                    TooltipLine lineSK4 = new TooltipLine(mod, "", SK4);
                    tooltips.Add(lineSK4);
                }

            }
            if (Main.hardMode)
            {
                if (LaugicalityVars.HardDamage.Contains(Class))
                {
                    TooltipLine lineWoF1 = new TooltipLine(mod, "", WoF1);
                    tooltips.Add(lineWoF1);
                }
                if (LaugicalityVars.HardRegen.Contains(Class))
                {
                    TooltipLine lineWoF2 = new TooltipLine(mod, "", WoF2);
                    tooltips.Add(lineWoF2);
                }
                if (LaugicalityVars.HardMana.Contains(Class))
                {
                    TooltipLine lineWoF3 = new TooltipLine(mod, "", WoF3);
                    tooltips.Add(lineWoF3);
                }
                if (LaugicalityVars.HardObsid.Contains(Class))
                {
                    TooltipLine lineWoF4 = new TooltipLine(mod, "", WoF4);
                    tooltips.Add(lineWoF4);
                }
            }
            if (NPC.downedMechBoss2)
            {
                if (LaugicalityVars.Mech1Crit.Contains(Class))
                
                    {
                        TooltipLine lineTW1 = new TooltipLine(mod, "", TW1);
                        tooltips.Add(lineTW1);
                    }
                if (LaugicalityVars.Mech1Speed.Contains(Class))
                    {
                        TooltipLine lineTW2 = new TooltipLine(mod, "", TW2);
                        tooltips.Add(lineTW2);
                    }
            }
            if (NPC.downedMechBoss1)
            {
                if (LaugicalityVars.Mech2Magic.Contains(Class))
                    {
                        TooltipLine lineDST1 = new TooltipLine(mod, "", DST1);
                        tooltips.Add(lineDST1);
                    }
                if (LaugicalityVars.Mech2Jump.Contains(Class))
                    {
                        TooltipLine lineDST2 = new TooltipLine(mod, "", DST2);
                        tooltips.Add(lineDST2);
                    }
            }
            if (NPC.downedMechBoss3)
            {
                if (LaugicalityVars.Mech3Damage.Contains(Class))
                    {
                        TooltipLine lineSP1 = new TooltipLine(mod, "", SP1);
                        tooltips.Add(lineSP1);
                    }
                if (LaugicalityVars.Mech3Defense.Contains(Class))
                    {
                        TooltipLine lineSP2 = new TooltipLine(mod, "", SP2);
                        tooltips.Add(lineSP2);
                    }
            }
            if (NPC.downedPlantBoss)
            {
                if (LaugicalityVars.PlantBonus.Contains(Class))
                {
                    TooltipLine linePT1 = new TooltipLine(mod, "", PT1);
                    tooltips.Add(linePT1);
                }
                if (LaugicalityVars.PlantThorns.Contains(Class))
                {
                    TooltipLine linePT2 = new TooltipLine(mod, "", PT2);
                    tooltips.Add(linePT2);
                }
            }
            if (NPC.downedGolemBoss)
            {
                if (LaugicalityVars.GolemCrit.Contains(Class))
                {
                    TooltipLine lineGL1 = new TooltipLine(mod, "", GL1);
                    tooltips.Add(lineGL1);
                }
                if (LaugicalityVars.GolemRegen.Contains(Class))
                {
                    TooltipLine lineGL2 = new TooltipLine(mod, "", GL2);
                    tooltips.Add(lineGL2);
                }
            }
            if (NPC.downedFishron)
            {
                if (LaugicalityVars.FishDouche.Contains(Class))
                {
                    TooltipLine lineDF1 = new TooltipLine(mod, "", DF1);
                    tooltips.Add(lineDF1);
                }
                if (LaugicalityVars.FishSpeed.Contains(Class))
                {
                    TooltipLine lineDF2 = new TooltipLine(mod, "", DF2);
                    tooltips.Add(lineDF2);
                }
                if (LaugicalityVars.FishMDamage.Contains(Class))
                {
                    TooltipLine lineDF3 = new TooltipLine(mod, "", DF3);
                    tooltips.Add(lineDF3);
                }
            }
            if (NPC.downedAncientCultist)
            {
                if (LaugicalityVars.CultistDamage1.Contains(Class))
                {
                    TooltipLine lineLC1 = new TooltipLine(mod, "", LC1);
                    tooltips.Add(lineLC1);
                }
                if (LaugicalityVars.CultistDamage2.Contains(Class))
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