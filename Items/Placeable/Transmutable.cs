using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Laugicality.Items.Placeable
{
    public class Transmutable : LaugicalityItem
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
            CTrecipe.AddTile(mod, nameof(Tiles.TransmutationTable));
            CTrecipe.SetResult(ItemID.TinOre, 3);
            CTrecipe.AddRecipe();

            //Tin to Copper
            ModRecipe TCrecipe = new ModRecipe(mod);
            TCrecipe.AddIngredient(ItemID.TinOre, 3);
            TCrecipe.AddTile(mod, nameof(Tiles.TransmutationTable));
            TCrecipe.SetResult(ItemID.CopperOre, 3);
            TCrecipe.AddRecipe();

            //Iron to Lead
            ModRecipe ILrecipe = new ModRecipe(mod);
            ILrecipe.AddIngredient(ItemID.IronOre, 3);
            ILrecipe.AddTile(mod, nameof(Tiles.TransmutationTable));
            ILrecipe.SetResult(ItemID.LeadOre, 3);
            ILrecipe.AddRecipe();

            //Lead to Iron
            ModRecipe LIrecipe = new ModRecipe(mod);
            LIrecipe.AddIngredient(ItemID.LeadOre, 3);
            LIrecipe.AddTile(mod, nameof(Tiles.TransmutationTable));
            LIrecipe.SetResult(ItemID.IronOre, 3);
            LIrecipe.AddRecipe();

            //Silver to Tungsten
            ModRecipe STrecipe = new ModRecipe(mod);
            STrecipe.AddIngredient(ItemID.SilverOre, 4);
            STrecipe.AddTile(mod, nameof(Tiles.TransmutationTable));
            STrecipe.SetResult(ItemID.TungstenOre, 4);
            STrecipe.AddRecipe();

            //Tungsten to Silver
            ModRecipe TSrecipe = new ModRecipe(mod);
            TSrecipe.AddIngredient(ItemID.TungstenOre, 4);
            TSrecipe.AddTile(mod, nameof(Tiles.TransmutationTable));
            TSrecipe.SetResult(ItemID.SilverOre, 4);
            TSrecipe.AddRecipe();

            //Gold to Platinum
            ModRecipe GPrecipe = new ModRecipe(mod);
            GPrecipe.AddIngredient(ItemID.GoldOre, 4);
            GPrecipe.AddTile(mod, nameof(Tiles.TransmutationTable));
            GPrecipe.SetResult(ItemID.PlatinumOre, 4);
            GPrecipe.AddRecipe();

            //Platinum to Gold
            ModRecipe PGrecipe = new ModRecipe(mod);
            PGrecipe.AddIngredient(ItemID.PlatinumOre, 4);
            PGrecipe.AddTile(mod, nameof(Tiles.TransmutationTable));
            PGrecipe.SetResult(ItemID.GoldOre, 4);
            PGrecipe.AddRecipe();

            //Bars
            //Copper to Tin
            ModRecipe CTBrecipe = new ModRecipe(mod);
            CTBrecipe.AddIngredient(ItemID.CopperBar, 3);
            CTBrecipe.AddTile(mod, nameof(Tiles.TransmutationTable));
            CTBrecipe.SetResult(ItemID.TinBar, 3);
            CTBrecipe.AddRecipe();

            //Tin to Copper
            ModRecipe TCBrecipe = new ModRecipe(mod);
            TCBrecipe.AddIngredient(ItemID.TinBar, 3);
            TCBrecipe.AddTile(mod, nameof(Tiles.TransmutationTable));
            TCBrecipe.SetResult(ItemID.CopperBar, 3);
            TCBrecipe.AddRecipe();

            //Iron to Lead
            ModRecipe ILBrecipe = new ModRecipe(mod);
            ILBrecipe.AddIngredient(ItemID.IronBar, 3);
            ILBrecipe.AddTile(mod, nameof(Tiles.TransmutationTable));
            ILBrecipe.SetResult(ItemID.LeadBar, 3);
            ILBrecipe.AddRecipe();

            //Lead to Iron
            ModRecipe LIBrecipe = new ModRecipe(mod);
            LIBrecipe.AddIngredient(ItemID.LeadBar, 3);
            LIBrecipe.AddTile(mod, nameof(Tiles.TransmutationTable));
            LIBrecipe.SetResult(ItemID.IronBar, 3);
            LIBrecipe.AddRecipe();

            //Silver to Tungsten
            ModRecipe STBrecipe = new ModRecipe(mod);
            STBrecipe.AddIngredient(ItemID.SilverBar, 4);
            STBrecipe.AddTile(mod, nameof(Tiles.TransmutationTable));
            STBrecipe.SetResult(ItemID.TungstenBar, 4);
            STBrecipe.AddRecipe();

            //Tungsten to Silver
            ModRecipe TSBrecipe = new ModRecipe(mod);
            TSBrecipe.AddIngredient(ItemID.TungstenBar, 4);
            TSBrecipe.AddTile(mod, nameof(Tiles.TransmutationTable));
            TSBrecipe.SetResult(ItemID.SilverBar, 4);
            TSBrecipe.AddRecipe();

            //Gold to Platinum
            ModRecipe GPBrecipe = new ModRecipe(mod);
            GPBrecipe.AddIngredient(ItemID.GoldBar, 4);
            GPBrecipe.AddTile(mod, nameof(Tiles.TransmutationTable));
            GPBrecipe.SetResult(ItemID.PlatinumBar, 4);
            GPBrecipe.AddRecipe();

            //Platinum to Gold
            ModRecipe PGBrecipe = new ModRecipe(mod);
            PGBrecipe.AddIngredient(ItemID.PlatinumBar, 4);
            PGBrecipe.AddTile(mod, nameof(Tiles.TransmutationTable));
            PGBrecipe.SetResult(ItemID.GoldBar, 4);
            PGBrecipe.AddRecipe();
        }
    }
}