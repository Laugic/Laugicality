using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Laugicality.Items.Armor
{
	[AutoloadEquip(EquipType.Body)]
	public class BysmalChestguard : ModItem
	{
		public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Bysmal Chestguard");
            Tooltip.SetDefault("(20 Defense, +20 Defense when in the Etherial)");
		}

		public override void SetDefaults()
		{
			item.width = 34;
			item.height = 22;
			item.value = 10000;
			item.rare = 3;
			item.defense = 20;
        }

        public override void UpdateEquip(Player player)
        {
            LaugicalityPlayer modPlayer = player.GetModPlayer<LaugicalityPlayer>(mod);
            if (modPlayer.Etherable > 0 || LaugicalityWorld.downedEtheria)
                item.defense = 40;
            else
                item.defense = 20;
        }


        public override bool IsArmorSet(Item head, Item body, Item legs)
        {
            return head.type == mod.ItemType("BysmalMask") && legs.type == mod.ItemType("BysmalBoots");
        }

        public override void UpdateArmorSet(Player player)
        {
            LaugicalityPlayer modPlayer = player.GetModPlayer<LaugicalityPlayer>(mod);
            player.setBonus = "Absorb the power of up to 3 Etherial creatures";
            if(modPlayer.BysmalAbsorbDisabled)
                player.setBonus += "\nLocked- Will not absorb any new bonuses";
            modPlayer.fullBysmal = 2;

            for (int i = 0; i < modPlayer.BysmalPowers.Count; i++)
            {
                if (modPlayer.BysmalPowers[i] ==(NPCID.KingSlime))
                    player.setBonus += "\nSuper Jump Boost & Super Speed Boost while in the Etherial";
                if (modPlayer.BysmalPowers[i] ==(NPCID.EyeofCthulhu))
                    player.setBonus += "\nAllows you to see all creatures, no matter which dimension you are in.";
                if (modPlayer.BysmalPowers[i] ==(NPCID.EaterofWorldsHead))
                    player.setBonus += "\nWhile in the etherial, prevent a hit of lethal damage once every minute. \n20% Damage Reduction";
                if (modPlayer.BysmalPowers[i] ==(NPCID.BrainofCthulhu))
                    player.setBonus += "\nWhile in the etherial, if you would die from contact damage, heal 300 life instead. 3 minute cooldown.\nAfter colliding with an enemy, that enemy takes 50% more damage for 15 seconds.";
                if (modPlayer.BysmalPowers[i] ==(mod.NPCType("Hypothema")))
                    player.setBonus += "\nAttacks inflict 'Frostbite'";
                if (modPlayer.BysmalPowers[i] ==(NPCID.QueenBee))
                    player.setBonus += "\nHoney provides triple the normal regen, 15 defense, and +15% damage while in the Etherial";
                if (modPlayer.BysmalPowers[i] ==(mod.NPCType("Ragnar")))
                    player.setBonus += "\nAfter submerging in Lava in the Etherial, greatly increased attack stats and mobility. +25% Max Life.";
                if (modPlayer.BysmalPowers[i] ==(NPCID.SkeletronHead))
                    player.setBonus += "\nWhile in the Etherial, after taking damage, your damage is boosted by the percentage of your health that was taken for 10 seconds.\nIf this buff is still active when damage is taken again, the boost is stacked.";
                if (modPlayer.BysmalPowers[i] ==(mod.NPCType("AnDio3")))
                    player.setBonus += "\nYour projectiles are immune to Time Stop when in the Etherial";
                if (modPlayer.BysmalPowers[i] ==(NPCID.Retinazer) || modPlayer.BysmalPowers[i] ==(NPCID.Spazmatism))
                    player.setBonus += "\nTaking damage in the Etherial heals you for that damage instead once every 90 seconds.";
                if (modPlayer.BysmalPowers[i] ==(NPCID.TheDestroyer))
                    player.setBonus += "\nYour global damage modifier is applied to your defense while in the Etherial";
                if (modPlayer.BysmalPowers[i] ==(NPCID.SkeletronPrime))
                    player.setBonus += "\nIn the Etherial, deal more damage the lower your life is";
                if (modPlayer.BysmalPowers[i] ==(mod.NPCType("TheAnnihilator")))
                    player.setBonus += "\nKilling an enemy while in the Etherial boosts your damage by 20% for 10 seconds. Killing another enemy in this time resets the timer and stacks the bonus.";
                if (modPlayer.BysmalPowers[i] ==(mod.NPCType("Slybertron")))
                    player.setBonus += "\nAttacks in the Etherial inflict 'Steamified', dealing damage over time, making enemies take more damage, and explode into cogs on death.";
                if (modPlayer.BysmalPowers[i] ==(mod.NPCType("SteamTrain")))
                    player.setBonus += "\nCHOO CHOO! While in the etherial, the faster you move, the higher your damage. Colliding with an enemy deals your movement speed * 500 in damage. Greatly increases Movement Speed.";
                if (modPlayer.BysmalPowers[i] ==(NPCID.Plantera))
                    player.setBonus += "\nIf you are grappled to a tile in the Etherial, +50% Damage & increased life regen.";
                if (modPlayer.BysmalPowers[i] ==(NPCID.Golem))
                    player.setBonus += "\nYour defense is added to your Max Life. Greatly increased Life Regen and +20 Defense while in the Etherial";
                if (modPlayer.BysmalPowers[i] ==(NPCID.DukeFishron))
                    player.setBonus += "\nWater brings you great power in the Etherial";
                if (modPlayer.BysmalPowers[i] ==(NPCID.MoonLordCore))
                    player.setBonus += "\nAll Etherial effects can occur in any dimension";
            }
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(null, "BysmalBar", 18);
            recipe.AddIngredient(null, "EtherialEssence", 4);
            recipe.AddTile(134);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}