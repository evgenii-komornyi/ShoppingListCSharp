using ShoppingList.Exceptions;
using System;
using System.Collections.Generic;
using System.Data.Entity.Core;
using System.Data.Entity.Infrastructure;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingList.Helper
{
    public class DbContextHelper
    {
        /// <summary>
        /// Handles the unique key violation and throws UniqueKeyViolationException if violated
        /// </summary>
        /// <param name="action">Some action</param>
        /// <returns>returns action's int value when there are no problems</returns>
        public static int HandleUniqueKeyViolation(Func<int> action)
        {
            try
            {
                return action.Invoke();
            }
            catch (DbUpdateException ex)
            {
                if ((ex.InnerException != null) &&
                    (ex.InnerException.GetType() == typeof(UpdateException)) &&
                    (ex.InnerException.InnerException != null) &&
                    (ex.InnerException.InnerException.GetType() == typeof(SqlException)))
                {
                    var sqlEx = (ex.InnerException.InnerException as SqlException);
                    //see sys.Messages for details 
                    //or msdn (https://social.msdn.microsoft.com/Forums/sqlserver/en-US/272c3c7e-0819-4750-a8e8-ae364be34f01/errors-2601-and-2627?forum=transactsql)
                    if (sqlEx.Number == 2601 || sqlEx.Number == 2627)
                    {
                        throw new UniqueKeyViolationException(ex);
                    }
                    else throw;
                }
                else throw;
            }
        }
    }
}
