using CacheManager.Core;
using System;
using Unity.Interception.PolicyInjection.Pipeline;

namespace CachingAspectOrientedImplemetation
{
    public class CacheAttributeHandler : ICallHandler
    {
        private BaseCacheManager<object> _cache;

        public String KeyPrefix { get; set; }
        public int Order { get; set; }

        public CacheAttributeHandler(string keyPrefix)
        {
            var config = new ConfigurationBuilder()
                .WithSystemRuntimeCacheHandle()
                .Build();

            _cache = new BaseCacheManager<object>(config);
            KeyPrefix = keyPrefix;
        }

        public IMethodReturn Invoke(IMethodInvocation input, GetNextHandlerDelegate getNext)
        {
            var result = _cache.Get(KeyPrefix);
            if (result != null)
                return input.CreateMethodReturn(result);

            IMethodReturn methodReturn = getNext()(input, getNext);

            _cache.Add(KeyPrefix, methodReturn.ReturnValue);

            return methodReturn;
        }
    }
}