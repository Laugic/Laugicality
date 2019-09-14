using Laugicality.Items.Loot;
using Terraria.ID;
using Terraria.ModLoader;

namespace Laugicality.Items.Weapons.Melee
{
    public class BysmalBrand : LaugicalityItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Borealis");
            Tooltip.SetDefault("'The great frost comes'\nWhile in the Etherial after defeating Etheria, Borealis projectiles spawn twice as many Bysmal Blasts on hit");
        }

        public override void SetDefaults()
        {
            item.scale *= 1.25f;
            item.damage = 110;
            item.melee = true;
            item.width = 144;
            item.height = 144;
            item.useTime = 22;
            item.useAnimation = 22;
            item.useStyle = 1;
            item.knockBack = 6;
            item.value = 10000;
            item.rare = ItemRarityID.Lime;
            item.UseSound = SoundID.Item1;
            item.autoReuse = true;
            item.shoot = mod.ProjectileType("Borealis");
            item.shootSpeed = 18f;
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(null, "Aurora", 1);
            recipe.AddIngredient(null, "BysmalBar", 12);
            recipe.AddIngredient(mod, nameof(EtherialEssence), 5);
            recipe.AddTile(null, "AlchemicalInfuser");
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
        /*
        public override void OnHitNPC(Player player, NPC target, int damage, float knockback, bool crit)
        {
            if(!LaugicalityVars.ENPCs.Contains(target.type) && !LaugicalityVars.etherial.Contains(target.type) && target.damage > 0 && target.boss == false)
            {
                target.GetGlobalNPC<EtherialGlobalNPC>(mod).etherial = true;
            }
            target.AddBuff(mod.BuffType("Frostbite"), 2 * 60);
        }*/
    }
}
