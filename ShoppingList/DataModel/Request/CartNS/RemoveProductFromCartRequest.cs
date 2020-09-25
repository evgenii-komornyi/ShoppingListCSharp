namespace ShoppingList.DataModel.Request.CartNS
{
    public class RemoveProductFromCartRequest
    {
        public long CartId { get; set; }
        public long ProductId { get; set; }
    }
}
