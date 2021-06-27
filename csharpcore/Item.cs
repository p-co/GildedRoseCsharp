using System;

namespace csharpcore
{
    public class Item
    {
        public string Name { get; set; }
        public int SellIn { get; set; }
        public int Quality { get; set; }

        public static int MAX_QUALITY { get; } = 50;
        public static int CONJURED_DEGRADATION_MULT = 2;

        /**
         * Update quality and sellin values of this item
         */
        internal void UpdateQuality(int addedQuality, int addedSellIn)
        {
            this.Quality += addedQuality;
            this.SellIn += addedSellIn;
        }
    }
}
