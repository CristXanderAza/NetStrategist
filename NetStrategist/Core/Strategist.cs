using Microsoft.Extensions.DependencyInjection;

namespace NetStrategist.Core
{
    public class Strategist<I, K> : IStrategistFor<I, K>
    {
        private readonly StrategiesCollection<I, K> _strategiesCollection;
        private readonly IServiceProvider _serviceProvider;
        public Strategist(StrategiesCollection<I, K> strategiesCollection, IServiceProvider serviceProvider)
        {
            _strategiesCollection = strategiesCollection;
            _serviceProvider = serviceProvider;
        }
        public I GetStrategy(K key)
        {
            if (!_strategiesCollection.Strategies.TryGetValue(key, out var strategyType))
            {
                throw new KeyNotFoundException($"No strategy registered for key {key}.");
            }

            return (I)_serviceProvider.GetRequiredService(strategyType);
        }

        public bool TryGetStrategy(K key, out I strategy)
        {
            strategy = default;
            if (!_strategiesCollection.Strategies.TryGetValue(key, out var strategyType))
            {
                return false;
            }

            strategy = (I)_serviceProvider.GetRequiredService(strategyType);
            return true;
        }

        public IEnumerable<K> GetKeys()
        {
            return _strategiesCollection.Strategies.Keys;
        }
    }
}
