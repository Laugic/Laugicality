using Terraria;
using Terraria.ModLoader;
using Laugicality.Items;

namespace Laugicality.Prefixes
{
    public class Yeeting : ModPrefix
    {
        /*private int power = 0;
        public override float RollChance(Item item)
        {
            return 4f;
        }

        public override bool CanRoll(Item item)
        {
            return true;
        }

        public override PrefixCategory Category { get { return PrefixCategory.Accessory; } }

        public Yeeting()
        {

        }

        public Yeeting(int power)
        {
            this.power = power;
        }

        public override bool Autoload(ref string name)
        {
            if (base.Autoload(ref name))
            {
                mod.AddPrefix("Swift", new Yeeting(1));
                mod.AddPrefix("Speedy", new Yeeting(2));
                mod.AddPrefix("Zippy", new Yeeting(3));
                mod.AddPrefix("Yeeting", new Yeeting(4));
            }
            return false;
        }

        public override void Apply(Item item)
        {
            item.GetGlobalItem<LaugicalityGlobalItem>().yeet = power;
        }

        public override void ModifyValue(ref float valueMult)
        {
            float multiplier = 1f + 0.05f * power;
            valueMult *= multiplier;
        }*/
    }
}