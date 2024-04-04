using System.Collections.Generic;
using GildedRoseKata;
using NUnit.Framework;

namespace GildedRoseTests;

public class GildedRoseTest
{
    [Test]
    public void Foo()
    {
        // Arrange
        var items = new List<Item> { new Item { Name = "fixme", SellIn = 0, Quality = 0 } };
        var app = new GildedRose(items);
        
        // Act
        app.UpdateQuality();
        
        // Assert
        Assert.That(items[0].Name, Is.EqualTo("fixme"));
    }
}