using Xunit;
using System.Collections.Generic;

namespace csharpcore
{
    public class GildedRoseTest
    {
        [Fact]
        public void AssertSellInDoesDecrement()
        {
            IList<Item> Items = new List<Item> { new Item { Name = "foo", SellIn = 0, Quality = 0 } };
            GildedRose app = new GildedRose(Items);
            app.UpdateQuality();
            Assert.Equal(-1, Items[0].SellIn);
        }

        [Fact]
        public void AssertQualityDoesDecrement()
        {
            IList<Item> Items = new List<Item> { new Item { Name = "foo", SellIn = 5, Quality = 10 } };
            GildedRose app = new GildedRose(Items);
            app.UpdateQuality();
            Assert.Equal(9, Items[0].Quality);
        }

        [Theory]
        [InlineData("regular item", 5, 5, 4, 4)]
        [InlineData("Aged Brie", 5, 5, 4, 6)]
        [InlineData("Backstage pass for something", 5, 5, 4, 8)]
        [InlineData("Conjured Stuff", 5, 5, 4, 3)] 
        [InlineData("Sulfuras, Hand of Ragnaros", 0, 5, 0, 5)]
        public void AssertDecrementsCorrectlyAccordingToItemType(string itemName, int sellIn, int quality, int expectedSellIn, int expectedQuality)
        {
            IList<Item> Items = new List<Item> { ItemFactory.Create(itemName, sellIn, quality) };
            GildedRose app = new GildedRose(Items);
            app.UpdateQuality();
            Assert.Equal(expectedQuality, Items[0].Quality);
            Assert.Equal(expectedSellIn, Items[0].SellIn);
        }
    }
}