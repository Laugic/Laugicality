using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Laugicality.Items.Weapons.Melee
{
    public class BrassClaymore : ModItem
    {
        public override void SetStaticDefaults()
        {
            Tooltip.SetDefault("Inflicts 'Steamy'");
        }

        public override void SetDefaults()
        {
            item.scale = 2f;
            item.damage = 99;
            item.melee = true;
            item.width = 54;
            item.height = 64;
            item.useTime = 12;
            item.useAnimation = 12;
            item.useStyle = 1;
            item.knockBack = 6;
            item.value = 10000;
            item.rare = 7;
            item.UseSound = SoundID.Item71;
            item.autoReuse = true;
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(null, "SteamBar", 14);
            recipe.AddIngredient(ItemID.Cog, 20);
            recipe.AddTile(TileID.MythrilAnvil);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
        
        public override void OnHitNPC(Player player, NPC target, int damage, float knockback, bool crit)
        {
            target.AddBuff(mod.BuffType("Steamy"), 5 * 60);
        }
    }
}
