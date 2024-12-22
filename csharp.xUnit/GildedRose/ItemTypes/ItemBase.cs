
namespace GildedRoseKata.ItemTypes
{
    public abstract class ItemBase
    {
        protected Item Item;
        public ItemBase(Item item)
        {
            Item = item;
        }

        public abstract void UpdateItem();

        protected void DecreaseSellIn()
        {
            Item.SellIn -= 1;
        }

        protected void IncreaseQuality()
        {
            Item.Quality += 1;
        }

        protected void IncreaseQualityIfBelowThreshold()
        {
            if (Item.Quality < Constants.QualityThreshold)
            {
                IncreaseQuality();
            }
        }

        protected void DecreaseQualityIfAboveZero()
        {
            if (Item.Quality > 0)
            {
                Item.Quality -= 1;
            }
        }
    }
}
