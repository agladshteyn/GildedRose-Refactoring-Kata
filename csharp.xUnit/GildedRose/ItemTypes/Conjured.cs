
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

            var diff = currentQuality - Item.Quality;

            Item.Quality -= diff;
        }
    }
}
