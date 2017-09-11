using System;
using System.Collections.Generic;
using System.IO;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.ModLoader.IO;
using Terraria.GameContent;
using Terraria.GameContent.UI;
using Terraria.GameInput;
using Terraria.Graphics.Capture;
using Terraria.Graphics.Effects;
using Terraria.Graphics.Shaders;
using Laugicality.Items.Accessories;

namespace Laugicality
{
    public class LaugicalityPlayer : ModPlayer
    {
        public const int maxBuffs = 42;
        public bool obsidium = false;
        //Summons
        public bool mCore = false;
        public bool tV = false;
        public bool sShark = false;


        public bool skp = false;
        public bool douche = false;
        public int mysticCrit = 4;
        public bool eFied = false; //Electrified Debuff
        public bool meFied = false;
        public bool mFied = false; //Mystified Debuff
        public bool toyTrain = false; //Toy Train Pet

        //Mystic vars
        public float mysticDamage = 1f;
        public float mysticDuration = 1f;
        public int mysticMode = 1; //1 = Destruction, 2 = Illusion, 3 = Conjuration

        public float illusiomDamage = 1f;
        public float destructionDamage = 1f;
        public float conjurationDamage = 1f;
        public float illusiomPower = 1f;
        public float destructionPower = 1f;
        public float conjurationPower = 1f;


        public override void ResetEffects()
        {
            obsidium = false;
            mCore = false;
            sShark = false;
            skp = false;
            douche = false;
            tV = false;
            eFied = false;
            meFied = false;
            mFied = false;
            toyTrain = false;

            //Mystic
            mysticCrit = 4;
            mysticDamage = 1f;
            mysticDuration = 1f;

            illusiomDamage = 1f;
            destructionDamage = 1f;
            conjurationDamage = 1f;
            illusiomPower = 1f;
            destructionPower = 1f;
            conjurationPower = 1f;
    }

        public override TagCompound Save()
        {
            return new TagCompound {
                {"EoC", Items.Accessories.SoulStone.EoC },
                {"King", Items.Accessories.SoulStone.EoC },
                {"EoWBoC", Items.Accessories.SoulStone.EoWBoC },
                { "KS", Items.Accessories.SoulStone.KS},
            {"EoW", Items.Accessories.SoulStone.EoW},
            {"BoC", Items.Accessories.SoulStone.BoC},
            {"QB", Items.Accessories.SoulStone.QB},
            {"QBalt", Items.Accessories.SoulStone.QBalt},
            {"QBa", Items.Accessories.SoulStone.QBa},
            {"QBb", Items.Accessories.SoulStone.QBb},
            {"SK", Items.Accessories.SoulStone.SK},
            {"SKalt", Items.Accessories.SoulStone.SKalt},
            {"SKa", Items.Accessories.SoulStone.SKa},
            {"SKb", Items.Accessories.SoulStone.SKb},
            {"SKc", Items.Accessories.SoulStone.SKc},
            {"SKd", Items.Accessories.SoulStone.SKd},
            {"SKe", Items.Accessories.SoulStone.SKe},
            {"SKg", Items.Accessories.SoulStone.SKg},
            {"SKh", Items.Accessories.SoulStone.SKh},
            {"WoF", Items.Accessories.SoulStone.WoF},
            {"WoFalt", Items.Accessories.SoulStone.WoFalt},
            {"WoFa", Items.Accessories.SoulStone.WoFa},
            {"WoFb", Items.Accessories.SoulStone.WoFb},
            {"SP", Items.Accessories.SoulStone.SP}, //Spas
            {"RT", Items.Accessories.SoulStone.RT}, //Ret
            {"SKP", Items.Accessories.SoulStone.SKP},
            {"DST", Items.Accessories.SoulStone.DST},
            {"PT", Items.Accessories.SoulStone.PT},
            {"PTalt", Items.Accessories.SoulStone.PTalt},
            {"PTa", Items.Accessories.SoulStone.PTa},
            {"PTb", Items.Accessories.SoulStone.PTb},
            {"GM", Items.Accessories.SoulStone.GM},
            {"LC", Items.Accessories.SoulStone.LC},
            {"LCalt", Items.Accessories.SoulStone.LCalt},
            {"LCa", Items.Accessories.SoulStone.LCa},
            {"LCb", Items.Accessories.SoulStone.LCb},
            {"DF", Items.Accessories.SoulStone.DF},
            {"ML", Items.Accessories.SoulStone.ML}
        };
    }

