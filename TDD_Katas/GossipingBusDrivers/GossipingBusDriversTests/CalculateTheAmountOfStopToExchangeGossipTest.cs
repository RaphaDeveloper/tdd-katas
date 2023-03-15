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
        public void Should_Be_Necessary_One_Stop_To_Exchange_All_Gossips_When_There_Is_Two_Drivers_And_They_Cross_Each_Other_On_The_First_Stop()
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
        public void Should_Be_Necessary_One_Stop_To_Exchange_All_Gossips_When_There_Is_Two_Drivers_And_They_Cross_Each_Other_On_The_First_Stop_Even_If_They_Cross_Each_Other_More_Than_Once()
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
        public void Should_Be_Necessary_Four_Stops_To_Exchange_All_Gossips_When_There_Is_Two_Drivers_And_They_Cross_Each_Other_On_The_Fourth_Stop()
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
        public void Should_Be_Necessary_Four_Stops_To_Exchange_All_Gossips_When_There_Are_Three_Drivers_With_Different_Routes_Crossing_At_Different_Time_Considering_That_Driver_Two_Cross_All_Other_Drivers()
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
        public void Should_Be_Necessary_480_Stops_When_The_Drivers_Cross_Each_Other_Just_On_The_Last_Stop()
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
        public void Should_Be_Necessary_480_Stops_When_The_Drivers_Cross_Each_Other_Just_On_The_Last_Stop2()
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
            driver1.TotalAmountOfGossipsByDriver[driver2].Should().Be(2);
            driver2.TotalAmountOfGossipsByDriver[driver1].Should().Be(2);
        }

        [Test]
        public void Should_Be_Necessary_Four_Stops_To_Exchange_All_Gossips_When_There_Are_Three_Drivers_With_Different_Routes_Crossing_At_Different_Time_Considering_That_Driver_One_Cross_All_Other_Drivers()
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
        public void Should_Be_Necessary_Seven_Stops_When_There_Are_Four_Drivers_With_Different_Routes_Crossing_At_Different_Time()
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

        [Test]
        public void Should_Be_Possible_To_Calculate_The_Amount_Of_Stops_When_Drivers_Has_Different_Routes_Size()
        {
            CalculateTheAmountOfStopToExchangeGossip calculateTheAmountOfStopsToExchangeGossip = new CalculateTheAmountOfStopToExchangeGossip();
            Driver driver1 = new Driver(route: new int[] { 3, 1, 2, 3 });
            Driver driver2 = new Driver(route: new int[] { 3, 2, 3, 1 });
            Driver driver3 = new Driver(route: new int[] { 4, 2, 3, 4, 5 });
            Driver[] drivers = new Driver[]
            {
                driver1,
                driver2,
                driver3
            };


            string result = calculateTheAmountOfStopsToExchangeGossip.Do(drivers);


            result.Should().Be("5");
        }

        [Test]
        public void The_Total_Amount_Of_Gossips_That_All_Drivers_Knows_About_Each_Other_Should_Be_The_Amount_Of_Drivers_When_All_Drivers_Cross_At_Least_Once()
        {
            CalculateTheAmountOfStopToExchangeGossip calculateTheAmountOfStopToExchangeGossip = new CalculateTheAmountOfStopToExchangeGossip();
            Driver driver1 = new Driver(route: new int[] { 1, 3, 4, 2, 1, 3 });
            Driver driver2 = new Driver(route: new int[] { 1, 4, 2, 3, 2, 1 });
            Driver driver3 = new Driver(route: new int[] { 2, 3, 1, 3, 3, 4 });
            Driver driver4 = new Driver(route: new int[] { 3, 1, 4, 1, 2, 4 });

            Driver[] drivers = new Driver[]
            {
                driver1,
                driver2,
                driver3,
                driver4
            };


            calculateTheAmountOfStopToExchangeGossip.Do(drivers);


            driver1.TotalAmountOfGossipsByDriver[driver1].Should().Be(4);
            driver1.TotalAmountOfGossipsByDriver[driver2].Should().Be(4);
            driver1.TotalAmountOfGossipsByDriver[driver3].Should().Be(4);
            driver1.TotalAmountOfGossipsByDriver[driver4].Should().Be(4);

            driver2.TotalAmountOfGossipsByDriver[driver1].Should().Be(4);
            driver2.TotalAmountOfGossipsByDriver[driver2].Should().Be(4);
            driver2.TotalAmountOfGossipsByDriver[driver3].Should().Be(4);
            driver2.TotalAmountOfGossipsByDriver[driver4].Should().Be(4);

            driver3.TotalAmountOfGossipsByDriver[driver1].Should().Be(4);
            driver3.TotalAmountOfGossipsByDriver[driver2].Should().Be(4);
            driver3.TotalAmountOfGossipsByDriver[driver3].Should().Be(4);
            driver3.TotalAmountOfGossipsByDriver[driver4].Should().Be(4);

            driver4.TotalAmountOfGossipsByDriver[driver1].Should().Be(4);
            driver4.TotalAmountOfGossipsByDriver[driver2].Should().Be(4);
            driver4.TotalAmountOfGossipsByDriver[driver3].Should().Be(4);
            driver4.TotalAmountOfGossipsByDriver[driver4].Should().Be(4);
        }
    }
}