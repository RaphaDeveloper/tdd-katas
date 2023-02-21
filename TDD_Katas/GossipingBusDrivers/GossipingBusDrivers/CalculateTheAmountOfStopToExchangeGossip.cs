namespace GossipingBusDrivers
{
    public class CalculateTheAmountOfStopToExchangeGossip
    {
        public string Do(Driver[] drivers)
        {
            if (!drivers.Any())
                return "Never";

            int? lastStopWithGossipsExchange = null;

            for (int stop = 1; stop <= 480; stop++)
            {
                bool driversExchangedGossips = false;

                for (int i = 0; i < drivers.Length; i++)
                {
                    Driver currentDriver = drivers[i];

                    for (int j = i + 1; j < drivers.Length; j++)
                    {
                        Driver nextDriver = drivers[j];

                        if (currentDriver.Route[currentDriver.CurrentStop] == nextDriver.Route[nextDriver.CurrentStop])
                        {
                            int amountOfGossipsOfCurrentDriver = currentDriver.AmountOfGossips;
                            int amountOfGossipsOfNextDriver = nextDriver.AmountOfGossips;

                            if (!currentDriver.AmountOfGossipsByDriver.ContainsKey(nextDriver) || currentDriver.AmountOfGossipsByDriver[nextDriver] != nextDriver.AmountOfGossips)
                            {
                                currentDriver.AmountOfGossipsByDriver.TryGetValue(nextDriver, out int lastAmountOfGossips);

                                currentDriver.AmountOfGossips += (amountOfGossipsOfNextDriver - lastAmountOfGossips);

                                driversExchangedGossips = true;
                            }

                            if (!nextDriver.AmountOfGossipsByDriver.ContainsKey(currentDriver) || nextDriver.AmountOfGossipsByDriver[currentDriver] != currentDriver.AmountOfGossips)
                            {
                                nextDriver.AmountOfGossipsByDriver.TryGetValue(currentDriver, out int lastAmountOfGossips);

                                nextDriver.AmountOfGossips += (amountOfGossipsOfCurrentDriver - lastAmountOfGossips);

                                driversExchangedGossips = true;
                            }

                            currentDriver.AmountOfGossipsByDriver[nextDriver] = nextDriver.AmountOfGossips;
                            nextDriver.AmountOfGossipsByDriver[currentDriver] = currentDriver.AmountOfGossips;
                        }
                    }

                    currentDriver.GoToNextStop();
                }

                if (driversExchangedGossips)
                    lastStopWithGossipsExchange = stop;
            }

            return lastStopWithGossipsExchange?.ToString() ?? "Never";
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
        public int AmountOfGossips { get; internal set; } = 1;
        public Dictionary<Driver, int> AmountOfGossipsByDriver { get; internal set; } = new Dictionary<Driver, int>();

        internal void GoToNextStop()
        {
            CurrentStop++;

            if (CurrentStop == Route.Length)
                CurrentStop = 0;
        }
    }
}