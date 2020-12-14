using Laugicality.Buffs;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Laugicality.Items.Consumables.Potions
{
	public class OmegaJumpBoostPotion : LaugicalityItem
    {
        public override void SetStaticDefaults()
        {
            Tooltip.SetDefault("INSANELY increases jump height\n5 minute duration");
        }
        public override void SetDefaults()
		{
			item.width = 24;
			item.height = 24;
			item.maxStack = 30;
			item.rare = ItemRarityID.Blue;
            item.useAnimation = 15;
            item.useTime = 15;
            item.useStyle = 2;
			item.UseSound = SoundID.Item3;
			item.consumable = true;
            item.value = Item.sellPrice(gold: 1);
        }
        

        public override bool UseItem(Player player)
        {
            player.AddBuff(ModContent.BuffType<OmegaJumpBoost>(), 5*60*60, true);
            return true;
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.BottledWater, 1);
            recipe.AddIngredient(ItemID.Feather, 1);
            recipe.AddIngredient(ItemID.PinkGel, 1);
            recipe.AddIngredient(575, 1); //Soul of Flight
            recipe.AddIngredient(1516, 1); //GiantHarpyFeather
            recipe.AddIngredient(null, "VerdiDust", 1);
            recipe.AddTile(13);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}