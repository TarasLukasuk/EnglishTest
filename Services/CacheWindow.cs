using System.Windows;
using System.Windows.Controls;

namespace EnglishTest.Services
{
    internal sealed class CacheWindow : CacheAbstract<Window>
    {
        private readonly Dictionary<string, Window> _cache = [];

        public override void CreateCache(string name, Window value)
        {
            if (value == null)
            {
                throw new ArgumentNullException(nameof(value));
            }

            if (!_cache.TryGetValue(name, out Window window))
            {
                _cache[name] = value;
            }
        }

        public override Window GetCache(string name)
        {
            return _cache[name];
        }
    }
}
