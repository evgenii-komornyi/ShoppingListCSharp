namespace ShoppingList.DataModel
{
    public abstract class CartBasicRequest : BasicRequest
    {
        public long UserId { get; set; }
    }
}
