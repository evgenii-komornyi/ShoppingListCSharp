using System.Collections.Generic;

namespace ShoppingList.Validation
{
    public interface Validatable<T, E>
    {
        List<E> Validate(T request);
    }
}
