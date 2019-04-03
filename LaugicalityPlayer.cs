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
using Laugicality.NPCs;
using Laugicality.Items.Placeable;

namespace Laugicality
{
    public partial class LaugicalityPlayer : ModPlayer
    {
        //Buffs
        public const int maxBuffs = 42;
        public bool obsidium = false;
        public bool frost = false;
        public bool frigid = false;
        public bool frosty = false;
        public bool rocks = false;
        public bool sandy = false;
        public bool truecurse = false;
        public bool noRegen = false;
        public bool halfDef = false;
        public int connected = 0;
        public int verdi = 0;

        //Summons
        public bool mCore = false;
        public bool tV = false;
        public bool sShark = false;
        public bool dCopter = false;
        public bool rTwins = false;
        public bool sCopter = false;
        public bool uBois = false; //Ultimate Leader
        public bool arcticHydra = false;

        //Soul Stone
        public int Class = 0;
        public bool SoulStoneV = true;
        public bool SoulStoneM = true;

        public bool skp = false;
        public bool douche = false;
        public bool eFied = false;
        public bool meFied = false;
        public bool mFied = false; //Mystified Debuff
        public bool toyTrain = false; //Toy Train Pet
        public bool bRage = false;
        public bool qB = false;
        public bool eyes = false;
        public bool spores = false;
        public bool slimey = false;

        //Potion Gems
        public bool inf = true;
        public bool calm = true;
        public bool ww = true;
        public bool battle = true;
        public bool hunter = true;
        public bool spelunker = true;
        public bool owl = true;
        public bool danger = true;
        public bool feather = true;

        //Steam vars
        public float steamDamage = 1f;

        //Etherial
        public bool etherial = false;
        public int etherialTrail = 0;
        public int ethBkg = 0;
        public bool etherialSlot = false;

        //Misc
        public bool zImmune = false;
        public bool zCool = false;
        public int zaWarudoDuration = 0;
        public float xTemp = 0;
        public float yTemp = 0;
        public bool zProjImmune = false;
        public int zCoolDown = 1800;
        public float theta = 0f;
        public bool obsHeart = false;
        public bool crysMag = false;
        public bool frostbite = false;
        public int fullBysmal = 0;
        bool boosted = false;
        float ringBoost = 0;
        float fanBoost = 0;

        //Music
        public bool ZoneObsidium = false;
        public bool etherialMusic = false;

        //Camera Effects
        public int shakeDur = 0;
        public float shakeMag = 0f;
        public Vector2 shakeO;
        public bool shakeReset = false;

        public override void SetupStartInventory(IList<Item> items)
        {
            mysticBurstDisabled = false;
            inf = true;
            calm = true;
            ww = true;
            battle = true;
            hunter = true;
            spelunker = true;
            owl = true;
            danger = true;
            feather = true;
            int[] bysmalItems = { 0, 0, 0 };
        }

        /// <summary>
        /// Challenge : Refactor This to be short and without having it look disgusting
        /// </summary>
        public override void ResetEffects()
        {
            MysticReset();
            if (fullBysmal > 0)
                fullBysmal -= 1; 
            if (shakeDur > 0)
            {
                shakeDur--;
                shakeReset = false;
            }
            else
            {
                shakeMag = 0;
                if (shakeReset == true)
                    shakeO = player.position;
                else
                {
                    player.position = shakeO;
                    shakeReset = true;
                }
            }
            if (verdi > 0)
                verdi -= 1;
            slimey = false;
            magmatic = false;
            crysMag = false;
            theta += 3.14f / 40f;
            uBois = false;
            obsHeart = false;
            zCoolDown = 65 * 60;
            zaWarudoDuration = 4 * 60;
            midnight = false;
            andioChestplate = false;
            andioChestguard = false;
            sCopter = false;
            zProjImmune = false;
            rTwins = false;
            connected = 0;
            halfDef = false;
            noRegen = false;
            truecurse = false;
            zImmune = false;
            zCool = false;
            etherialMusic = false;
            rocks = false;
            sandy = false;
            frost = false;
            obsidium = false;
            frosty = false;
            frigid = false;
            mCore = false;
            sShark = false;
            skp = false;
            douche = false;
            tV = false;
            dCopter = false;
            eFied = false;
            meFied = false;
            mFied = false;
            toyTrain = false;
            bRage = false;
            qB = false;
            eyes = false;
            spores = false;
            frostbite = false;
            arcticHydra = false;

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
            ResetEtherial();

        }

