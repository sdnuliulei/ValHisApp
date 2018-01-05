using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;
using System.Threading.Tasks;
using Autofac;
using Autofac.Extras.DynamicProxy;
using IHIS;
using VHApp.AOP;

namespace VHApp.Utils
{
    public class BLLModule
    {
        /// <summary>
        ///注册组件
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        private static IContainer Register<T>()
        {
            ContainerBuilder builder = new ContainerBuilder();
            Type baseType = typeof(IDependency);

            Assembly[] assemblies = new Assembly[]
            {
                Assembly.LoadFrom(AppDomain.CurrentDomain.BaseDirectory + "HIS.dll")
            };

            builder.RegisterType<CallLogger>();
            builder.RegisterType<T>()
                .EnableClassInterceptors()
                .InterceptedBy(typeof(CallLogger));

            builder.RegisterAssemblyTypes(assemblies)
                   .Where(type => baseType.IsAssignableFrom(type)&&!type.IsAbstract)
                  .AsImplementedInterfaces()
                  .InstancePerLifetimeScope()
                  .EnableClassInterceptors()
                  .InterceptedBy(typeof(CallLogger));//InstancePerLifetimeScope 保证对象生命周期基于请求
            var constructorParams=new List<NamedParameter>
            {
                new NamedParameter("msg","hello"),
                new NamedParameter("next",123)
            };
            builder.RegisterAssemblyTypes(assemblies).As<IHIS.Module>()
                .WithParameter(new TypedParameter(typeof(string), "hello"))
                .WithParameter(new TypedParameter(typeof(int),12323))
                .EnableClassInterceptors()
                .InterceptedBy(typeof(CallLogger));
            IContainer container = builder.Build();
            return container;
        }

        private static IContainer RegisterDll<T>()
        {
            ContainerBuilder builder = new ContainerBuilder();
            Assembly[] assemblies = new Assembly[]
            {
                Assembly.LoadFrom(AppDomain.CurrentDomain.BaseDirectory + "HIS.dll")
            };
            builder.RegisterType<CallLogger>();

            IContainer container = builder.Build();
            return container;
        }

        /// <summary>
        /// 获取解析实例
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static T GetInstance<T>() where T:class
        {
            IContainer container = Register<T>();
            return container.Resolve<T>();
        }
    }
}
