using System;
using System.Collections.Generic;
using System.IO;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Laugicality.Items.Accessories;
using Laugicality;
using static Laugicality.LaugicalityVars;

namespace Laugicality.Items.SoulStone
{
    public class WarlockStone : ModItem
    {
        public override void SetStaticDefaults()
        {
            Tooltip.SetDefault("Enfuses your soul with the essence of a Warlock \nMagic and Damage focus \nRight click to bind your Soul");
        }
        public override void SetDefaults()
        {
            item.width = 32;
            item.height = 30;
            item.maxStack = 1;
            item.rare = 3;
            item.useAnimation = 45;
            item.useTime = 45;
            item.useStyle = 4;
            item.UseSound = SoundID.Item9;
            //item.consumable = true;
        }

        public override bool CanRightClick()
        {
            return true;
        }


        public override void RightClick(Player player)
        {
            //Player Vars
            player.GetModPlayer<LaugicalityPlayer>().Class = (int)ClassType.Warlock;
            Main.NewText("Your Soul has been bound to the Soul Stone.", 50, 200, 50);  //this is the message that will appear when the npc is killed  , 200, 200, 55 is the text color
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.FallenStar);
            recipe.AddIngredient(ItemID.Amethyst);
            recipe.AddTile(null, "AlchemicalInfuser");
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}