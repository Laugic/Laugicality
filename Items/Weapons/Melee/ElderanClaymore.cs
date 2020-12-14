using Laugicality.Items.Loot;
using Laugicality.Items.Materials;
using Laugicality.Items.Placeable;
using Laugicality.Projectiles.Melee;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Laugicality.Items.Weapons.Melee
{
    public class ElderanClaymore : LaugicalityItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Elderan Claymore");
            Tooltip.SetDefault("'The ancient crystals slot together quite nicely.'");
        }

        public override void SetDefaults()
        {
            item.damage = 56;
            item.crit = 20;
            item.melee = true;
            item.noMelee = false;
            item.width = 60;
            item.height = 60;
            item.useTime = 20;
            item.useAnimation = 20;
            item.useStyle = 1;
            item.knockBack = 6;
            item.value = 10000;
            item.rare = ItemRarityID.LightPurple;
            item.UseSound = SoundID.Item1;
            item.autoReuse = true;
            item.shootSpeed = 16f;
            item.useTurn = true;
            item.maxStack = 1;
            item.consumable = false;
            item.shoot = ModContent.ProjectileType<ElderanClaymoreProjectile>();
        }
        public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
        {
            if(player.ownedProjectileCounts[ModContent.ProjectileType<ElderanClaymoreProjectile>()] < 3)
            {
                Main.PlaySound(SoundID.Item101, player.position);
                return true;
            }
            return false;
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(mod, nameof(ElderPearl), 12);
            recipe.AddIngredient(mod, nameof(ElderockItem), 8);
            recipe.AddIngredient(mod, nameof(ObsidiumRock), 20);
            recipe.AddTile(TileID.MythrilAnvil);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}
