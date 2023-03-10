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

                        ExchangeGossipsBetweenDrivers(currentDriver, nextDriver);

                        driversExchangedGossips = driversExchangedGossips || currentDriver.GotNewGossips || nextDriver.GotNewGossips;
                    }

                    currentDriver.GoToNextStop();
                }

                if (driversExchangedGossips)
                    lastStopWithGossipsExchange = stop;
            }

            return lastStopWithGossipsExchange?.ToString() ?? "Never";
        }

        private static void ExchangeGossipsBetweenDrivers(Driver currentDriver, Driver nextDriver)
        {
            if (currentDriver.IsOnTheSameStopAs(nextDriver))
            {
                currentDriver.GetAllNewGossipsFrom(nextDriver);

                nextDriver.GetAllNewGossipsFrom(currentDriver);

                nextDriver.TotalAmountOfGossipsByDriver[currentDriver] = currentDriver.TotalAmountOfGossips;
                currentDriver.TotalAmountOfGossipsByDriver[nextDriver] = nextDriver.TotalAmountOfGossips;
            }
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
        public int TotalAmountOfGossips => TotalAmountOfGossipsByDriver[this];
        public bool GotNewGossips { get; private set; }
        public Dictionary<Driver, int> TotalAmountOfGossipsByDriver { get; internal set; } = new Dictionary<Driver, int>();

        internal void GetAllNewGossipsFrom(Driver nextDriver)
        {
            if (IsThereAnyNewGossipsToGetFrom(nextDriver))
                foreach (var driverAndTotalAmountOfGossips in nextDriver.TotalAmountOfGossipsByDriver)
                    GetNewGossipsAndUpdateTotalAmountOfGossipsIKnowThatAnotherDriverKnows(anotherDriver: driverAndTotalAmountOfGossips.Key, totalAmountOfGossipsOfAnotherDriver: driverAndTotalAmountOfGossips.Value);
        }

        private void GetNewGossipsAndUpdateTotalAmountOfGossipsIKnowThatAnotherDriverKnows(Driver anotherDriver, int totalAmountOfGossipsOfAnotherDriver)
        {
            if (this != anotherDriver)
            {
                GetGossipsFrom(anotherDriver);

                TotalAmountOfGossipsByDriver[anotherDriver] = totalAmountOfGossipsOfAnotherDriver;
            }
        }

        internal void GetGossipsFrom(Driver anotherDriver)
        {
            if (!IKnowAnyGossipsOf(anotherDriver))
            {
                TotalAmountOfGossipsByDriver[this] += anotherDriver.AmountOfGossips;

                GotNewGossips = true;
            }
        }

        internal void GoToNextStop()
        {
            CurrentStop++;

            if (CurrentStop == Route.Length)
                CurrentStop = 0;

            GotNewGossips = false;
        }

        internal bool IsOnTheSameStopAs(Driver anotherDriver)
        {
            return Route[CurrentStop] == anotherDriver.Route[anotherDriver.CurrentStop];
        }

        internal bool IKnowAnyGossipsOf(Driver anotherDriver)
        {
            return TotalAmountOfGossipsByDriver.ContainsKey(anotherDriver);
        }

        internal bool IsThereAnyNewGossipsToGetFrom(Driver anotherDriver)
        {
            return !IKnowAnyGossipsOf(anotherDriver) || TotalAmountOfGossipsByDriver[anotherDriver] != anotherDriver.TotalAmountOfGossips;
        }
    }
}