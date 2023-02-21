namespace GossipingBusDrivers
{
    public class CalculateTheAmountOfStopToExchangeGossip
    {
        public string Do(Driver[] drivers)
        {
            if (!drivers.Any())
                return "Never";
            
            int amount = 0;            

            for (int min = 0; min < 480; min++)
            {
                bool increment = false;

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

                                increment = true;
                            }

                            if (!nextDriver.AmountOfGossipsByDriver.ContainsKey(currentDriver) || nextDriver.AmountOfGossipsByDriver[currentDriver] != currentDriver.AmountOfGossips)
                            {
                                nextDriver.AmountOfGossipsByDriver.TryGetValue(currentDriver, out int lastAmountOfGossips);

                                nextDriver.AmountOfGossips += (amountOfGossipsOfCurrentDriver - lastAmountOfGossips);

                                increment = true;
                            }

                            currentDriver.AmountOfGossipsByDriver[nextDriver] = nextDriver.AmountOfGossips;
                            nextDriver.AmountOfGossipsByDriver[currentDriver] = currentDriver.AmountOfGossips;
                        }
                    }

                    currentDriver.GoToNextStop();
                }

                if (increment)
                    amount++;
            }

            return amount == 0 ? "Never" : amount.ToString();
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