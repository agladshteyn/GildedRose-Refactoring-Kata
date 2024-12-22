
namespace GildedRoseKata.ItemTypes
{
    public class Conjured : StandardItem
    {
        public Conjured(Item item) : base(item)
        {

        }
        public override void UpdateItem()
        {
            var currentQuality = Item.Quality;

            base.UpdateItem();

            // "Conjured" items degrade in Quality twice as fast as normal items.
            var diff = currentQuality - Item.Quality;

            Item.Quality -= diff;
        }
    }
}
