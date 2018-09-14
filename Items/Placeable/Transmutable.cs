using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Laugicality.Items.Placeable
{
    public class Transmutable : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Transmutable");
            Tooltip.SetDefault("For basic metal transmutations");
        }

        public override void SetDefaults()
        {
            item.width = 32;
            item.height = 16;
            item.maxStack = 99;
            item.useTurn = true;
            item.autoReuse = true;
            item.useAnimation = 15;
            item.useTime = 10;
            item.useStyle = 1;
            item.consumable = true;
            item.value = 150;
            item.createTile = mod.TileType("Transmutable");
        }
        
        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddTile(16); //Anvil
            recipe.AddIngredient(3066, 12); //SmoothMarble
            recipe.AddIngredient(ItemID.Book);
            recipe.SetResult(this);
            recipe.AddRecipe();

            //Ores
            //Copper to Tin
            ModRecipe CTrecipe = new ModRecipe(mod);
            CTrecipe.AddIngredient(ItemID.CopperOre, 3);
            CTrecipe.AddTile(null, "Transmutable");
            CTrecipe.SetResult(ItemID.TinOre, 3);
            CTrecipe.AddRecipe();

            //Tin to Copper
            ModRecipe TCrecipe = new ModRecipe(mod);
            TCrecipe.AddIngredient(ItemID.TinOre, 3);
            TCrecipe.AddTile(null, "Transmutable");
            TCrecipe.SetResult(ItemID.CopperOre, 3);
            TCrecipe.AddRecipe();

            //Iron to Lead
            ModRecipe ILrecipe = new ModRecipe(mod);
            ILrecipe.AddIngredient(ItemID.IronOre, 3);
            ILrecipe.AddTile(null, "Transmutable");
            ILrecipe.SetResult(ItemID.LeadOre, 3);
            ILrecipe.AddRecipe();

            //Lead to Iron
            ModRecipe LIrecipe = new ModRecipe(mod);
            LIrecipe.AddIngredient(ItemID.LeadOre, 3);
            LIrecipe.AddTile(null, "Transmutable");
            LIrecipe.SetResult(ItemID.IronOre, 3);
            LIrecipe.AddRecipe();

            //Silver to Tungsten
            ModRecipe STrecipe = new ModRecipe(mod);
            STrecipe.AddIngredient(ItemID.SilverOre, 4);
            STrecipe.AddTile(null, "Transmutable");
            STrecipe.SetResult(ItemID.TungstenOre, 4);
            STrecipe.AddRecipe();

            //Tungsten to Silver
            ModRecipe TSrecipe = new ModRecipe(mod);
            TSrecipe.AddIngredient(ItemID.TungstenOre, 4);
            TSrecipe.AddTile(null, "Transmutable");
            TSrecipe.SetResult(ItemID.SilverOre, 4);
            TSrecipe.AddRecipe();

            //Gold to Platinum
            ModRecipe GPrecipe = new ModRecipe(mod);
            GPrecipe.AddIngredient(ItemID.GoldOre, 4);
            GPrecipe.AddTile(null, "Transmutable");
            GPrecipe.SetResult(ItemID.PlatinumOre, 4);
            GPrecipe.AddRecipe();

            //Platinum to Gold
            ModRecipe PGrecipe = new ModRecipe(mod);
            PGrecipe.AddIngredient(ItemID.PlatinumOre, 4);
            PGrecipe.AddTile(null, "Transmutable");
            PGrecipe.SetResult(ItemID.GoldOre, 4);
            PGrecipe.AddRecipe();

            //Bars
            //Copper to Tin
            ModRecipe CTBrecipe = new ModRecipe(mod);
            CTBrecipe.AddIngredient(ItemID.CopperBar, 3);
            CTBrecipe.AddTile(null, "Transmutable");
            CTBrecipe.SetResult(ItemID.TinBar, 3);
            CTBrecipe.AddRecipe();

            //Tin to Copper
            ModRecipe TCBrecipe = new ModRecipe(mod);
            TCBrecipe.AddIngredient(ItemID.TinBar, 3);
            TCBrecipe.AddTile(null, "Transmutable");
            TCBrecipe.SetResult(ItemID.CopperBar, 3);
            TCBrecipe.AddRecipe();

            //Iron to Lead
            ModRecipe ILBrecipe = new ModRecipe(mod);
            ILBrecipe.AddIngredient(ItemID.IronBar, 3);
            ILBrecipe.AddTile(null, "Transmutable");
            ILBrecipe.SetResult(ItemID.LeadBar, 3);
            ILBrecipe.AddRecipe();

            //Lead to Iron
            ModRecipe LIBrecipe = new ModRecipe(mod);
            LIBrecipe.AddIngredient(ItemID.LeadBar, 3);
            LIBrecipe.AddTile(null, "Transmutable");
            LIBrecipe.SetResult(ItemID.IronBar, 3);
            LIBrecipe.AddRecipe();

            //Silver to Tungsten
            ModRecipe STBrecipe = new ModRecipe(mod);
            STBrecipe.AddIngredient(ItemID.SilverBar, 4);
            STBrecipe.AddTile(null, "Transmutable");
            STBrecipe.SetResult(ItemID.TungstenBar, 4);
            STBrecipe.AddRecipe();

            //Tungsten to Silver
            ModRecipe TSBrecipe = new ModRecipe(mod);
            TSBrecipe.AddIngredient(ItemID.TungstenBar, 4);
            TSBrecipe.AddTile(null, "Transmutable");
            TSBrecipe.SetResult(ItemID.SilverBar, 4);
            TSBrecipe.AddRecipe();

            //Gold to Platinum
            ModRecipe GPBrecipe = new ModRecipe(mod);
            GPBrecipe.AddIngredient(ItemID.GoldBar, 4);
            GPBrecipe.AddTile(null, "Transmutable");
            GPBrecipe.SetResult(ItemID.PlatinumBar, 4);
            GPBrecipe.AddRecipe();

            //Platinum to Gold
            ModRecipe PGBrecipe = new ModRecipe(mod);
            PGBrecipe.AddIngredient(ItemID.PlatinumBar, 4);
            PGBrecipe.AddTile(null, "Transmutable");
            PGBrecipe.SetResult(ItemID.GoldBar, 4);
            PGBrecipe.AddRecipe();
        }
    }
}