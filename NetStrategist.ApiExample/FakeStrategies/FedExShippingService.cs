namespace NetStrategist.ApiExample.FakeStrategies
{
    public class FedExShippingService : IShippingService
    {
        public string Ship()
        {
            return "Shipped by FedEx";
        }
    }

}
