using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GildedRoseKata.ItemTypes
{
    public class StandardItem : ItemBase
    {
        public StandardItem(Item item) : base(item)
        {

        }

        public override void UpdateItem()
        {
            // At the end of each day our system lowers SellIn and Quality.
            DecreaseQualityIfAboveZero();
            DecreaseSellIn();

            // Once the sell by date has passed, Quality degrades twice as fast.
            if (Item.SellIn < 0)
            {
                DecreaseQualityIfAboveZero();
            }
        }
    }
}
