using Laugicality.Items.Materials;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Laugicality.Items.Tools
{
	public class ObsidiumPickaxe : LaugicalityItem
	{
		public override void SetStaticDefaults()
		{
			Tooltip.SetDefault("'It's molten inside'");
		}

		public override void SetDefaults()
		{
			item.damage = 20;
			item.melee = true;
			item.width = 40;
			item.height = 40;
			item.useTime = 15;
			item.useAnimation = 30;
			item.pick = 100;
			item.useStyle = 1;
			item.knockBack = 6;
            item.value = Item.sellPrice(gold: 1);
            item.rare = ItemRarityID.Orange;
            item.UseSound = SoundID.Item1;
			item.autoReuse = true;
		}

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(mod, nameof(ObsidiumBar), 14);
            recipe.AddIngredient(ItemID.Obsidian, 10);
            recipe.AddTile(16);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}