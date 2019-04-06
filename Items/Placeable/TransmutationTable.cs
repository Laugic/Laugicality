using Terraria.ID;
using Terraria.ModLoader;

namespace Laugicality.Items.Placeable
{
    public class TransmutationTable : ModItem
    {
        public override void SetStaticDefaults()
        {
            Tooltip.SetDefault("Transmutes items of equal value");
        }

        public override void SetDefaults()
        {
            item.width = 48;
            item.height = 64;
            item.maxStack = 1;
            item.useTurn = true;
            item.autoReuse = true;
            item.useAnimation = 15;
            item.useTime = 10;
            item.useStyle = 1;
            item.consumable = true;
            item.value = 150;
            item.createTile = mod.TileType("TransmutationTable");
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddTile(null, "LaugicalWorkbench");
            recipe.AddRecipeGroup("LargeGems");
            recipe.AddRecipeGroup("DungeonTables");
            recipe.AddIngredient(ItemID.WaterCandle);
            recipe.AddIngredient(ItemID.Book);
            recipe.SetResult(this);
            recipe.AddRecipe();

            //Dungeon Table Recipes
            //Green
            ModRecipe grecipe = new ModRecipe(mod);
            grecipe.AddIngredient(ItemID.Bone, 10);
            grecipe.AddIngredient(137, 24);
            grecipe.AddTile(16);
            grecipe.SetResult(1400);
            grecipe.AddRecipe();
            //Blue
            ModRecipe brecipe = new ModRecipe(mod);
            brecipe.AddIngredient(ItemID.Bone, 10);
            brecipe.AddIngredient(134, 24);
            brecipe.AddTile(16);
            brecipe.SetResult(1397);
            brecipe.AddRecipe();
            //Pink
            ModRecipe precipe = new ModRecipe(mod);
            precipe.AddIngredient(ItemID.Bone, 10);
            precipe.AddIngredient(139, 24);
            precipe.AddTile(16);
            precipe.SetResult(1403);
            precipe.AddRecipe();

            //Metal Transmutation!!
            //Ores
            //Copper to Tin
            ModRecipe cTrecipe = new ModRecipe(mod);
            cTrecipe.AddIngredient(ItemID.CopperOre, 3);
            cTrecipe.AddTile(null, "TransmutationTable");
            cTrecipe.SetResult(ItemID.TinOre, 3);
            cTrecipe.AddRecipe();

            //Tin to Copper
            ModRecipe crecipe = new ModRecipe(mod);
            crecipe.AddIngredient(ItemID.TinOre, 3);
            crecipe.AddTile(null, "TransmutationTable");
            crecipe.SetResult(ItemID.CopperOre, 3);
            crecipe.AddRecipe();

            //Tin to Iron
            ModRecipe irecipe = new ModRecipe(mod);
            irecipe.AddIngredient(ItemID.TinOre, 4);
            irecipe.AddTile(null, "TransmutationTable");
            irecipe.SetResult(ItemID.IronOre, 3);
            irecipe.AddRecipe();

            //Iron to Tin
            ModRecipe trecipe = new ModRecipe(mod);
            trecipe.AddIngredient(ItemID.IronOre, 3);
            trecipe.AddTile(null, "TransmutationTable");
            trecipe.SetResult(ItemID.TinOre, 3);
            trecipe.AddRecipe();

            //Iron to Lead
            ModRecipe lrecipe = new ModRecipe(mod);
            lrecipe.AddIngredient(ItemID.IronOre, 3);
            lrecipe.AddTile(null, "TransmutationTable");
            lrecipe.SetResult(ItemID.LeadOre, 3);
            lrecipe.AddRecipe();

            //Lead to Iron
            ModRecipe lIrecipe = new ModRecipe(mod);
            lIrecipe.AddIngredient(ItemID.LeadOre, 3);
            lIrecipe.AddTile(null, "TransmutationTable");
            lIrecipe.SetResult(ItemID.IronOre, 3);
            lIrecipe.AddRecipe();

            //Lead to Silver
            ModRecipe lSrecipe = new ModRecipe(mod);
            lSrecipe.AddIngredient(ItemID.LeadOre, 5);
            lSrecipe.AddTile(null, "TransmutationTable");
            lSrecipe.SetResult(ItemID.SilverOre, 3);
            lSrecipe.AddRecipe();

            //Silver to Lead
            ModRecipe sLrecipe = new ModRecipe(mod);
            sLrecipe.AddIngredient(ItemID.SilverOre, 3);
            sLrecipe.AddTile(null, "TransmutationTable");
            sLrecipe.SetResult(ItemID.LeadOre, 3);
            sLrecipe.AddRecipe();

            //Silver to Tungsten
            ModRecipe sTrecipe = new ModRecipe(mod);
            sTrecipe.AddIngredient(ItemID.SilverOre, 4);
            sTrecipe.AddTile(null, "TransmutationTable");
            sTrecipe.SetResult(ItemID.TungstenOre, 4);
            sTrecipe.AddRecipe();

            //Tungsten to Silver
            ModRecipe srecipe = new ModRecipe(mod);
            srecipe.AddIngredient(ItemID.TungstenOre, 4);
            srecipe.AddTile(null, "TransmutationTable");
            srecipe.SetResult(ItemID.SilverOre, 4);
            srecipe.AddRecipe();

            //Tungsten to Gold
            ModRecipe gRecipe = new ModRecipe(mod);
            gRecipe.AddIngredient(ItemID.TungstenOre, 5);
            gRecipe.AddTile(null, "TransmutationTable");
            gRecipe.SetResult(ItemID.GoldOre, 4);
            gRecipe.AddRecipe();

            //Gold to Tungsten
            ModRecipe gTrecipe = new ModRecipe(mod);
            gTrecipe.AddIngredient(ItemID.GoldOre, 4);
            gTrecipe.AddTile(null, "TransmutationTable");
            gTrecipe.SetResult(ItemID.TungstenOre, 4);
            gTrecipe.AddRecipe();

            //Gold to Platinum
            ModRecipe gPrecipe = new ModRecipe(mod);
            gPrecipe.AddIngredient(ItemID.GoldOre, 4);
            gPrecipe.AddTile(null, "TransmutationTable");
            gPrecipe.SetResult(ItemID.PlatinumOre, 4);
            gPrecipe.AddRecipe();

            //Platinum to Gold
            ModRecipe pGrecipe = new ModRecipe(mod);
            pGrecipe.AddIngredient(ItemID.PlatinumOre, 4);
            pGrecipe.AddTile(null, "TransmutationTable");
            pGrecipe.SetResult(ItemID.GoldOre, 4);
            pGrecipe.AddRecipe();

            //Platinum to Cobalt
            ModRecipe pCrecipe = new ModRecipe(mod);
            pCrecipe.AddIngredient(ItemID.PlatinumOre, 6);
            pCrecipe.AddTile(null, "TransmutationTable");
            pCrecipe.AddTile(null, "MineralEnchanter");
            pCrecipe.SetResult(ItemID.CobaltOre, 4);
            pCrecipe.AddRecipe();

            //Cobalt to Platinum
            ModRecipe cPrecipe = new ModRecipe(mod);
            cPrecipe.AddIngredient(ItemID.CobaltOre, 3);
            cPrecipe.AddTile(null, "TransmutationTable");
            cPrecipe.SetResult(ItemID.PlatinumOre, 3);
            cPrecipe.AddRecipe();

            //Cobalt to Palladium
            ModRecipe cParecipe = new ModRecipe(mod);
            cParecipe.AddIngredient(ItemID.CobaltOre, 3);
            cParecipe.AddTile(null, "TransmutationTable");
            cParecipe.SetResult(ItemID.PalladiumOre, 3);
            cParecipe.AddRecipe();

            //Palladium to Cobalt
            ModRecipe paCrecipe = new ModRecipe(mod);
            paCrecipe.AddIngredient(ItemID.PalladiumOre, 3);
            paCrecipe.AddTile(null, "TransmutationTable");
            paCrecipe.SetResult(ItemID.CobaltOre, 3);
            paCrecipe.AddRecipe();

            //Palladium to Mythril
            ModRecipe pMrecipe = new ModRecipe(mod);
            pMrecipe.AddIngredient(ItemID.PalladiumOre, 5);
            pMrecipe.AddTile(null, "TransmutationTable");
            pMrecipe.SetResult(ItemID.MythrilOre, 3);
            pMrecipe.AddRecipe();

            //Mythril to Palladium
            ModRecipe mPrecipe = new ModRecipe(mod);
            mPrecipe.AddIngredient(ItemID.MythrilOre, 3);
            mPrecipe.AddTile(null, "TransmutationTable");
            mPrecipe.SetResult(ItemID.PalladiumOre, 3);
            mPrecipe.AddRecipe();

            //Mythril to Orichalcum
            ModRecipe mOrecipe = new ModRecipe(mod);
            mOrecipe.AddIngredient(ItemID.MythrilOre, 4);
            mOrecipe.AddTile(null, "TransmutationTable");
            mOrecipe.SetResult(ItemID.OrichalcumOre, 4);
            mOrecipe.AddRecipe();

            //Orichalcum to Mythril
            ModRecipe oMrecipe = new ModRecipe(mod);
            oMrecipe.AddIngredient(ItemID.OrichalcumOre, 4);
            oMrecipe.AddTile(null, "TransmutationTable");
            oMrecipe.SetResult(ItemID.MythrilOre, 4);
            oMrecipe.AddRecipe();

            //Orichalcum to Adamantite
            ModRecipe oArecipe = new ModRecipe(mod);
            oArecipe.AddIngredient(ItemID.OrichalcumOre, 6);
            oArecipe.AddTile(null, "TransmutationTable");
            oArecipe.SetResult(ItemID.AdamantiteOre, 4);
            oArecipe.AddRecipe();

            //Adamantite to Orichalcum
            ModRecipe aOrecipe = new ModRecipe(mod);
            aOrecipe.AddIngredient(ItemID.AdamantiteOre, 4);
            aOrecipe.AddTile(null, "TransmutationTable");
            aOrecipe.SetResult(ItemID.OrichalcumOre, 4);
            aOrecipe.AddRecipe();

            //Adamantite to Titanium
            ModRecipe aTrecipe = new ModRecipe(mod);
            aTrecipe.AddIngredient(ItemID.AdamantiteOre, 5);
            aTrecipe.AddTile(null, "TransmutationTable");
            aTrecipe.SetResult(ItemID.TitaniumOre, 5);
            aTrecipe.AddRecipe();

            //Titanium to Adamantite
            ModRecipe arecipe = new ModRecipe(mod);
            arecipe.AddIngredient(ItemID.TitaniumOre, 5);
            arecipe.AddTile(null, "TransmutationTable");
            arecipe.SetResult(ItemID.AdamantiteOre, 5);
            arecipe.AddRecipe();

            //Bars
            //Copper to Tin
            ModRecipe ctBrecipe = new ModRecipe(mod);
            ctBrecipe.AddIngredient(ItemID.CopperBar, 3);
            ctBrecipe.AddTile(null, "TransmutationTable");
            ctBrecipe.SetResult(ItemID.TinBar, 3);
            ctBrecipe.AddRecipe();

            //Tin to Copper
            ModRecipe tcBrecipe = new ModRecipe(mod);
            tcBrecipe.AddIngredient(ItemID.TinBar, 3);
            tcBrecipe.AddTile(null, "TransmutationTable");
            tcBrecipe.SetResult(ItemID.CopperBar, 3);
            tcBrecipe.AddRecipe();

            //Tin to Iron
            ModRecipe tiBrecipe = new ModRecipe(mod);
            tiBrecipe.AddIngredient(ItemID.TinBar, 4);
            tiBrecipe.AddTile(null, "TransmutationTable");
            tiBrecipe.SetResult(ItemID.IronBar, 3);
            tiBrecipe.AddRecipe();

            //Iron to Tin
            ModRecipe itBrecipe = new ModRecipe(mod);
            itBrecipe.AddIngredient(ItemID.IronBar, 3);
            itBrecipe.AddTile(null, "TransmutationTable");
            itBrecipe.SetResult(ItemID.TinBar, 3);
            itBrecipe.AddRecipe();

            //Iron to Lead
            ModRecipe ilBrecipe = new ModRecipe(mod);
            ilBrecipe.AddIngredient(ItemID.IronBar, 3);
            ilBrecipe.AddTile(null, "TransmutationTable");
            ilBrecipe.SetResult(ItemID.LeadBar, 3);
            ilBrecipe.AddRecipe();

            //Lead to Iron
            ModRecipe liBrecipe = new ModRecipe(mod);
            liBrecipe.AddIngredient(ItemID.LeadBar, 3);
            liBrecipe.AddTile(null, "TransmutationTable");
            liBrecipe.SetResult(ItemID.IronBar, 3);
            liBrecipe.AddRecipe();

            //Lead to Silver
            ModRecipe lsBrecipe = new ModRecipe(mod);
            lsBrecipe.AddIngredient(ItemID.LeadBar, 5);
            lsBrecipe.AddTile(null, "TransmutationTable");
            lsBrecipe.SetResult(ItemID.SilverBar, 3);
            lsBrecipe.AddRecipe();

            //Silver to Lead
            ModRecipe slBrecipe = new ModRecipe(mod);
            slBrecipe.AddIngredient(ItemID.SilverBar, 3);
            slBrecipe.AddTile(null, "TransmutationTable");
            slBrecipe.SetResult(ItemID.LeadBar, 3);
            slBrecipe.AddRecipe();

            //Silver to Tungsten
            ModRecipe stBrecipe = new ModRecipe(mod);
            stBrecipe.AddIngredient(ItemID.SilverBar, 4);
            stBrecipe.AddTile(null, "TransmutationTable");
            stBrecipe.SetResult(ItemID.TungstenBar, 4);
            stBrecipe.AddRecipe();

            //Tungsten to Silver
            ModRecipe tsBrecipe = new ModRecipe(mod);
            tsBrecipe.AddIngredient(ItemID.TungstenBar, 4);
            tsBrecipe.AddTile(null, "TransmutationTable");
            tsBrecipe.SetResult(ItemID.SilverBar, 4);
            tsBrecipe.AddRecipe();

            //Tungsten to Gold
            ModRecipe tgBrecipe = new ModRecipe(mod);
            tgBrecipe.AddIngredient(ItemID.TungstenBar, 5);
            tgBrecipe.AddTile(null, "TransmutationTable");
            tgBrecipe.SetResult(ItemID.GoldBar, 4);
            tgBrecipe.AddRecipe();

            //Gold to Tungsten
            ModRecipe gtBrecipe = new ModRecipe(mod);
            gtBrecipe.AddIngredient(ItemID.GoldBar, 4);
            gtBrecipe.AddTile(null, "TransmutationTable");
            gtBrecipe.SetResult(ItemID.TungstenBar, 4);
            gtBrecipe.AddRecipe();

            //Gold to Platinum
            ModRecipe gpBrecipe = new ModRecipe(mod);
            gpBrecipe.AddIngredient(ItemID.GoldBar, 4);
            gpBrecipe.AddTile(null, "TransmutationTable");
            gpBrecipe.SetResult(ItemID.PlatinumBar, 4);
            gpBrecipe.AddRecipe();

            //Platinum to Gold
            ModRecipe pgBrecipe = new ModRecipe(mod);
            pgBrecipe.AddIngredient(ItemID.PlatinumBar, 4);
            pgBrecipe.AddTile(null, "TransmutationTable");
            pgBrecipe.SetResult(ItemID.GoldBar, 4);
            pgBrecipe.AddRecipe();

            //Platinum to Cobalt
            ModRecipe pcBrecipe = new ModRecipe(mod);
            pcBrecipe.AddIngredient(ItemID.PlatinumBar, 6);
            pcBrecipe.AddTile(null, "TransmutationTable");
            pcBrecipe.AddTile(null, "MineralEnchanter");
            pcBrecipe.SetResult(ItemID.CobaltBar, 4);
            pcBrecipe.AddRecipe();

            //Cobalt to Platinum
            ModRecipe cpBrecipe = new ModRecipe(mod);
            cpBrecipe.AddIngredient(ItemID.CobaltBar, 3);
            cpBrecipe.AddTile(null, "TransmutationTable");
            cpBrecipe.SetResult(ItemID.PlatinumBar, 3);
            cpBrecipe.AddRecipe();

            //Cobalt to Palladium
            ModRecipe cPaBrecipe = new ModRecipe(mod);
            cPaBrecipe.AddIngredient(ItemID.CobaltBar, 3);
            cPaBrecipe.AddTile(null, "TransmutationTable");
            cPaBrecipe.SetResult(ItemID.PalladiumBar, 3);
            cPaBrecipe.AddRecipe();

            //Palladium to Cobalt
            ModRecipe paCBrecipe = new ModRecipe(mod);
            paCBrecipe.AddIngredient(ItemID.PalladiumBar, 3);
            paCBrecipe.AddTile(null, "TransmutationTable");
            paCBrecipe.SetResult(ItemID.CobaltBar, 3);
            paCBrecipe.AddRecipe();

            //Palladium to Mythril
            ModRecipe pmBrecipe = new ModRecipe(mod);
            pmBrecipe.AddIngredient(ItemID.PalladiumBar, 5);
            pmBrecipe.AddTile(null, "TransmutationTable");
            pmBrecipe.SetResult(ItemID.MythrilBar, 3);
            pmBrecipe.AddRecipe();

            //Mythril to Palladium
            ModRecipe mpBrecipe = new ModRecipe(mod);
            mpBrecipe.AddIngredient(ItemID.MythrilBar, 3);
            mpBrecipe.AddTile(null, "TransmutationTable");
            mpBrecipe.SetResult(ItemID.PalladiumBar, 3);
            mpBrecipe.AddRecipe();

            //Mythril to Orichalcum
            ModRecipe moBrecipe = new ModRecipe(mod);
            moBrecipe.AddIngredient(ItemID.MythrilBar, 4);
            moBrecipe.AddTile(null, "TransmutationTable");
            moBrecipe.SetResult(ItemID.OrichalcumBar, 4);
            moBrecipe.AddRecipe();

            //Orichalcum to Mythril
            ModRecipe omBrecipe = new ModRecipe(mod);
            omBrecipe.AddIngredient(ItemID.OrichalcumBar, 4);
            omBrecipe.AddTile(null, "TransmutationTable");
            omBrecipe.SetResult(ItemID.MythrilBar, 4);
            omBrecipe.AddRecipe();

            //Orichalcum to Adamantite
            ModRecipe oaBrecipe = new ModRecipe(mod);
            oaBrecipe.AddIngredient(ItemID.OrichalcumBar, 6);
            oaBrecipe.AddTile(null, "TransmutationTable");
            oaBrecipe.SetResult(ItemID.AdamantiteBar, 4);
            oaBrecipe.AddRecipe();

            //Adamantite to Orichalcum
            ModRecipe aoBrecipe = new ModRecipe(mod);
            aoBrecipe.AddIngredient(ItemID.AdamantiteBar, 4);
            aoBrecipe.AddTile(null, "TransmutationTable");
            aoBrecipe.SetResult(ItemID.OrichalcumBar, 4);
            aoBrecipe.AddRecipe();

            //Adamantite to Titanium
            ModRecipe atBrecipe = new ModRecipe(mod);
            atBrecipe.AddIngredient(ItemID.AdamantiteBar, 5);
            atBrecipe.AddTile(null, "TransmutationTable");
            atBrecipe.SetResult(ItemID.TitaniumBar, 5);
            atBrecipe.AddRecipe();

            //Titanium to Adamantite
            ModRecipe taBrecipe = new ModRecipe(mod);
            taBrecipe.AddIngredient(ItemID.TitaniumBar, 5);
            taBrecipe.AddTile(null, "TransmutationTable");
            taBrecipe.SetResult(ItemID.AdamantiteBar, 5);
            taBrecipe.AddRecipe();


            //Crimson to Corruption
            
            //Undertaker to Musket
            ModRecipe uMrecipe = new ModRecipe(mod);
            uMrecipe.AddIngredient(ItemID.TheUndertaker);
            uMrecipe.AddTile(null, "TransmutationTable");
            uMrecipe.SetResult(ItemID.Musket);
            uMrecipe.AddRecipe();

            //Musket to Undertaker
            ModRecipe mUrecipe = new ModRecipe(mod);
            mUrecipe.AddIngredient(ItemID.Musket);
            mUrecipe.AddTile(null, "TransmutationTable");
            mUrecipe.SetResult(ItemID.TheUndertaker);
            mUrecipe.AddRecipe();

            //Rotted Fork to Ball o' Hurt
            ModRecipe rBrecipe = new ModRecipe(mod);
            rBrecipe.AddIngredient(802);
            rBrecipe.AddTile(null, "TransmutationTable");
            rBrecipe.SetResult(162);
            rBrecipe.AddRecipe();

            //Ball o' Hurt to Rotted Fork
            ModRecipe bRrecipe = new ModRecipe(mod);
            bRrecipe.AddIngredient(162);
            bRrecipe.AddTile(null, "TransmutationTable");
            bRrecipe.SetResult(802);
            bRrecipe.AddRecipe();

            //CrimsonRod to Vilethorn
            ModRecipe cVrecipe = new ModRecipe(mod);
            cVrecipe.AddIngredient(ItemID.CrimsonRod);
            cVrecipe.AddTile(null, "TransmutationTable");
            cVrecipe.SetResult(ItemID.Vilethorn);
            cVrecipe.AddRecipe();

            //Vilethorn to CrimsonRod
            ModRecipe vCrecipe = new ModRecipe(mod);
            vCrecipe.AddIngredient(ItemID.Vilethorn);
            vCrecipe.AddTile(null, "TransmutationTable");
            vCrecipe.SetResult(ItemID.CrimsonRod);
            vCrecipe.AddRecipe();

            //Panic Necklace to Band of Starpower
            ModRecipe pBrecipe = new ModRecipe(mod);
            pBrecipe.AddIngredient(ItemID.PanicNecklace);
            pBrecipe.AddTile(null, "TransmutationTable");
            pBrecipe.SetResult(111);
            pBrecipe.AddRecipe();

            //Band of Starpower to Panic Necklace
            ModRecipe bPrecipe = new ModRecipe(mod);
            bPrecipe.AddIngredient(111);
            bPrecipe.AddTile(null, "TransmutationTable");
            bPrecipe.SetResult(ItemID.PanicNecklace);
            bPrecipe.AddRecipe();

            //Crimson Heart to Shadow Orb
            ModRecipe cSrecipe = new ModRecipe(mod);
            cSrecipe.AddIngredient(3062);
            cSrecipe.AddTile(null, "TransmutationTable");
            cSrecipe.SetResult(ItemID.ShadowOrb);
            cSrecipe.AddRecipe();

            //Shadow Orb to Crimson Heart
            ModRecipe sCrecipe = new ModRecipe(mod);
            sCrecipe.AddIngredient(ItemID.ShadowOrb);
            sCrecipe.AddTile(null, "TransmutationTable");
            sCrecipe.SetResult(3062);
            sCrecipe.AddRecipe();

            //Demonite to Crimtane
            ModRecipe dCrecipe = new ModRecipe(mod);
            dCrecipe.AddIngredient(ItemID.DemoniteOre, 3);
            dCrecipe.AddTile(null, "TransmutationTable");
            dCrecipe.SetResult(ItemID.CrimtaneOre, 3);
            dCrecipe.AddRecipe();

            //Crimtane to Demonite
            ModRecipe cDrecipe = new ModRecipe(mod);
            cDrecipe.AddIngredient(ItemID.CrimtaneOre, 3);
            cDrecipe.AddTile(null, "TransmutationTable");
            cDrecipe.SetResult(ItemID.DemoniteOre, 3);
            cDrecipe.AddRecipe();

            //CrimtaneBar to DemoniteBar
            ModRecipe cdBrecipe = new ModRecipe(mod);
            cdBrecipe.AddIngredient(ItemID.CrimtaneBar, 3);
            cdBrecipe.AddTile(null, "TransmutationTable");
            cdBrecipe.SetResult(ItemID.DemoniteBar, 3);
            cdBrecipe.AddRecipe();

            //DemoniteBar to CrimtaneBar
            ModRecipe dcBrecipe = new ModRecipe(mod);
            dcBrecipe.AddIngredient(ItemID.DemoniteBar, 3);
            dcBrecipe.AddTile(null, "TransmutationTable");
            dcBrecipe.SetResult(ItemID.CrimtaneBar, 3);
            dcBrecipe.AddRecipe();

            //Ebonstone to Crimstone
            ModRecipe eCrecipe = new ModRecipe(mod);
            eCrecipe.AddIngredient(ItemID.EbonstoneBlock);
            eCrecipe.AddTile(null, "TransmutationTable");
            eCrecipe.SetResult(ItemID.CrimstoneBlock);
            eCrecipe.AddRecipe();

            //Crimstone to Ebonstone
            ModRecipe cErecipe = new ModRecipe(mod);
            cErecipe.AddIngredient(ItemID.CrimstoneBlock);
            cErecipe.AddTile(null, "TransmutationTable");
            cErecipe.SetResult(ItemID.EbonstoneBlock);
            cErecipe.AddRecipe();

            //CursedFlame to Ichor
            ModRecipe cIrecipe = new ModRecipe(mod);
            cIrecipe.AddIngredient(ItemID.CursedFlame);
            cIrecipe.AddTile(null, "TransmutationTable");
            cIrecipe.SetResult(ItemID.Ichor);
            cIrecipe.AddRecipe();

            //Ichor to CursedFlame
            ModRecipe cRecipe = new ModRecipe(mod);
            cRecipe.AddIngredient(ItemID.Ichor);
            cRecipe.AddTile(null, "TransmutationTable");
            cRecipe.SetResult(ItemID.CursedFlame);
            cRecipe.AddRecipe();

            //Ebonkoi to Hemopiranha
            ModRecipe eHrecipe = new ModRecipe(mod);
            eHrecipe.AddIngredient(ItemID.Ebonkoi);
            eHrecipe.AddTile(null, "TransmutationTable");
            eHrecipe.SetResult(ItemID.Hemopiranha);
            eHrecipe.AddRecipe();

            //Hemopiranha to Ebonkoi
            ModRecipe hErecipe = new ModRecipe(mod);
            hErecipe.AddIngredient(ItemID.Hemopiranha);
            hErecipe.AddTile(null, "TransmutationTable");
            hErecipe.SetResult(ItemID.Ebonkoi);
            hErecipe.AddRecipe();

            //Ebonkoi to CrimsonTigerfish
            ModRecipe eTrecipe = new ModRecipe(mod);
            eTrecipe.AddIngredient(ItemID.Ebonkoi);
            eTrecipe.AddTile(null, "TransmutationTable");
            eTrecipe.SetResult(ItemID.CrimsonTigerfish);
            eTrecipe.AddRecipe();

            //CrimsonTigerfish to Ebonkoi
            ModRecipe erecipe = new ModRecipe(mod);
            erecipe.AddIngredient(ItemID.CrimsonTigerfish);
            erecipe.AddTile(null, "TransmutationTable");
            erecipe.SetResult(ItemID.Ebonkoi);
            erecipe.AddRecipe();

            //CrimsonSeeds to CorruptSeeds
            ModRecipe cCrecipe = new ModRecipe(mod);
            cCrecipe.AddIngredient(ItemID.CrimsonSeeds);
            cCrecipe.AddTile(null, "TransmutationTable");
            cCrecipe.SetResult(ItemID.CorruptSeeds);
            cCrecipe.AddRecipe();

            //CorruptSeeds to CrimsonSeeds
            ModRecipe cCsrecipe = new ModRecipe(mod);
            cCsrecipe.AddIngredient(ItemID.CorruptSeeds);
            cCsrecipe.AddTile(null, "TransmutationTable");
            cCsrecipe.SetResult(ItemID.CrimsonSeeds);
            cCsrecipe.AddRecipe();

            //Crafting Life Fruits
            ModRecipe lFrecipe = new ModRecipe(mod);
            lFrecipe.AddIngredient(ItemID.LifeCrystal);
            lFrecipe.AddIngredient(1006, 5);
            lFrecipe.AddTile(null, "TransmutationTable");
            lFrecipe.SetResult(ItemID.LifeFruit);
            lFrecipe.AddRecipe();
        }
    }
}