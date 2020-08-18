using Autofac;
using Autofac.Integration.WebApi;
using ShoppingList;
using ShoppingList.DataModel;
using ShoppingList.Repository;
using ShoppingList.Service;
using ShoppingList.Service.Product;
using ShoppingList.Validation.Cart;
using ShoppingList.Validation.Product;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Http;

namespace ShoppingListAPI.App_Start
{
    public class AutofacWebapiConfig
    {

        public static IContainer Container;

        public static void Initialize(HttpConfiguration config)
        {
            Initialize(config, RegisterServices(new ContainerBuilder()));
        }


        public static void Initialize(HttpConfiguration config, IContainer container)
        {
            config.DependencyResolver = new AutofacWebApiDependencyResolver(container);
        }

        private static IContainer RegisterServices(ContainerBuilder builder)
        {
            builder.RegisterApiControllers(Assembly.GetExecutingAssembly());
            
            builder.RegisterType<ProductService>().As<IProductService>();

            builder.RegisterType<ProductRepository>().As<IProduct>();

            builder.RegisterType<ProductValidation>().AsSelf();
            builder.RegisterType<CreateRequestValidation>().AsSelf();
            builder.RegisterType<FindRequestValidation>().AsSelf();
            builder.RegisterType<UpdateRequestValidation>().AsSelf();
            builder.RegisterType<DeleteRequestValidation>().AsSelf();

            builder.RegisterType<CartRepository>().As<ICart>();
            builder.RegisterType<CartService>().As<ICartService>();

            builder.RegisterType<CartValidation>().AsSelf();
            builder.RegisterType<CartCreateRequestValidation>().AsSelf();
            builder.RegisterType<CartFindRequestValidation>().AsSelf();
            builder.RegisterType<AddProductToCartValidation>().AsSelf();
            builder.RegisterType<CartRemoveRequestValidation>().AsSelf();
            builder.RegisterType<RemoveFromCartRequestValidation>().AsSelf();
            builder.RegisterType<CartClearRequestValidation>().AsSelf();

            builder.RegisterType<ShoppingListContext>().AsSelf();

            Container = builder.Build();

            return Container;
        }

    }
}