        public override void Load(TagCompound tag)
        {
            Items.Accessories.SoulStone.EoC = tag.GetInt("EoC");
            Items.Accessories.SoulStone.King = tag.GetInt("EoC");
            Items.Accessories.SoulStone.KS = tag.GetInt("EoC");
            Items.Accessories.SoulStone.EoWBoC = tag.GetInt("EoWBoC");
            Items.Accessories.SoulStone.EoW = tag.GetInt("EoW");
            Items.Accessories.SoulStone.BoC = tag.GetInt("BoC");
            Items.Accessories.SoulStone.QB = tag.GetInt("QB");
            Items.Accessories.SoulStone.QBalt = tag.GetInt("QBalt");
            Items.Accessories.SoulStone.QBa = tag.GetInt("QBa");
            Items.Accessories.SoulStone.QBb = tag.GetInt("QBb");
            Items.Accessories.SoulStone.SK = tag.GetInt("SK");
            Items.Accessories.SoulStone.SKalt = tag.GetInt("SKalt");
            Items.Accessories.SoulStone.SKa = tag.GetInt("SKa");
            Items.Accessories.SoulStone.SKb = tag.GetInt("SKb");
            Items.Accessories.SoulStone.SKc = tag.GetInt("SKc");
            Items.Accessories.SoulStone.SKd = tag.GetInt("SKd");
            Items.Accessories.SoulStone.SKe = tag.GetInt("SKe");
            Items.Accessories.SoulStone.SKg = tag.GetInt("SKg");
            Items.Accessories.SoulStone.SKh = tag.GetInt("SKh");
            Items.Accessories.SoulStone.WoF = tag.GetInt("WoF");
            Items.Accessories.SoulStone.WoFalt = tag.GetInt("WoFalt");
            Items.Accessories.SoulStone.WoFa = tag.GetInt("WoFa");
            Items.Accessories.SoulStone.WoFb = tag.GetInt("WoFb");
            Items.Accessories.SoulStone.SP = tag.GetInt("SP"); //Spas
            Items.Accessories.SoulStone.RT = tag.GetInt("RT"); //Ret
            Items.Accessories.SoulStone.SKP = tag.GetInt("SKP");
            Items.Accessories.SoulStone.DST = tag.GetInt("DST");
            Items.Accessories.SoulStone.PT = tag.GetInt("PT");
            Items.Accessories.SoulStone.PTalt = tag.GetInt("PTalt");
            Items.Accessories.SoulStone.PTa = tag.GetInt("PTa");
            Items.Accessories.SoulStone.PTb = tag.GetInt("PTb");
            Items.Accessories.SoulStone.GM = tag.GetInt("GM");
            Items.Accessories.SoulStone.LC = tag.GetInt("LC");
            Items.Accessories.SoulStone.LCalt = tag.GetInt("LCalt");
            Items.Accessories.SoulStone.LCa = tag.GetInt("LCa");
            Items.Accessories.SoulStone.LCb = tag.GetInt("LCb");
            Items.Accessories.SoulStone.DF = tag.GetInt("DF");
            Items.Accessories.SoulStone.ML = tag.GetInt("ML");
        }

       

        /*
        public override int GetWeaponDamage(Item sItem)
        {
            bool flag23 = false;
            bool critTry = false;
            int mCrit = this.inventory[this.selectedItem].crit; +this.mysticCrit;
            Random mCritChance = new Random();
            int mCritTry = mCritChance.Next(1,100);
            if (mCritTry < mCrit) {
                critTry = true;
                bool flag23 = true;
            }
            
            int num = sItem.damage;
            if (critTry == true) num *= 2;
            if (num > 0)
            {
                if (sItem.mystic)
                {
                    num = (int)((float)num * this.mysticDamage + 5E-06f);
                }
            }
            return num;
        }*/

        public override void UpdateDead()
        {
            eFied = false;
        }

        public override void UpdateBadLifeRegen()
        {
            if (eFied)//Electrified
            {
                if (player.lifeRegen > 0)
                {
                    player.lifeRegen = 0;
                }
                player.lifeRegenTime = 0;
                player.lifeRegen -= 16;
            }
            if (mFied)//Mystified
            {
                if (player.lifeRegen > 0)
                {
                    player.lifeRegen = 0;
                }
                player.lifeRegenTime = 0;
                player.lifeRegen -= 4;
            }
        }
        public override void OnHitNPC(Item item, NPC target, int damage, float knockback, bool crit)
        {
            int rand = Main.rand.Next(4);
            if (obsidium)
            {
                target.AddBuff(24, 120 + 60 * rand, false);
            }
            if (skp)
            {
                target.AddBuff(39, 120 + 60 * rand, false);
            }
            if (douche)
            {
                target.AddBuff(70, 120 + 60 * rand, false);
            }
            if (meFied)
            {
                target.AddBuff(mod.BuffType("Electrified"), 120 + 60 * rand, false);
            }
        }


        public override void DrawEffects(PlayerDrawInfo drawInfo, ref float r, ref float g, ref float b, ref float a, ref bool fullBright)
        {
            if (eFied)
            {
                if (Main.rand.Next(4) == 0 && drawInfo.shadow == 0f)
                {
                    int dust = Dust.NewDust(drawInfo.position - new Vector2(2f, 2f), player.width + 4, player.height + 4, mod.DustType("Lightning"), player.velocity.X * 0.4f, player.velocity.Y * 0.4f, 100, default(Color), 3f);
                    Main.dust[dust].noGravity = false;
                    Main.dust[dust].velocity *= 1.8f;
                    Main.dust[dust].velocity.Y -= 0.5f;
                    Main.playerDrawDust.Add(dust);
                }
                r *= 0.1f;
                g *= 0.8f;
                b *= 0.8f;
                fullBright = true;
            }
        }

    }
       
}