namespace NetStrategist.ApiExample.FakeStrategies
{
    public class UpsShippingService : IShippingService
    {
        public string Ship()
        {
            return "Shipped by UPS";
        }
    }

}
