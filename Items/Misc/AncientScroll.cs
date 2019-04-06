using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Laugicality.Items.Misc
{
    public class AncientScroll : ModItem
    {
        string TableOfContents = "'A window into Mystica'\nGives information on the Mystic Class!\nInformation given is based on the amount of scrolls you have in a stack.\nTable of Contents:\n" +
                                 "1: Table of Contents (This page!)\n2: The Mystic Class\n3: Mysticism\n4: Potentia\n5: Duration\n6: Overflow\n7: Bursts\n8: Potentia Conversion\n9: The Origins";
        string TheMysticClass = "- The Mystic Class -\nThe Mystic Class is an ancient class from long ago. In order to harness its power,\nyou have to be able to change between the different Mysticisms at will, and channel their energy\n" + 
                                "through the artifacts of old. In order to do this, set a hotkey for 'Toggle Mysticism' (Right click is recommended).\nThen, when you are holding a Mystic weapon, you should see the magic in action!";
        string Mysticisms = "- Mysticism -\nThe three Mysticisms are Destruction, Conjuration, and Illusion.\nDestruction finds its power through raw destructive strength.\nConjuration spawns many recurring projectiles to overwhelm your foes.\n" +
                            "Illusion inflicts an entourage of debuffs to weaken your enemies.\nFinding the balance in using all three is the key to being the greatest Mystic of all time!";
        string Potentia = "- Potentia -\nPotentia is the measure of how much of a certain Mysticism you can use.\nEach Mysticism has a different Potentia it uses-\nLux is Destruction, Vis is Illusion, and Mundus is Conjuration.\n" +
                          "As you use Potentia, it is discharged from one type to the other 2 that you are not using.\nThis is the main way you regain Potentia, so you must switch Mysticisms to be able to constantly attack.";
        string MysticDuration = "- Duration -\nMystic Duration is a measure of how long Mystic spells last.\nThis represents both how long the life of Mystic projectiles is, as well as how long Illusion debuffs are inflicted for.";
        string Overflow = "- Overflow -\nAs you use Mysticism, you may notice a blue bar appearing at the end of your Potentia bars.\nThis is Overflow. Overflow can typically only be filled through Potentia conversion.\n" +
                          "The amount of Overflow you can have is a percentage of your maximum Potentia.\nBy default it is 25%, so you can get up to 125% of your Potentia through Overflow,\nbut this can be buffed through several different sources.\n" +
                          "Attacks you cast using Overflow can also be buffed specifically to have more damage, or to inflict special effects.\nBe on the lookout for ways that change how you use Overflow!";
        string MysticBursts = "- Bursts -\nMystic Bursts are effects that occur when you switch Mysticisms,\nas long as you are not on Cooldown. Mystic Bursts generally shoot projectiles that damage enemies,\nbut they can also give you buffs, among other things.";
        string PotentiaConversion = "- Potentia Conversion -\nPotentia Conversion refers to the rate that the Potentia of one Mysticism turns into the other Potentias.\nThe default rate is 50%, and this can be buffed from many different sources.\n" +
                                    "You can also buff the Absorption of Potentia for specific Mysticisms.\n'+25% Vis Absorption' would make it so that Lux or Mundus add an additional 25% Potentia to Vis than they otherwise would have.";
        string Origins = "- The Origins -\nTo understand the origins of the Mystic weapons, you must first know of the Moldyrians. Moldyr is a kingdom of Mystics,\nwhose land is rich with Magic and Worship. Hailing to the gods of old,\n" +
                         "they were able to create artifacts infused with some of their power.\nThey devoted their lives to the gods, and in turn, the gods granted them powers few other humans could even dream of rivalling.\n"+
                         "The Moldyrians declared themselves defenders of the world, for so many of the gods loved and cherished the creatures and places on this planet.\nThat also entailed defeating any creatures who dared to threaten the sacredness of the planet, however.\n" +
                         "To be able to accomplish this, they blessed the people of the world with the knowledge of how to create artifacts of their own,\nso that all those devoted enough to the gods could share their power and protect the world.";

        public override void SetDefaults()
        {
            item.width = 16;
            item.height = 16;
            item.maxStack = 9;
            item.rare = 1;
            item.useAnimation = 1;
            item.useTime = 15;
            item.useStyle = 1;
        }

        public override void ModifyTooltips(List<TooltipLine> tooltips)
        {
            Player ttPlayer = Main.player[Main.myPlayer];
            string toolTip = "";
            switch(item.stack)
            {
                case 1:
                    toolTip = TableOfContents;
                    break;
                case 2:
                    toolTip = TheMysticClass;
                    break;
                case 3:
                    toolTip = Mysticisms;
                    break;
                case 4:
                    toolTip = Potentia;
                    break;
                case 5:
                    toolTip = MysticDuration;
                    break;
                case 6:
                    toolTip = Overflow;
                    break;
                case 7:
                    toolTip = MysticBursts;
                    break;
                case 8:
                    toolTip = PotentiaConversion;
                    break;
                case 9:
                    toolTip = Origins;
                    break;
                default:
                    toolTip = TableOfContents;
                    break;
            }
            TooltipLine linePage = new TooltipLine(mod, "", toolTip); tooltips.Add(linePage);
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.Wood, 1);
            recipe.AddIngredient(null, "ArcaneShard", 1);
            recipe.AddTile(TileID.DemonAltar);
            recipe.anyWood = true;
            recipe.SetResult(this, 1);
            recipe.AddRecipe();
        }
    }
}