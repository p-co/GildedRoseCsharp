using csharpcore.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace csharpcore
{
    public static class ItemFactory
    {
        public static Item Create(string name, int sellin, int quality)
        {
            switch(name)
            {
                case "Aged Brie":
                    return new AgedBrie
                    {
                        Name = name,
                        SellIn = sellin,
                        Quality = quality
                    };
                case string s when s.StartsWith("Backstage pass"):
                    return new BackstagePass
                    {
                        Name = name,
                        SellIn = sellin,
                        Quality = quality
                    };
                case "Sulfuras, Hand of Ragnaros":
                    return new Sulfuras
                    {
                        Name = name,
                        SellIn = sellin,
                        Quality = quality
                    };
                case string s when s.StartsWith("Conjured"):
                    return new ConjuredItem
                    {
                        Name = name,
                        SellIn = sellin,
                        Quality = quality
                    };
                default:
                    return new Item
                    {
                        Name = name,
                        SellIn = sellin,
                        Quality = quality
                    };
            }
        }

        public static Item Create(Item item)
        {
            return Create(item.Name, item.SellIn, item.Quality);
        }
    }
}
