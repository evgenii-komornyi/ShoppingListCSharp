using System;

namespace ShoppingList.Exceptions
{
    public class UniqueKeyViolationException : Exception
    {
        public Exception OriginalException { get; set; }

        public UniqueKeyViolationException(Exception originalException)
        {
            OriginalException = originalException;
        }
    }
}
