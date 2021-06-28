using csharpcore.Models;
using System.Collections.Generic;

namespace csharpcore
{
    public class GildedRose
    {
        

        IList<Item> Items;
        public GildedRose(IList<Item> Items)
        {
            this.Items = Items;
        }

        /**
         * Iterate through inventory to update quality
         */
        public void UpdateQuality()
        {
            foreach (Item item in Items)
            {
                Item generatedItem = ItemFactory.Create(item);
                generatedItem.UpdateQuality();
                item.SellIn = generatedItem.SellIn;
                item.Quality = generatedItem.Quality;

            }
        }
    }
}
