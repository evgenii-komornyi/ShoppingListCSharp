namespace DataTransferObjects.CartDTO
{
    public class AddUpdateCartDTO : CartBasicDTO
    {
        public long productId { get; set; }
        public long cartId { get; set; }
        public int quantity { get; set; }
    }
}
