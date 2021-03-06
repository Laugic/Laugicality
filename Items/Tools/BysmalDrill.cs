using Laugicality.Items.Loot;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Laugicality.Items.Tools
{
    public class BysmalDrill : LaugicalityItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Drill-o-Tron 5000");
            Tooltip.SetDefault("'To the core.'");
        }

        public override void SetDefaults()
        {
            item.damage = 90;
            item.melee = true;
            item.width = 82;
            item.height = 34;
            item.useTime = 3;
            item.useAnimation = 12;
            item.channel = true;
            item.noUseGraphic = true;
            item.noMelee = true;
            item.pick = 250;
            item.tileBoost += 8;
            item.useStyle = 5;
            item.knockBack = 6;
            item.value = Item.sellPrice(0, 12, 0, 0);
            item.rare = ItemRarityID.Purple;
            item.UseSound = SoundID.Item23;
            item.autoReuse = true;
            item.shoot = ModContent.ProjectileType<Projectiles.Tools.BysmalDrillProjectile>();
            item.shootSpeed = 40f;
        }
        /*
        public override bool UseItem(Player player)
        {
            float mag = 14f;
            player.velocity = mag * player.DirectionTo(Main.MouseWorld);
            //player.pickSpeed = 0.00001f;
            for(int i = -1; i < 2; i++)
            {
                for(int j = -1; j < 2; j++)
                {
                    int k = Main.SmartCursorX + i;
                    int l = Main.SmartCursorY + j;
                    Terraria.WorldGen.KillTile(k, l);
                }
            }
            return true;
        }*/
        public override void HoldItem(Player player)
        {
            if (player.itemAnimation > 0)
            {
                if (Main.SmartCursorShowing)
                {
                    float mag = 14f;
                    player.velocity = mag * player.DirectionTo(new Vector2(Main.SmartCursorX * 16, Main.SmartCursorY * 16));
                    for (int i = -1; i < 2; i++)
                    {
                        for (int j = -1; j < 2; j++)
                        {
                            int k = Main.SmartCursorX + i;
                            int l = Main.SmartCursorY + j;
                            player.PickTile(k, l, item.pick);
                        }
                    }
                }
            }
        }
        public override void OnHitNPC(Player player, NPC target, int damage, float knockback, bool crit)
        {
            float mag = 14f;
            player.velocity = mag * player.DirectionTo(Main.MouseWorld);
        }
        
        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(null, "BysmalBar", 18);
            recipe.AddIngredient(mod, nameof(EtherialEssence), 10);
            recipe.AddTile(TileID.MythrilAnvil);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}
