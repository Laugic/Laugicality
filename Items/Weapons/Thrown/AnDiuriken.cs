using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Laugicality.Items.Weapons.Thrown
{
    public class AnDiuriken : LaugicalityItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("AnDiuriken");
            Tooltip.SetDefault("Stacks up to 4");
        }
        public override void SetDefaults()
        {
            item.damage = 36;           
            item.thrown = true;            
            item.noMelee = true;
            item.width = 30;
            item.height = 20;
            item.useTime = 20;      
            item.useAnimation = 20;   
            item.useStyle = 1;
            item.knockBack = 6;
            item.value = 100000;
            item.rare = ItemRarityID.Orange;
            item.UseSound = SoundID.Item1;
            item.autoReuse = true;       
            item.shoot = ModContent.ProjectileType("AnDiuriken");
            item.shootSpeed = 16f;     
            item.useTurn = true;
            item.maxStack = 4;       
            item.consumable = false;  
            item.noUseGraphic = true;

        }

        public override bool CanUseItem(Player player)
        {
            return player.ownedProjectileCounts[ModContent.ProjectileType("AnDiuriken")] < item.stack;
        }

        public override void AddRecipes()  
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(null, "AndesiaCore", 1);
            recipe.AddIngredient(null, "DioritusCore", 1);
            recipe.AddIngredient(3081, 10);
            recipe.AddIngredient(3086, 25);
            recipe.AddTile(16);
            recipe.SetResult(this, 2);
            recipe.AddRecipe();
        }
    }
}