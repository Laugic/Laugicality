using System;
using System.Collections.Generic;
using System.IO;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Laugicality.Items.Accessories;

namespace Laugicality.Items.SoulStone
{
    public class BumblySoulCrystal : ModItem
    {
        public override void SetStaticDefaults()
        {
            Tooltip.SetDefault("Increases max Minions by 1 \n'You can feel a buzzing in your Soul'\nRight click to activate. Can only activate one part.");
        }
        public override void SetDefaults()
        {
            item.width = 32;
            item.height = 30;
            item.maxStack = 20;
            item.rare = 3;
            item.useAnimation = 45;
            item.useTime = 45;
            item.useStyle = 4;
            item.UseSound = SoundID.Item9;
            item.consumable = true;
        }

        public override bool CanRightClick()
        {
            return true;
        }


        public override void RightClick(Player player)
        {
            player.QuickSpawnItem(3333);
            if (Items.Accessories.SoulStone.QBalt == 0)
            {
                Items.Accessories.SoulStone.QBalt = 1;
                Items.Accessories.SoulStone.QBa += 1;
                Main.NewText("The Soul Stone has absorbed the power.", 200, 150, 0);  //this is the message that will appear when the npc is killed  , 200, 200, 55 is the text color
            }else Main.NewText("The Soul Crystal has been rejected.", 250, 0, 0);  //this is the message that will appear when the npc is killed  , 200, 200, 55 is the text color

        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(null, "HonifiedSoulCrystal");
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}