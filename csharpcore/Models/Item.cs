using System;

namespace csharpcore
{
    public class Item
    {
        public string Name { get; set; }
        public int SellIn { get; set; }
        public int Quality { get; set; }

        public static int MAX_QUALITY { get; } = 50;

        /**
         * Update quality and sellin values of this item
         */
        internal virtual void UpdateQuality()
        {
            //regular item decay of 1 when sellin over 0 and 2 when sellin under 0
            if (SellIn <= 0 && Quality > 0)
            {
                //quality decays to 2 if it can
                //if it's under 2 (when == 1) setting it to 0
                if (Quality >= 2)
                    Quality -= 2;
                else if (Quality > 0)
                    Quality = 0;
            }
            else if (SellIn > 0 && Quality > 0)
                Quality -= 1;

            SellIn -= 1;
        }
    }
}
