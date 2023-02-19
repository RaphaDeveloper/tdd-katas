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

        [Test]
        public void Should_Exchange_Gossip_Once_When_There_Is_Two_Drivers_And_They_Cross_Each_Other_Once()
        {
            CalculateTheAmountOfStopToExchangeGossip calculateTheAmountOfStopToExchangeGossip = new CalculateTheAmountOfStopToExchangeGossip();
            Driver driver1 = new Driver(route: new int[] { 1, 2, 3 });
            Driver driver2 = new Driver(route: new int[] { 1, 4, 5 });
            Driver[] drivers = new Driver[] 
            { 
                driver1,
                driver2
            };


            string result = calculateTheAmountOfStopToExchangeGossip.Do(drivers);


            result.Should().Be("1");
        }

        [Test]
        public void Should_Never_Exchange_Gossip_When_There_Is_No_Drivers()
        {
            CalculateTheAmountOfStopToExchangeGossip calculateTheAmountOfStopToExchangeGossip = new CalculateTheAmountOfStopToExchangeGossip();
            Driver[] drivers = new Driver[0];


            string result = calculateTheAmountOfStopToExchangeGossip.Do(drivers);


            result.Should().Be("Never");
        }

        [Test]
        public void Should_Exchange_Gossip_Once_When_There_Is_Two_Drivers_Even_If_They_Cross_Each_More_Than_Once()
        {
            CalculateTheAmountOfStopToExchangeGossip calculateTheAmountOfStopToExchangeGossip = new CalculateTheAmountOfStopToExchangeGossip();
            Driver driver1 = new Driver(route: new int[] { 1, 2, 3 });
            Driver driver2 = new Driver(route: new int[] { 1, 2, 3 });
            Driver[] drivers = new Driver[]
            {
                driver1,
                driver2
            };


            string result = calculateTheAmountOfStopToExchangeGossip.Do(drivers);


            result.Should().Be("1");
        }

        [Test]
        public void Should_Exchange_Gossip_Once_When_There_Is_Two_Drivers_With_Different_Route_Size_But_In_Some_Moment_They_Cross_Each_Other()
        {
            CalculateTheAmountOfStopToExchangeGossip calculateTheAmountOfStopToExchangeGossip = new CalculateTheAmountOfStopToExchangeGossip();
            Driver driver1 = new Driver(route: new int[] { 1, 2, 3 });
            Driver driver2 = new Driver(route: new int[] { 4, 1 });
            Driver[] drivers = new Driver[]
            {
                driver1,
                driver2
            };


            string result = calculateTheAmountOfStopToExchangeGossip.Do(drivers);


            result.Should().Be("1");
        }
    }
}