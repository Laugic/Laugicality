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
    public class QueenBeeMedallion : ModItem
    {
        public override void SetStaticDefaults()
        {
            Tooltip.SetDefault("A relic of Queen Bee's defeat \nImbues the Soul Stone with Queen Bee's essence \nRight click to activate. Returns the expert item when activated.");
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
            player.QuickSpawnItem(3333, 1);
            Items.Accessories.SoulStone.QB += 1;                                                         //Red  Green Blue
            //Main.NewText("The Soul Stone has absorbed Queen Bee's power.", 200, 200, 0);  //this is the message that will appear when the npc is killed  , 200, 200, 55 is the text color
        }

        public override void AddRecipes()
        {/*
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(3333);
            recipe.SetResult(this);
            recipe.AddRecipe(); 
            */
             ModRecipe Rrecipe = new ModRecipe(mod);
            Rrecipe.AddIngredient(3333);
            Rrecipe.SetResult(null, "HonifiedSoulCrystal");
            Rrecipe.AddRecipe();
            
        }
    }
}