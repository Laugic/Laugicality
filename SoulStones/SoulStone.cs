﻿using System.Collections.Generic;
using Laugicality.Items;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using System;
using Laugicality.Items.Materials;
using Laugicality.Tiles;

namespace Laugicality.SoulStones
{
    public class SoulStone : LaugicalityItem
    {
        public override void SetStaticDefaults()
        {
            base.SetStaticDefaults();

            Tooltip.SetDefault("Absorbs the souls of powerful fallen creatures\nWorks from your Inventory");
        }

        public override void SetDefaults()
        {
            base.SetDefaults();

            item.width = 30;
            item.height = 28;
            item.value = Item.buyPrice(silver: 20);
            item.rare = ItemRarityID.Expert;

            //item.accessory = true;
            Cursed = true;
        }

        //public override bool CanEquipAccessory(Player player, int slot) => base.CanEquipAccessory(player, slot) && player.GetModPlayer<LaugicalityPlayer>().Focus != null;

        public override void ModifyTooltips(List<TooltipLine> tooltips)
        {
            base.ModifyTooltips(tooltips);

            LaugicalityPlayer laugicalityPlayer = LaugicalityPlayer.Get();

            Cursed = !LaugicalityWorld.downedNecrodon;
            if (Cursed)
                tooltips.Add(new TooltipLine(mod, "SoulStoneNoPlayerFocus", "--An otherwordly entity seems to have sealed some of its power--"));

            if (laugicalityPlayer.Focus == null)
            {
                tooltips.Add(new TooltipLine(mod, "SoulStoneNoPlayerFocus", "You must select a Focus to use the Soul Stone!")
                {
                    overrideColor = Color.Red
                });
                return;
            }

            tooltips.Add(new TooltipLine(Laugicality.Instance, "SoulStoneDisplayFocusName", "Your focus is " + laugicalityPlayer.Focus.DisplayName + '.')
            {
                overrideColor = laugicalityPlayer.Focus.AssociatedColor
            });

            for (int i = 0; i < laugicalityPlayer.Focus.EffectsCount; i++)
            {
                if (laugicalityPlayer.Focus.GetEffect(i).Condition(laugicalityPlayer))
                    tooltips.Add(laugicalityPlayer.Focus.GetEffect(i).Tooltip);
            }

            if(LaugicalityWorld.GetCurseCount() > 0)
            {
                tooltips.Add(new TooltipLine(Laugicality.Instance, "CurseLine", "----Curses----")
                {
                    overrideColor = Color.Red
                });

                GetCurseTooltips(tooltips);
            }
            if(!Cursed)
                tooltips.Add(new TooltipLine(mod, "SoulStoneNoPlayerFocus", "--The Curse has been lifted--")
                {
                    overrideColor = Color.Gold
                });
        }

        private static void GetCurseTooltips(List<TooltipLine> tooltips)
        {
            LaugicalityPlayer laugicalityPlayer = LaugicalityPlayer.Get();

            for (int i = 0; i < LaugicalityWorld.GetCurseCount() && i < laugicalityPlayer.Focus.CursesCount; i++)
            {
                for (int j = 0; j < laugicalityPlayer.Focus.NemesesCount; j++)
                {
                    if (laugicalityPlayer.Focus.Nemeses[j].GetCurse(i).Condition(laugicalityPlayer))
                        tooltips.Add(laugicalityPlayer.Focus.Nemeses[j].GetCurse(i).Tooltip);
                }
            }

            for (int i = 0; i < Math.Floor((float)LaugicalityWorld.GetCurseCount() / 2f) && i < laugicalityPlayer.Focus.CursesCount; i++)
            {
                for (int j = 0; j < laugicalityPlayer.Focus.EnemiesCount; j++)
                {
                    if (laugicalityPlayer.Focus.Enemies[j].GetCurse(i).Condition(laugicalityPlayer))
                        tooltips.Add(laugicalityPlayer.Focus.Enemies[j].GetCurse(i).Tooltip);
                }
            }
        }

        public override void UpdateInventory(Player player)
        {
            if (Main.LocalPlayer != player)
                return;

            LaugicalityPlayer laugicalityPlayer = LaugicalityPlayer.Get(Main.LocalPlayer);

            if (laugicalityPlayer.Focus == null)
                return;

            for (int i = 0; i < laugicalityPlayer.Focus.EffectsCount; i++)
            {
                if (laugicalityPlayer.Focus.GetEffect(i).Condition(laugicalityPlayer))
                    laugicalityPlayer.Focus.GetEffect(i).Effect(laugicalityPlayer, item.favorited);
            }

            if (LaugicalityWorld.GetCurseCount() > 0)
                GetCurseEffects(player, item.favorited);
            base.UpdateInventory(player);
        }

        /*
        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            if (Main.LocalPlayer != player)
                return;

            LaugicalityPlayer laugicalityPlayer = LaugicalityPlayer.Get(Main.LocalPlayer);

            if (laugicalityPlayer.Focus == null)
                return;

            for (int i = 0; i < laugicalityPlayer.Focus.EffectsCount; i++)
            {
                if (laugicalityPlayer.Focus.GetEffect(i).Condition(laugicalityPlayer))
                    laugicalityPlayer.Focus.GetEffect(i).Effect(laugicalityPlayer, hideVisual);
            }

            if(LaugicalityWorld.GetCurseCount() > 0)
                GetCurseEffects(player, hideVisual);
            base.UpdateAccessory(player, hideVisual);
        }*/

        private static void GetCurseEffects(Player player, bool hideVisual)
        {
            LaugicalityPlayer laugicalityPlayer = LaugicalityPlayer.Get(player);

            for (int i = 0; i < LaugicalityWorld.GetCurseCount() && i < laugicalityPlayer.Focus.CursesCount; i++)
            {
                for (int j = 0; j < laugicalityPlayer.Focus.NemesesCount; j++)
                {
                    if (laugicalityPlayer.Focus.Nemeses[j].GetCurse(i).Condition(laugicalityPlayer))
                        laugicalityPlayer.Focus.Nemeses[j].GetCurse(i).Effect(laugicalityPlayer, hideVisual);
                }
            }

            for (int i = 0; i < Math.Floor((float)LaugicalityWorld.GetCurseCount() / 2f) && i < laugicalityPlayer.Focus.CursesCount; i++)
            {
                for (int j = 0; j < laugicalityPlayer.Focus.EnemiesCount; j++)
                {
                    if (laugicalityPlayer.Focus.Enemies[j].GetCurse(i).Condition(laugicalityPlayer))
                        laugicalityPlayer.Focus.Enemies[j].GetCurse(i).Effect(laugicalityPlayer, hideVisual);
                }
            }
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.LifeCrystal);
            recipe.AddIngredient(ModContent.ItemType<ArcaneShard>(), 10);
            recipe.AddTile(ModContent.TileType<Tiles.AlchemicalInfuser>());
            recipe.SetResult(this);
            recipe.AddRecipe();
        }

        public bool Cursed { get; set; }
    }
}