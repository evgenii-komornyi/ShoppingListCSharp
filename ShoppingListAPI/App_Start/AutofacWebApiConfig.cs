using Autofac;
using Autofac.Integration.WebApi;
using ShoppingList.DataModel;
using ShoppingList.Repository.AddressNS;
using ShoppingList.Repository.CartNS;
using ShoppingList.Repository.CategoryNS;
using ShoppingList.Repository.FileStorageNS;
using ShoppingList.Repository.ProductNS;
using ShoppingList.Repository.UserNS;
using ShoppingList.Service.AddressNS;
using ShoppingList.Service.CartNS;
using ShoppingList.Service.CategoryNS;
using ShoppingList.Service.FileStorageNS;
using ShoppingList.Service.ProductNS;
using ShoppingList.Service.UserNS;
using ShoppingList.Validation.CartNS;
using ShoppingList.Validation.ProductNS;
using System.Reflection;
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

            builder.RegisterType<AddressRepository>().As<IAddress>();
            builder.RegisterType<AddressService>().As<IAddressService>();

            builder.RegisterType<CartRepository>().As<ICart>();
            builder.RegisterType<CartService>().As<ICartService>();

            builder.RegisterType<CartValidation>().AsSelf();
            builder.RegisterType<CartCreateRequestValidation>().AsSelf();
            builder.RegisterType<CartFindRequestValidation>().AsSelf();
            builder.RegisterType<AddProductToCartValidation>().AsSelf();
            builder.RegisterType<CartRemoveRequestValidation>().AsSelf();
            builder.RegisterType<RemoveFromCartRequestValidation>().AsSelf();
            builder.RegisterType<CartClearRequestValidation>().AsSelf();

            builder.RegisterType<CategoryRepository>().As<ICategory>();
            builder.RegisterType<CategoryService>().As<ICategoryService>();

            builder.RegisterType<FileStorageRepository>().As<IFileStorage>();
            builder.RegisterType<FileStorageService>().As<IFileStorageService>();

            builder.RegisterType<ProductRepository>().As<IProduct>();
            builder.RegisterType<ProductService>().As<IProductService>();

            builder.RegisterType<ProductValidation>().AsSelf();
            builder.RegisterType<CreateRequestValidation>().AsSelf();
            builder.RegisterType<FindRequestValidation>().AsSelf();
            builder.RegisterType<UpdateRequestValidation>().AsSelf();
            builder.RegisterType<DeleteRequestValidation>().AsSelf();

            builder.RegisterType<UserRepository>().As<IUser>();
            builder.RegisterType<UserService>().As<IUserService>();

            builder.RegisterType<ShoppingListContext>().AsSelf();

            Container = builder.Build();

            return Container;
        }

    }
}