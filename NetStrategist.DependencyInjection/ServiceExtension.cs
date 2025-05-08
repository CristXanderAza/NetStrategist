using Microsoft.Extensions.DependencyInjection;
using NetStrategist.Core;

namespace NetStrategist.DependencyInjection
{
    public static class ServiceCollectionExtensions
    {
        public static StrategistBuilder<C, K> AddStrategist<C, K>(this IServiceCollection services)
        {
            // Registra el Strategist principal
            services.AddSingleton<Strategist<C, K>>();
            return new StrategistBuilder<C, K>(services);
        }
    }

}
