

using Autofac;
using Autofac.Extras.DynamicProxy;
using Cafe.Business.Abstract;
using Cafe.Business.Business;
using Cafe.Core.Utilities.Interceptors;
using Cafe.DataAccess.Abstract;
using Cafe.DataAccess.Concrete.EntityFramework.MSSQL;
using Castle.DynamicProxy;
using System.Reflection;
using Cafe.Core.Utilities.Security.JWT;
using Microsoft.AspNetCore.Http;
using Module = Autofac.Module;

namespace Cafe.Business.DependencyResolvers.Autofac
{
    public class AutofacBusinessModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<DrinkManager>().As<IDrinkService>().SingleInstance();
            builder.RegisterType<EfDrinkDal>().As<IDrinkDal>().SingleInstance();
            builder.RegisterType<FoodManager>().As<IFoodService>().SingleInstance();
            builder.RegisterType<EfFoodDal>().As<IFoodDal>().SingleInstance();
            builder.RegisterType<DessertManager>().As<IDessertService>().SingleInstance();
            builder.RegisterType<EfDessertDal>().As<IDessertDal>().SingleInstance();



            builder.RegisterType<UserManager>().As<IUserService>().SingleInstance();
            builder.RegisterType<EfUserDal>().As<IUserDal>().SingleInstance();
            builder.RegisterType<AuthManager>().As<IAuthService>();
            builder.RegisterType<JwtHelper>().As<ITokenHelper>();
            builder.RegisterType<HttpContextAccessor>().As<IHttpContextAccessor>().SingleInstance();

            var assembly = Assembly.GetExecutingAssembly(); //GetExecutingAssembly: Mevcut Assemblye ulaşmak 

            builder.RegisterAssemblyTypes(assembly). // şu assembly türündeki bütün assemblyleri kayıt et
                AsImplementedInterfaces()
                .EnableInterfaceInterceptors(new ProxyGenerationOptions
                {
                    Selector = new AspectInterceptorSelectors() // Araaya girecek olan nesne 
                }).SingleInstance();
        }

    }
}
