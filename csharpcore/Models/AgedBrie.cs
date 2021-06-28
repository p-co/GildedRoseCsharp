using System;
using System.Collections.Generic;
using System.Text;

namespace csharpcore.Models
{
    public class AgedBrie : Item
    {
        internal override void UpdateQuality()
        {
            //Aged Brie increases in quality over time, capped to 50
            if (MAX_QUALITY > Quality)
                Quality++;

            SellIn -= 1;
        }
    }
}
