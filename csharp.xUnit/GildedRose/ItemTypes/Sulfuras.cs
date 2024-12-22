
namespace GildedRoseKata.ItemTypes
{
    public class Sulfuras : ItemBase
    {
        public Sulfuras(Item item) : base(item)
        {

        }

        public override void UpdateItem()
        {
            Item.Quality = Constants.QualityOfSulfuras;
        }
    }
}
