using System;
using System.Collections.Generic;

namespace csharpcore
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("OMGHAI!");

            IList<Item> Items = new List<Item>{
                ItemFactory.Create("+5 Dexterity Vest", 10, 20),
                ItemFactory.Create("Aged Brie", 2, 0),
                ItemFactory.Create("Elixir of the Mongoose", 5, 7),
                ItemFactory.Create("Sulfuras, Hand of Ragnaros", 0, 80),
                ItemFactory.Create("Sulfuras, Hand of Ragnaros", -1, 80),
                ItemFactory.Create("Backstage passes to a TAFKAL80ETC concert", 15,  20),
                ItemFactory.Create("Backstage passes to a TAFKAL80ETC concert", 10, 49),
                ItemFactory.Create("Backstage passes to a TAFKAL80ETC concert", 5, 49),
				// this conjured item does not work properly yet
				ItemFactory.Create("Conjured Mana Cake", 3, 6)
            };

            var app = new GildedRose(Items);


            for (var i = 0; i < 31; i++)
            {
                Console.WriteLine("-------- day " + i + " --------");
                Console.WriteLine("name, sellIn, quality");
                for (var j = 0; j < Items.Count; j++)
                {
                    System.Console.WriteLine(Items[j].Name + ", " + Items[j].SellIn + ", " + Items[j].Quality);
                }
                Console.WriteLine("");
                app.UpdateQuality();
            }
        }
    }
}