        public override void CatchFish(Item fishingRod, Item bait, int power, int liquidType, int poolSize, int worldLayer, int questFish, ref int caughtType, ref bool junk)
        {
            if (junk)
            {
                caughtType = ItemID.Obsidian;
                return;
            }
            if (ZoneObsidium && liquidType == 1 && bait.type == mod.ItemType("LavaGem") && fishingRod.type == ItemID.HotlineFishingHook)
            {
                if (Main.rand.Next(3) == 0)
                {
                    int rand = Main.rand.Next(6);
                    switch (rand)
                    {
                        case 0:
                            caughtType = ItemID.Topaz;
                            break;
                        case 1:
                            caughtType = ItemID.Amethyst;
                            break;
                        case 2:
                            caughtType = ItemID.Sapphire;
                            break;
                        case 3:
                            caughtType = ItemID.Emerald;
                            break;
                        case 4:
                            caughtType = ItemID.Ruby;
                            break;
                        default:
                            caughtType = ItemID.Diamond;
                            break;
                    }
                }
                if (NPC.downedBoss2)
                {
                    if(Main.rand.Next(3) == 0)
                        caughtType = mod.ItemType("ObsidiumOre");
                    if (Main.rand.Next(4) == 0)
                        caughtType = mod.ItemType("ObsidiumBar");
                }
                if (LaugicalityWorld.downedRagnar)
                {
                    if (Main.rand.Next(5) == 0)
                        caughtType = mod.ItemType("MagmaSnapper");
                    else if (Main.rand.Next(4) == 0)
                        caughtType = mod.ItemType("ObsidiumChunk");
                }
                if (Main.rand.Next(5) == 0)
                    caughtType = ItemID.Obsidian;
                if (Main.rand.Next(25) == 0)
                {
                    int rand = Main.rand.Next(6);
                    switch (rand)
                    {
                        case 0:
                            caughtType = ItemID.LavaCharm;
                            break;
                        case 1:
                            caughtType = mod.ItemType("ObsidiumLily");
                            break;
                        case 2:
                            caughtType = mod.ItemType("FireDust");
                            break;
                        case 3:
                            caughtType = mod.ItemType("Eruption");
                            break;
                        case 4:
                            caughtType = mod.ItemType("CrystalizedMagma");
                            break;
                        default:
                            caughtType = mod.ItemType("MagmaHeart");
                            break;
                    }
                }
            }
        }

        public override void PreUpdate()
        {
            etherial = LaugicalityWorld.downedEtheria;

            Random random = new Random();
            if (shakeDur > 0)
            {
                shakeMag += 1f / 5f;
                player.position.X = shakeO.X - shakeMag + (float)random.NextDouble() * shakeMag * 2;
                player.position.Y = shakeO.Y - shakeMag + (float)random.NextDouble() * shakeMag * 2;
            }

            CheckBysmalPowers();
            PreAccessories();
            if (LaugicalityWorld.downedEtheria || etherable > 0)
                GetEtherialAccessories();
        }
        
        private void PreAccessories()
        {

        }

        public override void PostUpdate()
        {
            PostUpdateZaWarudo();
            PostUpdateMysticBursts();
            PostUpdateMysticBuffs();
            PostUpdateMovementTileChecks();
        }

        private void PostUpdateZaWarudo()
        {
            if (Laugicality.zawarudo > 0 && zImmune == false)
            {
                player.velocity.X = 0;
                player.velocity.Y = 0;
                player.AddBuff(mod.BuffType("TrueCurse"), 1, true);
                if (xTemp == 0 || yTemp == 0)
                {
                    xTemp = player.position.X;
                    yTemp = player.position.Y;
                }
                else
                {
                    player.position.X = xTemp;
                    player.position.Y = yTemp;
                }
            }
            else if (frosty)
            {
                if (xTemp == 0 || yTemp == 0)
                {
                    xTemp = player.position.X;
                    yTemp = player.position.Y;
                }
                else
                {
                    player.position.X = xTemp;
                    player.position.Y = yTemp;
                }
            }
            else
            {
                xTemp = 0;
                yTemp = 0;
            }
        }
        

        private void PostAccessories()
        {
            if (verdi > 0)
            {
                player.maxRunSpeed += .1f;
            }
        }

