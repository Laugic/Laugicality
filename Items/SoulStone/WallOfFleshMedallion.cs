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
    public class WallOfFleshMedallion : ModItem
    {
        public override void SetStaticDefaults()
        {
            Tooltip.SetDefault("A relic of The Wall of Flesh's defeat \nImbues the Soul Stone with The Wall of Flesh's essence \nRight click to activate. Returns the best item in the game when activated. \nApologies for temporarily taking it from you.");
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
            player.QuickSpawnItem(ItemID.BreakerBlade, 1);
            Items.Accessories.SoulStone.WoF += 1;                                      //Red  Green Blue
            //Main.NewText("The Soul Stone has absorbed the powers of Light and Darkness.", 240, 100, 150);  //this is the message that will appear when the npc is killed  , 200, 200, 55 is the text color
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.BreakerBlade);
            recipe.SetResult(this);
            recipe.AddRecipe();
            
            ModRecipe Rrecipe = new ModRecipe(mod);
            Rrecipe.AddIngredient(ItemID.BreakerBlade);
            Rrecipe.SetResult(null, "HellishSoulCrystal");
            Rrecipe.AddRecipe();

            ModRecipe Trecipe = new ModRecipe(mod);
            Trecipe.AddIngredient(this);
            Trecipe.SetResult(null, "HellishSoulCrystal");
            Trecipe.AddRecipe();

            ModRecipe Nrecipe = new ModRecipe(mod);
            Nrecipe.AddIngredient(null, "HellishSoulCrystal");
            Nrecipe.SetResult(this);
            Nrecipe.AddRecipe();

        }
    }
}