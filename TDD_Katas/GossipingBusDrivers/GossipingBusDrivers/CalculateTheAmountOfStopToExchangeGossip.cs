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

                        if (currentDriver.IsOnTheSameStopAs(nextDriver))
                        {
                            if (currentDriver.ShouldBeUpdatedAboutGossipsFrom(nextDriver))
                            {
                                foreach (var driverAndTotalAmountOfGossips in nextDriver.TotalAmountOfGossipsByDriver)
                                {
                                    Driver anotherDriver = driverAndTotalAmountOfGossips.Key;
                                    int totalAmountOfGossipsOfAnotherDriver = driverAndTotalAmountOfGossips.Value;

                                    if (currentDriver != anotherDriver)
                                    {
                                        if (!currentDriver.KnowsAnyGossipsOf(anotherDriver))
                                        {
                                            currentDriver.TotalAmountOfGossipsByDriver[currentDriver] += anotherDriver.AmountOfGossips;
                                        
                                            driversExchangedGossips = true;
                                        }

                                        currentDriver.TotalAmountOfGossipsByDriver[anotherDriver] = totalAmountOfGossipsOfAnotherDriver;
                                    }
                                }
                            }


                            if (nextDriver.ShouldBeUpdatedAboutGossipsFrom(currentDriver))
                            {
                                foreach (var driverAndTotalAmountOfGossips in currentDriver.TotalAmountOfGossipsByDriver)
                                {
                                    Driver anotherDriver = driverAndTotalAmountOfGossips.Key;
                                    int totalAmountOfGossipsOfAnotherDriver = driverAndTotalAmountOfGossips.Value;

                                    if (nextDriver != anotherDriver)
                                    {
                                        if (!nextDriver.KnowsAnyGossipsOf(anotherDriver))
                                        {
                                            nextDriver.TotalAmountOfGossipsByDriver[nextDriver] += anotherDriver.AmountOfGossips;

                                            driversExchangedGossips = true;
                                        }

                                        nextDriver.TotalAmountOfGossipsByDriver[anotherDriver] = totalAmountOfGossipsOfAnotherDriver;
                                    }
                                }
                            }

                            currentDriver.TotalAmountOfGossipsByDriver[nextDriver] = nextDriver.TotalAmountOfGossipsByDriver[nextDriver];
                            nextDriver.TotalAmountOfGossipsByDriver[currentDriver] = currentDriver.TotalAmountOfGossipsByDriver[currentDriver];
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
            AmountOfGossips = 1;
            TotalAmountOfGossipsByDriver[this] = AmountOfGossips;
        }

        public int[] Route { get; }
        public int CurrentStop { get; internal set; }
        public int AmountOfGossips { get; internal set; }
        public Dictionary<Driver, int> TotalAmountOfGossipsByDriver { get; internal set; } = new Dictionary<Driver, int>();

        internal void GoToNextStop()
        {
            CurrentStop++;

            if (CurrentStop == Route.Length)
                CurrentStop = 0;
        }

        internal bool IsOnTheSameStopAs(Driver anotherDriver)
        {
            return Route[CurrentStop] == anotherDriver.Route[anotherDriver.CurrentStop];
        }

        internal bool KnowsAnyGossipsOf(Driver anotherDriver)
        {
            return TotalAmountOfGossipsByDriver.ContainsKey(anotherDriver);
        }

        internal bool ShouldBeUpdatedAboutGossipsFrom(Driver anotherDriver)
        {
            return !KnowsAnyGossipsOf(anotherDriver) || TotalAmountOfGossipsByDriver[anotherDriver] != anotherDriver.TotalAmountOfGossipsByDriver[anotherDriver];
        }
    }
}