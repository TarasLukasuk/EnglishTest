namespace EnglishTest.Services
{
    internal abstract class CacheAbstract<T>
    {
        public abstract void CreateCache(string name, T value);
        public abstract T GetCache(string name);
    }
}