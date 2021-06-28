using System;
using System.Collections.Generic;
using System.Text;

namespace csharpcore.Models
{
    public class BackstagePass : Item
    {
        internal override void UpdateQuality()
        {
            //Backstage pass increases in quality over time, capped to 50
            //when sellin under 10 quality increase twice as fast
            //when sellin under 5 quality increase three times as fast
            //when sellin gets under 0, set quality to 0
            if (SellIn == 0)
                Quality = 0;
            else if (SellIn > 0 && SellIn <= 5 && Quality < MAX_QUALITY)
            {
                if (Quality <= MAX_QUALITY - 3)
                    Quality += 3;
                else
                    Quality = 3;
            }
            else if (SellIn > 5 && SellIn <= 10)
            {
                if (Quality <= MAX_QUALITY - 2)
                    Quality += 2;
                else
                    Quality = 2;
            }

            SellIn -= 1;
        }
    }
}