        private void PostUpdateMysticBursts()
        {
            if (mysticErupting > 0)
            {
                if (Main.rand.Next(4) == 0)
                {
                    Projectile.NewProjectile(player.Center.X, player.Center.Y, player.velocity.X - 4 + Main.rand.Next(9), -Main.rand.Next(6, 9), mod.ProjectileType("Eruption"), (int)(30 * mysticDamage * mysticBurstDamage), 3, Main.myPlayer);
                }
            }
            if (mysticSpiralBurst > 0)
            {
                mysticSpiralDelay++;
                if (mysticSpiralDelay > 2)
                {
                    mysticSpiralDelay = 0;
                    Projectile.NewProjectile(player.Center.X, player.Center.Y, 4 * (float)Math.Cos(theta * 2), 4 * (float)Math.Sin(theta * 2), mod.ProjectileType("AnDioChestguardBurst"), (int)(32 * mysticDamage * mysticBurstDamage), 3, Main.myPlayer);
                }
            }
            if (mysticSteamSpiralBurst > 0)
            {
                mysticSteamSpiralDelay++;
                if (mysticSteamSpiralDelay > 5)
                {
                    mysticSteamSpiralDelay = 0;
                    Projectile.NewProjectile(player.Center.X, player.Center.Y, 6 * (float)Math.Cos(theta), 6 * (float)Math.Sin(theta), mod.ProjectileType("SteamBurst"), (int)(40 * mysticDamage * mysticBurstDamage), 3, Main.myPlayer);
                    Projectile.NewProjectile(player.Center.X, player.Center.Y, 6 * (float)Math.Cos(theta + 3.14f), 6 * (float)Math.Sin(theta + 3.14f), mod.ProjectileType("SteamBurst"), (int)(40 * mysticDamage * mysticBurstDamage), 3, Main.myPlayer);
                }
            }
        }

        private void PostUpdateMovementTileChecks()
        {
            CheckVENT();
            CheckRING();
            CheckFAN();
            CheckFANRight();
        }

        private void CheckVENT()
        {
            if (Main.tile[(int)(player.Center.X / 16), (int)(player.Center.Y / 16)].type == mod.TileType("SteamVENT"))
            {
                if(player.velocity.Y >= 0)
                    Main.PlaySound(SoundLoader.customSoundType, -1, -1, mod.GetSoundSlot(SoundType.Custom, "Sounds/BrassFAN"));
                player.velocity.Y = -25;
            }
        }

        private void CheckRING()
        {
            float vSpeed = player.velocity.Y;
            float minVSpeed = 10;
            float maxVSpeed = 50;
            if (Main.tile[(int)(player.Center.X / 16), (int)(player.Center.Y / 16)].type == mod.TileType("BrassRING") && vSpeed < 0)
            {
                if (ringBoost == 0 && Math.Abs(player.velocity.Y) > 1)
                {
                    if (vSpeed > -minVSpeed)
                        player.velocity.Y = -minVSpeed;
                    ringBoost = player.velocity.Y * 2f;
                    Main.PlaySound(SoundLoader.customSoundType, -1, -1, mod.GetSoundSlot(SoundType.Custom, "Sounds/BrassRING"));
                    if (ringBoost < -maxVSpeed)
                        ringBoost = -maxVSpeed;
                }
                if (Math.Abs(ringBoost) > 1)
                    player.velocity.Y = ringBoost;
            }
            else
                ringBoost = 0;
        }

        private void CheckFAN()
        {
            float hSpeed = player.velocity.X;
            float minHSpeed = 10;
            float maxHSpeed = 50;
            if (Main.tile[(int)(player.Center.X / 16), (int)(player.Center.Y / 16)].type == mod.TileType("BrassFAN"))
            {
                if (fanBoost == 0)
                {
                    if (hSpeed > -minHSpeed)
                        player.velocity.X = -minHSpeed;
                    fanBoost = player.velocity.X * 2f;
                    Main.PlaySound(SoundLoader.customSoundType, -1, -1, mod.GetSoundSlot(SoundType.Custom, "Sounds/BrassFAN"));
                    if (fanBoost < -maxHSpeed)
                        fanBoost = -maxHSpeed;
                }
                if (Math.Abs(fanBoost) > 1)
                    player.velocity.X = fanBoost;
            }
            else
                fanBoost = 0;
        }
        
