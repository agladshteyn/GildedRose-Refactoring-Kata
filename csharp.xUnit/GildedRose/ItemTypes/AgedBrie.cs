
namespace GildedRoseKata.ItemTypes
{
    public class AgedBrie : ItemBase
    {
        public AgedBrie(Item item) : base(item)
        {

        }

        public override void UpdateItem()
        {
            IncreaseQualityIfBelowThreshold();
            DecreaseSellIn();

            if (Item.SellIn < 0)
            {
                IncreaseQualityIfBelowThreshold();
            }
        }
    }
}
