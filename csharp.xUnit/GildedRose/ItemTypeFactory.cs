using System;
using System.Collections.Generic;
using System.Linq;
using GildedRoseKata.ItemTypes;

namespace GildedRoseKata
{
    public class ItemTypeFactory
    {
        public static ItemBase Create(Item item)
        {
            switch (item.Name)
            {
                case Constants.ItemNames.AgedBrie:
                    {
                        return new AgedBrie(item);
                    }
                case Constants.ItemNames.Plus5DexterityVest:
                    {
                        return new Plus5DexterityVest(item);
                    }
                case Constants.ItemNames.Elixir:
                    {
                        return new Elixir(item);
                    }
                case Constants.ItemNames.Sulfuras:
                    {
                        return new Sulfuras(item);
                    }
                case Constants.ItemNames.BackstagePasses:
                    {
                        return new BackstagePasses(item);
                    }
                case Constants.ItemNames.Conjured:
                    {
                        return new Conjured(item);
                    }
            }

            return new StandardItem(item);
        }
    }
}
