namespace ShoppingList.DataModel.Request.UserNS
{
    public abstract class UserBasicRequest
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Birthday { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public string Role { get; set; }
        public long DefaultAddress_Id { get; set; }
    }
}
