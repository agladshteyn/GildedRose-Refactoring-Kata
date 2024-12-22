using GildedRoseKata;

using System;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Generic;

using VerifyXunit;

using Xunit;

namespace GildedRoseTests;

public class ApprovalTest
{
    [Fact]
    public Task Foo()
    {
        Item[] items = { new Item { Name = "foo", SellIn = 0, Quality = 0 } };
        GildedRose app = new GildedRose(items);
        app.UpdateQuality();
        
        return Verifier.Verify(items);
    }
    
    [Fact]
    public Task ThirtyDays()
    {
        var fakeoutput = new StringBuilder();
        Console.SetOut(new StringWriter(fakeoutput));
        Console.SetIn(new StringReader($"a{Environment.NewLine}"));

        Program.Main(new string[] { "30" });
        var output = fakeoutput.ToString();

        return Verifier.Verify(output);
    }

    // Test to ensure Quality value is properly updated.
    [Theory]
    [InlineData("foo", 1, 3, 2)]
    [InlineData("bar", 0, 0, 0)] // Ensure Quality is never negative
    [InlineData("some item", 0, 2, 0)] // Once the sell by date has passed, Quality degrades twice as fast
    [InlineData("Conjured Mana Cake", 1, 3, 1)] // "Conjured" item decreases twice as fast
    [InlineData("Conjured Mana Cake", 0, 2, 0)]
    [InlineData("Conjured Mana Cake", 1, 2, 0)]
    [InlineData("Aged Brie", 1, 2, 3)] // "Aged Brie" increases in Quality the older it gets
    [InlineData("Aged Brie", 0, 2, 4)]
    [InlineData("Aged Brie", 0, 50, 50)] // The Quality of an item is never more than 50
    [InlineData("Sulfuras, Hand of Ragnaros", 2, 2, 80)] // "Sulfuras" is a legendary item and as such its Quality is 80 and it never alters
    [InlineData("Backstage passes to a TAFKAL80ETC concert", 11, 2, 3)] // "Backstage passes" like aged brie, increases in Quality as its SellIn value approaches
    [InlineData("Backstage passes to a TAFKAL80ETC concert", 10, 2, 4)] // Quality increases by 2 when there are 10 days or less
    [InlineData("Backstage passes to a TAFKAL80ETC concert", 5, 2, 5)] // Quality increases by 3 when there are 5 days or less
    [InlineData("Backstage passes to a TAFKAL80ETC concert", 0, 5, 0)] // Quality drops to 0 after the concert
    public void ValidateQuality(string itemName, int sellIn, int quality, int expectedQuality)
    {
        IList<Item> Items = new List<Item> { new Item { Name = itemName, SellIn = sellIn, Quality = quality } };
        GildedRose app = new GildedRose(Items);
        app.UpdateQuality();

        Assert.Equal(expectedQuality, Items[0].Quality);
    }
}