using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;

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
        public int luxCost = 10;
        public int mundusCost = 10;
        public int visCost = 10;
        int hold = 0;

        public abstract void Destruction(LaugicalityPlayer modPlayer);
        public abstract void Illusion(LaugicalityPlayer modPlayer);
        public abstract void Conjuration(LaugicalityPlayer modPlayer);

        public abstract void SetMysticDefaults();

        public sealed override void SetDefaults()
        {
            hold = 0;
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
            luxCost = 10;
            visCost = 10;
            mundusCost = 10;
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
            if (hold > 0)
                hold--;
            TooltipLine tt2 = new TooltipLine(mod, "PlayerMysticChanneling", getMysticType());
            TooltipLine tt3 = new TooltipLine(mod, "PlayerMysticChanneling", getMysticaType());
            tooltips.Insert(index + 1, tt2);
            tooltips.Insert(index + 2, tt3);
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
            globalDmg = player.meleeDamage;
            if(player.rangedDamage < globalDmg)
                globalDmg = player.rangedDamage;
            if (player.magicDamage < globalDmg)
                globalDmg = player.magicDamage;
            if (player.thrownDamage < globalDmg)
                globalDmg = player.thrownDamage;
            if (player.minionDamage < globalDmg)
                globalDmg = player.minionDamage;
            if (globalDmg > 1)
                damage = (int)(originalDmg * globalDmg);
            switch (modPlayer.mysticMode)
            {
                case 1:
                    damage = (int)(damage * modPlayer.destructionDamage);
                    if (modPlayer.lux > modPlayer.luxMax + modPlayer.luxMaxPermaBoost)
                        damage = (int)(damage * modPlayer.overflowDamage);
                    break;
                case 2:
                    damage = (int)(damage * modPlayer.illusionDamage);
                    if (modPlayer.vis > modPlayer.visMax + modPlayer.visMaxPermaBoost)
                        damage = (int)(damage * modPlayer.overflowDamage);
                    break;
                case 3:
                    damage = (int)(damage * modPlayer.conjurationDamage);
                    if (modPlayer.mundus > modPlayer.mundusMax + modPlayer.mundusMaxPermaBoost)
                        damage = (int)(damage * modPlayer.overflowDamage);
                    break;
            }
            if (modPlayer.mysticBurstDisabled)
                damage = (int)(damage * 1.05f);
            modPlayer.mysticHold = 2;
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
            modPlayer.currentLuxCost = luxCost;
            modPlayer.currentVisCost = visCost;
            modPlayer.currentMundusCost = mundusCost;
            hold = 2;
            Laugicality.instance.mysticaUI.Update();
        }

        private string getMysticType()
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
            return "mystic";
        }

        private string getMysticaType()
        {
            LaugicalityPlayer modPlayer = Main.LocalPlayer.GetModPlayer<LaugicalityPlayer>(mod);
            switch (modPlayer.mysticMode)
            {
                case 1:
                    return "Uses " + (modPlayer.currentLuxCost * modPlayer.luxUseRate * modPlayer.globalPotentiaUseRate).ToString() + " lux";
                case 2:
                    return "Uses " + (modPlayer.currentVisCost * modPlayer.visUseRate * modPlayer.globalPotentiaUseRate).ToString() + " vis";
                case 3:
                    return "Uses " + (modPlayer.currentMundusCost * modPlayer.mundusUseRate * modPlayer.globalPotentiaUseRate).ToString() + " mundus";
            }
            return "mystica";
        }

        /*public override bool CanUseItem(Player player)
        {
            LaugicalityPlayer modPlayer = player.GetModPlayer<LaugicalityPlayer>(mod);
            switch (modPlayer.mysticMode)
            {
                case 1:
                    return modPlayer.lux > luxCost;
                case 2:
                    return modPlayer.vis > visCost;
                case 3:
                    return modPlayer.mundus > mundusCost;
            }
            return true;
        }*/
        
        public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
        {
            LaugicalityPlayer modPlayer = player.GetModPlayer<LaugicalityPlayer>(mod);
            switch (modPlayer.mysticMode)
            {
                case 1:
                    if (modPlayer.lux > luxCost * modPlayer.luxUseRate * modPlayer.globalPotentiaUseRate)
                    {
                        modPlayer.lux -= luxCost * modPlayer.luxUseRate * modPlayer.globalPotentiaUseRate;
                        if (modPlayer.lux < 0)
                            modPlayer.lux = 0;
                        if (modPlayer.lux > (modPlayer.luxMax + modPlayer.luxMaxPermaBoost) * modPlayer.luxOverflow * modPlayer.globalOverflow)
                            modPlayer.lux = (modPlayer.luxMax + modPlayer.luxMaxPermaBoost) * modPlayer.luxOverflow * modPlayer.globalOverflow;
                        modPlayer.vis += luxCost * modPlayer.globalAbsorbRate * modPlayer.visAbsorbRate * modPlayer.luxDischargeRate * modPlayer.luxUseRate * modPlayer.globalPotentiaUseRate;
                        if (modPlayer.vis > (modPlayer.visMax + modPlayer.visMaxPermaBoost) * modPlayer.visOverflow * modPlayer.globalOverflow)
                            modPlayer.vis = (modPlayer.visMax + modPlayer.visMaxPermaBoost) * modPlayer.visOverflow * modPlayer.globalOverflow;
                        modPlayer.mundus += luxCost * modPlayer.globalAbsorbRate * modPlayer.mundusAbsorbRate * modPlayer.luxDischargeRate * modPlayer.luxUseRate * modPlayer.globalPotentiaUseRate;
                        if (modPlayer.mundus > (modPlayer.mundusMax + modPlayer.mundusMaxPermaBoost) * modPlayer.mundusOverflow * modPlayer.globalOverflow)
                            modPlayer.mundus = (modPlayer.mundusMax + modPlayer.mundusMaxPermaBoost) * modPlayer.mundusOverflow * modPlayer.globalOverflow;
                    }
                    else
                        return false;
                    break;
                case 2:
                    if (modPlayer.vis > visCost * modPlayer.visUseRate * modPlayer.globalPotentiaUseRate)
                    {
                        modPlayer.vis -= visCost * modPlayer.visUseRate * modPlayer.globalPotentiaUseRate;
                        if (modPlayer.vis < 0)
                            modPlayer.vis = 0;
                        modPlayer.lux += visCost * modPlayer.globalAbsorbRate * modPlayer.luxAbsorbRate * modPlayer.visDischargeRate * modPlayer.visUseRate * modPlayer.globalPotentiaUseRate;
                        if (modPlayer.lux > (modPlayer.luxMax + modPlayer.luxMaxPermaBoost) * modPlayer.luxOverflow * modPlayer.globalOverflow)
                            modPlayer.lux = (modPlayer.luxMax + modPlayer.luxMaxPermaBoost) * modPlayer.luxOverflow * modPlayer.globalOverflow;
                        if (modPlayer.vis > (modPlayer.visMax + modPlayer.visMaxPermaBoost) * modPlayer.visOverflow * modPlayer.globalOverflow)
                            modPlayer.vis = (modPlayer.visMax + modPlayer.visMaxPermaBoost) * modPlayer.visOverflow * modPlayer.globalOverflow;
                        modPlayer.mundus += visCost * modPlayer.globalAbsorbRate * modPlayer.mundusAbsorbRate * modPlayer.visDischargeRate * modPlayer.visUseRate * modPlayer.globalPotentiaUseRate;
                        if (modPlayer.mundus > (modPlayer.mundusMax + modPlayer.mundusMaxPermaBoost) * modPlayer.mundusOverflow * modPlayer.globalOverflow)
                            modPlayer.mundus = (modPlayer.mundusMax + modPlayer.mundusMaxPermaBoost) * modPlayer.mundusOverflow * modPlayer.globalOverflow;
                    }
                    else
                        return false;
                    break;
                case 3:
                    if (modPlayer.mundus > mundusCost * modPlayer.mundusUseRate * modPlayer.globalPotentiaUseRate)
                    {
                        modPlayer.mundus -= mundusCost * modPlayer.mundusUseRate * modPlayer.globalPotentiaUseRate;
                        if (modPlayer.mundus < 0)
                            modPlayer.mundus = 0;
                        modPlayer.lux += mundusCost * modPlayer.globalAbsorbRate * modPlayer.luxAbsorbRate * modPlayer.mundusDischargeRate * modPlayer.mundusUseRate * modPlayer.globalPotentiaUseRate;
                        if (modPlayer.lux > (modPlayer.luxMax + modPlayer.luxMaxPermaBoost) * modPlayer.luxOverflow * modPlayer.globalOverflow)
                            modPlayer.lux = (modPlayer.luxMax + modPlayer.luxMaxPermaBoost) * modPlayer.luxOverflow * modPlayer.globalOverflow;
                        modPlayer.vis += mundusCost * modPlayer.globalAbsorbRate * modPlayer.visAbsorbRate * modPlayer.mundusDischargeRate * modPlayer.mundusUseRate * modPlayer.globalPotentiaUseRate;
                        if (modPlayer.vis > (modPlayer.visMax + modPlayer.visMaxPermaBoost) * modPlayer.visOverflow * modPlayer.globalOverflow)
                            modPlayer.vis = (modPlayer.visMax + modPlayer.visMaxPermaBoost) * modPlayer.visOverflow * modPlayer.globalOverflow;
                        if (modPlayer.mundus > (modPlayer.mundusMax + modPlayer.mundusMaxPermaBoost) * modPlayer.mundusOverflow * modPlayer.globalOverflow)
                            modPlayer.mundus = (modPlayer.mundusMax + modPlayer.mundusMaxPermaBoost) * modPlayer.mundusOverflow * modPlayer.globalOverflow;
                    }
                    else
                        return false;
                    break;
            }
            return MysticShoot(player, ref position, ref speedX, ref speedY, ref type, ref damage, ref knockBack);
        }

        public virtual bool MysticShoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
        {
            return true;
        }

    }
}