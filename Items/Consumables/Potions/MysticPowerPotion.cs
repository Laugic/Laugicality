using Laugicality.Buffs;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Laugicality.Items.Consumables.Potions
{
	public class MysticPowerPotion : LaugicalityItem
    {
        public override void SetStaticDefaults()
        {
            Tooltip.SetDefault("+10% Mystic Damage");
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
            item.value = Item.sellPrice(silver: 2);
            item.buffType = ModContent.BuffType<MysticPower>();
            item.buffTime = 10800;
        }

        /*
        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.BottledWater, 1);
            recipe.AddIngredient(null, "AlbusDust", 1);
            recipe.AddIngredient(null, "AuraDust", 1);
            recipe.AddIngredient(null, "RubrumDust", 1);
            recipe.AddIngredient(null, "VerdiDust", 1);
            recipe.AddIngredient(null, "RegisDust", 1);
            recipe.AddIngredient(null, "AquosDust", 1);
            recipe.AddTile(13);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }*/
    }
}