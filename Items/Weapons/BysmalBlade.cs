using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Laugicality.NPCs;

namespace Laugicality.Items.Weapons
{
	public class BysmalBlade : ModItem
	{
		public override void SetStaticDefaults()
		{
			Tooltip.SetDefault("Tears a hole through dimensions. \nBanishes weak creatures to the Etherial.");	//The (English) text shown below your weapon's name
		}

		public override void SetDefaults()
		{
            item.scale = 2f;
            item.scale *= 1.25f;
			item.damage = 315;			
			item.melee = true;			
			item.width = 144;			
			item.height = 144;			
			item.useTime = 15;			
			item.useAnimation = 15;			
			item.useStyle = 1;			
			item.knockBack = 6;			
			item.value = 10000;			
			item.rare = 7;				
			item.UseSound = SoundID.Item71;		
			item.autoReuse = true;          
        }

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(null, "BysmalBar", 12);
            recipe.AddIngredient(null, "EtherialEssence", 8);
            recipe.AddTile(134);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
        

		public override void OnHitNPC(Player player, NPC target, int damage, float knockback, bool crit)
		{
			if(!LaugicalityVars.ENPCs.Contains(target.type) && !LaugicalityVars.Etherial.Contains(target.type) && target.damage > 0 && target.boss == false)
            {
                target.GetGlobalNPC<EtherialGlobalNPC>(mod).etherial = true;
            }
		}
	}
}
