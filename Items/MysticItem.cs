using System;
using System.Collections.Generic;
using System.Linq;
using Laugicality.Buffs.Mystic;
using Laugicality.Projectiles.Mystic.Conjuration;
using Laugicality.Projectiles.Mystic.Overflow;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;

namespace Laugicality.Items
{
    public abstract class MysticItem : LaugicalityItem
    {
        public abstract void Destruction(LaugicalityPlayer modPlayer);

        public abstract void Illusion(LaugicalityPlayer modPlayer);

        public abstract void Conjuration(LaugicalityPlayer modPlayer);

        public abstract void SetMysticDefaults();

        public sealed override void SetDefaults()
        {
            Hold = 0;
            item.melee = false;
            item.ranged = false;
            item.magic = false;
            item.thrown = false;
            item.summon = false;
            item.crit = 4;
            LuxCost = 10;
            VisCost = 10;
            MundusCost = 10;
            item.GetGlobalItem<LaugicalityGlobalItem>().Mystic = true;
            SetMysticDefaults();
        }

        public override void ModifyTooltips(List<TooltipLine> tooltips)
        {
            TooltipLine tt = tooltips.FirstOrDefault(x => x.Name == "Damage" && x.mod == "Terraria");
            int index = tooltips.FindIndex(x => x.Name == "Damage" && x.mod == "Terraria");
            if (tt != null)
            {
                
                string[] split = tt.text.Split(' ');
                
                tt.text = split.First() + " mystic " + split.Last();
            }
            if (Hold > 0)
                Hold--;

            TooltipLine tt2 = new TooltipLine(mod, "PlayerMysticChanneling", GetMysticType());
            TooltipLine tt3 = new TooltipLine(mod, "PlayerMysticChanneling", GetMysticaType());
            TooltipLine tt4 = new TooltipLine(mod, "PlayerMysticChanneling", GetExtraTooltip());

            tooltips.Insert(++index, tt2);
            tooltips.Insert(++index, tt3);
            if(GetExtraTooltip() != "")
                tooltips.Insert(++index, tt4);
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
                    //return ModContent.PrefixType("Chaotic");
                    if (pref != "")
                        return ModContent.PrefixType(pref);
                    else
                        return -1;
                }
                return -1;
            }

            /*
            if (item.accessory || item.damage > 0 && item.maxStack == 1 && rand.NextBool(30))
            {
                return ModContent.PrefixType(rand.Next(2) == 0 ? "Awesome" : "ReallyAwesome");
            }

            return -1;
        }

        public override void GetWeaponDamage(Player player, ref int damage)
        {
            LaugicalityPlayer modPlayer = LaugicalityPlayer.Get(player);
            float damageMult = 1f;
            damageMult = modPlayer.MysticDamage + (player.allDamage - 1);

            switch (modPlayer.MysticMode)
            {
                case 1:
                    damage = (int)(damage * modPlayer.DestructionDamage);
                    if (modPlayer.Lux > modPlayer.LuxMax + modPlayer.LuxMaxPermaBoost)
                        damage = (int)(damage * modPlayer.OverflowDamage);
                    else
                        damage = (int)(damage * modPlayer.AntiflowDamage);
                    break;
                case 2:
                    damage = (int)(damage * modPlayer.IllusionDamage);
                    if (modPlayer.Vis > modPlayer.VisMax + modPlayer.VisMaxPermaBoost)
                        damage = (int)(damage * modPlayer.OverflowDamage);
                    else
                        damage = (int)(damage * modPlayer.AntiflowDamage);
                    break;
                case 3:
                    damage = (int)(damage * modPlayer.ConjurationDamage);
                    if (modPlayer.Mundus > modPlayer.MundusMax + modPlayer.MundusMaxPermaBoost)
                        damage = (int)(damage * modPlayer.OverflowDamage);
                    else
                        damage = (int)(damage * modPlayer.AntiflowDamage);
                    break;
            }

            if (modPlayer.MysticBurstDisabled)
                damage = (int)(damage * 1.05f);

            modPlayer.MysticHold = 2;
        }*/

