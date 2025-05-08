using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetStrategist.Core
{
    public class StrategiesCollection<I, K>
    {
        public Dictionary<K,Type> Strategies { get; set; } = new Dictionary<K, Type>();


        public void AddStrategy(K key, Type strategy)
        {
            if (Strategies.ContainsKey(key))
            {
                throw new ArgumentException($"Strategy for key {key} already exists.");
            }
            else if (!typeof(I).IsAssignableFrom(strategy)){

                throw new ArgumentException($"Type {strategy} does not implement {typeof(I)}.");
            }
            else if (strategy.IsAbstract)
            {
                throw new ArgumentException($"Type {strategy} is abstract.");
            }

            Strategies[key] = strategy;
        }

    }
}
