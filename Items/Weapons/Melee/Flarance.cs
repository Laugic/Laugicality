using Laugicality.Items.Materials;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Laugicality.Items.Weapons.Melee
{
    class Flarance : LaugicalityItem
    {
        public override void SetStaticDefaults()
        {
            Tooltip.SetDefault("'Eruptions fly forth'");
        }

        public override void SetDefaults()
        {
            item.damage = 24;           
            item.melee = true;          
            item.width = 42;            
            item.height = 48;           
            item.useTime = 25;          
            item.useAnimation = 25;         
            item.useStyle = 1;          
            item.knockBack = 5;         
            item.value = 10000;         
            item.rare = ItemRarityID.Green;              
            item.UseSound = SoundID.Item1;    
            item.autoReuse = true;
            item.shoot = mod.ProjectileType("Flarance");
            item.shootSpeed = 14f;
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(mod, nameof(ObsidiumBar), 12);
            recipe.AddTile(16);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}
