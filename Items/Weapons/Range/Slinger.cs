using Laugicality.Items.Loot;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Laugicality.Items.Materials;

namespace Laugicality.Items.Weapons.Range
{
    public class Slinger : LaugicalityItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Slinger");
        }

        public override void SetDefaults()
        {
            item.damage = 14;
            item.ranged = true;
            item.width = 50;
            item.height = 26;
            item.useAnimation = item.useTime = 22;
            item.useStyle = 5;
            item.noMelee = true;
            item.knockBack = 2;
            item.value = Item.sellPrice(silver: 10);
            item.rare = ItemRarityID.Blue;
            item.UseSound = SoundID.Item5;
            item.autoReuse = false;
            item.shootSpeed = 16f;
            item.useAmmo = AmmoID.Snowball;
            item.shoot = ProjectileID.SnowBallFriendly;
        }

        public override Vector2? HoldoutOffset()
        {
            return new Vector2(-5, 0);
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.RichMahogany, 16);
            recipe.AddIngredient(ItemID.Stinger, 4);
            recipe.AddIngredient(ItemID.Vine);
            recipe.AddTile(TileID.WorkBenches);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}