        public override void ModifyWeaponDamage(Player player, ref float add, ref float mult, ref float flat)
        {
            LaugicalityPlayer modPlayer = LaugicalityPlayer.Get(player);
            mult += modPlayer.MysticDamage - 1;

            switch (modPlayer.MysticMode)
            {
                case 1:
                    mult += modPlayer.DestructionDamage - 1;
                    if (modPlayer.Lux > modPlayer.LuxMax + modPlayer.LuxMaxPermaBoost)
                        mult += modPlayer.OverflowDamage - 1;
                    else
                        mult += modPlayer.AntiflowDamage - 1;
                    break;
                case 2:
                    mult += modPlayer.IllusionDamage - 1;
                    if (modPlayer.Vis > modPlayer.VisMax + modPlayer.VisMaxPermaBoost)
                        mult += modPlayer.OverflowDamage - 1;
                    else
                        mult += modPlayer.AntiflowDamage - 1;
                    break;
                case 3:
                    mult += modPlayer.ConjurationDamage - 1;
                    if (modPlayer.Mundus > modPlayer.MundusMax + modPlayer.MundusMaxPermaBoost)
                        mult += modPlayer.OverflowDamage - 1;
                    else
                        mult += modPlayer.AntiflowDamage - 1;
                    break;
            }

            if (modPlayer.MysticBurstDisabled)
                mult += .05f;

            modPlayer.MysticHold = 2;
        }

        public override void UpdateInventory(Player player)
        {
            GetCosts();
            base.UpdateInventory(player);
        }

        private void GetCosts()
        {

            LaugicalityPlayer modPlayer = LaugicalityPlayer.Get();

            switch (modPlayer.MysticMode)
            {
                case 1:
                    Destruction(modPlayer);
                    break;
                case 2:
                    Illusion(modPlayer);
                    break;
                case 3:
                    Conjuration(modPlayer);
                    break;
            }
        }

        public override void HoldItem(Player player)
        {

            LaugicalityPlayer modPlayer = LaugicalityPlayer.Get(player);

            switch (modPlayer.MysticMode)
            {
                case 1:
                    player.AddBuff(ModContent.BuffType<Destruction>(), 1, true);
                    break;
                case 2:
                    player.AddBuff(ModContent.BuffType<Illusion>(), 1, true);
                    break;
                case 3:
                    player.AddBuff(ModContent.BuffType<Conjuration>(), 1, true);
                    break;
            }

            GetCosts();

            Hold = 2;
            modPlayer.CurrentLuxCost = LuxCost;
            modPlayer.CurrentVisCost = VisCost;
            modPlayer.CurrentMundusCost = MundusCost;

            Laugicality.MysticaUI.Update();
        }