        private void CheckFANRight()
        {
            float hSpeed = player.velocity.X;
            float minHSpeed = 10;
            float maxHSpeed = 50;
            if (Main.tile[(int)(player.Center.X / 16), (int)(player.Center.Y / 16)].type == mod.TileType("BrassFANRight"))
            {
                if (fanBoost == 0)
                {
                    if (hSpeed < minHSpeed)
                        player.velocity.X = minHSpeed;
                    fanBoost = player.velocity.X * 2f;
                    Main.PlaySound(SoundLoader.customSoundType, -1, -1, mod.GetSoundSlot(SoundType.Custom, "Sounds/BrassFAN"));
                    if (fanBoost > maxHSpeed)
                        fanBoost = maxHSpeed;
                }
                if (Math.Abs(fanBoost) > 1)
                    player.velocity.X = fanBoost;
            }
            else
                fanBoost = 0;
        }

        /*
        private void CheckRepCore()
        {
            if (Main.tile[(int)(player.Center.X / 16 + player.velocity.X / 16), (int)(player.Center.Y / 16)].type == mod.TileType("RepulsionCore") && Math.Abs(player.velocity.X) > 4)
            {
                player.velocity.X = -player.velocity.X;
            }
            if (Main.tile[(int)(player.Center.X / 16), (int)(player.Center.Y / 16 + player.velocity.Y / 16)].type == mod.TileType("RepulsionCore") && Math.Abs(player.velocity.Y) > 4)
            {
                player.velocity.Y = -player.velocity.Y;
            }
        }*/

        public override void PostUpdateEquips()
        {
            CheckBysmalPowers();
            PostAccessories();
            if (verdi > 0)
            {
                player.maxRunSpeed *= 1.1f;
            }
            if (LaugicalityWorld.downedEtheria || etherable > 0)
                GetEtherialAccessoriesPost();
        }

        public override TagCompound Save()
        {
            return new TagCompound {
                {"Class", Class },
                {"Etherial", etherial },
                {"ESlot", etherialSlot },
                {"SoulStoneMove", SoulStoneM },
                {"SoulStoneVis", SoulStoneV },
                {"Inferno", inf},
                {"Calming", calm},
                {"WaterWalking", ww},
                {"Battle", battle},
                {"Hunter", hunter},
                {"Spelunker", spelunker},
                {"NightOwl", owl},
                {"Dangersense", danger},
                {"Featherfall", feather},
                {"BysmalPowers", bysmalPowers},
                {"LuxMaxPermaBoost", luxMaxPermaBoost},
                {"VisMaxPermaBoost", visMaxPermaBoost},
                {"MundusMaxPermaBoost", mundusMaxPermaBoost},
                {"MysticBurstDisabled", mysticBurstDisabled},
            };
        }

        public override void UpdateBiomeVisuals()
        {
            player.ManageSpecialBiomeVisuals("Laugicality:Etherial", LaugicalityWorld.downedEtheria);
            player.ManageSpecialBiomeVisuals("Laugicality:Etherial2", !Main.dayTime && LaugicalityWorld.downedEtheria);
            bool useWorld = false;
            if (Laugicality.zawarudo > 0)
                useWorld = true;
            player.ManageSpecialBiomeVisuals("Laugicality:ZaWarudo", useWorld);
        }

        public override void Load(TagCompound tag)
        {
            Class = tag.GetInt("Class");
            etherial = tag.GetBool("Etherial");
            etherialSlot = tag.GetBool("ESlot");
            SoulStoneM = tag.GetBool("SoulStoneMove");
            SoulStoneV = tag.GetBool("SoulStoneVis");
            inf = tag.GetBool("Inferno");
            calm = tag.GetBool("Calming");
            ww = tag.GetBool("WaterWalking");
            battle = tag.GetBool("Battle");
            hunter = tag.GetBool("Hunter");
            spelunker = tag.GetBool("Spelunker");
            owl = tag.GetBool("NightOwl");
            danger = tag.GetBool("Dangersense");
            feather = tag.GetBool("Featherfall");
            luxMaxPermaBoost = tag.GetFloat("LuxMaxPermaBoost");
            visMaxPermaBoost = tag.GetFloat("VisMaxPermaBoost");
            mundusMaxPermaBoost = tag.GetFloat("MundusMaxPermaBoost");
            mysticBurstDisabled = tag.GetBool("MysticBurstDisabled");
            bysmalPowers = (List<int>)tag.GetList<int>("BysmalPowers");
        }
        
