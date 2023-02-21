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


            result.Should().Be("4");
        }

        [Test]
        public void Should_Exchange_Gossip_Three_Times_When_There_Are_Three_Drivers_With_Different_Routes_Crossing_At_Different_Time_Considering_That_Driver_Two_Cross_All_Other_Drivers()
        {
            CalculateTheAmountOfStopToExchangeGossip calculateTheAmountOfStopToExchangeGossip = new CalculateTheAmountOfStopToExchangeGossip();
            Driver driver1 = new Driver(route: new int[] { 1, 2, 3 });
            Driver driver2 = new Driver(route: new int[] { 1, 4, 5 });
            Driver driver3 = new Driver(route: new int[] { 2, 4, 6 });
            Driver[] drivers = new Driver[]
            {
                driver1,
                driver2,
                driver3
            };


            string result = calculateTheAmountOfStopToExchangeGossip.Do(drivers);


            result.Should().Be("4");
        }

        [Test]
        public void Should_Exchange_Gossip_Once_When_Drivers_Cross_Each_Other_On_The_Last_Stop_Considering_They_Stop_480_Times()
        {
            int[] route1 = new int[480];
            for (int i = 0; i < 479; i++)
                route1[i] = 1;
            
            int[] route2 = new int[480];
            for (int i = 0; i < 479; i++)
                route1[i] = 2;
            
            route1[479] = 3;
            route2[479] = 3;

            CalculateTheAmountOfStopToExchangeGossip calculateTheAmountOfStopToExchangeGossip = new CalculateTheAmountOfStopToExchangeGossip();
            Driver driver1 = new Driver(route1);
            Driver driver2 = new Driver(route2);
            Driver[] drivers = new Driver[]
            {
                driver1,
                driver2
            };


            string result = calculateTheAmountOfStopToExchangeGossip.Do(drivers);


            result.Should().Be("480");
        }

        [Test]
        public void Should_Exchange_Gossip_Three_Times_When_There_Are_Three_Drivers_With_Different_Routes_Crossing_At_Different_Time_Considering_That_Driver_One_Cross_All_Other_Drivers()
        {
            CalculateTheAmountOfStopToExchangeGossip calculateTheAmountOfStopToExchangeGossip = new CalculateTheAmountOfStopToExchangeGossip();
            Driver driver1 = new Driver(route: new int[] { 1, 4, 3 });
            Driver driver2 = new Driver(route: new int[] { 1, 2, 5 });
            Driver driver3 = new Driver(route: new int[] { 2, 4, 6 });
            Driver[] drivers = new Driver[]
            {
                driver1,
                driver2,
                driver3
            };


            string result = calculateTheAmountOfStopToExchangeGossip.Do(drivers);


            result.Should().Be("4");
        }

        [Test]
        public void Should_Exchange_Gossip_Six_Times_When_There_Are_Four_Drivers_With_Different_Routes_Crossing_At_Different_Time()
        {
            CalculateTheAmountOfStopToExchangeGossip calculateTheAmountOfStopToExchangeGossip = new CalculateTheAmountOfStopToExchangeGossip();
            Driver driver1 = new Driver(route: new int[] { 1, 4, 3 });
            Driver driver2 = new Driver(route: new int[] { 1, 2, 5 });
            Driver driver3 = new Driver(route: new int[] { 2, 4, 6 });
            Driver driver4 = new Driver(route: new int[] { 3, 1, 6 });
            Driver[] drivers = new Driver[]
            {
                driver1,
                driver2,
                driver3,
                driver4
            };


            string result = calculateTheAmountOfStopToExchangeGossip.Do(drivers);


            result.Should().Be("7");
        }
    }
}