using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;

namespace Laugicality.Items.Weapons.Magic
{
    public class BysmalWand : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Bysmal Wand");
            Tooltip.SetDefault("'Frigid Breeze'\nWhen in the Etherial after defeating Etheria, shoot an additional blast.");
            Item.staff[item.type] = true;
        }

        public override void SetDefaults()
        {
            item.damage = 250;
            item.magic = true;
            item.mana = 6;
            item.width = 28;
            item.height = 30;
            item.useTime = 8;
            item.useAnimation = 24;
            item.useStyle = 5;
            item.noMelee = true;
            item.knockBack = 5;
            item.value = 10000;
            item.rare = 9;
            item.UseSound = SoundID.Item20;
            item.autoReuse = true;
            item.shoot = mod.ProjectileType("BysmalBlast");
            item.shootSpeed = 24f;
        }

        public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
        {
            Vector2 target = Main.MouseWorld;
            Vector2 vel = player.DirectionTo(target) * item.shootSpeed;
            int n = Projectile.NewProjectile(player.Center.X, player.Center.Y, vel.X, vel.Y, mod.ProjectileType("BysmalWand"), (int)(item.damage), 3, Main.myPlayer);
            Main.projectile[n].ai[0] = 1;
            int M = Projectile.NewProjectile(player.Center.X, player.Center.Y, vel.X, vel.Y, mod.ProjectileType("BysmalWand"), (int)(item.damage), 3, Main.myPlayer);
            Main.projectile[M].ai[0] = -1;
            if ((LaugicalityWorld.downedEtheria || player.GetModPlayer<LaugicalityPlayer>(mod).Etherable > 2) && LaugicalityWorld.downedTrueEtheria)
                return true;
            return false;
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(null, "BysmalBar", 18);
            recipe.AddIngredient(null, "EtherialEssence", 8);
            recipe.AddTile(null, "AlchemicalInfuser");
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}