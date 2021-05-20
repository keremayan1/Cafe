

using Autofac;
using Autofac.Extras.DynamicProxy;
using Cafe.Business.Abstract;
using Cafe.Business.Business;
using Cafe.Core.Utilities.Interceptors;
using Cafe.DataAccess.Abstract;
using Cafe.DataAccess.Concrete.EntityFramework.MSSQL;
using Castle.DynamicProxy;
using System.Reflection;
using Module = Autofac.Module;

namespace Cafe.Business.DependencyResolvers.Autofac
{
    public class AutofacBusinessModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<DrinkManager>().As<IDrinkService>().SingleInstance();
            builder.RegisterType<EfDrinkDal>().As<IDrinkDal>().SingleInstance();


            var assembly = Assembly.GetExecutingAssembly();
            builder.RegisterAssemblyTypes(assembly).AsImplementedInterfaces().EnableInterfaceInterceptors(new ProxyGenerationOptions
            {
                Selector = new AspectInterceptorSelectors()
            }).SingleInstance();
        }

    }
}
