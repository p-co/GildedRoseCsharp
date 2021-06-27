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
                switch(item.Name)
                {
                    case "Aged Brie":
                        //Aged Brie increases in quality over time, capped to 50
                        if (Item.MAX_QUALITY > item.Quality)
                            item.Quality++;

                        item.SellIn -= 1;

                        break;
                    case string s when s.StartsWith("Backstage pass"):
                        //Backstage pass increases in quality over time, capped to 50
                        //when sellin under 10 quality increase twice as fast
                        //when sellin under 5 quality increase three times as fast
                        //when sellin gets under 0, set quality to 0
                        if (item.SellIn == 0)
                            item.Quality = 0;
                        else if (item.SellIn > 0 && item.SellIn <= 5 && item.Quality < Item.MAX_QUALITY)
                        {
                            if (item.Quality <= Item.MAX_QUALITY - 3)
                                item.Quality += 3;
                            else
                                item.Quality = 3;
                        }
                        else if (item.SellIn > 5 && item.SellIn <= 10)
                        {
                            if (item.Quality <= Item.MAX_QUALITY - 2)
                                item.Quality += 2;
                            else
                                item.Quality = 2;
                        }

                        item.SellIn -= 1;

                        break;
                    case "Sulfuras, Hand of Ragnaros":
                        //Sulfuras does not decay and does not have sellin
                        break;
                    case string s when s.StartsWith("Conjured"):
                        //conjured decay twice as fast

                        if (item.SellIn <= 0 && item.Quality > 0) //if perempted
                        {
                            //quality decays to 4 if it can
                            //if it's under 4 (when == 1 or 2 or 3), setting it to 0
                            if (item.Quality >= 4)
                                item.Quality -= 4;
                            else if (item.Quality > 0)
                                item.Quality = 0;
                        }
                        else if (item.SellIn > 0 && item.Quality > 0) //if not yet perempted
                        {
                            //quality decays to 2 if it can
                            //if it's under 2 (when == 1), setting it to 0
                            if (item.Quality >= 2)
                                item.Quality -= 2;
                            else if (item.Quality > 0)
                                item.Quality = 0;
                        }

                        item.SellIn -= 1;
                        break;
                    default:
                        //regular item decay of 1 when sellin over 0 and 2 when sellin under 0
                        if (item.SellIn <= 0 && item.Quality > 0)
                        {
                            //quality decays to 2 if it can
                            //if it's under 2 (when == 1) setting it to 0
                            if (item.Quality >= 2)
                                item.Quality -= 2;
                            else if (item.Quality > 0)
                                item.Quality = 0;
                        }
                        else if (item.SellIn > 0 && item.Quality > 0)
                            item.Quality -= 1;

                        item.SellIn -= 1;

                        break;
                }


                //if (item.Name != "Aged Brie" && item.Name != "Backstage passes to a TAFKAL80ETC concert")
                //{
                //    if (item.Quality > 0)
                //    {
                //        if (item.Name != "Sulfuras, Hand of Ragnaros")
                //        {
                //            item.Quality = item.Quality - 1;
                //        }
                //    }
                //}
                //else
                //{
                //    if (item.Quality < 50)
                //    {
                //        item.Quality = item.Quality + 1;

                //        if (item.Name == "Backstage passes to a TAFKAL80ETC concert")
                //        {
                //            if (item.SellIn < 11)
                //            {
                //                if (item.Quality < 50)
                //                {
                //                    item.Quality = item.Quality + 1;
                //                }
                //            }

                //            if (item.SellIn < 6)
                //            {
                //                if (item.Quality < 50)
                //                {
                //                    item.Quality = item.Quality + 1;
                //                }
                //            }
                //        }
                //    }
                //}

                //if (item.Name != "Sulfuras, Hand of Ragnaros")
                //{
                //    item.SellIn = item.SellIn - 1;
                //}

                //if (item.SellIn < 0)
                //{
                //    if (item.Name != "Aged Brie")
                //    {
                //        if (item.Name != "Backstage passes to a TAFKAL80ETC concert")
                //        {
                //            if (item.Quality > 0)
                //            {
                //                if (item.Name != "Sulfuras, Hand of Ragnaros")
                //                {
                //                    item.Quality = item.Quality - 1;
                //                }
                //            }
                //        }
                //        else
                //        {
                //            item.Quality = item.Quality - item.Quality;
                //        }
                //    }
                //    else
                //    {
                //        if (item.Quality < 50)
                //        {
                //            item.Quality = item.Quality + 1;
                //        }
                //    }
                //}
            }
        }
    }
}
