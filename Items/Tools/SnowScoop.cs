using Laugicality.Items.Materials;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Laugicality.Items.Tools
{
    public class SnowScoop : LaugicalityItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("The Scoop Mk II");
            Tooltip.SetDefault("Gathers snowballs from snow");
        }
        public override void SetDefaults()
        {
            item.damage = 4;
            item.melee = true;
            item.width = 40;
            item.height = 40;
            item.pick = 25;
            item.useAnimation = item.useTime = 12;
            item.useStyle = 1;
            item.knockBack = 1;
            item.value = Item.sellPrice(silver: 10);
            item.rare = ItemRarityID.Blue;
            item.UseSound = SoundID.Item1;
            item.autoReuse = true;
        }

        public override void HoldItem(Player player)
        {
            if (player.itemAnimation == player.itemAnimationMax - 1)
            {
                int x;
                int y;
                if(Main.SmartCursorShowing)
                {
                    x = Main.SmartCursorX;
                    y = Main.SmartCursorY;
                }
                else
                {
                    x = (int)Main.MouseWorld.X / 16;
                    y = (int)Main.MouseWorld.Y / 16;
                }
                if (Main.tile[x, y] != null && Main.tile[x, y].type == TileID.SnowBlock && Main.netMode != 1 && LaugicalityWorld.Distance(x, y, player.position.X / 16, player.position.Y / 16) <= player.lastTileRangeX + .25)
                {
                    Item.NewItem(new Vector2(x * 16 + 4, y * 16), ItemID.Snowball, Main.rand.Next(1, 3));
                }
            }
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.IronBar, 6);
            recipe.anyIronBar = true;
            recipe.AddTile(16);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}
