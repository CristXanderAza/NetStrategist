

namespace NetStrategist
{
    public interface IStrategistFor<I, K> 
    {
        I GetStrategy(K key);
        IEnumerable<K> GetKeys();
    }
}
