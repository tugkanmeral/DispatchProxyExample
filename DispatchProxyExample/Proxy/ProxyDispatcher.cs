using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace DispatchProxyExample.Proxy
{
    public class ProxyDispatcher<T> : DispatchProxy
    {
        public T _decorated;

        protected override object Invoke(MethodInfo targetMethod, object[] args)
        {
            object result = null;

            Console.WriteLine($"Before {targetMethod.Name}");
            
            try
            {
                result = targetMethod.Invoke(_decorated, args);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error message: {ex.Message}");
            }

            Console.WriteLine($"After {targetMethod.Name}");

            return result;
        }

        public static T Resolve(T decorated)
        {
            object proxy = Create<T, ProxyDispatcher<T>>();
            ((ProxyDispatcher<T>)proxy).SetParameters(decorated);

            return (T)proxy;
        }

        private void SetParameters(T decorated)
        {
            _decorated = decorated ?? throw new ArgumentNullException(nameof(decorated));
        }
    }
}
