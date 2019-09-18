namespace Laugicality.Gadgets
{
    public class Gadget
    {
        public Gadget(int horizontalSlots, int verticalSlots)
        {
            HorizontalSlots = horizontalSlots;
            VerticalSlots = verticalSlots;
        }


        public int HorizontalSlots { get; }
        public int VerticalSlots { get; }
    }
}