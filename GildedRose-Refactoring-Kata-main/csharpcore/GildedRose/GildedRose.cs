using System.Collections.Generic;
using System.Net;
using System.Runtime.CompilerServices;

namespace GildedRoseKata;

public class GildedRose
{
    private readonly IList<Item> _items;

    public GildedRose(IList<Item> items)
    {
        _items = items;
    }

    public void UpdateQuality()
    {
        for (var i = 0; i < _items.Count; i++)
        {
            if (_items[i].Name == "Sulfuras, Hand of Ragnaros")
            {
                UpdateSulfuras(_items[i]);
                continue;
            }
            
            if (_items[i].Name == "Backstage passes to a TAFKAL80ETC concert")
            {
                UpdateBackstagePasses(_items[i]);
                continue;
            }
            
            if (_items[i].Name != "Aged Brie")
            {
                if (_items[i].Quality > 0)
                {
                    _items[i].Quality = _items[i].Quality - 1;
                }
            }
            else
            {
                if (_items[i].Quality < 50)
                {
                    _items[i].Quality = _items[i].Quality + 1;
                }
            }
            
            _items[i].SellIn = _items[i].SellIn - 1;
            
            if (_items[i].SellIn < 0)
            {
                if (_items[i].Name != "Aged Brie")
                {
                    if (_items[i].Quality > 0)
                    {
                        _items[i].Quality = _items[i].Quality - 1;
                    }
                    else
                    {
                        _items[i].Quality = _items[i].Quality - _items[i].Quality;
                    }
                }
                else
                {
                    if (_items[i].Quality < 50)
                    {
                        _items[i].Quality = _items[i].Quality + 1;
                    }
                }
            }
            
        }
    }

    /// <summary>
    /// "Sulfuras", being a legendary item, never has to be sold or decreases in Quality
    /// </summary>
    /// <param name="item"></param>
    /// <exception cref="NotImplementedException"></exception>
    private void UpdateSulfuras(Item item)
    {
        // Nothing
    }
    
    /// <summary>
    /// "Backstage passes", like aged brie, increases in Quality as its SellIn value approaches;
    // Quality increases by 2 when there are 10 days or less and by 3 when there are 5 days or less but
    // Quality drops to 0 after the concert
    // an item can never have its Quality increase above 50
    /// </summary>
    /// <param name="item"></param>
    private void UpdateBackstagePasses(Item item)
    {
        item.SellIn = item.SellIn - 1;
        
        // Q = 0 after concert
        if (item.SellIn < 0)
        {
            item.Quality = 0;
            return;
        }
        
        // Q + 3 at SellIn 5 days or less
        if (item.SellIn < 5)
        {
            item.Quality += 3;
            if (item.Quality > 50)
            {
                item.Quality = 50;
            }
            return;
        }
        
        // Q + 2 at SellIn 10 days or less
        if (item.SellIn < 10)
        {
            item.Quality += 2;
            if (item.Quality > 50)
            {
                item.Quality = 50;
            }

            return;
        }

        // Else Q adds 1
        item.Quality++;
        if (item.Quality > 50)
        {
            item.Quality = 50;
        }
    }

}