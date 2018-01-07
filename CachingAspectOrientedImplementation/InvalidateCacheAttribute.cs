using System;
using Unity;
using Unity.Interception.PolicyInjection.Pipeline;
using Unity.Interception.PolicyInjection.Policies;

namespace CachingAspectOrientedImplemetation
{
    [AttributeUsage(AttributeTargets.Method, Inherited = false, AllowMultiple = false)]
    public class InvalidateCacheAttribute : HandlerAttribute
    {
        public InvalidateCacheAttribute(string keyPrefix)
        {
            this.KeyPrefix = KeyPrefix;
        }

        public string KeyPrefix { get; set; }

        public override ICallHandler CreateHandler(IUnityContainer container)
        {
            return new InvalidateCacheAttributeHandler(this.KeyPrefix);
        }
    }
}