﻿namespace ShoppingList.DataModel
{
    public class ProductFindRequest
    {
        public long ProductId { get; set; }
        public string Name { get; set; }
        public long Category_Id { get; set; }
    }
}
