using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;

namespace Laugicality.Gadgets
{
    // Inspired (if not copied) by the Factorio Powerarmor grid.
    public class GadgetGrid
    {
        private Gadget[,] _slots;


        public GadgetGrid(int horizontalSlots, int verticalSlots)
        {
            HorizontalSlots = horizontalSlots;
            VerticalSlots = verticalSlots;

            _slots = new Gadget[horizontalSlots, verticalSlots];
        }


        /// <summary>Tries inserting the <see cref="Gadget"/> into the specified slot (top-left of the <see cref="Gadget"/>).</summary>
        /// <param name="gadget">The <see cref="Gadget"/> to insert.</param>
        /// <param name="topLeftCellIndex">The cell into which to insert the top-left corner of the <see cref="Gadget"/>.</param>
        /// <returns>true if the gadget was successfully inserted; false otherwise.</returns>
        public bool Insert(Gadget gadget, int topLeftCellIndex) => Insert(gadget, GetXY(topLeftCellIndex));

        /// <summary>Tries inserting the <see cref="Gadget"/> into the specified slot (top-left of the <see cref="Gadget"/>).</summary>
        /// <param name="gadget">The <see cref="Gadget"/> to insert.</param>
        /// <param name="topLeftCellPosition">The cell into which to insert the top-left corner of the <see cref="Gadget"/>.</param>
        /// <returns>true if the gadget was successfully inserted; false otherwise.</returns>
        public bool Insert(Gadget gadget, int[] topLeftCellPosition)
        {
            if (!CanHold(gadget, topLeftCellPosition))
                return false;

            for (int x = topLeftCellPosition[0]; x < gadget.HorizontalSlots; x++)
                for (int y = topLeftCellPosition[1]; y < gadget.VerticalSlots; y++)
                    _slots[x, y] = gadget;

            return true;
        }


        public void Remove(int topLeftCellPosition) => Remove(GetXY(topLeftCellPosition));

        public bool Remove(int[] topLeftCellPosition)
        {
            int cellX = topLeftCellPosition[0],
                cellY = topLeftCellPosition[1];

            Gadget foundGadget = _slots[cellX, cellY];

            if (foundGadget == null)
                return false;


            int startXIndex = cellX - (foundGadget.HorizontalSlots - 1),
                startYIndex = cellY - (foundGadget.VerticalSlots - 1);

            if (startXIndex < 0)
                startXIndex = 0;

            if (startYIndex < 0)
                startYIndex = 0;


            int endXIndex = cellX + (foundGadget.HorizontalSlots - 1),
                endYIndex = cellY + (foundGadget.VerticalSlots - 1);

            if (endXIndex >= HorizontalSlots)
                endXIndex = HorizontalSlots;

            if (endYIndex >= VerticalSlots)
                endYIndex = VerticalSlots;


            for (int x = startXIndex; x < endXIndex; x++)
                for (int y = startYIndex; y < endYIndex; y++)
                    if (_slots[x, y] == foundGadget)
                        _slots[x, y] = null;

            return true;
        }


        public bool CanHold(Gadget gadget)
        {
            if (gadget.HorizontalSlots > HorizontalSlots || gadget.VerticalSlots > VerticalSlots)
                return false;

            return true;
        }

        public bool CanHold(Gadget gadget, int topLeftCellIndex) => CanHold(gadget, GetXY(topLeftCellIndex));

        public bool CanHold(Gadget gadget, int[] topLeftCellPosition)
        {
            if (!CanHold(gadget))
                return false;

            // Array indexes start at 0, count starts at 1.
            // For a grid of 1x1, the index would be 0, 0 (top left cell), so we add 1 to each in order to check if its within the bounds.
            if (topLeftCellPosition[0] + 1 + gadget.HorizontalSlots > HorizontalSlots || topLeftCellPosition[1] + 1 + gadget.VerticalSlots > VerticalSlots)
                return false;

            for (int i = topLeftCellPosition[0]; i < topLeftCellPosition[0] + gadget.HorizontalSlots; i++)
                for (int j = topLeftCellPosition[1]; j < topLeftCellPosition[1] + gadget.VerticalSlots; j++)
                    if (_slots[i, j] != null)
                        return false;

            return true;
        }


        public bool Contains(Gadget gadget) => ForAnySlot(g => g != null && g == gadget);

        public bool ContainsOfType(Gadget gadget) => ForAnySlot(g => g != null && g.GetType() == gadget.GetType());


        public int Count()
        {
            List<Gadget> distinct = new List<Gadget>();

            ForAllSlots(g =>
            {
                if (g != null && !distinct.Contains(g))
                    distinct.Add(g);
            });

            return distinct.Count;
        }


        public Rectangle GetBounds(Gadget gadget)
        {
            // Find the first slot that, that should be the top-left of the gadget, unless its a parallelogram or something dumb.

            int[] xy = null;

            for (int x = 0; x < HorizontalSlots; x++)
            {
                for (int y = 0; y < VerticalSlots; y++)
                {
                    if (_slots[x, y] == gadget)
                    {
                        xy = new int[] {x, y};
                        break;
                    }
                }

                if (xy != null)
                    break;
            }

            if (xy == null)
                return Rectangle.Empty;

            return new Rectangle(xy[0], xy[1], gadget.HorizontalSlots, gadget.VerticalSlots);
        }


        public bool IsEmpty() => ForAllSlots(g => g == null);


        private void ForAllSlots(Action<Gadget> action)
        {
            for (int x = 0; x < HorizontalSlots; x++)
                for (int y = 0; y < VerticalSlots; y++)
                    action(_slots[x, y]);
        }

        private bool ForAllSlots(Predicate<Gadget> predicate)
        {
            for (int x = 0; x < HorizontalSlots; x++)
                for (int y = 0; y < VerticalSlots; y++)
                    if (!predicate(_slots[x, y]))
                        return false;

            return true;
        }

        private bool ForAnySlot(Predicate<Gadget> predicate)
        {
            for (int x = 0; x < HorizontalSlots; x++)
                for (int y = 0; y < VerticalSlots; y++)
                    if (predicate(_slots[x, y]))
                        return true;

            return false;
        }


        public int GetCellIndex(int row, int column) => row * HorizontalSlots + column;

        public int[] GetXY(int cellIndex) =>
            new int[] { HorizontalSlots / cellIndex, cellIndex % HorizontalSlots };


        public int HorizontalSlots { get; private set; }
        public int VerticalSlots { get; private set; }
    }
}