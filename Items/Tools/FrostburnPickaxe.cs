using Laugicality.Items.Loot;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Laugicality.Items.Tools
{
	public class FrostburnPickaxe : LaugicalityItem
	{
		public override void SetStaticDefaults()
		{
			Tooltip.SetDefault("'The best of both worlds'");
		}

		public override void SetDefaults()
		{
			item.damage = 40;
			item.melee = true;
			item.width = 40;
			item.height = 40;
			item.useTime = 10;
			item.useAnimation = 20;
			item.pick = 160;
			item.useStyle = 1;
			item.knockBack = 6;
            item.value = Item.sellPrice(gold: 2);
            item.rare = ItemRarityID.Pink;
            item.UseSound = SoundID.Item1;
			item.autoReuse = true;
		}

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(null, "FrigidPickaxe", 1);
            recipe.AddIngredient(null, "ObsidiumPickaxe", 1);
            recipe.AddIngredient(mod, nameof(SoulOfSought), 8);
            recipe.AddIngredient(mod, nameof(SoulOfHaught), 8);
            recipe.AddTile(TileID.MythrilAnvil);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}