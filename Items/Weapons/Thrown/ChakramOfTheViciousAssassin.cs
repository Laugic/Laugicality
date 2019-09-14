using Terraria.ID;

namespace Laugicality.Items.Weapons.Thrown
{
    public class ChakramOfTheViciousAssassin : LaugicalityItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Chakram of The Vicious Assassin");
            Tooltip.SetDefault("'Surround and eliminate'");
        }
        public override void SetDefaults()
        {
            item.damage = 320;           
            item.thrown = true;            
            item.noMelee = true;
            item.width = 90;
            item.height = 90;
            item.useTime = 20;      
            item.useAnimation = 20;   
            item.useStyle = 1;
            item.knockBack = 6;
            item.value = 10;
            item.rare = ItemRarityID.Cyan;
            item.UseSound = SoundID.Item1;
            item.autoReuse = true;       
            item.shoot = mod.ProjectileType("ViciousAssassinMain");  
            item.shootSpeed = 20f;     
            item.useTurn = true;
            item.maxStack = 1;       
            item.consumable = false;  
            item.noUseGraphic = true;

        }
        /*
        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(3467, 16);
            recipe.AddIngredient(null, "NovaFragment", 8);
            recipe.AddTile(412);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }*/

    }
}