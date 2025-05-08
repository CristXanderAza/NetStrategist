using Microsoft.Extensions.DependencyInjection;
using NetStrategist.Core;

namespace NetStrategist.DependencyInjection
{
    public static class ServiceCollectionExtensions
    {
        public static StrategistBuilder<C, K> AddStrategist<C, K>(this IServiceCollection services)
        {
            services.AddSingleton<IStrategistFor<C,K>,Strategist<C, K>>();
            return new StrategistBuilder<C, K>(services);
        }
    }

}
