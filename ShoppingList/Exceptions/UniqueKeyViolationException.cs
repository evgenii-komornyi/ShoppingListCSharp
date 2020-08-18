using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
