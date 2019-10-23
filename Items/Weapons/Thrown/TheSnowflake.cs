using Terraria.ID;
using Terraria.ModLoader;

namespace Laugicality.Items.Weapons.Thrown
{
    public class TheSnowflake : LaugicalityItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Snowflake");
            Tooltip.SetDefault("");
        }
        public override void SetDefaults()
        {
            item.damage = 30;           
            item.thrown = true;             
            item.noMelee = true;
            item.width = 38;
            item.height = 38;
            item.useTime = 45;      
            item.useAnimation = 45;   
            item.useStyle = 1;
            item.knockBack = 6;
            item.value = 100000;
            item.rare = ItemRarityID.Blue;   
            item.UseSound = SoundID.Item1;
            item.autoReuse = true;       
            item.shoot = ModContent.ProjectileType("TheSnowflake"); 
            item.shootSpeed = 6f;     
            item.useTurn = true;
            item.maxStack = 999;       
            item.consumable = true;  
            item.noUseGraphic = true;

        }
        public override void AddRecipes()  
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(null, "ChilledBar", 4);
            recipe.AddIngredient(null, "FrostShard", 1);
            recipe.AddTile(16);
            recipe.SetResult(this, 200);
            recipe.AddRecipe();
        }
    }
}