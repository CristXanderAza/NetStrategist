using Microsoft.Extensions.DependencyInjection;
using NetStrategist.Core;

namespace NetStrategist.DependencyInjection
{
    public class StrategistBuilder<I,K>
    {
        private readonly IServiceCollection _services;
        private readonly StrategiesCollection<I, K> _strategies = new();

        public StrategistBuilder(IServiceCollection services)
        {
            _services = services;
        }


        public StrategistBuilder<I, K> AddStrategy(K key, Type strategyType)
        {
            if (!typeof(I).IsAssignableFrom(strategyType))
                throw new InvalidOperationException($"Strategy must implement {typeof(I).Name}");

            _strategies.Strategies.Add(key, strategyType);
            _services.AddTransient(strategyType); // Opcional: auto-registro    
            return this;
        }

        public StrategistBuilder<I, K> AddStrategy<TStrategy>(K key) where TStrategy : I
            => AddStrategy(key, typeof(TStrategy));


        public IServiceCollection Build() 
        {
            _services.AddSingleton<StrategiesCollection<I,K>>(_strategies);
            return _services;
        }
    }
}
