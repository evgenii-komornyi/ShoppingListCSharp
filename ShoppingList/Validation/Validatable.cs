using ShoppingList.DataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingList.Validation
{
    public interface Validatable<T, E>
    {
        List<E> Validate(T request);
    }
}
