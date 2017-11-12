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
        public bool frost = false;
        public bool frigid = false;
        public bool rocks = false;
        public bool sandy = false;

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
        public bool bRage = false;
        public bool qB = false;
        public bool eyes = false;
        public bool spores = false;

        //Soul Stone
        public int Class = 0;
        public bool SoulStoneV = true;
        public bool SoulStoneM = true;

        //Mystic vars
        public float mysticDamage = 1f;
        public float mysticDuration = 1f;
        public int mysticMode = 1; //1 = Destruction, 2 = Illusion, 3 = Conjuration

        public float illusionDamage = 1f;
        public float destructionDamage = 1f;
        public float conjurationDamage = 1f;
        public int illusionPower = 1;
        public int destructionPower = 1;
        public int conjurationPower = 1;

        public bool etherial = false;
        public int etherialTrail = 0;
        public bool etherable = false;
        public int ethBkg = 0;
        public bool etherialSlot = false;
        public bool etherVision = false;

        public bool ZoneObsidium = false;

        public override void ResetEffects()
        {
            etherVision = false;
            etherable = false;
            rocks = false;
            sandy = false;
            frost = false;
            obsidium = false;
            frigid = false;
            mCore = false;
            sShark = false;
            skp = false;
            douche = false;
            tV = false;
            eFied = false;
            meFied = false;
            mFied = false;
            toyTrain = false;
            bRage = false;
            qB = false;
            eyes = false;
            spores = false;

            //Mystic
            mysticCrit = 4;
            mysticDamage = 1f;
            mysticDuration = 1f;

            illusionDamage = 1f;
            destructionDamage = 1f;
            conjurationDamage = 1f;
            illusionPower = 1;
            destructionPower = 1;
            conjurationPower = 1;


            if (player.extraAccessory)
            {
                player.extraAccessorySlots = 1;
                if (etherialSlot)
                {
                    player.extraAccessorySlots = 2;
                }
            }
            else if (etherialSlot)
            {
                player.extraAccessorySlots = 2;
            }

            if (!player.extraAccessory && !etherialSlot)
            {
                player.extraAccessorySlots = 0;
            }
        }

        public override TagCompound Save()
        {
            return new TagCompound {
                {"Class", Class },
                {"Etherial", etherial },
                {"ESlot", etherialSlot }
            };
        }

        public override void UpdateBiomeVisuals()
        {
            bool useNebula = NPC.AnyNPCs(mod.NPCType("EtherialBkg"));
            player.ManageSpecialBiomeVisuals("Laugicality:Etherial", useNebula);
        }

        public override void Load(TagCompound tag)
        {
            Class = tag.GetInt("Class");
            etherial = tag.GetBool("Etherial");
            etherialSlot = tag.GetBool("ESlot");
        }


        public override void UpdateBiomes()
        {
            ZoneObsidium = (LaugicalityWorld.obsidiumTiles > 250);
        }


        public override bool CustomBiomesMatch(Player other)
        {
            LaugicalityPlayer modOther = other.GetModPlayer<LaugicalityPlayer>(mod);
            return ZoneObsidium == modOther.ZoneObsidium;
        }

        public override void CopyCustomBiomesTo(Player other)
        {
            LaugicalityPlayer modOther = other.GetModPlayer<LaugicalityPlayer>(mod);
            modOther.ZoneObsidium = ZoneObsidium;
        }

        public override void SendCustomBiomes(BinaryWriter writer)
        {
            BitsByte flags = new BitsByte();
            flags[0] = ZoneObsidium;
            writer.Write(flags);
        }

        public override void ReceiveCustomBiomes(BinaryReader reader)
        {
            BitsByte flags = reader.ReadByte();
            ZoneObsidium = flags[0];
        }

        public override Texture2D GetMapBackgroundImage()
        {
            if (ZoneObsidium)
            {
                return mod.GetTexture("ObsidiumBiomeMapBackground");
            }
            return null;
        }
        

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
                target.AddBuff(24, (int)((120 + 60 * rand)*mysticDuration), false);
            }
            if (frost)
            {
                target.AddBuff(BuffID.Frostburn, (int)((120 + 60 * rand) * mysticDuration), false);
            }
            if (skp)
            {
                target.AddBuff(39, (int)((120 + 60 * rand) * mysticDuration), false);
            }
            if (douche)
            {
                target.AddBuff(70, (int)((120 + 60 * rand) * mysticDuration), false);
            }
            if (qB)
            {
                target.AddBuff(20, (int)((120 + 60 * rand) * mysticDuration), false);
            }
            if (meFied)
            {
                target.AddBuff(mod.BuffType("Electrified"), (int)((120 + 60 * rand) * mysticDuration), false);
            }
        }
        public bool etherialCheck()
        {
            return etherial;
        }


        public override void PreUpdate()
        {
            etherial = LaugicalityWorld.etherial;
        }

        public override void DrawEffects(PlayerDrawInfo drawInfo, ref float r, ref float g, ref float b, ref float a, ref bool fullBright)
        {

            if (etherialTrail > 0)
            {
                etherialTrail -= 1;
                if(Main.rand.Next(0,4) == 0)
                    Dust.NewDust(player.position + player.velocity, player.width, player.height, mod.DustType("Etherial"), 0f, 0f);
            }
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
            if (etherial)
            {
                r = 0.2f;
                g = 0.9f;
                b = 1f;

                if(ethBkg <= 0)
                {
                    ethBkg = 9;
                    NPC.NewNPC((int)player.position.X, (int)player.position.Y, mod.NPCType("EtherialBkg"));
                }
                else
                {
                    ethBkg -= 1;
                }
            }
        }
        //Hotkey
        public override void ProcessTriggers(TriggersSet triggersSet)
        {
            if (Laugicality.ToggleMystic.JustPressed)
            {
                mysticMode += 1;
                if (mysticMode > 3) mysticMode = 1;
            }
            if (Laugicality.ToggleSoulStoneV.JustPressed)
            {
                SoulStoneV = !SoulStoneV;
            }
            if (Laugicality.ToggleSoulStoneM.JustPressed)
            {
                SoulStoneM = !SoulStoneM;
            }
            if (Laugicality.ToggleEtherial.JustPressed && etherable)
            {
                Dust.NewDust(player.position + player.velocity, player.width, player.height, mod.DustType("Etherial"), 0f, 0f);
                Dust.NewDust(player.position + player.velocity, player.width, player.height, mod.DustType("Etherial"), 0f, 0f);
                Dust.NewDust(player.position + player.velocity, player.width, player.height, mod.DustType("Etherial"), 0f, 0f);
                Dust.NewDust(player.position + player.velocity, player.width, player.height, mod.DustType("Etherial"), 0f, 0f);
                Dust.NewDust(player.position + player.velocity, player.width, player.height, mod.DustType("Etherial"), 0f, 0f);
                Dust.NewDust(player.position + player.velocity, player.width, player.height, mod.DustType("Etherial"), 0f, 0f);
                Dust.NewDust(player.position + player.velocity, player.width, player.height, mod.DustType("Etherial"), 0f, 0f);
                Dust.NewDust(player.position + player.velocity, player.width, player.height, mod.DustType("Etherial"), 0f, 0f);
                Dust.NewDust(player.position + player.velocity, player.width, player.height, mod.DustType("Etherial"), 0f, 0f);
                if(LaugicalityWorld.etherial)
                    LaugicalityWorld.etherial = false;
                else
                    LaugicalityWorld.etherial = true;

                etherialTrail = 45;
                Main.PlaySound(SoundLoader.customSoundType, -1, -1, mod.GetSoundSlot(SoundType.Custom, "Sounds/EtherialChange"));
            }
        }
        /*
        public override void OnHitByNPC(NPC npc, int damage, bool crit)
        {
        }*/

        public override void PostHurt(bool pvp, bool quiet, double damage, int hitDirection, bool crit)
        {
            if (bRage)
            {
                player.AddBuff(mod.BuffType("BloodRage"), 420);
                Projectile.NewProjectile(player.Center.X, player.Center.Y, 6 - Main.rand.Next(12), 0, 565, 16, 3f, player.whoAmI);
                Projectile.NewProjectile(player.Center.X, player.Center.Y, 6 - Main.rand.Next(12), 0, 565, 16, 3f, player.whoAmI);
            }
            if (eyes)
            {
                Projectile.NewProjectile(player.Center.X, player.Center.Y, 6 -  Main.rand.Next(12), 6 - Main.rand.Next(12), mod.ProjectileType("MiniEye"), 16, 3f, player.whoAmI);
                Projectile.NewProjectile(player.Center.X, player.Center.Y, 6 -  Main.rand.Next(12), 6 - Main.rand.Next(12), mod.ProjectileType("MiniEye"), 16, 3f, player.whoAmI);
                Projectile.NewProjectile(player.Center.X, player.Center.Y, 6 -  Main.rand.Next(12), 6 - Main.rand.Next(12), mod.ProjectileType("MiniEye"), 16, 3f, player.whoAmI);
                Projectile.NewProjectile(player.Center.X, player.Center.Y, 6 -  Main.rand.Next(12), 6 - Main.rand.Next(12), mod.ProjectileType("MiniEye"), 16, 3f, player.whoAmI);
                if (Main.rand.Next(0, 2) == 0) Projectile.NewProjectile(player.Center.X, player.Center.Y, 6 -  Main.rand.Next(12), 6 - Main.rand.Next(12), mod.ProjectileType("MiniEye"), 16, 3f, player.whoAmI);
                if (Main.rand.Next(0, 2) == 0) Projectile.NewProjectile(player.Center.X, player.Center.Y, 6 -  Main.rand.Next(12), 6 - Main.rand.Next(12), mod.ProjectileType("MiniEye"), 16, 3f, player.whoAmI);
            }

            if (sandy)
            {
                Projectile.NewProjectile(player.Center.X, player.Center.Y, 4, 4, mod.ProjectileType("Sandball"), 18, 5, Main.myPlayer);
                Projectile.NewProjectile(player.Center.X, player.Center.Y, 4, -4, mod.ProjectileType("Sandball"), 18, 5, Main.myPlayer);
                Projectile.NewProjectile(player.Center.X, player.Center.Y, -4, -4, mod.ProjectileType("Sandball"), 18, 5, Main.myPlayer);
                Projectile.NewProjectile(player.Center.X, player.Center.Y, -4, 4, mod.ProjectileType("Sandball"), 18, 5, Main.myPlayer);
            }

            if (frigid)
            {
                Projectile.NewProjectile(player.Center.X, player.Center.Y, 6 - Main.rand.Next(12), 6 - Main.rand.Next(12), mod.ProjectileType("IceShardF"), 16, 3f, player.whoAmI);
                Projectile.NewProjectile(player.Center.X, player.Center.Y, 6 - Main.rand.Next(12), 6 - Main.rand.Next(12), mod.ProjectileType("IceShardF"), 16, 3f, player.whoAmI);
            }

            if (spores)
            {
                Projectile.NewProjectile(player.Center.X, player.Center.Y, 6 -  Main.rand.Next(12), 6 - Main.rand.Next(12), 567, 48, 3f, player.whoAmI);
                Projectile.NewProjectile(player.Center.X, player.Center.Y, 6 -  Main.rand.Next(12), 6 - Main.rand.Next(12), 568, 48, 3f, player.whoAmI);
                Projectile.NewProjectile(player.Center.X, player.Center.Y, 6 -  Main.rand.Next(12), 6 - Main.rand.Next(12), 569, 48, 3f, player.whoAmI);
                Projectile.NewProjectile(player.Center.X, player.Center.Y, 6 -  Main.rand.Next(12), 6 - Main.rand.Next(12), 570, 48, 3f, player.whoAmI);
                if (Main.rand.Next(0, 2) == 0) Projectile.NewProjectile(player.Center.X, player.Center.Y, 6 -  Main.rand.Next(12), 6 - Main.rand.Next(12), 571, 48, 3f, player.whoAmI); 
                if (Main.rand.Next(0, 2) == 0) Projectile.NewProjectile(player.Center.X, player.Center.Y, 6 -  Main.rand.Next(12), 6 - Main.rand.Next(12), 567, 48, 3f, player.whoAmI);
            }

            if (rocks)
            {
                Projectile.NewProjectile(player.Center.X, player.Center.Y, 8, 0, mod.ProjectileType("RockShard"), 20, 3, Main.myPlayer);
                Projectile.NewProjectile(player.Center.X, player.Center.Y, -8, 0, mod.ProjectileType("RockShard"), 20, 3, Main.myPlayer);
                Projectile.NewProjectile(player.Center.X, player.Center.Y, 0, 8, mod.ProjectileType("RockShard"), 20, 3, Main.myPlayer);
                Projectile.NewProjectile(player.Center.X, player.Center.Y, -8 + Main.rand.Next(0, 17), -8 + Main.rand.Next(0, 17), mod.ProjectileType("RockShard"), 20, 3, Main.myPlayer);
                Projectile.NewProjectile(player.Center.X, player.Center.Y, -8 + Main.rand.Next(0, 17), -8 + Main.rand.Next(0, 17), mod.ProjectileType("RockShard"), 20, 3, Main.myPlayer);
                Projectile.NewProjectile(player.Center.X, player.Center.Y, -8 + Main.rand.Next(0, 17), -8 + Main.rand.Next(0, 17), mod.ProjectileType("RockShard"), 20, 3, Main.myPlayer);
                Projectile.NewProjectile(player.Center.X, player.Center.Y, -8 + Main.rand.Next(0, 17), -8 + Main.rand.Next(0, 17), mod.ProjectileType("RockShard"), 20, 3, Main.myPlayer);
                Projectile.NewProjectile(player.Center.X, player.Center.Y, -8 + Main.rand.Next(0, 17), -8 + Main.rand.Next(0, 17), mod.ProjectileType("RockShard"), 20, 3, Main.myPlayer);
            }

        }

    }
}
       
