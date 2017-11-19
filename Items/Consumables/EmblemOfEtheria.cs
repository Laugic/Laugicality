using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Laugicality.Items.Consumables
{
	public class EmblemOfEtheria : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Emblem of Etheria");
            Tooltip.SetDefault("Calls Etheria\n\'This seems like a terrible idea.\'");
        }
        public override void SetDefaults()
		{
			item.width = 32;
			item.height = 32;
			item.maxStack = 20;
			item.rare = 1;
			item.useAnimation = 45;
			item.useTime = 45;
			item.useStyle = 4;
			item.UseSound = SoundID.Item44;
			item.consumable = true;
			item.shoot = mod.ProjectileType("EtheriaSpawn");
		}

        public override bool CanUseItem(Player player)
        {
            if (Main.dayTime || LaugicalityWorld.downedEtheria)
                return true;
            else return false;
        }

        public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.SpookyWood, 100);
            recipe.AddIngredient(ItemID.Ectoplasm, 25);
            recipe.AddTile(26);
			recipe.SetResult(this);
			recipe.AddRecipe();

            ModRecipe Arecipe = new ModRecipe(mod);
            Arecipe.AddIngredient(null, "EtherialEssence", 15);
            Arecipe.AddTile(26);
            Arecipe.SetResult(this);
            Arecipe.AddRecipe();
        }
	}
}