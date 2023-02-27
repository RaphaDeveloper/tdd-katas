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
                            bool nextDriverKnowsGossipsThatCurrentDoesNot = !currentDriver.TotalAmountOfGossipsByDriver.ContainsKey(nextDriver) || currentDriver.TotalAmountOfGossipsByDriver[nextDriver] != nextDriver.TotalAmountOfGossipsByDriver[nextDriver];
                            if (nextDriverKnowsGossipsThatCurrentDoesNot)
                            {
                                foreach (var driverAndTotalAmountOfGossips in nextDriver.TotalAmountOfGossipsByDriver)
                                {
                                    Driver anotherDriver = driverAndTotalAmountOfGossips.Key;
                                    int totalAmountOfGossipsOfAnotherDriver = driverAndTotalAmountOfGossips.Value;

                                    if (currentDriver != anotherDriver)
                                    {
                                        bool currentDriverKnowsAnyGossipsOfAnotherDriver = currentDriver.TotalAmountOfGossipsByDriver.TryGetValue(anotherDriver, out int totalAmountOfGossipsOfAnotherDriverThatCurrentDriverKnows);

                                        if (!currentDriverKnowsAnyGossipsOfAnotherDriver)
                                        {
                                            currentDriver.TotalAmountOfGossipsByDriver[currentDriver] += anotherDriver.AmountOfGossips;
                                        
                                            driversExchangedGossips = true;
                                        }

                                        currentDriver.TotalAmountOfGossipsByDriver[anotherDriver] = totalAmountOfGossipsOfAnotherDriver;
                                    }
                                }
                            }


                            bool currentDriverKnowsGossipsThatNextDoesNot = !nextDriver.TotalAmountOfGossipsByDriver.ContainsKey(currentDriver) || nextDriver.TotalAmountOfGossipsByDriver[currentDriver] != currentDriver.TotalAmountOfGossipsByDriver[currentDriver];
                            if (currentDriverKnowsGossipsThatNextDoesNot)
                            {
                                foreach (var driverAndTotalAmountOfGossips in currentDriver.TotalAmountOfGossipsByDriver)
                                {
                                    Driver anotherDriver = driverAndTotalAmountOfGossips.Key;
                                    int totalAmountOfGossipsOfAnotherDriver = driverAndTotalAmountOfGossips.Value;

                                    if (nextDriver != anotherDriver)
                                    {
                                        bool nextDriverKnowsAnyGossipsOfAnotherDriver = nextDriver.TotalAmountOfGossipsByDriver.TryGetValue(anotherDriver, out int totalAmountOfGossipsOfAnotherDriverThatNextDriverKnows);

                                        if (!nextDriverKnowsAnyGossipsOfAnotherDriver)
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
    }
}