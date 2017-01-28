using System;
using System.Collections.Generic;

namespace DynamicBundles.Test
{
    public class TestCacheHelper : ICacheHelper
    {
        public T Get<T>(string cacheKey, Func<T> createItem, IEnumerable<string> directories)
        {
            T item = createItem();
            return item;
        }
    }
}
