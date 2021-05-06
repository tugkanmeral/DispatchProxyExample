using DispatchProxyExample.Proxy;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace DispatchProxyExample.Extentions
{
    public static class ServiceCollectionProxyExtensions
    {
        public static void AddProxySingleton<TService, TImplementation>(this IServiceCollection services)
        {
            AddProxy<TService, TImplementation>(services, ServiceLifetime.Singleton);
        }

        public static void AddProxyScoped<TService, TImplementation>(this IServiceCollection services)
        {
            AddProxy<TService, TImplementation>(services, ServiceLifetime.Scoped);
        }

        public static void AddProxyTransient<TService, TImplementation>(this IServiceCollection services)
        {
            AddProxy<TService, TImplementation>(services, ServiceLifetime.Transient);
        }

        private static void AddProxy<TService, TImplementation>(IServiceCollection services, ServiceLifetime serviceLifetime)
        {
            var descriptor = ServiceDescriptor.Describe(
                    typeof(TService),
                    sp =>
                    {
                        return ProxyDispatcher<TService>.Resolve(
                                    (TService)ActivatorUtilities.GetServiceOrCreateInstance(sp, typeof(TImplementation))
                                );
                    },
                    serviceLifetime);

            services.Add(descriptor);
        }
    }
}
