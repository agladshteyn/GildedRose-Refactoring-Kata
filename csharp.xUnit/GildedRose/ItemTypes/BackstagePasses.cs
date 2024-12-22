
namespace GildedRoseKata.ItemTypes
{
    public class BackstagePasses : ItemBase
    {
        public BackstagePasses(Item item) : base(item)
        {

        }
        public override void UpdateItem()
        {
            if (Item.Quality < Constants.QualityThreshold)
            {
                IncreaseQuality();

                if (Item.SellIn < 11)
                {
                    IncreaseQualityIfBelowThreshold();
                }

                if (Item.SellIn < 6)
                {
                    IncreaseQualityIfBelowThreshold();
                }
            }

            DecreaseSellIn();

            if (Item.SellIn < 0)
            {
                Item.Quality = 0;
            }
        }
    }
}
