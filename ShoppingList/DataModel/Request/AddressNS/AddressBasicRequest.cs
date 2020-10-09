namespace ShoppingList.DataModel.Request.AddressNS
{
    public class AddressBasicRequest
    {
        public string Country { get; set; }
        public string City { get; set; }
        public string Street { get; set; }
        public string House_Number { get; set; }
        public string Flat_Number { get; set; }
        public string Additional_Info { get; set; }
        public string Phone { get; set; }
        public long User_Id { get; set; }
    }
}
