namespace GossipingBusDrivers
{
    public class CalculateTheAmountOfStopToExchangeGossip
    {
        public string Do(Driver[] drivers)
        {
            if (!drivers.Any())
                return "Never";

            Driver driver1 = drivers[0];
            Driver driver2 = drivers[1];

            for (int min = 0; min < 480; min++)
            {
                if (driver1.Route[driver1.CurrentStop] == driver2.Route[driver2.CurrentStop])
                    return "1";

                driver1.GoToNextStop();
                driver2.GoToNextStop();
            }

            return "Never";
        }
    }

    public class Driver
    {
        public Driver(int[] route)
        {
            Route = route;
        }

        public int[] Route { get; }
        public int CurrentStop { get; internal set; }

        internal void GoToNextStop()
        {
            CurrentStop++;

            if (CurrentStop == Route.Length)
                CurrentStop = 0;
        }
    }
}