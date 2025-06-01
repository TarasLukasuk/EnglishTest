using System.Windows.Controls;

namespace EnglishTest.Services
{
    internal sealed class CachePage : CacheAbstract<Page>
    {
        private readonly Dictionary<string, Page> _cache = [];

        public override void CreateCache(string name, Page value)
        {
            if (value == null)
            {
                throw new ArgumentNullException(nameof(value));
            }

            if (!_cache.TryGetValue(name, out Page page))
            {
                _cache[name] = value;   
            }
        }

        public override Page GetCache(string name)
        {
            return _cache[name];
        }
    }
}
