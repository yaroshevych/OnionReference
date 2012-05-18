using System.Reflection;
using Autofac;
using Autofac.Integration.Mvc;
using Bookstore.Core;
using Bookstore.Infrastructure;

namespace Bookstore.DependencyResolution
{
    public static class ServiceResolver
    {
        private static IContainer container;

        public static void Initialize(Assembly applicationAssembly, string dataDirPath)
        {
            if (container == null)
            {
                var builder = new ContainerBuilder();
                builder.RegisterControllers(applicationAssembly);

                builder.RegisterType<BookRepository>().As<IBookRepository>();
                builder.RegisterType<LoggerFactory>().As<ILoggerFactory>();
                builder.RegisterType<BookService>().As<BookService>();

                container = builder.Build();
            }
        }

        public static System.Web.Mvc.IDependencyResolver CreateDependencyResolver()
        {
            return new AutofacDependencyResolver(container);
        }

        private class LoggerFactory : ILoggerFactory
        {
            public ILogger Create<T>()
            {
                return LoggerInstance<T>.Instance;
            }

            // this class will hold logger instance for specific type
            class LoggerInstance<T>
            {
                static ILogger logger = (Bookstore.Infrastructure.Logger)NLog.LogManager.GetLogger(typeof(T).FullName, typeof(Bookstore.Infrastructure.Logger));
                public static ILogger Instance { get { return logger; } }
            }
        }
    }
}
