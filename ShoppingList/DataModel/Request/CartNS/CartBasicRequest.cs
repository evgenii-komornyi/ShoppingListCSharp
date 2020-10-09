namespace ShoppingList.DataModel.Request.CartNS
{
    public abstract class CartBasicRequest : BasicRequest
    {
        public long UserId { get; set; }
    }
}
