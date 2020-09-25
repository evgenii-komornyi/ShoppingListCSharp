namespace ShoppingList.DataModel
{
    public class AddUpdateCartRequest
    {
        public long CartId { get; set; }
        public long ProductId { get; set; }
        public int Quantity { get; set; }

        public override bool Equals(object obj)
        {
            return obj is AddUpdateCartRequest request &&
                   CartId == request.CartId &&
                   ProductId == request.ProductId &&
                   Quantity == request.Quantity;
        }

        public override int GetHashCode()
        {
            int hashCode = -2134810397;
            hashCode = hashCode * -1521134295 + CartId.GetHashCode();
            hashCode = hashCode * -1521134295 + ProductId.GetHashCode();
            hashCode = hashCode * -1521134295 + Quantity.GetHashCode();
            return hashCode;
        }

        public override string ToString()
        {
            return $"{{{nameof(CartId)}={CartId.ToString()}, {nameof(ProductId)}={ProductId.ToString()}, {nameof(Quantity)}={Quantity.ToString()}}}";
        }
    }
}
