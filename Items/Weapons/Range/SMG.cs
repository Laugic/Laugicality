using Laugicality.Items.Loot;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Laugicality.Items.Materials;

namespace Laugicality.Items.Weapons.Range
{
    public class SMG : LaugicalityItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("S.M.G.");
            Tooltip.SetDefault("'Snow Machine Gun'\n20% chance not to consume ammo");
        }

        public override void SetDefaults()
        {
            item.damage = 12;
            item.ranged = true;
            item.width = 50;
            item.height = 26;
            item.useTime = 12;
            item.useAnimation = 12;
            item.useStyle = 5;
            item.noMelee = true;
            item.knockBack = 2;
            item.value = 1000;
            item.rare = ItemRarityID.Green;
            item.UseSound = SoundID.Item34;
            item.autoReuse = true;
            item.shootSpeed = 13f;
            item.useAmmo = AmmoID.Snowball;
            item.shoot = ProjectileID.SnowBallFriendly;
        }

        public override bool ConsumeAmmo(Player player)
        {
            if (Main.rand.Next(5) == 0)
                return false;
            return base.ConsumeAmmo(player);
        }

        public override Vector2? HoldoutOffset()
        {
            return new Vector2(-5, 0);
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.SnowballCannon);
            recipe.AddIngredient(mod.ItemType<FrostShard>());
            recipe.AddIngredient(mod.ItemType<ChilledBar>(), 12);
            recipe.AddTile(TileID.Anvils);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}