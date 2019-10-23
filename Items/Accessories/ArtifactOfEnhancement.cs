using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Laugicality.Items.Accessories
{
    public class ArtifactOfEnhancement : LaugicalityItem
    {
        public override void SetStaticDefaults()
        {
            Tooltip.SetDefault("Mastery of all");
        }

        public override void SetDefaults()
        {
            item.width = 72;
            item.height = 72;
            item.value = 10000;
            item.rare = ItemRarityID.Red;
            item.accessory = true;
            item.defense = 4;
            item.lifeRegen = 2;
        }

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            LaugicalityPlayer modPlayer = LaugicalityPlayer.Get(player);
            if (modPlayer.SoulStoneVisuals)
            {
                if (modPlayer.spelunker)
                    player.findTreasure = true;
                Lighting.AddLight((int)(player.position.X + (float)(player.width / 2)) / 16, (int)(player.position.Y + (float)(player.height / 2)) / 16, 0.8f, 0.95f, 1f);
                if (modPlayer.owl)
                    player.nightVision = true;
                if (modPlayer.hunter)
                    player.detectCreature = true;
                if (modPlayer.danger)
                    player.dangerSense = true;
                if(modPlayer.inf)
                    player.AddBuff(116, 2);
            }
            if (modPlayer.SoulStoneMovement)
            {
                if (modPlayer.feather)
                    player.slowFall = true;
            }
            player.maxMinions++;
            player.resistCold = true;
            player.lifeMagnet = true;
            player.statLifeMax2 += (player.statLifeMax + player.statLifeMax2) / 5 / 20 * 20 - (player.statLifeMax / 5 / 20 * 20);
            player.lavaImmune = true;
            player.fireWalk = true;
            player.buffImmune[24] = true;
            if (modPlayer.ww)
                player.waterWalk = true;
            player.gills = true;
            player.ignoreWater = true;
            player.accFlipper = true;
            player.cratePotion = true;
            player.sonarPotion = true;
            player.fishingSkill += 15;
            player.tileSpeed += 0.25f;
            player.wallSpeed += 0.25f;
            player.blockRange++;
            player.pickSpeed -= 0.25f;
            player.moveSpeed += 0.25f;
            player.endurance += 0.10f;
            player.allDamage += 0.10f;
            player.meleeCrit += 10;
            player.rangedCrit += 10;
            player.magicCrit += 10;
            player.thrownCrit += 10;
            player.manaRegenBonus += 25;
            player.magicDamage += 0.20f;
            player.kbBuff = true;
            if (player.thorns < 1f)
            {
                player.thorns = 0.333333343f;
            }
            player.ammoCost80 = true;
            player.rangedDamage += 0.10f;
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(null, "AncientRelic", 1);
            recipe.AddIngredient(null, "CursedRelic", 1);
            recipe.AddIngredient(null, "HallowedRelic", 1);
            recipe.AddTile(412);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}