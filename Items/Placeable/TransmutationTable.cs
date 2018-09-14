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
            ModRecipe Grecipe = new ModRecipe(mod);
            Grecipe.AddIngredient(ItemID.Bone, 10);
            Grecipe.AddIngredient(137, 24);
            Grecipe.AddTile(16);
            Grecipe.SetResult(1400);
            Grecipe.AddRecipe();
            //Blue
            ModRecipe Brecipe = new ModRecipe(mod);
            Brecipe.AddIngredient(ItemID.Bone, 10);
            Brecipe.AddIngredient(134, 24);
            Brecipe.AddTile(16);
            Brecipe.SetResult(1397);
            Brecipe.AddRecipe();
            //Pink
            ModRecipe Precipe = new ModRecipe(mod);
            Precipe.AddIngredient(ItemID.Bone, 10);
            Precipe.AddIngredient(139, 24);
            Precipe.AddTile(16);
            Precipe.SetResult(1403);
            Precipe.AddRecipe();

            //Metal Transmutation!!
            //Ores
            //Copper to Tin
            ModRecipe CTrecipe = new ModRecipe(mod);
            CTrecipe.AddIngredient(ItemID.CopperOre, 3);
            CTrecipe.AddTile(null, "TransmutationTable");
            CTrecipe.SetResult(ItemID.TinOre, 3);
            CTrecipe.AddRecipe();

            //Tin to Copper
            ModRecipe TCrecipe = new ModRecipe(mod);
            TCrecipe.AddIngredient(ItemID.TinOre, 3);
            TCrecipe.AddTile(null, "TransmutationTable");
            TCrecipe.SetResult(ItemID.CopperOre, 3);
            TCrecipe.AddRecipe();

            //Tin to Iron
            ModRecipe TIrecipe = new ModRecipe(mod);
            TIrecipe.AddIngredient(ItemID.TinOre, 4);
            TIrecipe.AddTile(null, "TransmutationTable");
            TIrecipe.SetResult(ItemID.IronOre, 3);
            TIrecipe.AddRecipe();

            //Iron to Tin
            ModRecipe ITrecipe = new ModRecipe(mod);
            ITrecipe.AddIngredient(ItemID.IronOre, 3);
            ITrecipe.AddTile(null, "TransmutationTable");
            ITrecipe.SetResult(ItemID.TinOre, 3);
            ITrecipe.AddRecipe();

            //Iron to Lead
            ModRecipe ILrecipe = new ModRecipe(mod);
            ILrecipe.AddIngredient(ItemID.IronOre, 3);
            ILrecipe.AddTile(null, "TransmutationTable");
            ILrecipe.SetResult(ItemID.LeadOre, 3);
            ILrecipe.AddRecipe();

            //Lead to Iron
            ModRecipe LIrecipe = new ModRecipe(mod);
            LIrecipe.AddIngredient(ItemID.LeadOre, 3);
            LIrecipe.AddTile(null, "TransmutationTable");
            LIrecipe.SetResult(ItemID.IronOre, 3);
            LIrecipe.AddRecipe();

            //Lead to Silver
            ModRecipe LSrecipe = new ModRecipe(mod);
            LSrecipe.AddIngredient(ItemID.LeadOre, 5);
            LSrecipe.AddTile(null, "TransmutationTable");
            LSrecipe.SetResult(ItemID.SilverOre, 3);
            LSrecipe.AddRecipe();

            //Silver to Lead
            ModRecipe SLrecipe = new ModRecipe(mod);
            SLrecipe.AddIngredient(ItemID.SilverOre, 3);
            SLrecipe.AddTile(null, "TransmutationTable");
            SLrecipe.SetResult(ItemID.LeadOre, 3);
            SLrecipe.AddRecipe();

            //Silver to Tungsten
            ModRecipe STrecipe = new ModRecipe(mod);
            STrecipe.AddIngredient(ItemID.SilverOre, 4);
            STrecipe.AddTile(null, "TransmutationTable");
            STrecipe.SetResult(ItemID.TungstenOre, 4);
            STrecipe.AddRecipe();

            //Tungsten to Silver
            ModRecipe TSrecipe = new ModRecipe(mod);
            TSrecipe.AddIngredient(ItemID.TungstenOre, 4);
            TSrecipe.AddTile(null, "TransmutationTable");
            TSrecipe.SetResult(ItemID.SilverOre, 4);
            TSrecipe.AddRecipe();

            //Tungsten to Gold
            ModRecipe TGrecipe = new ModRecipe(mod);
            TGrecipe.AddIngredient(ItemID.TungstenOre, 5);
            TGrecipe.AddTile(null, "TransmutationTable");
            TGrecipe.SetResult(ItemID.GoldOre, 4);
            TGrecipe.AddRecipe();

            //Gold to Tungsten
            ModRecipe GTrecipe = new ModRecipe(mod);
            GTrecipe.AddIngredient(ItemID.GoldOre, 4);
            GTrecipe.AddTile(null, "TransmutationTable");
            GTrecipe.SetResult(ItemID.TungstenOre, 4);
            GTrecipe.AddRecipe();

            //Gold to Platinum
            ModRecipe GPrecipe = new ModRecipe(mod);
            GPrecipe.AddIngredient(ItemID.GoldOre, 4);
            GPrecipe.AddTile(null, "TransmutationTable");
            GPrecipe.SetResult(ItemID.PlatinumOre, 4);
            GPrecipe.AddRecipe();

            //Platinum to Gold
            ModRecipe PGrecipe = new ModRecipe(mod);
            PGrecipe.AddIngredient(ItemID.PlatinumOre, 4);
            PGrecipe.AddTile(null, "TransmutationTable");
            PGrecipe.SetResult(ItemID.GoldOre, 4);
            PGrecipe.AddRecipe();

            //Platinum to Cobalt
            ModRecipe PCrecipe = new ModRecipe(mod);
            PCrecipe.AddIngredient(ItemID.PlatinumOre, 6);
            PCrecipe.AddTile(null, "TransmutationTable");
            PCrecipe.AddTile(null, "MineralEnchanter");
            PCrecipe.SetResult(ItemID.CobaltOre, 4);
            PCrecipe.AddRecipe();

            //Cobalt to Platinum
            ModRecipe CPrecipe = new ModRecipe(mod);
            CPrecipe.AddIngredient(ItemID.CobaltOre, 3);
            CPrecipe.AddTile(null, "TransmutationTable");
            CPrecipe.SetResult(ItemID.PlatinumOre, 3);
            CPrecipe.AddRecipe();

            //Cobalt to Palladium
            ModRecipe CParecipe = new ModRecipe(mod);
            CParecipe.AddIngredient(ItemID.CobaltOre, 3);
            CParecipe.AddTile(null, "TransmutationTable");
            CParecipe.SetResult(ItemID.PalladiumOre, 3);
            CParecipe.AddRecipe();

            //Palladium to Cobalt
            ModRecipe PaCrecipe = new ModRecipe(mod);
            PaCrecipe.AddIngredient(ItemID.PalladiumOre, 3);
            PaCrecipe.AddTile(null, "TransmutationTable");
            PaCrecipe.SetResult(ItemID.CobaltOre, 3);
            PaCrecipe.AddRecipe();

            //Palladium to Mythril
            ModRecipe PMrecipe = new ModRecipe(mod);
            PMrecipe.AddIngredient(ItemID.PalladiumOre, 5);
            PMrecipe.AddTile(null, "TransmutationTable");
            PMrecipe.SetResult(ItemID.MythrilOre, 3);
            PMrecipe.AddRecipe();

            //Mythril to Palladium
            ModRecipe MPrecipe = new ModRecipe(mod);
            MPrecipe.AddIngredient(ItemID.MythrilOre, 3);
            MPrecipe.AddTile(null, "TransmutationTable");
            MPrecipe.SetResult(ItemID.PalladiumOre, 3);
            MPrecipe.AddRecipe();

            //Mythril to Orichalcum
            ModRecipe MOrecipe = new ModRecipe(mod);
            MOrecipe.AddIngredient(ItemID.MythrilOre, 4);
            MOrecipe.AddTile(null, "TransmutationTable");
            MOrecipe.SetResult(ItemID.OrichalcumOre, 4);
            MOrecipe.AddRecipe();

            //Orichalcum to Mythril
            ModRecipe OMrecipe = new ModRecipe(mod);
            OMrecipe.AddIngredient(ItemID.OrichalcumOre, 4);
            OMrecipe.AddTile(null, "TransmutationTable");
            OMrecipe.SetResult(ItemID.MythrilOre, 4);
            OMrecipe.AddRecipe();

            //Orichalcum to Adamantite
            ModRecipe OArecipe = new ModRecipe(mod);
            OArecipe.AddIngredient(ItemID.OrichalcumOre, 6);
            OArecipe.AddTile(null, "TransmutationTable");
            OArecipe.SetResult(ItemID.AdamantiteOre, 4);
            OArecipe.AddRecipe();

            //Adamantite to Orichalcum
            ModRecipe AOrecipe = new ModRecipe(mod);
            AOrecipe.AddIngredient(ItemID.AdamantiteOre, 4);
            AOrecipe.AddTile(null, "TransmutationTable");
            AOrecipe.SetResult(ItemID.OrichalcumOre, 4);
            AOrecipe.AddRecipe();

            //Adamantite to Titanium
            ModRecipe ATrecipe = new ModRecipe(mod);
            ATrecipe.AddIngredient(ItemID.AdamantiteOre, 5);
            ATrecipe.AddTile(null, "TransmutationTable");
            ATrecipe.SetResult(ItemID.TitaniumOre, 5);
            ATrecipe.AddRecipe();

            //Titanium to Adamantite
            ModRecipe TArecipe = new ModRecipe(mod);
            TArecipe.AddIngredient(ItemID.TitaniumOre, 5);
            TArecipe.AddTile(null, "TransmutationTable");
            TArecipe.SetResult(ItemID.AdamantiteOre, 5);
            TArecipe.AddRecipe();

            //Bars
            //Copper to Tin
            ModRecipe CTBrecipe = new ModRecipe(mod);
            CTBrecipe.AddIngredient(ItemID.CopperBar, 3);
            CTBrecipe.AddTile(null, "TransmutationTable");
            CTBrecipe.SetResult(ItemID.TinBar, 3);
            CTBrecipe.AddRecipe();

            //Tin to Copper
            ModRecipe TCBrecipe = new ModRecipe(mod);
            TCBrecipe.AddIngredient(ItemID.TinBar, 3);
            TCBrecipe.AddTile(null, "TransmutationTable");
            TCBrecipe.SetResult(ItemID.CopperBar, 3);
            TCBrecipe.AddRecipe();

            //Tin to Iron
            ModRecipe TIBrecipe = new ModRecipe(mod);
            TIBrecipe.AddIngredient(ItemID.TinBar, 4);
            TIBrecipe.AddTile(null, "TransmutationTable");
            TIBrecipe.SetResult(ItemID.IronBar, 3);
            TIBrecipe.AddRecipe();

            //Iron to Tin
            ModRecipe ITBrecipe = new ModRecipe(mod);
            ITBrecipe.AddIngredient(ItemID.IronBar, 3);
            ITBrecipe.AddTile(null, "TransmutationTable");
            ITBrecipe.SetResult(ItemID.TinBar, 3);
            ITBrecipe.AddRecipe();

            //Iron to Lead
            ModRecipe ILBrecipe = new ModRecipe(mod);
            ILBrecipe.AddIngredient(ItemID.IronBar, 3);
            ILBrecipe.AddTile(null, "TransmutationTable");
            ILBrecipe.SetResult(ItemID.LeadBar, 3);
            ILBrecipe.AddRecipe();

            //Lead to Iron
            ModRecipe LIBrecipe = new ModRecipe(mod);
            LIBrecipe.AddIngredient(ItemID.LeadBar, 3);
            LIBrecipe.AddTile(null, "TransmutationTable");
            LIBrecipe.SetResult(ItemID.IronBar, 3);
            LIBrecipe.AddRecipe();

            //Lead to Silver
            ModRecipe LSBrecipe = new ModRecipe(mod);
            LSBrecipe.AddIngredient(ItemID.LeadBar, 5);
            LSBrecipe.AddTile(null, "TransmutationTable");
            LSBrecipe.SetResult(ItemID.SilverBar, 3);
            LSBrecipe.AddRecipe();

            //Silver to Lead
            ModRecipe SLBrecipe = new ModRecipe(mod);
            SLBrecipe.AddIngredient(ItemID.SilverBar, 3);
            SLBrecipe.AddTile(null, "TransmutationTable");
            SLBrecipe.SetResult(ItemID.LeadBar, 3);
            SLBrecipe.AddRecipe();

            //Silver to Tungsten
            ModRecipe STBrecipe = new ModRecipe(mod);
            STBrecipe.AddIngredient(ItemID.SilverBar, 4);
            STBrecipe.AddTile(null, "TransmutationTable");
            STBrecipe.SetResult(ItemID.TungstenBar, 4);
            STBrecipe.AddRecipe();

            //Tungsten to Silver
            ModRecipe TSBrecipe = new ModRecipe(mod);
            TSBrecipe.AddIngredient(ItemID.TungstenBar, 4);
            TSBrecipe.AddTile(null, "TransmutationTable");
            TSBrecipe.SetResult(ItemID.SilverBar, 4);
            TSBrecipe.AddRecipe();

            //Tungsten to Gold
            ModRecipe TGBrecipe = new ModRecipe(mod);
            TGBrecipe.AddIngredient(ItemID.TungstenBar, 5);
            TGBrecipe.AddTile(null, "TransmutationTable");
            TGBrecipe.SetResult(ItemID.GoldBar, 4);
            TGBrecipe.AddRecipe();

            //Gold to Tungsten
            ModRecipe GTBrecipe = new ModRecipe(mod);
            GTBrecipe.AddIngredient(ItemID.GoldBar, 4);
            GTBrecipe.AddTile(null, "TransmutationTable");
            GTBrecipe.SetResult(ItemID.TungstenBar, 4);
            GTBrecipe.AddRecipe();

            //Gold to Platinum
            ModRecipe GPBrecipe = new ModRecipe(mod);
            GPBrecipe.AddIngredient(ItemID.GoldBar, 4);
            GPBrecipe.AddTile(null, "TransmutationTable");
            GPBrecipe.SetResult(ItemID.PlatinumBar, 4);
            GPBrecipe.AddRecipe();

            //Platinum to Gold
            ModRecipe PGBrecipe = new ModRecipe(mod);
            PGBrecipe.AddIngredient(ItemID.PlatinumBar, 4);
            PGBrecipe.AddTile(null, "TransmutationTable");
            PGBrecipe.SetResult(ItemID.GoldBar, 4);
            PGBrecipe.AddRecipe();

            //Platinum to Cobalt
            ModRecipe PCBrecipe = new ModRecipe(mod);
            PCBrecipe.AddIngredient(ItemID.PlatinumBar, 6);
            PCBrecipe.AddTile(null, "TransmutationTable");
            PCBrecipe.AddTile(null, "MineralEnchanter");
            PCBrecipe.SetResult(ItemID.CobaltBar, 4);
            PCBrecipe.AddRecipe();

            //Cobalt to Platinum
            ModRecipe CPBrecipe = new ModRecipe(mod);
            CPBrecipe.AddIngredient(ItemID.CobaltBar, 3);
            CPBrecipe.AddTile(null, "TransmutationTable");
            CPBrecipe.SetResult(ItemID.PlatinumBar, 3);
            CPBrecipe.AddRecipe();

            //Cobalt to Palladium
            ModRecipe CPaBrecipe = new ModRecipe(mod);
            CPaBrecipe.AddIngredient(ItemID.CobaltBar, 3);
            CPaBrecipe.AddTile(null, "TransmutationTable");
            CPaBrecipe.SetResult(ItemID.PalladiumBar, 3);
            CPaBrecipe.AddRecipe();

            //Palladium to Cobalt
            ModRecipe PaCBrecipe = new ModRecipe(mod);
            PaCBrecipe.AddIngredient(ItemID.PalladiumBar, 3);
            PaCBrecipe.AddTile(null, "TransmutationTable");
            PaCBrecipe.SetResult(ItemID.CobaltBar, 3);
            PaCBrecipe.AddRecipe();

            //Palladium to Mythril
            ModRecipe PMBrecipe = new ModRecipe(mod);
            PMBrecipe.AddIngredient(ItemID.PalladiumBar, 5);
            PMBrecipe.AddTile(null, "TransmutationTable");
            PMBrecipe.SetResult(ItemID.MythrilBar, 3);
            PMBrecipe.AddRecipe();

            //Mythril to Palladium
            ModRecipe MPBrecipe = new ModRecipe(mod);
            MPBrecipe.AddIngredient(ItemID.MythrilBar, 3);
            MPBrecipe.AddTile(null, "TransmutationTable");
            MPBrecipe.SetResult(ItemID.PalladiumBar, 3);
            MPBrecipe.AddRecipe();

            //Mythril to Orichalcum
            ModRecipe MOBrecipe = new ModRecipe(mod);
            MOBrecipe.AddIngredient(ItemID.MythrilBar, 4);
            MOBrecipe.AddTile(null, "TransmutationTable");
            MOBrecipe.SetResult(ItemID.OrichalcumBar, 4);
            MOBrecipe.AddRecipe();

            //Orichalcum to Mythril
            ModRecipe OMBrecipe = new ModRecipe(mod);
            OMBrecipe.AddIngredient(ItemID.OrichalcumBar, 4);
            OMBrecipe.AddTile(null, "TransmutationTable");
            OMBrecipe.SetResult(ItemID.MythrilBar, 4);
            OMBrecipe.AddRecipe();

            //Orichalcum to Adamantite
            ModRecipe OABrecipe = new ModRecipe(mod);
            OABrecipe.AddIngredient(ItemID.OrichalcumBar, 6);
            OABrecipe.AddTile(null, "TransmutationTable");
            OABrecipe.SetResult(ItemID.AdamantiteBar, 4);
            OABrecipe.AddRecipe();

            //Adamantite to Orichalcum
            ModRecipe AOBrecipe = new ModRecipe(mod);
            AOBrecipe.AddIngredient(ItemID.AdamantiteBar, 4);
            AOBrecipe.AddTile(null, "TransmutationTable");
            AOBrecipe.SetResult(ItemID.OrichalcumBar, 4);
            AOBrecipe.AddRecipe();

            //Adamantite to Titanium
            ModRecipe ATBrecipe = new ModRecipe(mod);
            ATBrecipe.AddIngredient(ItemID.AdamantiteBar, 5);
            ATBrecipe.AddTile(null, "TransmutationTable");
            ATBrecipe.SetResult(ItemID.TitaniumBar, 5);
            ATBrecipe.AddRecipe();

            //Titanium to Adamantite
            ModRecipe TABrecipe = new ModRecipe(mod);
            TABrecipe.AddIngredient(ItemID.TitaniumBar, 5);
            TABrecipe.AddTile(null, "TransmutationTable");
            TABrecipe.SetResult(ItemID.AdamantiteBar, 5);
            TABrecipe.AddRecipe();


            //Crimson to Corruption
            
            //Undertaker to Musket
            ModRecipe UMrecipe = new ModRecipe(mod);
            UMrecipe.AddIngredient(ItemID.TheUndertaker);
            UMrecipe.AddTile(null, "TransmutationTable");
            UMrecipe.SetResult(ItemID.Musket);
            UMrecipe.AddRecipe();

            //Musket to Undertaker
            ModRecipe MUrecipe = new ModRecipe(mod);
            MUrecipe.AddIngredient(ItemID.Musket);
            MUrecipe.AddTile(null, "TransmutationTable");
            MUrecipe.SetResult(ItemID.TheUndertaker);
            MUrecipe.AddRecipe();

            //Rotted Fork to Ball o' Hurt
            ModRecipe RBrecipe = new ModRecipe(mod);
            RBrecipe.AddIngredient(802);
            RBrecipe.AddTile(null, "TransmutationTable");
            RBrecipe.SetResult(162);
            RBrecipe.AddRecipe();

            //Ball o' Hurt to Rotted Fork
            ModRecipe BRrecipe = new ModRecipe(mod);
            BRrecipe.AddIngredient(162);
            BRrecipe.AddTile(null, "TransmutationTable");
            BRrecipe.SetResult(802);
            BRrecipe.AddRecipe();

            //CrimsonRod to Vilethorn
            ModRecipe CVrecipe = new ModRecipe(mod);
            CVrecipe.AddIngredient(ItemID.CrimsonRod);
            CVrecipe.AddTile(null, "TransmutationTable");
            CVrecipe.SetResult(ItemID.Vilethorn);
            CVrecipe.AddRecipe();

            //Vilethorn to CrimsonRod
            ModRecipe VCrecipe = new ModRecipe(mod);
            VCrecipe.AddIngredient(ItemID.Vilethorn);
            VCrecipe.AddTile(null, "TransmutationTable");
            VCrecipe.SetResult(ItemID.CrimsonRod);
            VCrecipe.AddRecipe();

            //Panic Necklace to Band of Starpower
            ModRecipe PBrecipe = new ModRecipe(mod);
            PBrecipe.AddIngredient(ItemID.PanicNecklace);
            PBrecipe.AddTile(null, "TransmutationTable");
            PBrecipe.SetResult(111);
            PBrecipe.AddRecipe();

            //Band of Starpower to Panic Necklace
            ModRecipe BPrecipe = new ModRecipe(mod);
            BPrecipe.AddIngredient(111);
            BPrecipe.AddTile(null, "TransmutationTable");
            BPrecipe.SetResult(ItemID.PanicNecklace);
            BPrecipe.AddRecipe();

            //Crimson Heart to Shadow Orb
            ModRecipe CSrecipe = new ModRecipe(mod);
            CSrecipe.AddIngredient(3062);
            CSrecipe.AddTile(null, "TransmutationTable");
            CSrecipe.SetResult(ItemID.ShadowOrb);
            CSrecipe.AddRecipe();

            //Shadow Orb to Crimson Heart
            ModRecipe SCrecipe = new ModRecipe(mod);
            SCrecipe.AddIngredient(ItemID.ShadowOrb);
            SCrecipe.AddTile(null, "TransmutationTable");
            SCrecipe.SetResult(3062);
            SCrecipe.AddRecipe();

            //Demonite to Crimtane
            ModRecipe DCrecipe = new ModRecipe(mod);
            DCrecipe.AddIngredient(ItemID.DemoniteOre, 3);
            DCrecipe.AddTile(null, "TransmutationTable");
            DCrecipe.SetResult(ItemID.CrimtaneOre, 3);
            DCrecipe.AddRecipe();

            //Crimtane to Demonite
            ModRecipe CDrecipe = new ModRecipe(mod);
            CDrecipe.AddIngredient(ItemID.CrimtaneOre, 3);
            CDrecipe.AddTile(null, "TransmutationTable");
            CDrecipe.SetResult(ItemID.DemoniteOre, 3);
            CDrecipe.AddRecipe();

            //CrimtaneBar to DemoniteBar
            ModRecipe CDBrecipe = new ModRecipe(mod);
            CDBrecipe.AddIngredient(ItemID.CrimtaneBar, 3);
            CDBrecipe.AddTile(null, "TransmutationTable");
            CDBrecipe.SetResult(ItemID.DemoniteBar, 3);
            CDBrecipe.AddRecipe();

            //DemoniteBar to CrimtaneBar
            ModRecipe DCBrecipe = new ModRecipe(mod);
            DCBrecipe.AddIngredient(ItemID.DemoniteBar, 3);
            DCBrecipe.AddTile(null, "TransmutationTable");
            DCBrecipe.SetResult(ItemID.CrimtaneBar, 3);
            DCBrecipe.AddRecipe();

            //Ebonstone to Crimstone
            ModRecipe ECrecipe = new ModRecipe(mod);
            ECrecipe.AddIngredient(ItemID.EbonstoneBlock);
            ECrecipe.AddTile(null, "TransmutationTable");
            ECrecipe.SetResult(ItemID.CrimstoneBlock);
            ECrecipe.AddRecipe();

            //Crimstone to Ebonstone
            ModRecipe CErecipe = new ModRecipe(mod);
            CErecipe.AddIngredient(ItemID.CrimstoneBlock);
            CErecipe.AddTile(null, "TransmutationTable");
            CErecipe.SetResult(ItemID.EbonstoneBlock);
            CErecipe.AddRecipe();

            //CursedFlame to Ichor
            ModRecipe CIrecipe = new ModRecipe(mod);
            CIrecipe.AddIngredient(ItemID.CursedFlame);
            CIrecipe.AddTile(null, "TransmutationTable");
            CIrecipe.SetResult(ItemID.Ichor);
            CIrecipe.AddRecipe();

            //Ichor to CursedFlame
            ModRecipe ICrecipe = new ModRecipe(mod);
            ICrecipe.AddIngredient(ItemID.Ichor);
            ICrecipe.AddTile(null, "TransmutationTable");
            ICrecipe.SetResult(ItemID.CursedFlame);
            ICrecipe.AddRecipe();

            //Ebonkoi to Hemopiranha
            ModRecipe EHrecipe = new ModRecipe(mod);
            EHrecipe.AddIngredient(ItemID.Ebonkoi);
            EHrecipe.AddTile(null, "TransmutationTable");
            EHrecipe.SetResult(ItemID.Hemopiranha);
            EHrecipe.AddRecipe();

            //Hemopiranha to Ebonkoi
            ModRecipe HErecipe = new ModRecipe(mod);
            HErecipe.AddIngredient(ItemID.Hemopiranha);
            HErecipe.AddTile(null, "TransmutationTable");
            HErecipe.SetResult(ItemID.Ebonkoi);
            HErecipe.AddRecipe();

            //Ebonkoi to CrimsonTigerfish
            ModRecipe ETrecipe = new ModRecipe(mod);
            ETrecipe.AddIngredient(ItemID.Ebonkoi);
            ETrecipe.AddTile(null, "TransmutationTable");
            ETrecipe.SetResult(ItemID.CrimsonTigerfish);
            ETrecipe.AddRecipe();

            //CrimsonTigerfish to Ebonkoi
            ModRecipe TErecipe = new ModRecipe(mod);
            TErecipe.AddIngredient(ItemID.CrimsonTigerfish);
            TErecipe.AddTile(null, "TransmutationTable");
            TErecipe.SetResult(ItemID.Ebonkoi);
            TErecipe.AddRecipe();

            //CrimsonSeeds to CorruptSeeds
            ModRecipe CCrecipe = new ModRecipe(mod);
            CCrecipe.AddIngredient(ItemID.CrimsonSeeds);
            CCrecipe.AddTile(null, "TransmutationTable");
            CCrecipe.SetResult(ItemID.CorruptSeeds);
            CCrecipe.AddRecipe();

            //CorruptSeeds to CrimsonSeeds
            ModRecipe CCsrecipe = new ModRecipe(mod);
            CCsrecipe.AddIngredient(ItemID.CorruptSeeds);
            CCsrecipe.AddTile(null, "TransmutationTable");
            CCsrecipe.SetResult(ItemID.CrimsonSeeds);
            CCsrecipe.AddRecipe();

            //Crafting Life Fruits
            ModRecipe LFrecipe = new ModRecipe(mod);
            LFrecipe.AddIngredient(ItemID.LifeCrystal);
            LFrecipe.AddIngredient(1006, 5);
            LFrecipe.AddTile(null, "TransmutationTable");
            LFrecipe.SetResult(ItemID.LifeFruit);
            LFrecipe.AddRecipe();
        }
    }
}