using Laugicality.Items.Loot;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Laugicality.Items.Weapons.Summon
{
    public class ArcticHydra : LaugicalityItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Arctic Hydra Staff");
            Tooltip.SetDefault("'The beast of many Heads'\nWhen in the Etherial after defeating Etheria, Double Damage and Aggro range.");
        }

        public override void SetDefaults()
        {
            item.damage = 100;
            item.summon = true;
            item.mana = 16;
            item.width = 48;
            item.height = 48;
            item.useTime = 36;
            item.useAnimation = 36;
            item.useStyle = 1;
            item.noMelee = true;
            item.knockBack = 3;
            item.value = Item.buyPrice(0, 25, 0, 0);
            item.rare = ItemRarityID.Lime;
            item.UseSound = SoundID.Item44;
            item.shoot = ModContent.ProjectileType("ArcticHydraHead");
            item.shootSpeed = 0;
            item.buffType = ModContent.BuffType("ArcticHydra");
            item.buffTime = 60;
        }

        public override void HoldItem(Player player)
        {
            if ((LaugicalityWorld.downedEtheria || LaugicalityPlayer.Get(player).Etherable > 0) && LaugicalityWorld.downedTrueEtheria)
            {
                item.damage = 200;
            }
            else
            {
                item.damage = 100;
            }
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(null, "BysmalBar", 14);
            recipe.AddIngredient(mod, nameof(EtherialEssence), 6);
            recipe.AddIngredient(ItemID.StaffoftheFrostHydra);
            recipe.AddTile(null, "AlchemicalInfuser");
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}