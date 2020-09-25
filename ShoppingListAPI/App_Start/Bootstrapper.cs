using System.Web.Http;

namespace ShoppingListAPI.App_Start
{
    public class Bootstrapper
    {
        public static void Run()
        {
            //Configure AutoFac  
            AutofacWebapiConfig.Initialize(GlobalConfiguration.Configuration);
        }
    }
}