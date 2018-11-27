using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;
using Laugicality.Items;
using Laugicality.Items.Weapons.Mystic;
using Terraria.Utilities;


namespace Laugicality
{
    public abstract class MysticItem : ModItem
    {
        private static readonly string MYSTIC_DAMAGE_PREFIX = "mystic";

        // make-safe
        public bool mystic = true;
        public static float destruction = 0f;
        public static float illusion = 0f;
        public static float conjuration = 0f;
        public static float destructionMultiplier = 1f;
        public static float conjurationMultiplier = 1f;
        public static float illusionMultiplier = 1f;

        public abstract void Destruction(LaugicalityPlayer modPlayer);
        public abstract void Illusion(LaugicalityPlayer modPlayer);
        public abstract void Conjuration(LaugicalityPlayer modPlayer);

        public abstract void SetMysticDefaults();

        public sealed override void SetDefaults()
        {
            item.melee = false;
            item.ranged = false;
            item.magic = false;
            item.thrown = false;
            item.summon = false;
            item.crit = 4;
            destruction = 0f;
            illusion = 0f;
            conjuration = 0f;
            destructionMultiplier = 1f;
            illusionMultiplier = 1f;
            conjurationMultiplier = 1f;
            SetMysticDefaults();
        }

        public override void ModifyTooltips(List<TooltipLine> tooltips)
        {
            var tt = tooltips.FirstOrDefault(x => x.Name == "Damage" && x.mod == "Terraria");
            int index = tooltips.FindIndex(x => x.Name == "Damage" && x.mod == "Terraria");
            if (tt != null)
            {
                
                string[] split = tt.text.Split(' ');
                
                tt.text = split.First() + " mystic " + split.Last();
            }

            TooltipLine tt2 = new TooltipLine(mod, "PlayerMysticChanneling", getMysticType());
            tooltips.Insert(index + 1, tt2);
            /*if (!item.social && item.prefix > 0)
            {
                if (destruction == 1f)
                {
                    TooltipLine line = new TooltipLine(mod, "Chaotic", "[c/63CA89:+5% Destruction Damage]");
                    //line.isModifier = true;
                    tooltips.Add(line);
                }
                if (destruction == 2f)
                {
                    TooltipLine line = new TooltipLine(mod, "Riotus", "c/63CA89:+10% Destruction Damage");
                    //line.isModifier = true;
                    tooltips.Add(line);
                }
                if (destruction == 3f)
                {
                    TooltipLine line = new TooltipLine(mod, "Anarchic", "c/63CA89:+12% Destruction Damage\n+1 Destruction Power");
                    //line.isModifier = true;
                    tooltips.Add(line);
                }
            }*/
        }
       
        /*
        public string ChooseMysticPrefix()
        {
            /* 50%: Destruction/Illusion/Conjuration
             * 25%: Cool Utility effects (Mystic Duration, various Mystic Burst effects)
             * 15%: Negative
             * 10%: Awesome Effects
             * 
            int pref = Main.rand.Next(100);
            if (pref < 51)//Destruction/Illusion/Conjuration
            {
                /*0-23 = level 1
                 * 24-41 = level 2
                 * 42-50 = level 3
                 * 
                if (pref < 8)//D1
                    return "Chaotic";
                if (pref < 16)//I1
                    return "Deceptive";
                if (pref < 24)//C1
                    return "Stable";
                if (pref < 30)//D2
                    return "Riotus";
                if (pref < 36)//I2
                    return "Illusive";
                if (pref < 42)//C2
                    return "Ordered";
                if (pref < 45)//D3
                    return "Anarchic";
                if (pref < 48)//I3
                    return "Manipulative";
                if (pref < 51)//C3
                    return "Authoritus";
            }
            else if (pref < 75)//Cool Utility effects (Mystic Duration, various Mystic Burst effects)
            {

            }
            else if (pref < 90)//Negative
            {

            }
            else//Awesome Effects
            {

            }
            return "";
        }

        public override int ChoosePrefix(UnifiedRandom rand)
        {
            if (this.mystic)
            {
                if (Main.rand.Next(10) != 9)
                {
                    string pref = ChooseMysticPrefix();
                    //return mod.PrefixType("Chaotic");
                    if (pref != "")
                        return mod.PrefixType(pref);
                    else
                        return -1;
                }
                return -1;
            }

            /*
            if (item.accessory || item.damage > 0 && item.maxStack == 1 && rand.NextBool(30))
            {
                return mod.PrefixType(rand.Next(2) == 0 ? "Awesome" : "ReallyAwesome");
            }

            return -1;
        }*/

        

        public override void GetWeaponDamage(Player player, ref int damage)
        {
            LaugicalityPlayer modPlayer = player.GetModPlayer<LaugicalityPlayer>(mod);
            int originalDmg = damage;
            damage = (int)(damage * modPlayer.mysticDamage);
            float globalDmg = 1;
            globalDmg = player.meleeDamage - 1;
            if(player.rangedDamage - 1 < globalDmg)
                globalDmg = player.rangedDamage - 1;
            if (player.magicDamage - 1 < globalDmg)
                globalDmg = player.magicDamage - 1;
            if (player.thrownDamage - 1 < globalDmg)
                globalDmg = player.thrownDamage - 1;
            if (player.minionDamage - 1 < globalDmg)
                globalDmg = player.minionDamage - 1;
            if (globalDmg > 0)
                damage = damage + (int)(originalDmg * globalDmg);
            modPlayer.mysticHold = true;

        }

        public override void HoldItem(Player player)
        {
            LaugicalityPlayer modPlayer = player.GetModPlayer<LaugicalityPlayer>(mod);
            switch (modPlayer.mysticMode)
            {
                case 1 :
                    player.AddBuff(mod.BuffType("Destruction"), 1, true);
                    Destruction(modPlayer);
                    break;
                case 2:
                    player.AddBuff(mod.BuffType("Illusion"), 1, true);
                    Illusion(modPlayer);
                    break;
                case 3:
                    player.AddBuff(mod.BuffType("Conjuration"), 1, true);
                    Conjuration(modPlayer);
                    break;
            }
        }

        private string getMysticType()
        {
            if (Main.netMode != 1)
            {
                LaugicalityPlayer modPlayer = Main.LocalPlayer.GetModPlayer<LaugicalityPlayer>(mod);
                switch (modPlayer.mysticMode)
                {
                    case 1:
                        return "[c/F1C40F:- Destruction -]";
                    case 2:
                        return "[c/8E44AD:- Illusion -]";
                    case 3:
                        return "[c/28B463:- Conjuration -]";
                }
            }

            return "mystic";
        }
    }
}