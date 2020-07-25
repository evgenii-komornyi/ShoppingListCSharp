using Autofac;
using ShoppingList.Repository.Cart;
using ShoppingList.Repository.Product;
using ShoppingList.Service.Product;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingList.Utils
{
    public class Configuration : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<ProductRepository>().As<IProduct>();
            builder.RegisterType<CartRepository>().As<ICart>();
            builder.RegisterType<ProductService>().AsSelf();
        }
    }
}
