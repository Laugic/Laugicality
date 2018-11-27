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
            Tooltip.SetDefault("+20 Defense when in the Etherial");
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
            if (modPlayer.etherable || LaugicalityWorld.downedEtheria)
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
            modPlayer.fullBysmal = 2;
            
            if (modPlayer.bysmalPowers.Contains(NPCID.KingSlime))
                player.setBonus += "\nSuper Jump Boost while in the Etherial";
            if (modPlayer.bysmalPowers.Contains(NPCID.EyeofCthulhu))
                player.setBonus += "\nAllows you to see all creatures, no matter which dimension you are in.";
            if (modPlayer.bysmalPowers.Contains(NPCID.EaterofWorldsHead))
                player.setBonus += "\nWhile in the etherial, prevent a hit of lethal damage once every minute. \n20% Damage Reduction";
            if (modPlayer.bysmalPowers.Contains(NPCID.BrainofCthulhu))
                player.setBonus += "\nWhile in the etherial, if you would die from contact damage, heal 300 life instead. 3 minute cooldown.\nAfter colliding with an enemy, that enemy takes 50% more damage for 15 seconds.";
            if (modPlayer.bysmalPowers.Contains(mod.NPCType("Hypothema")))
                player.setBonus += "\n+30% Melee and Ranged crit when in the Etherial";
            if (modPlayer.bysmalPowers.Contains(NPCID.QueenBee))
                player.setBonus += "\n+30% Movement Speed and Max Run Speed while in the Etherial";
            if (modPlayer.bysmalPowers.Contains(mod.NPCType("Ragnar")))
                player.setBonus += "\n+8 Defense, +60% Throwing Velocity and Mystic Duration while in the Etherial";
            if (modPlayer.bysmalPowers.Contains(NPCID.SkeletronHead))
                player.setBonus += "\n+20% Damage while in the Etherial";
            if (modPlayer.bysmalPowers.Contains(mod.NPCType("AnDio3")))
                player.setBonus += "\nYour projectiles are immune to Time Stop when in the Etherial";
            if (modPlayer.bysmalPowers.Contains(NPCID.Retinazer) || modPlayer.bysmalPowers.Contains(NPCID.Spazmatism))
                player.setBonus += "\n+20% Conjuration Damage and +2 Conjuration Power while in the Etherial";
            if (modPlayer.bysmalPowers.Contains(NPCID.TheDestroyer))
                player.setBonus += "\n+20% Destruction Damage and +2 Destruction Power while in the Etherial";
            if (modPlayer.bysmalPowers.Contains(NPCID.SkeletronPrime))
                player.setBonus += "\n+20% Illusion Damage and +2 Illusion Power while in the Etherial";
            if (modPlayer.bysmalPowers.Contains(mod.NPCType("TheAnnihilator")))
                player.setBonus += "\nIncreases your max number of minions by 4 while in the Etherial";
            if (modPlayer.bysmalPowers.Contains(mod.NPCType("Slybertron")))
                player.setBonus += "\n+30% Throwing damage and +50% Throwing Velocity while in the Etherial";
            if (modPlayer.bysmalPowers.Contains(mod.NPCType("SteamTrain")))
                player.setBonus += "\n+30% Mystic Damage while in the Etherial";
            if (modPlayer.bysmalPowers.Contains(NPCID.Plantera))
                player.setBonus += "\n+30% Crit Chance while in the Etherial";
            if (modPlayer.bysmalPowers.Contains(NPCID.Golem))
                player.setBonus += "\nGreatly increased life regeneration while in the Etherial";
            if (modPlayer.bysmalPowers.Contains(NPCID.DukeFishron))
                player.setBonus += "\nIncreased mobility while in the Etherial";
            if (modPlayer.bysmalPowers.Contains(NPCID.MoonLordCore))
                player.setBonus += "\nAll Etherial effects can occur in any dimension";
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