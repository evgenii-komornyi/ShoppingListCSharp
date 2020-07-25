using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingList.DataModel.Request.Product
{
    public class ProductFindRequest
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public Category Category { get; set; }

        public override bool Equals(object obj)
        {
            return obj is ProductFindRequest request &&
                   Id == request.Id &&
                   Name == request.Name &&
                   Category == request.Category;
        }

        public override int GetHashCode()
        {
            int hashCode = 784765735;
            hashCode = hashCode * -1521134295 + Id.GetHashCode();
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Name);
            hashCode = hashCode * -1521134295 + Category.GetHashCode();
            return hashCode;
        }
    }
}
