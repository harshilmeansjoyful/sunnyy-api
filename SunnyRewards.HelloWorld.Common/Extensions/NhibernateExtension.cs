using FluentNHibernate;
using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using Microsoft.Extensions.DependencyInjection;
using NHibernate;
using SunnyRewards.HelloWorld.Common.Models;

namespace SunnyRewards.HelloWorld.Common.Extensions
{
    /// <summary>
    /// 
    /// </summary>
    public static class NhibernateExtension
    {
        /// <summary>
        /// Attach fluent nhibernate to .net core service collection
        /// </summary>
        /// <param name="services"></param>
        /// <param name="connectionString"></param>
        /// <returns></returns>
        public static IServiceCollection AddNhibernate<T>(this IServiceCollection services, string connectionString) where T :
            IMappingProvider, new()
        {
            try
            {
                if (!string.IsNullOrEmpty(connectionString))
                {
                    var configureSessionFactory = BuildSessionFactory<T>(connectionString);
                    services.AddSingleton(configureSessionFactory);
                    services.AddScoped(_ => configureSessionFactory.OpenSession());
                }
            }
            catch (Exception ex)
            {
                Console.Write(ex);
            }
            return services;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="connectionString"></param>
        /// <returns></returns>
        private static ISessionFactory BuildSessionFactory<T>(this string connectionString)
        {
            ISessionFactory? sessionFactory = CreateSession<T>(connectionString);
            return sessionFactory;
        }

        /// <summary>
        /// Will create an ORM session
        /// </summary>
        /// <param name="connectionString"></param>
        /// <returns></returns>
        private static ISessionFactory CreateSession<T>(string connectionString)
        {

            return Fluently.Configure()
                  .Database(PostgreSQLConfiguration.Standard.ConnectionString(connectionString))
                  .Mappings(m =>
                  {
                      m.FluentMappings.AddFromAssemblyOf<T>();
                      m.FluentMappings.AddFromAssemblyOf<BaseMapping<BaseModel>>();
                  })
                  .BuildConfiguration()
                  .BuildSessionFactory();
        }
    }
}