        public override void UpdateBiomes()
        {
            ZoneObsidium = (LaugicalityWorld.obsidiumTiles > 150 && player.position.Y > WorldGen.rockLayer + 150);
            etherialMusic = etherial;
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

        /// <summary>
        /// Refactor This to be short
        /// </summary>
        public override void UpdateBadLifeRegen()
        {
            
            //Main.NewText(mysticDuration.ToString(), 250, 250, 0);
            if (halfDef)
            {
                player.statDefense /= 2;
            }
            if (noRegen)
            {
                if (player.lifeRegen > 0)
                {
                    player.lifeRegen = 0;
                }
                player.lifeRegenTime = 0;
                player.lifeRegen = -1;
            }
            if (eFied)
            {
                if (player.lifeRegen > 0)
                {
                    player.lifeRegen = 0;
                }
                player.lifeRegenTime = 0;
                player.lifeRegen -= 16;
            }
            if (frostbite)
            {
                if (player.lifeRegen > 0)
                {
                    player.lifeRegen = 0;
                }
                player.lifeRegenTime = 0;
                player.lifeRegen -= 32;
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


        public override bool PreItemCheck()
        {
            if (truecurse)
                return false;
            return true;
        }

        /// <summary>
        /// Refactor This to be short
        /// </summary>
        public override void OnHitNPC(Item item, NPC target, int damage, float knockback, bool crit)
        {
            int rand = Main.rand.Next(4);
            if (obsidium)
            {
                target.AddBuff(BuffID.OnFire, (int)((120 + 60 * rand)), false);
            }
            if (frost)
            {
                target.AddBuff(BuffID.Frostburn, (int)((120 + 60 * rand)), false);
            }
            if (skp)
            {
                target.AddBuff(39, (int)((120 + 60 * rand)), false);
            }
            if (douche)
            {
                target.AddBuff(70, (int)((120 + 60 * rand)), false);
            }
            if (qB)
            {
                target.AddBuff(20, (int)((120 + 60 * rand)), false);
            }
            if (meFied)
            {
                target.AddBuff(mod.BuffType("Steamy"), (int)((120 + 60 * rand)), false);
            }
            if (slimey)
            {
                target.AddBuff(mod.BuffType("Slimed"), (int)((120 + 60 * rand)), false);
            }
            if (etherialFrost)
            {
                target.AddBuff(mod.BuffType("Frostbite"), (int)((12 * 60 + 60 * rand)), false);
            }
            if (etherialPipes)
            {
                target.AddBuff(mod.BuffType("Steamified"), (int)((12 * 60 + 60 * rand)), false);
            }
            if (crysMag)
            {
                if (crit)
                {
                    float mag = 6f;
                    float theta2 = (float)(Main.rand.NextDouble() * 2 * Math.PI);
                    if (Main.netMode != 1)
                        Projectile.NewProjectile(target.Center.X, target.Center.Y, (float)Math.Cos(theta2) * mag, (float)Math.Sin(theta2) * mag, mod.ProjectileType("ObsidiumArrowHead"), damage, 3f, Main.myPlayer);
                    theta2 = (float)(Main.rand.NextDouble() * 2 * Math.PI);
                    if (Main.netMode != 1)
                        Projectile.NewProjectile(target.Center.X, target.Center.Y, (float)Math.Cos(theta2) * mag, (float)Math.Sin(theta2) * mag, mod.ProjectileType("ObsidiumArrowHead"), damage, 3f, Main.myPlayer);
                    theta2 = (float)(Main.rand.NextDouble() * 2 * Math.PI);
                    if (Main.netMode != 1)
                        Projectile.NewProjectile(target.Center.X, target.Center.Y, (float)Math.Cos(theta2) * mag, (float)Math.Sin(theta2) * mag, mod.ProjectileType("ObsidiumArrowHead"), damage, 3f, Main.myPlayer);
                }
            }
        }

        public bool etherialCheck()
        {
            return etherial;
        }

        public void Explode(Vector2 center, float range, int damage)
        {
            foreach (NPC npc in Main.npc)
            {
                float dist = Vector2.Distance(center, npc.Center);
                if (dist <= range && npc.dontTakeDamage == false)
                {
                    npc.life -= damage;
                }
            }

        }

        public override void DrawEffects(PlayerDrawInfo drawInfo, ref float r, ref float g, ref float b, ref float a, ref bool fullBright)
        {

            if (etherialTrail > 0)
            {
                DrawEtherialTrailEffect();
            }
            if (eFied)
            {
                DrawSteamEffect(drawInfo, ref r, ref g, ref b, out fullBright);
            }
            if (etherial)
            {
                DrawEtherialEffect(out r, out g, out b);
            }
            if(etherialTank)
            {
                DrawEtherialTankSteam();
            }
            if(mysticHold > 0)
            {
                //DrawMysticUI();
            }
        }

        private void DrawEtherialTrailEffect()
        {
            etherialTrail -= 1;
            if (Main.rand.Next(0, 4) == 0)
            {
                Dust.NewDust(player.position + player.velocity, player.width, player.height, mod.DustType("Etherial"), 0f, 0f);
            }
        }

        private void DrawSteamEffect(PlayerDrawInfo drawInfo, ref float r, ref float g, ref float b, out bool fullBright)
        {
            if (Main.rand.Next(13) == 0 && drawInfo.shadow == 0f)
            {
                int dust = Dust.NewDust(drawInfo.position - new Vector2(2f, 2f), player.width + 4, player.height + 4,
                    mod.DustType("TrainSteam"), player.velocity.X * 0.4f, player.velocity.Y * 0.4f, 100, default(Color), 3f);
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

        private void DrawEtherialEffect(out float r, out float g, out float b)
        {
            r = 0.2f;
            g = 0.9f;
            b = 1f;

            if (ethBkg <= 0)
            {
                ethBkg = 9;
            }
            else
            {
                ethBkg -= 1;
            }
        }

        private void DrawEtherialTankSteam()
        {
            if (Math.Abs(player.velocity.X) > 14f && SoulStoneV)
            {
                Rectangle rect = player.getRect();
                Dust.NewDust(new Vector2(rect.X, rect.Y), rect.Width, 0, mod.DustType("TrainSteam"));
            }
        }

        //Hotkey
        public override void ProcessTriggers(TriggersSet triggersSet)
        {
            if (Laugicality.ToggleMystic.JustPressed && mysticHold > 0)
            {
                mysticSwitch();
                Main.PlaySound(SoundLoader.customSoundType, -1, -1, mod.GetSoundSlot(SoundType.Custom, "Sounds/MysticSwitch"));
            }
            if (Laugicality.QuickMystica.JustPressed && mysticality == 0)
            {
                bool mysticaPotion = false;
                foreach (Item item in player.inventory)
                {
                    if (item.type == mod.ItemType("SupremeMysticaPotion"))
                    {
                        mysticaPotion = true;
                        item.stack -= 1;
                        Main.PlaySound(2, (int)player.position.X, (int)player.position.Y, 3);
                        if (lux < (luxMax + luxMaxPermaBoost) * (1 + (luxOverflow - 1) / 2))
                            lux = (luxMax + luxMaxPermaBoost) * (1 + (luxOverflow - 1) / 2);
                        if (vis < (visMax + visMaxPermaBoost) * (1 + (visOverflow - 1) / 2))
                            vis = (visMax + visMaxPermaBoost) * (1 + (visOverflow - 1) / 2);
                        if (mundus < (mundusMax + mundusMaxPermaBoost) * (1 + (mundusOverflow - 1) / 2))
                            mundus = (mundusMax + mundusMaxPermaBoost) * (1 + (mundusOverflow - 1) / 2);
                        player.AddBuff(mod.BuffType("Mysticality3"), 60 * 60, true);
                    }
                    if (mysticaPotion)
                        break;
                }
                if(!mysticaPotion)
                {
                    foreach (Item item in player.inventory)
                    {
                        if (item.type == mod.ItemType("GreaterMysticaPotion"))
                        {
                            mysticaPotion = true;
                            item.stack -= 1;
                            Main.PlaySound(2, (int)player.position.X, (int)player.position.Y, 3);
                            if(lux < luxMax + luxMaxPermaBoost)
                            lux = luxMax + luxMaxPermaBoost;
                            if (vis < visMax + visMaxPermaBoost)
                                vis = visMax + visMaxPermaBoost;
                            if (mundus < mundusMax + mundusMaxPermaBoost)
                                mundus = mundusMax + mundusMaxPermaBoost;
                            player.AddBuff(mod.BuffType("Mysticality2"), 60 * 60, true);
                        }
                        if (mysticaPotion)
                            break;
                    }
                }
                if (!mysticaPotion)
                {
                    foreach (Item item in player.inventory)
                    {
                        if (item.type == mod.ItemType("MysticaPotion"))
                        {
                            mysticaPotion = true;
                            item.stack -= 1;
                            Main.PlaySound(2, (int)player.position.X, (int)player.position.Y, 3);
                            lux = luxMax + luxMaxPermaBoost;
                            vis = visMax + visMaxPermaBoost;
                            mundus = mundusMax + mundusMaxPermaBoost;
                            player.AddBuff(mod.BuffType("Mysticality"), 60 * 60, true);
                        }
                        if (mysticaPotion)
                            break;
                    }
                }
            }
            if (Laugicality.ToggleSoulStoneV.JustPressed)
            {
                SoulStoneV = !SoulStoneV;
                Main.NewText("Soul Stone and Potion Crystal visual effects: " + SoulStoneV.ToString(), 250, 250, 0);
            }
            if (Laugicality.ToggleSoulStoneM.JustPressed)
            {
                SoulStoneM = !SoulStoneM;
                Main.NewText("Soul Stone and Potion Crystal mobility effects: " + SoulStoneM.ToString(), 250, 250, 0);
            }
        }


        public override void PostHurt(bool pvp, bool quiet, double damage, int hitDirection, bool crit)
        {
            if (mysticSwitchCool <= 0)
            {
                if (bRage)
                {
                    ApplyBloodRage();
                }
                SpawnProjectileOnPlayerHurt();
                ArmorEffectPlayerHurt();
                mysticSwitchCool = 120;
            }
        }

        private void ArmorEffectPlayerHurt()
        {
            if (andioChestguard && player.statLife < player.statLifeMax2 / 4 && zCool == false)
            {
                ZaWarudo();
            }

            if (andioChestplate && player.statLife < player.statLifeMax2 / 4 && zCool == false)
            {
                ZaWarudo();
            }
        }
        

        private void ZaWarudo()
        {
            Main.PlaySound(SoundLoader.customSoundType, -1, -1, mod.GetSoundSlot(SoundType.Custom, "Sounds/zawarudo"));
            player.AddBuff(mod.BuffType("TimeExhausted"), zCoolDown, true);
            if(Laugicality.zawarudo < zaWarudoDuration)
            {
                Laugicality.zawarudo = zaWarudoDuration;
                LaugicalGlobalNPCs.zTime = zaWarudoDuration;
            }
        }


        private void SpawnProjectileOnPlayerHurt()
        {
            if (eyes)
            {
                SpawnMiniEye();
            }

            if (sandy)
            {
                SpawnSandBall();
            }

            if (frigid)
            {
                SpawnIceShard();
            }

            if (spores)
            {
                SpawnSpore();
            }

            if (rocks)
            {
                SpawnRockShard();
            }
        }

        private void ApplyBloodRage()
        {
            player.AddBuff(mod.BuffType("BloodRage"), 420);
            Projectile.NewProjectile(player.Center.X, player.Center.Y, 6 - Main.rand.Next(12), 0, 565, 16, 3f, player.whoAmI);
            Projectile.NewProjectile(player.Center.X, player.Center.Y, 6 - Main.rand.Next(12), 0, 565, 16, 3f, player.whoAmI);
        }

        private void SpawnMiniEye()
        {
            Projectile.NewProjectile(player.Center.X, player.Center.Y, 6 - Main.rand.Next(12), 6 - Main.rand.Next(12),
                mod.ProjectileType("MiniEye"), 16, 3f, player.whoAmI);
            Projectile.NewProjectile(player.Center.X, player.Center.Y, 6 - Main.rand.Next(12), 6 - Main.rand.Next(12),
                mod.ProjectileType("MiniEye"), 16, 3f, player.whoAmI);
            Projectile.NewProjectile(player.Center.X, player.Center.Y, 6 - Main.rand.Next(12), 6 - Main.rand.Next(12),
                mod.ProjectileType("MiniEye"), 16, 3f, player.whoAmI);
            Projectile.NewProjectile(player.Center.X, player.Center.Y, 6 - Main.rand.Next(12), 6 - Main.rand.Next(12),
                mod.ProjectileType("MiniEye"), 16, 3f, player.whoAmI);
            if (Main.rand.Next(0, 2) == 0)
                Projectile.NewProjectile(player.Center.X, player.Center.Y, 6 - Main.rand.Next(12), 6 - Main.rand.Next(12),
                    mod.ProjectileType("MiniEye"), 16, 3f, player.whoAmI);
            if (Main.rand.Next(0, 2) == 0)
                Projectile.NewProjectile(player.Center.X, player.Center.Y, 6 - Main.rand.Next(12), 6 - Main.rand.Next(12),
                    mod.ProjectileType("MiniEye"), 16, 3f, player.whoAmI);
        }

        private void SpawnSandBall()
        {
            Projectile.NewProjectile(player.Center.X, player.Center.Y, 4, 4, mod.ProjectileType("Sandball"), 18, 5,
                Main.myPlayer);
            Projectile.NewProjectile(player.Center.X, player.Center.Y, 4, -4, mod.ProjectileType("Sandball"), 18, 5,
                Main.myPlayer);
            Projectile.NewProjectile(player.Center.X, player.Center.Y, -4, -4, mod.ProjectileType("Sandball"), 18, 5,
                Main.myPlayer);
            Projectile.NewProjectile(player.Center.X, player.Center.Y, -4, 4, mod.ProjectileType("Sandball"), 18, 5,
                Main.myPlayer);
        }

        private void SpawnIceShard()
        {
            Projectile.NewProjectile(player.Center.X, player.Center.Y, 6 - Main.rand.Next(12), 6 - Main.rand.Next(12),
                mod.ProjectileType("IceShardF"), 16, 3f, player.whoAmI);
            Projectile.NewProjectile(player.Center.X, player.Center.Y, 6 - Main.rand.Next(12), 6 - Main.rand.Next(12),
                mod.ProjectileType("IceShardF"), 16, 3f, player.whoAmI);
        }

        private void SpawnSpore()
        {
            Projectile.NewProjectile(player.Center.X, player.Center.Y, 6 - Main.rand.Next(12), 6 - Main.rand.Next(12), 567, 48,
                3f, player.whoAmI);
            Projectile.NewProjectile(player.Center.X, player.Center.Y, 6 - Main.rand.Next(12), 6 - Main.rand.Next(12), 568, 48,
                3f, player.whoAmI);
            Projectile.NewProjectile(player.Center.X, player.Center.Y, 6 - Main.rand.Next(12), 6 - Main.rand.Next(12), 569, 48,
                3f, player.whoAmI);
            Projectile.NewProjectile(player.Center.X, player.Center.Y, 6 - Main.rand.Next(12), 6 - Main.rand.Next(12), 570, 48,
                3f, player.whoAmI);
            if (Main.rand.Next(0, 2) == 0)
                Projectile.NewProjectile(player.Center.X, player.Center.Y, 6 - Main.rand.Next(12), 6 - Main.rand.Next(12), 571,
                    48, 3f, player.whoAmI);
            if (Main.rand.Next(0, 2) == 0)
                Projectile.NewProjectile(player.Center.X, player.Center.Y, 6 - Main.rand.Next(12), 6 - Main.rand.Next(12), 567,
                    48, 3f, player.whoAmI);
        }

        private void SpawnRockShard()
        {
            Projectile.NewProjectile(player.Center.X, player.Center.Y, 8, 0, mod.ProjectileType("RockShard"), 20, 3,
                Main.myPlayer);
            Projectile.NewProjectile(player.Center.X, player.Center.Y, -8, 0, mod.ProjectileType("RockShard"), 20, 3,
                Main.myPlayer);
            Projectile.NewProjectile(player.Center.X, player.Center.Y, 0, 8, mod.ProjectileType("RockShard"), 20, 3,
                Main.myPlayer);
            Projectile.NewProjectile(player.Center.X, player.Center.Y, -8 + Main.rand.Next(0, 17), -8 + Main.rand.Next(0, 17),
                mod.ProjectileType("RockShard"), 20, 3, Main.myPlayer);
            Projectile.NewProjectile(player.Center.X, player.Center.Y, -8 + Main.rand.Next(0, 17), -8 + Main.rand.Next(0, 17),
                mod.ProjectileType("RockShard"), 20, 3, Main.myPlayer);
            Projectile.NewProjectile(player.Center.X, player.Center.Y, -8 + Main.rand.Next(0, 17), -8 + Main.rand.Next(0, 17),
                mod.ProjectileType("RockShard"), 20, 3, Main.myPlayer);
            Projectile.NewProjectile(player.Center.X, player.Center.Y, -8 + Main.rand.Next(0, 17), -8 + Main.rand.Next(0, 17),
                mod.ProjectileType("RockShard"), 20, 3, Main.myPlayer);
            Projectile.NewProjectile(player.Center.X, player.Center.Y, -8 + Main.rand.Next(0, 17), -8 + Main.rand.Next(0, 17),
                mod.ProjectileType("RockShard"), 20, 3, Main.myPlayer);
        }

        public LaugicalityPlayer GetModPlayer(Player player)
        {
            return player.GetModPlayer<LaugicalityPlayer>(mod);
        }
    }
}