        private string GetMysticType()
        {
            LaugicalityPlayer laugicalityPlayer = LaugicalityPlayer.Get();

            switch (laugicalityPlayer.MysticMode)
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

        private string GetMysticaType()
        {
            LaugicalityPlayer laugicalityPlayer = LaugicalityPlayer.Get();

            switch (laugicalityPlayer.MysticMode)
            {
                case 1:
                    return "Uses " + (GetLuxCost() * laugicalityPlayer.LuxUseRate * laugicalityPlayer.GlobalPotentiaUseRate) + " lux";
                case 2:
                    return "Uses " + (GetVisCost() * laugicalityPlayer.VisUseRate * laugicalityPlayer.GlobalPotentiaUseRate) + " vis";
                case 3:
                    return "Uses " + (GetMundusCost() * laugicalityPlayer.MundusUseRate * laugicalityPlayer.GlobalPotentiaUseRate) + " mundus";
            }

            return "mystica";
        }

        /*public override bool CanUseItem(Player player)
        {
            LaugicalityPlayer modPlayer = LaugicalityPlayer.Get(player);
            switch (modPlayer.MysticMode)
            {
                case 1:
                    return modPlayer.Lux > luxCost;
                case 2:
                    return modPlayer.Vis > visCost;
                case 3:
                    return modPlayer.Mundus > mundusCost;
            }
            return true;
        }*/
        
        public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
        {
            LaugicalityPlayer modPlayer = LaugicalityPlayer.Get(player);

            ModifyMysticShoot(player, ref position, ref speedX, ref speedY, ref type, ref damage, ref knockBack);
            GetMysticShots(player, ref position, ref speedX, ref speedY, ref type, ref damage, ref knockBack);
            switch (modPlayer.MysticMode)
            {
                case 1:
                    if (modPlayer.Lux >= LuxCost * modPlayer.LuxUseRate * modPlayer.GlobalPotentiaUseRate)
                    {
                        modPlayer.Lux -= LuxCost * modPlayer.LuxUseRate * modPlayer.GlobalPotentiaUseRate;
                        if (modPlayer.Lux < 0)
                            modPlayer.Lux = 0;
                        if (modPlayer.Lux > (modPlayer.LuxMax + modPlayer.LuxMaxPermaBoost) * modPlayer.LuxOverflow * modPlayer.GlobalOverflow)
                            modPlayer.Lux = (modPlayer.LuxMax + modPlayer.LuxMaxPermaBoost) * modPlayer.LuxOverflow * modPlayer.GlobalOverflow;
                        modPlayer.Vis += LuxCost * modPlayer.GlobalAbsorbRate * modPlayer.VisAbsorbRate * modPlayer.LuxDischargeRate * modPlayer.LuxUseRate * modPlayer.GlobalPotentiaUseRate;
                        if (modPlayer.Vis > (modPlayer.VisMax + modPlayer.VisMaxPermaBoost) * modPlayer.VisOverflow * modPlayer.GlobalOverflow)
                            modPlayer.Vis = (modPlayer.VisMax + modPlayer.VisMaxPermaBoost) * modPlayer.VisOverflow * modPlayer.GlobalOverflow;
                        modPlayer.Mundus += LuxCost * modPlayer.GlobalAbsorbRate * modPlayer.MundusAbsorbRate * modPlayer.LuxDischargeRate * modPlayer.LuxUseRate * modPlayer.GlobalPotentiaUseRate;
                        if (modPlayer.Mundus > (modPlayer.MundusMax + modPlayer.MundusMaxPermaBoost) * modPlayer.MundusOverflow * modPlayer.GlobalOverflow)
                            modPlayer.Mundus = (modPlayer.MundusMax + modPlayer.MundusMaxPermaBoost) * modPlayer.MundusOverflow * modPlayer.GlobalOverflow;
                    }
                    else
                        return false;
                    break;
                case 2:
                    if (modPlayer.Vis >= VisCost * modPlayer.VisUseRate * modPlayer.GlobalPotentiaUseRate)
                    {
                        modPlayer.Vis -= VisCost * modPlayer.VisUseRate * modPlayer.GlobalPotentiaUseRate;
                        if (modPlayer.Vis < 0)
                            modPlayer.Vis = 0;
                        modPlayer.Lux += VisCost * modPlayer.GlobalAbsorbRate * modPlayer.LuxAbsorbRate * modPlayer.VisDischargeRate * modPlayer.VisUseRate * modPlayer.GlobalPotentiaUseRate;
                        if (modPlayer.Lux > (modPlayer.LuxMax + modPlayer.LuxMaxPermaBoost) * modPlayer.LuxOverflow * modPlayer.GlobalOverflow)
                            modPlayer.Lux = (modPlayer.LuxMax + modPlayer.LuxMaxPermaBoost) * modPlayer.LuxOverflow * modPlayer.GlobalOverflow;
                        if (modPlayer.Vis > (modPlayer.VisMax + modPlayer.VisMaxPermaBoost) * modPlayer.VisOverflow * modPlayer.GlobalOverflow)
                            modPlayer.Vis = (modPlayer.VisMax + modPlayer.VisMaxPermaBoost) * modPlayer.VisOverflow * modPlayer.GlobalOverflow;
                        modPlayer.Mundus += VisCost * modPlayer.GlobalAbsorbRate * modPlayer.MundusAbsorbRate * modPlayer.VisDischargeRate * modPlayer.VisUseRate * modPlayer.GlobalPotentiaUseRate;
                        if (modPlayer.Mundus > (modPlayer.MundusMax + modPlayer.MundusMaxPermaBoost) * modPlayer.MundusOverflow * modPlayer.GlobalOverflow)
                            modPlayer.Mundus = (modPlayer.MundusMax + modPlayer.MundusMaxPermaBoost) * modPlayer.MundusOverflow * modPlayer.GlobalOverflow;
                    }
                    else
                        return false;
                    break;
                case 3:
                    if (modPlayer.Mundus >= MundusCost * modPlayer.MundusUseRate * modPlayer.GlobalPotentiaUseRate)
                    {
                        modPlayer.Mundus -= MundusCost * modPlayer.MundusUseRate * modPlayer.GlobalPotentiaUseRate;
                        if (modPlayer.Mundus < 0)
                            modPlayer.Mundus = 0;
                        modPlayer.Lux += MundusCost * modPlayer.GlobalAbsorbRate * modPlayer.LuxAbsorbRate * modPlayer.MundusDischargeRate * modPlayer.MundusUseRate * modPlayer.GlobalPotentiaUseRate;
                        if (modPlayer.Lux > (modPlayer.LuxMax + modPlayer.LuxMaxPermaBoost) * modPlayer.LuxOverflow * modPlayer.GlobalOverflow)
                            modPlayer.Lux = (modPlayer.LuxMax + modPlayer.LuxMaxPermaBoost) * modPlayer.LuxOverflow * modPlayer.GlobalOverflow;
                        modPlayer.Vis += MundusCost * modPlayer.GlobalAbsorbRate * modPlayer.VisAbsorbRate * modPlayer.MundusDischargeRate * modPlayer.MundusUseRate * modPlayer.GlobalPotentiaUseRate;
                        if (modPlayer.Vis > (modPlayer.VisMax + modPlayer.VisMaxPermaBoost) * modPlayer.VisOverflow * modPlayer.GlobalOverflow)
                            modPlayer.Vis = (modPlayer.VisMax + modPlayer.VisMaxPermaBoost) * modPlayer.VisOverflow * modPlayer.GlobalOverflow;
                        if (modPlayer.Mundus > (modPlayer.MundusMax + modPlayer.MundusMaxPermaBoost) * modPlayer.MundusOverflow * modPlayer.GlobalOverflow)
                            modPlayer.Mundus = (modPlayer.MundusMax + modPlayer.MundusMaxPermaBoost) * modPlayer.MundusOverflow * modPlayer.GlobalOverflow;
                    }
                    else
                        return false;
                    break;
            }
            return MysticShoot(player, ref position, ref speedX, ref speedY, ref type, ref damage, ref knockBack);
        }

        private void ModifyMysticShoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
        {
            LaugicalityPlayer modPlayer = LaugicalityPlayer.Get(player);
            if(modPlayer.IsOnOverflow())
            {
                speedX *= modPlayer.OverflowVelocity;
                speedY *= modPlayer.OverflowVelocity;
            }
        }

        private void GetMysticShots(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
        {
            LaugicalityPlayer modPlayer = LaugicalityPlayer.Get(player);
            if (modPlayer.Crystillium && modPlayer.IsOnOverflow())
                Projectile.NewProjectile(position, new Vector2(speedX / 16f, speedY / 16f), ModContent.ProjectileType<CrystilliumShard>(), damage, knockBack, player.whoAmI);
            if (modPlayer.OverflowFire && modPlayer.IsOnOverflow())
                Projectile.NewProjectile(position, new Vector2(speedX, speedY), ModContent.ProjectileType<OverflowThermalite>(), (int)(damage / 1.2f), knockBack, player.whoAmI);
            if (modPlayer.ShroomOverflow > 0 && modPlayer.IsOnOverflow())
                Projectile.NewProjectile(new Vector2(player.Center.X, player.position.Y), new Vector2(0, -10f), ModContent.ProjectileType<FreyaConjuration2>(), damage, 3, player.whoAmI);
        }

        public virtual bool MysticShoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
        {
            return true;
        }

        public virtual string GetExtraTooltip()
        {
            return "";
        }

        private int GetLuxCost()
        {
            Destruction(LaugicalityPlayer.Get());
            return LuxCost;
        }

        private int GetVisCost()
        {
            Illusion(LaugicalityPlayer.Get());
            return VisCost;
        }

        private int GetMundusCost()
        {
            Conjuration(LaugicalityPlayer.Get());
            return MundusCost;
        }

        public int LuxCost { get; set; } = 10;

        public int MundusCost { get; set; } = 10;

        public int VisCost { get; set; } = 10;

        public int Hold { get; private set; }
    }
}