using System;
using Unity;
using Unity.Interception.PolicyInjection.Pipeline;
using Unity.Interception.PolicyInjection.Policies;

namespace CachingAspectOrientedImplemetation
{
    [AttributeUsage(AttributeTargets.Method, Inherited = false, AllowMultiple = false)]
    public class CacheAttribute : HandlerAttribute
    {
        public string KeyPrefix { get; set; }

        public CacheAttribute(string keyPrefix)
        {
            KeyPrefix = keyPrefix;
        }

        public override ICallHandler CreateHandler(IUnityContainer container)
        {
            return new CacheAttributeHandler(this.KeyPrefix);
        }
    }
}