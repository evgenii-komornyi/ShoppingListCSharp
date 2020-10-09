using ShoppingList.DataModel;

namespace DataTransferObjects.CartDTO
{
    public class ProductInCartDTO
    {
        public long id { get; set; }
        public string name { get; set; }
        public Category category { get; set; }
        public decimal regPrice { get; set; }
        public decimal discount { get; set; }
        public decimal actPrice { get; set; }
        public string description { get; set; }
    }
}
