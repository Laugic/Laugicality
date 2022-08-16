using Laugicality.Items.Loot;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Laugicality.Items.Materials;

namespace Laugicality.Items.Weapons.Range
{
    public class Snowshot : LaugicalityItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Snowshot");
        }

        public override void SetDefaults()
        {
            item.damage = 8;
            item.ranged = true;
            item.width = 50;
            item.height = 26;
            item.useAnimation = item.useTime = 26;
            item.useStyle = 5;
            item.noMelee = true;
            item.knockBack = 2;
            item.value = Item.sellPrice(silver: 10);
            item.rare = ItemRarityID.White;
            item.UseSound = SoundID.Item5;
            item.autoReuse = false;
            item.shootSpeed = 6f;
            item.useAmmo = AmmoID.Snowball;
            item.shoot = ProjectileID.SnowBallFriendly;
        }

        public override Vector2? HoldoutOffset()
        {
            return new Vector2(0, -2);
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.BorealWood, 12);
            recipe.AddIngredient(ItemID.WhiteString);
            recipe.AddTile(TileID.WorkBenches);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}