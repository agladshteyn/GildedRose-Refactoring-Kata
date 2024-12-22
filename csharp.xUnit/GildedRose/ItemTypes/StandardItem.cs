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
            DecreaseQualityIfAboveZero();
            DecreaseSellIn();

            if (Item.SellIn < 0)
            {
                DecreaseQualityIfAboveZero();
            }
        }
    }
}
