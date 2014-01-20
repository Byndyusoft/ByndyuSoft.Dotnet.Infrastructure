namespace Mvc4Sample.Web.Application.Infrastructure
{
    using System.Configuration;

    public class Config
    {
        public static string QueriesAssemblyName
        {
            get { return ConfigurationManager.AppSettings["QueriesAssemblyName"]; }
        }

        public static string CommandsAssemblyName
        {
            get { return ConfigurationManager.AppSettings["CommandsAssemblyName"]; }
        }
    }
}