using FluentAssertions;
using GossipingBusDrivers;

namespace GossipingBusDriversTests
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Should_Never_Exchange_Gossip_When_Drivers_Dont_Cross_Each_Other()
        {
            CalculateTheAmountOfStopToExchangeGossip calculateTheAmountOfStopToExchangeGossip = new CalculateTheAmountOfStopToExchangeGossip();
            Driver driver1 = new Driver(route: new int[] { 2, 1, 2 });
            Driver driver2 = new Driver(route: new int[] { 5, 2, 8 });
            Driver[] drivers = new Driver[] 
            { 
                driver1,
                driver2
            };


            string result = calculateTheAmountOfStopToExchangeGossip.Do(drivers);


            result.Should().Be("Never");
        }
    }
}