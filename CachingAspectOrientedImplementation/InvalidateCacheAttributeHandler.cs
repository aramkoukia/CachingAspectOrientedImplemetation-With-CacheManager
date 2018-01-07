using CacheManager.Core;
using System;
using Unity.Interception.PolicyInjection.Pipeline;

namespace CachingAspectOrientedImplemetation
{
    public class InvalidateCacheAttributeHandler : ICallHandler
    {
        private BaseCacheManager<object> _cache;

        public String KeyPrefix { get; set; }
        public int Order { get; set; }

        public InvalidateCacheAttributeHandler(string keyPrefix)
        {
            var config = new ConfigurationBuilder()
                .WithSystemRuntimeCacheHandle()
                .Build();

            _cache = new BaseCacheManager<object>(config);
            KeyPrefix = keyPrefix;
        }

        public IMethodReturn Invoke(IMethodInvocation input, GetNextHandlerDelegate getNext)
        {
            var result = _cache.Remove(KeyPrefix);

            IMethodReturn methodReturn = getNext()(input, getNext);

            return methodReturn;
        }
    }
}