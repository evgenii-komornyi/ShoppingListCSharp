namespace ShoppingList.DataModel
{
    public class RemoveProductFromCartRequest
    {
        public long CartId { get; set; }
        public long ProductId { get; set; }
    }
}
