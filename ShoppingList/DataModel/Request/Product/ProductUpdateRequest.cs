using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingList.DataModel.Request.Product
{
   public class ProductUpdateRequest : ProductBasicRequest
    {
        public long Id { get; set; }

        public override bool Equals(object obj)
        {
            return obj is ProductUpdateRequest request &&
                   Name == request.Name &&
                   Category == request.Category &&
                   Price == request.Price &&
                   Discount == request.Discount &&
                   Description == request.Description &&
                   Id == request.Id;
        }

        public override int GetHashCode()
        {
            int hashCode = 1894313072;
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Name);
            hashCode = hashCode * -1521134295 + Category.GetHashCode();
            hashCode = hashCode * -1521134295 + Price.GetHashCode();
            hashCode = hashCode * -1521134295 + Discount.GetHashCode();
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Description);
            hashCode = hashCode * -1521134295 + Id.GetHashCode();
            return hashCode;
        }
    }
}
