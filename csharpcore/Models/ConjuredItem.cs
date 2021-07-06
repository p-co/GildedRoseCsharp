using System;
using System.Collections.Generic;
using System.Text;

namespace csharpcore.Models
{
    public class ConjuredItem : Item
    {
        internal override void UpdateQuality()
        {
            //conjured decay twice as fast as a regular item

            if (SellIn <= 0 && Quality > 0) //if perempted
            {
                //quality decays to 4 if it can
                //if it's under 4 (when == 1 or 2 or 3), setting it to 0
                if (Quality >= 4)
                    Quality -= 4;
                else if (Quality > 0)
                    Quality = 0;
            }
            else if (SellIn > 0 && Quality > 0) //if not yet perempted
            {
                //quality decays to 2 if it can
                //if it's under 2 (when == 1), setting it to 0
                if (Quality >= 2)
                    Quality -= 2;
                else if (Quality > 0)
                    Quality = 0;
            }

            SellIn -= 1;
        }
    }
}
