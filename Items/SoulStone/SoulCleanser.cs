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

namespace Laugicality.Items.SoulStone
{
    public class SoulCleanser : ModItem
    {
        public override void SetStaticDefaults()
        {
            Tooltip.SetDefault("Cleanses the Soul Stone bound to your Soul. \nRight click to use. \nCleanses the Soul Stone stats for all other characters.\nYou can regain your progress using medallions");
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
            item.consumable = true;
        }

        public override bool CanRightClick()
        {
            return true;
        }


        public override void RightClick(Player player)
        {
        Items.Accessories.SoulStone.KS = 0;
        Items.Accessories.SoulStone.EoC = 0;
        Items.Accessories.SoulStone.EoW = 0;
        Items.Accessories.SoulStone.EoWBoC = 0;
        Items.Accessories.SoulStone.BoC = 0;
        Items.Accessories.SoulStone.QB = 0;
            Items.Accessories.SoulStone.QBalt = 0;
            Items.Accessories.SoulStone.QBa = 0;
            Items.Accessories.SoulStone.QBb = 0;
        Items.Accessories.SoulStone.SK = 0;
            Items.Accessories.SoulStone.SKalt = 0;
            Items.Accessories.SoulStone.SKa = 0;
            Items.Accessories.SoulStone.SKb = 0;
            Items.Accessories.SoulStone.SKc = 0;
            Items.Accessories.SoulStone.SKd = 0;
            Items.Accessories.SoulStone.SKe = 0;
            Items.Accessories.SoulStone.SKg = 0;
            Items.Accessories.SoulStone.SKh = 0;
        Items.Accessories.SoulStone.WoF = 0;
            Items.Accessories.SoulStone.WoFalt = 0;
            Items.Accessories.SoulStone.WoFa = 0;
            Items.Accessories.SoulStone.WoFb = 0;
            Items.Accessories.SoulStone.SP = 0; //Spas
        Items.Accessories.SoulStone.RT = 0; //Ret
        Items.Accessories.SoulStone.SKP = 0;
        Items.Accessories.SoulStone.DST = 0;
        Items.Accessories.SoulStone.PT = 0;
            Items.Accessories.SoulStone.PTalt = 0;
            Items.Accessories.SoulStone.PTa = 0;
            Items.Accessories.SoulStone.PTb = 0;
        Items.Accessories.SoulStone.GM = 0;
        Items.Accessories.SoulStone.LC = 0;
            Items.Accessories.SoulStone.LCalt = 0;
            Items.Accessories.SoulStone.LCa = 0;
            Items.Accessories.SoulStone.LCb = 0;
        Items.Accessories.SoulStone.DF = 0;
        Items.Accessories.SoulStone.ML = 0;

            /*//Player Vars
            player.GetModPlayer<LaugicalityPlayer>().KS = 0;
            player.GetModPlayer<LaugicalityPlayer>().EoC = 0;
            player.GetModPlayer<LaugicalityPlayer>().EoW = 0;
            player.GetModPlayer<LaugicalityPlayer>().EoWBoC = 0;
            player.GetModPlayer<LaugicalityPlayer>().BoC = 0;
            player.GetModPlayer<LaugicalityPlayer>().QB = 0;
            player.GetModPlayer<LaugicalityPlayer>().QBalt = 0;
            player.GetModPlayer<LaugicalityPlayer>().QBa = 0;
            player.GetModPlayer<LaugicalityPlayer>().QBb = 0;
            player.GetModPlayer<LaugicalityPlayer>().SK = 0;
            player.GetModPlayer<LaugicalityPlayer>().SKalt = 0;
            player.GetModPlayer<LaugicalityPlayer>().SKa = 0;
            player.GetModPlayer<LaugicalityPlayer>().SKb = 0;
            player.GetModPlayer<LaugicalityPlayer>().SKc = 0;
            player.GetModPlayer<LaugicalityPlayer>().SKd = 0;
            player.GetModPlayer<LaugicalityPlayer>().SKe = 0;
            player.GetModPlayer<LaugicalityPlayer>().SKg = 0;
            player.GetModPlayer<LaugicalityPlayer>().SKh = 0;
            player.GetModPlayer<LaugicalityPlayer>().WoF = 0;
            player.GetModPlayer<LaugicalityPlayer>().WoFalt = 0;
            player.GetModPlayer<LaugicalityPlayer>().WoFa = 0;
            player.GetModPlayer<LaugicalityPlayer>().WoFb = 0;
            player.GetModPlayer<LaugicalityPlayer>().SP = 0; //Spas
            player.GetModPlayer<LaugicalityPlayer>().RT = 0; //Ret
            player.GetModPlayer<LaugicalityPlayer>().SKP = 0;
            player.GetModPlayer<LaugicalityPlayer>().DST = 0;
            player.GetModPlayer<LaugicalityPlayer>().PT = 0;
            player.GetModPlayer<LaugicalityPlayer>().PTalt = 0;
            player.GetModPlayer<LaugicalityPlayer>().PTa = 0;
            player.GetModPlayer<LaugicalityPlayer>().PTb = 0;
            player.GetModPlayer<LaugicalityPlayer>().GM = 0;
            player.GetModPlayer<LaugicalityPlayer>().LC = 0;
            player.GetModPlayer<LaugicalityPlayer>().LCalt = 0;
            player.GetModPlayer<LaugicalityPlayer>().LCa = 0;
            player.GetModPlayer<LaugicalityPlayer>().LCb = 0;
            player.GetModPlayer<LaugicalityPlayer>().DF = 0;
            player.GetModPlayer<LaugicalityPlayer>().ML = 0;*/
            //Red  Green Blue
            Main.NewText("Your Soul Stone has been cleansed.", 200, 50, 50);  //this is the message that will appear when the npc is killed  , 200, 200, 55 is the text color
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(75, 2);
            recipe.AddTile(null, "AlchemicalInfuser");
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}